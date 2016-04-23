using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dugun.Models;
using Dugun.Common;
using Dugun.Models.DataTransferObjects;
using System.Data.Entity.Validation;

namespace Dugun.Models.Managers
{
    public class UserManager
    {
        #region Singleton Instance

        private static UserManager instance;

        private UserManager() { }

        public static UserManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserManager();
                }
                return instance;
            }
        }
        #endregion

        public UserDto GetUser(int userID,  DugunEntities _context)
        {
            var entity = _context.User.FirstOrDefault(x => x.UserID == userID && x.RowStatus == (int)Enums.RowStatus.ACTIVE);

            UserDto user = new UserDto();
            user = _context.User.Where(x => x.UserID == userID).Select(x => new UserDto()
                {
                    UserID = x.UserID,
                    Name = x.Name,
                    Surname = x.Surname,
                    DugunSalonuID = x.DugunSalonuID,
                    DugunID = x.DugunID,
                    EMail = x.EMail,
                    TelNo = x.TelNo,
                    UserName = x.UserName,
                    DtInsert = x.DtInsert,
                    DtUpdate = x.DtUpdate,
                }).FirstOrDefault();
                return user;
        }

        public UserDto SetUser(UserDto dto, DugunEntities _context)
        {
            #region Server Validation

            if (!Utils.ValidEmail(dto.EMail))
                return new UserDto() { ErrorObject = new ErrorDto() { IsError = true, ErrorMessage = "Email adresi geçersizdir." } };

             #endregion

            #region Email'e göre sorgulama

            User entity = _context.User.Where(x => x.EMail == dto.EMail).FirstOrDefault();

            if (entity != null)
                return new UserDto() { ErrorObject = new ErrorDto() { IsError = true, ErrorMessage = "Bu Email adresi zaten kayıtlıdır." } };

            #endregion

            entity = new User();
            entity.Name = dto.Name;
            entity.Surname = dto.Surname;
            entity.EMail = dto.EMail;
            entity.UserTypeID = dto.UserTypeID;
            entity.DtInsert = DateTime.Now;
            entity.RowStatus = (int)Enums.RowStatus.PASSIVE;
            entity.Password = StringCipher.Encrypt(dto.Password, "password");
            entity.DtInsert = DateTime.Now;
            entity.TelNo = dto.TelNo;
            entity.DugunID = dto.DugunID;
            entity.DugunSalonuID = dto.DugunSalonuID;
            _context.User.Add(entity);
            _context.SaveChanges();

            return new UserDto(entity);
        }

        
    }
}