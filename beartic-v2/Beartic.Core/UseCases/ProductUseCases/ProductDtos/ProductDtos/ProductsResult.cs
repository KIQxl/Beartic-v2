using Beartic.Core.UseCases.CustomerUseCases.CustomerDtos;
using Beartic.Shared.Dtos;
using Flunt.Notifications;

namespace Beartic.Core.UseCases.ProductUseCases.ProductDtos.ProductDtos
{
    public class ProductsResult : Result<IList<ProductResultData>>
    {
        public ProductsResult(int status, string message, IList<ProductResultData> data) : base(status, message, data)
        {
        }

        public ProductsResult(int status, string message, IEnumerable<Notification>? notifications = null) : base(status, message, notifications)
        {
        }
    }
}
