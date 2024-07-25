using Beartic.Shared.Dtos;
using Flunt.Notifications;

namespace Beartic.Core.UseCases.CategoryUseCases.CategoryDtos
{
    public class CategoryResult : Result<CategoryResultData>
    {
        public CategoryResult(int status, string message, CategoryResultData data) : base(status, message, data)
        {
        }

        public CategoryResult(int status, string message, IEnumerable<Notification>? notifications = null) : base(status, message, notifications)
        {
        }
    }

    public record CategoryResultData(string Id, string Category);
}
