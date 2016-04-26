using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dugun.Models.DataTransferObjects;
using Dugun.Common;

namespace Dugun.Models.Managers
{
    public class CategoryManager
    {
        private static CategoryManager instance;

        private CategoryManager() { }

        public static CategoryManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CategoryManager();
                }
                return instance;
            }
        }
        public CategoryDto SetCategory(CategoryDto dto, dugunEntities _context)
        {
            Category entity = new Category();
            entity.CategoryName = dto.CategoryName;
    
            entity.DtInsert = DateTime.Now;
            entity.RowStatus = (int)Enums.RowStatus.ACTIVE;
            _context.Category.Add(entity);
            _context.SaveChanges();

            return new CategoryDto(entity);
        }
    }
}