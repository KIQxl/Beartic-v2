using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beartic.Core.UseCases.CategoryUseCases.CategoryDtos
{
    public record UpdateCategoryDto
    {
        public UpdateCategoryDto(string id, string categoryName, string categoryDescription)
        {
            Id = id;
            CategoryName = categoryName;
            CategoryDescription = categoryDescription;
        }

        public string Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
    }
}
