using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dugun.Models;

namespace Dugun.Models.DataTransferObjects
{
    public class ServiceDto:BaseDto
    {
        #region Properties

        public int ServiceID { get; set; }
        public string CaptainName { get; set; }
        public Nullable<decimal> CaptainTelNo { get; set; }
        public Nullable<int> RouteID { get; set; }
        public Nullable<int> DugunID { get; set; }

        public Nullable<int> PersonCount { get; set; }

        #endregion


        #region Constructors

        public ServiceDto()
        {

        }

        public ServiceDto(Service entity)
        {
            ToB(entity);
        }


        #endregion

        #region Functions

        public static Service ToD(ServiceDto dto)
        {
            return new Service()
            {
                ServiceID = dto.ServiceID,
                CaptainName = dto.CaptainName,
                CaptainTelNo = dto.CaptainTelNo,
                RouteID = dto.RouteID,
                DugunID = dto.DugunID,
                DtInsert = dto.DtInsert,
                DtUpdate = dto.DtUpdate,
                RowStatus = dto.RowStatus
            };
        }

        public ServiceDto ToB(Service entity)
        {
            this.ServiceID = entity.ServiceID;
            this.CaptainName = entity.CaptainName;
            this.CaptainTelNo = entity.CaptainTelNo;
            this.RouteID = entity.RouteID;
            this.DugunID = entity.DugunID;
            this.DtInsert = entity.DtInsert;
            this.DtUpdate = entity.DtUpdate;
            this.RowStatus = entity.RowStatus;

            return this;
        }
        #endregion
    }
}