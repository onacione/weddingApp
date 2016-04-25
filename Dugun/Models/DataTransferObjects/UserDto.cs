using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dugun.Models;

namespace Dugun.Models.DataTransferObjects
{
    public class UserDto : BaseDto
    {
        #region Properties

        public int UserID { get; set; }
        public int UserTypeID { get; set; }
        public Nullable<int> DugunSalonuID { get; set; }
        public Nullable<int> DugunID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EMail { get; set; }
        public Nullable<decimal> TelNo { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

         #endregion

 
        #region Constructors

        public UserDto()
        {

        }

        public UserDto(User entity)
        {
            ToB(entity);
        }

        #endregion

        #region Functions

        public static User ToD(UserDto dto)
        {
            return new User()
            {
                UserID = dto.UserID,
                UserTypeID = dto.UserTypeID,
                DugunSalonuID = dto.DugunSalonuID,
                DugunID = dto.DugunID,
                Name = dto.Name,
                Surname = dto.Surname,
                TelNo = dto.TelNo,
                UserName = dto.UserName,
                EMail = dto.EMail,
                Password = dto.Password,
                DtInsert = dto.DtInsert,
                DtUpdate = dto.DtUpdate,
                RowStatus = dto.RowStatus
            };
        }

        public UserDto ToB(User entity)
        {
            this.UserID = entity.UserID;
            this.UserTypeID = entity.UserTypeID;
            this.DugunSalonuID = entity.DugunSalonuID;
            this.DugunID = entity.DugunID;
            this.Surname = entity.Surname;
            this.TelNo = entity.TelNo;
            this.UserName = entity.UserName;
            this.Name = entity.Name;
            this.EMail = entity.EMail;
            this.Password = entity.Password;
            this.DtInsert = entity.DtInsert;
            this.DtUpdate = entity.DtUpdate;
            this.RowStatus = entity.RowStatus;

            return this;
        }

        #endregion
    }
}