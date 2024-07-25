namespace Beartic.Core.UseCases.CategoryUseCases.CategoryDtos
{
    public record CreateCategoryDto
    {
        public string Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
    }
}
