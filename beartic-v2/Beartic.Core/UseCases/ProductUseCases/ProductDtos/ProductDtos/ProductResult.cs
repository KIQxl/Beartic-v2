using Beartic.Shared.Dtos;
using Flunt.Notifications;

namespace Beartic.Core.UseCases.ProductUseCases.ProductDtos.ProductDtos
{
    public class ProductResult : Result<ProductResultData>
    {
        public ProductResult(int status, string message, ProductResultData data) : base(status, message, data)
        {
        }

        public ProductResult(int status, string message, IEnumerable<Notification>? notifications = null) : base(status, message, notifications)
        {
        }
    }

    public record ProductResultData(string Id, string Title, string Description, decimal Price, int Quantity);
}
