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
    public class MessageManager
    {
        public MessageDto SetMessage(MessageDto dto, dugunEntities _context)
        {
            Message entity = new Message();
            if (dto.UserIDSender != 0)
            {
                entity.UserIDSender = (int)SessionControl.UserStatus.UserID;
            }
            entity.MessageText = dto.MessageText;
            entity.UserIDReceiver = dto.UserIDReceiver;
            entity.RowStatus = (int)Enums.RowStatus.ACTIVE;
            entity.DtInsert = DateTime.Now;
            entity.IsRead = false;
            _context.Message.Add(entity);
            _context.SaveChanges();

            return new MessageDto(entity);
        }

        public List<MessageDto> GetUnreadedMessageList(dugunEntities _context)
        {
            var currentUser = SessionControl.UserStatus;
            List<MessageDto> messages = new List<MessageDto>();
            if (currentUser != null)
            {
                messages.AddRange(_context.Message.Where(x => x.UserIDReceiver == currentUser.UserID && x.IsRead == false).OrderByDescending(x => x.DtInsert).
                Select(x => new MessageDto()
                {
                    UserIDReceiver = x.UserIDReceiver,                    
                    DtInsert = x.DtInsert,
                    RowStatus = x.RowStatus,
                    MessageText = x.MessageText,
                    UserIDSender = x.UserIDSender,
                    User = x.UserIDSender != null ? new UserDto()
                    {
                        UserID = (int)x.UserIDSender,
                        Name = x.User.Name,
                    } : null,
                }).ToList());
            }

            return messages;
        }

        public List<MessageDto> GetSentMessages(int page, int size, dugunEntities _context)
        {
            List<MessageDto> messages = null;

            messages = _context.Message
                .Where(x => x.UserIDSender == SessionControl.UserStatus.UserID)
                .OrderByDescending(x => x.DtInsert)
                .Skip(page * size).Take(size)
              .Select(x => new MessageDto()
              {
                  UserIDSender = x.UserIDSender,
                  UserIDReceiver = x.UserIDReceiver,
                  DtInsert = x.DtInsert,
                  RowStatus = x.RowStatus,
                  MessageID = x.MessageID,
                  MessageText = x.MessageText,
                  User = new UserDto()
                  {
                      UserID = (int)x.UserIDSender,
                      Name = x.User.Name,
                  },
                  User1 = new UserDto()
                  {
                      UserID = (int)x.UserIDReceiver,
                      Name = x.User1.Name,
                  }
              }).ToList();

            return messages;
        }

        public List<MessageDto> GetReceivedMessages(int page, int size, dugunEntities _context)
        {
            var currentUser = SessionControl.UserStatus;
            List<MessageDto> messages = null;

            messages = _context.Message
                .Where(x => x.UserIDReceiver == currentUser.UserID)
                .OrderByDescending(x => x.DtInsert)
                .Skip(page * size).Take(size)
                .Select(x => new MessageDto()
                {
                    UserIDSender = x.UserIDSender,
                    UserIDReceiver = x.UserIDReceiver,
                    DtInsert = x.DtInsert,
                    RowStatus = x.RowStatus,
                    MessageID = x.MessageID,
                    MessageText = x.MessageText,
                    User1 = new UserDto()
                    {
                        UserID = (int)x.UserIDReceiver,
                        Name = x.User1.Name,
                    }
                }).ToList();

            return messages;
        }

        public Nullable<int> GetNewMessageCount(dugunEntities _context)
        {
            return _context.Message.Count(x => x.UserIDReceiver == SessionControl.UserStatus.UserID && x.RowStatus == (int)Enums.RowStatus.ACTIVE && x.IsRead == false);
        }
    }
}