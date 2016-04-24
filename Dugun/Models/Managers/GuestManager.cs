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
    public class GuestManager
    {
        public GuestDto GetGuest(int GuestID, dugunEntities _context)
        {
            var entity = _context.Guest.FirstOrDefault(x => x.GuestID == GuestID && x.RowStatus == (int)Enums.RowStatus.ACTIVE);

            GuestDto Guest = new GuestDto();
            Guest = _context.Guest.Where(x => x.GuestID == GuestID).Select(x => new GuestDto()
            {
                GuestID = x.GuestID,
                Name = x.Name,
                Surname = x.Surname,
                TelNo = x.TelNo,
                State = x.State,
                Count = x.Count,
                Alcoholic = x.Alcoholic,
                TableID = x.TableID,
                DugunID = x.DugunID,
                CategoryID = x.CategoryID,
                ServiceID = x.ServiceID,
                DtInsert = x.DtInsert,
                DtUpdate = x.DtUpdate,
            }).FirstOrDefault();
            return Guest;
        }

        public GuestDto SetGuest(GuestDto dto, dugunEntities _context)
        {
            Guest entity = new Guest();
            entity = new Guest();
            entity.Name = dto.Name;
            entity.Surname = dto.Surname;
            entity.TelNo = dto.TelNo;
            entity.State = dto.State;
            entity.Count = dto.Count;
            entity.Alcoholic = dto.Alcoholic;
            entity.TableID = dto.TableID;
            entity.DugunID = dto.DugunID;
            entity.CategoryID = dto.CategoryID;
            entity.ServiceID = dto.ServiceID;
            entity.DtInsert = DateTime.Now;
            entity.RowStatus = (int)Enums.RowStatus.ACTIVE;
            _context.Guest.Add(entity);
            _context.SaveChanges();

            return new GuestDto(entity);
        }

        public GuestDto DeleteGuest(int GuestID, dugunEntities _context)
        {
                Guest guest = _context.Guest.Where(x => x.GuestID == GuestID).FirstOrDefault();

                if( guest == null )
                {
                    return new GuestDto() { ErrorObject = new ErrorDto() { IsError = true, ErrorMessage = "Misafir bulunamadı." } };
                }

                if (guest.RowStatus == (int)Enums.RowStatus.PASSIVE)
                {
                    return new GuestDto() { ErrorObject = new ErrorDto() { IsError = true, ErrorMessage = "Misafir zaten daha önce silinmiş." } };
                }

                guest.DtUpdate = DateTime.Now;
                guest.RowStatus = (int)Enums.RowStatus.PASSIVE;
                _context.SaveChanges();
                return new GuestDto(guest);

        }
        public GuestDto ChangeGuestTable(int GuestID, int newTableID, dugunEntities _context)
        {
            Guest guest = _context.Guest.Where(x => x.GuestID == GuestID).FirstOrDefault();
            Table table = _context.Table.Where(x => x.TableID == newTableID).FirstOrDefault();

            if (guest == null)
            {
                return new GuestDto() { ErrorObject = new ErrorDto() { IsError = true, ErrorMessage = "Misafir bulunamadı." } };
            }

            if (table == null)
            {
                return new GuestDto() { ErrorObject = new ErrorDto() { IsError = true, ErrorMessage = "Masa bulunamadı." } };
            }

            if (guest.RowStatus == (int)Enums.RowStatus.PASSIVE)
            {
                return new GuestDto() { ErrorObject = new ErrorDto() { IsError = true, ErrorMessage = "Misafir silinmiş." } };
            }

            if ( GetCurrentCountTable(newTableID,_context) >= table.Count)
            {
                return new GuestDto() { ErrorObject = new ErrorDto() { IsError = true, ErrorMessage = "Ekleyeceğiniz masada yeterli yer bulunmamaktadır." } };
            }

            guest.DtUpdate = DateTime.Now;
            guest.TableID = newTableID;
            _context.SaveChanges();
            return new GuestDto(guest);

        }

        public int GetCurrentCountTable(int TableID, dugunEntities _context)
        {
            List<GuestDto> guestList = _context.Guest.Where(x => x.TableID == TableID && x.RowStatus == (int)Enums.RowStatus.ACTIVE)
                 .Select(x => new GuestDto
                 {
                     GuestID = x.GuestID,
                 }).ToList();

            return guestList.Count();
        }

        public List<GuestDto> GetGuestsByTable(int TableID, dugunEntities _context)
        {
            List<GuestDto> guestList = _context.Guest.Where(x => x.TableID == TableID && x.RowStatus == (int)Enums.RowStatus.ACTIVE)
                 .Select(x => new GuestDto
                {
                    GuestID = x.GuestID,
                    Name = x.Name,
                    Surname = x.Surname,
                    TelNo = x.TelNo,
                    State = x.State,
                    Count = x.Count,
                    Alcoholic = x.Alcoholic,
                    TableID = x.TableID,
                    DugunID = x.DugunID,
                    CategoryID = x.CategoryID,
                    ServiceID = x.ServiceID,
                    DtInsert = x.DtInsert,
                    DtUpdate = x.DtUpdate,
                }).ToList();

            return guestList;
        }

        public List<GuestDto> GetGuestsByWedding(int DugunID, int page, int size, dugunEntities _context)
        {
            List<GuestDto> discountList = _context.Guest.Where(x => x.DugunID == DugunID && x.RowStatus == (int)Enums.RowStatus.ACTIVE)
                 .Skip(page*size)
                 .Take(size)
                 .Select(x => new GuestDto
                 {
                     GuestID = x.GuestID,
                     Name = x.Name,
                     Surname = x.Surname,
                     TelNo = x.TelNo,
                     State = x.State,
                     Count = x.Count,
                     Alcoholic = x.Alcoholic,
                     TableID = x.TableID,
                     DugunID = x.DugunID,
                     CategoryID = x.CategoryID,
                     ServiceID = x.ServiceID,
                     DtInsert = x.DtInsert,
                     DtUpdate = x.DtUpdate,
                 }).ToList();

            return discountList;
        }

    }
}