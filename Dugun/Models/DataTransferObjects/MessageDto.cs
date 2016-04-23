using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dugun.Models;
using Dugun.Models.DataTransferObjects;

namespace Dugun.Models
{
    public class MessageDto : BaseDto
    {
           #region Properties

        public int MessageID { get; set; }
        public bool IsRead { get; set; }
        public string MessageText { get; set; }
        public int UserIDSender { get; set; }
        public int UserIDReceiver { get; set; }
        public Nullable<int> MessageType { get; set; }
        #endregion


        #region Constructors

        public MessageDto()
        {

        }

        public MessageDto(Message entity)
        {
            ToB(entity);
        }

        #endregion

         public string DateString
        {
            get
            {
                if (DtInsert != null)
                    return DtInsert.Value.ToShortDateString();
                else
                    return "";
            }
            set { }
        }


        #region Navigation Properties

        public virtual UserDto User { get; set; }

        public virtual UserDto User1 { get; set; }

        #endregion

        #region Functions

        public static Message ToD(MessageDto dto)
        {
            return new Message()
            {
                MessageID = dto.MessageID,
                UserIDSender = dto.UserIDSender,
                UserIDReceiver = dto.UserIDReceiver,
                MessageText = dto.MessageText,
                MessageType = dto.MessageType,
                IsRead = dto.IsRead,
                DtInsert = dto.DtInsert,
                DtUpdate = dto.DtUpdate,
                RowStatus = dto.RowStatus
            };
        }

        public MessageDto ToB(Message entity)
        {
            this.MessageID = entity.MessageID;
            this.UserIDSender = entity.UserIDReceiver;
            this.MessageType = entity.MessageType;
            this.MessageText = entity.MessageText;
            this.IsRead = entity.IsRead;
            this.DtInsert = entity.DtInsert;
            this.DtUpdate = entity.DtUpdate;
            this.RowStatus = entity.RowStatus;

            return this;
        }
        #endregion
    }
}