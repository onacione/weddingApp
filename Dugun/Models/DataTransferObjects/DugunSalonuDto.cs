using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dugun.Models;

namespace Dugun.Models.DataTransferObjects
{
    public class DugunSalonuDto : BaseDto
    {
           #region Properties

        public int DugunSalonuID { get; set; }
        public string Name { get; set; }

        public string Location { get; set; }

        public Nullable<decimal> TelNo { get; set; }



        #endregion


        #region Constructors

        public DugunSalonuDto()
        {

        }

        public DugunSalonuDto(DugunSalonu entity)
        {
            ToB(entity);
        }

        #endregion

        #region Functions

        public static DugunSalonu ToD(DugunSalonuDto dto)
        {
            return new DugunSalonu()
            {
                DugunSalonuID = dto.DugunSalonuID,
                Name = dto.Name,
                TelNo = dto.TelNo,
                Location = dto.Location,
                DtInsert = dto.DtInsert,
                DtUpdate = dto.DtUpdate,
                RowStatus = dto.RowStatus
            };
        }

        public DugunSalonuDto ToB(DugunSalonu entity)
        {
            this.DugunSalonuID = entity.DugunSalonuID;
            this.Name = entity.Name;
            this.TelNo = entity.TelNo;
            this.Location = entity.Location;
            this.DtInsert = entity.DtInsert;
            this.DtUpdate = entity.DtUpdate;
            this.RowStatus = entity.RowStatus;

            return this;
        }
        #endregion
    }
}