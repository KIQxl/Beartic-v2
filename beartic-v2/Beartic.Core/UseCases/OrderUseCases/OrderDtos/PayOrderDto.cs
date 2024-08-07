using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beartic.Core.UseCases.OrderUseCases.OrderDtos
{
    public record PayOrderDto
    {
        public PayOrderDto(string id, decimal amount)
        {
            Id = id;
            Amount = amount;
        }

        public string Id { get; set; }
        public decimal Amount { get; set; }
    }
}
