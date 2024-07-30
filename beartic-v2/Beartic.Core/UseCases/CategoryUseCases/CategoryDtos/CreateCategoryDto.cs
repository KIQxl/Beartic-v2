namespace Beartic.Core.UseCases.CategoryUseCases.CategoryDtos
{
    public record CreateCategoryDto
    {
        public CreateCategoryDto(string categoryName, string categoryDescription)
        {
            CategoryName = categoryName;
            CategoryDescription = categoryDescription;
        }

        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
    }
}
