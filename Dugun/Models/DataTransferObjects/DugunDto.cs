using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dugun.Models;
using Dugun.Models.DataTransferObjects;

namespace Dugun.Models.DataTransferObjects
{
    public class DugunDto: BaseDto
    {
        #region Properties

        public int DugunID { get; set; }

        public int DugunID { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }

        public DateTime StartTime { get; set; }

        #endregion


        #region Constructors

        public DugunDto()
        {

        }

        public DugunDto(Dugun entity)
        {
            ToB(entity);
        }


        #endregion

        #region Functions

        public static Dugun ToD(DugunDto dto)
        {
            return new Dugun()
            {
                DugunID = dto.DugunID,
                DugunName = dto.DugunName,
                DtInsert = dto.DtInsert,
                DtUpdate = dto.DtUpdate,
                RowStatus = dto.RowStatus
            };
        }

        public DugunDto ToB(Dugun entity)
        {
            this.DugunID = entity.DugunID;
            this.DugunName = entity.DugunName;
            this.DtInsert = entity.DtInsert;
            this.DtUpdate = entity.DtUpdate;
            this.RowStatus = entity.RowStatus;

            return this;
        }
        #endregion
    }
}