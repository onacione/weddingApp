using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dugun.Models;
using Dugun.Models.DataTransferObjects;

namespace Dugun.Models.DataTransferObjects
{
    public class DugunDto : BaseDto
    {
        #region Properties

        public int DugunID { get; set; }
        public int DugunSalonuID { get; set; }
        public string Name {get; set;}
        public DateTime Date {get; set;}
        public DateTime StartTime {get;set;}
        public DateTime EndTime {get;set;}
        public int PersonCount {get;set;}

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

        #region ExtraProperties

        #endregion

        #region Functions

        public static Dugun ToD(DugunDto dto)
        {
            return new Dugun()
            {
                DugunID = dto.DugunID,
                DugunSalonuID = dto.DugunSalonuID,
                Name = dto.Name,
                Date = dto.Date,
                StartTime =dto.StartTime.TimeOfDay,
                EndTime = dto.EndTime.TimeOfDay,
                PersonCount = dto.PersonCount,
                DtInsert = dto.DtInsert,
                DtUpdate = dto.DtUpdate,
                RowStatus = dto.RowStatus
            };
        }

        public DugunDto ToB(Dugun entity)
        {
            this.DugunID = entity.DugunID;
            this.DugunSalonuID = entity.DugunSalonuID;
            this.Name = entity.Name;
            this.PersonCount = entity.PersonCount;
            this.StartTime = Convert.ToDateTime(entity.StartTime);
            this.EndTime = Convert.ToDateTime(entity.EndTime);
            this.DugunID = entity.DugunID;
            this.DtInsert = entity.DtInsert;
            this.DtUpdate = entity.DtUpdate;
            this.RowStatus = entity.RowStatus;

            return this;
        }
        #endregion
    }
}