using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dugun.Models;

namespace Dugun.Models.DataTransferObjects
{
    public class UserTypeDto : BaseDto
    {
        #region Properties

        public int UserTypeID { get; set; }
        public string UserTypeName { get; set; }

        #endregion


        #region Constructors

        public UserTypeDto()
        {

        }

        public UserTypeDto(UserType entity)
        {
            ToB(entity);
        }


        #endregion

        #region Functions

        public static UserType ToD(UserTypeDto dto)
        {
            return new UserType()
            {
                UserTypeID = dto.UserTypeID,
                UserTypeName = dto.UserTypeName,
                DtInsert = dto.DtInsert,
                DtUpdate = dto.DtUpdate,
                RowStatus = dto.RowStatus
            };
        }

        public UserTypeDto ToB(UserType entity)
        {
            this.UserTypeID = entity.UserTypeID;
            this.UserTypeName = entity.UserTypeName;
            this.DtInsert = entity.DtInsert;
            this.DtUpdate = entity.DtUpdate;
            this.RowStatus = entity.RowStatus;

            return this;
        }
        #endregion

    }
}