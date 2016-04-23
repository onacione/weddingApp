using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dugun.Models;

namespace Dugun.Models.DataTransferObjects
{
    public class CategoryDto : BaseDto
    {
           #region Properties

        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        #endregion


        #region Constructors

        public CategoryDto()
        {

        }

        public CategoryDto(Category entity)
        {
            ToB(entity);
        }


        #endregion

        #region Functions

        public static Category ToD(CategoryDto dto)
        {
            return new Category()
            {
                CategoryID = dto.CategoryID,
                CategoryName = dto.CategoryName,
                DtInsert = dto.DtInsert,
                DtUpdate = dto.DtUpdate,
                RowStatus = dto.RowStatus
            };
        }

        public CategoryDto ToB(Category entity)
        {
            this.CategoryID = entity.CategoryID;
            this.CategoryName = entity.CategoryName;
            this.DtInsert = entity.DtInsert;
            this.DtUpdate = entity.DtUpdate;
            this.RowStatus = entity.RowStatus;

            return this;
        }
        #endregion
    }
}