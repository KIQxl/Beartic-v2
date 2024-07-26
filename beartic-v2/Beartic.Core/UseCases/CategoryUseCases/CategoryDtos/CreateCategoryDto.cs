namespace Beartic.Core.UseCases.CategoryUseCases.CategoryDtos
{
    public record CreateCategoryDto
    {
        public CreateCategoryDto(string? id, string categoryName, string categoryDescription)
        {
            Id = id;
            CategoryName = categoryName;
            CategoryDescription = categoryDescription;
        }

        public string? Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
    }
}
