using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dugun.Models;

namespace Dugun.Models.DataTransferObjects
{
    public class GuestDto : BaseDto
    {
          #region Properties

        public int GuestID { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }
        public Nullable<decimal> TelNo { get; set; }
        public Nullable<bool> State { get; set; }
        public Nullable<int> Count { get; set; }
        public Nullable<bool> Alcoholic { get; set; }
        public Nullable<int> TableID { get; set; }
        public Nullable<int> DugunID { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public Nullable<int> ServiceID { get; set; }

        #endregion


        #region Constructors

        public GuestDto()
        {

        }

        public GuestDto(Guest entity)
        {
            ToB(entity);
        }


        #endregion

        #region Functions

        public static Guest ToD(GuestDto dto)
        {
            return new Guest()
            {
                GuestID = dto.GuestID,
                Name = dto.Name,
                Surname = dto.Surname,
                Count = dto.Count,
                Alcoholic = dto.Alcoholic,
                DugunID = dto.DugunID,
                TelNo = dto.TelNo,
                TableID = dto.TableID,
                State = dto.State,
                ServiceID = dto.ServiceID,
                DtInsert = dto.DtInsert,
                DtUpdate = dto.DtUpdate,
                RowStatus = dto.RowStatus
            };
        }

        public GuestDto ToB(Guest entity)
        {
                this.GuestID = entity.GuestID;
                this.Name = entity.Name;
                this.Surname = entity.Surname;
                this.Count = entity.Count;
                this.Alcoholic = entity.Alcoholic;
                this.DugunID = entity.DugunID;
                this.TelNo = entity.TelNo;
                this.TableID = entity.TableID;
                this.State = entity.State;
                this.ServiceID = entity.ServiceID;
                this.DtInsert = entity.DtInsert;
                this.DtUpdate = entity.DtUpdate;
                this.RowStatus = entity.RowStatus;

            return this;
        }
        #endregion

    }
}