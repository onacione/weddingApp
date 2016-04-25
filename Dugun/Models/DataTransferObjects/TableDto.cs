using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dugun.Models;

namespace Dugun.Models.DataTransferObjects
{
    public class TableDto : BaseDto
    {
        #region Properties

        public int TableID { get; set; }
        public int MasaNo { get; set; }
        public Nullable<int> Count { get; set; }
        public Nullable<bool> Alcoholic { get; set; }
        public int DugunID { get; set; }

        #endregion


        #region Constructors

        public TableDto()
        {

        }

        public TableDto(Table entity)
        {
            ToB(entity);
        }


        #endregion

        #region Functions

        public static Table ToD(TableDto dto)
        {
            return new Table()
            {
                TableID = dto.TableID,
                MasaNo = dto.MasaNo,
                Count = dto.Count,
                Alcoholic = dto.Alcoholic,
                DugunID = dto.DugunID,
                DtInsert = dto.DtInsert,
                DtUpdate = dto.DtUpdate,
                RowStatus = dto.RowStatus
            };
        }

        public TableDto ToB(Table entity)
        {
            this.TableID = entity.TableID;
            this.MasaNo = entity.MasaNo;
            this.Count = entity.Count;
            this.Alcoholic = entity.Alcoholic;
            this.DugunID = entity.DugunID;
            this.DtInsert = entity.DtInsert;
            this.DtUpdate = entity.DtUpdate;
            this.RowStatus = entity.RowStatus;

            return this;
        }
        #endregion
    }
}