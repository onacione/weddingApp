using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dugun.Models;

namespace Dugun.Models.DataTransferObjects
{
    public class RouteDto : BaseDto
    {       
        #region Properties

        public int RouteID { get; set; }
        public string Content { get; set; }

        #endregion


        #region Constructors

        public RouteDto()
        {

        }

        public RouteDto(Route entity)
        {
            ToB(entity);
        }


        #endregion

        #region Functions

        public static Route ToD(RouteDto dto)
        {
            return new Route()
            {
                RouteID = dto.RouteID,
                Content = dto.Content,
                DtInsert = dto.DtInsert,
                DtUpdate = dto.DtUpdate,
                RowStatus = dto.RowStatus
            };
        }

        public RouteDto ToB(Route entity)
        {
            this.RouteID = entity.RouteID;
            this.Content = entity.Content;
            this.DtInsert = entity.DtInsert;
            this.DtUpdate = entity.DtUpdate;
            this.RowStatus = entity.RowStatus;

            return this;
        }
        #endregion
    }
}