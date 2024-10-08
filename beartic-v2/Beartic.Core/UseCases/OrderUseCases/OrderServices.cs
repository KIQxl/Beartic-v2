﻿using Beartic.Core.Entities;
using Beartic.Core.Interfaces;
using Beartic.Core.UseCases.OrderUseCases.OrderDtos;

namespace Beartic.Core.UseCases.OrderUseCases
{
    public class OrderServices : IOrderServices
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;

        public OrderServices(IOrderRepository orderRepository, ICustomerRepository customerRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
            _productRepository = productRepository;
        }

        public async Task<OrderResult> CancelOrderAsync(string id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if(order == null)
                return new OrderResult(404, "Pedido não encontrado");

            order.Cancel();
            _orderRepository.Update(order);

            return new OrderResult(200, "Pedido cancelado.", new OrderResultData(order.Id.ToString(), order.Customer.Name.ToString(), order.Date, order.Status, order.Installment.Price));
        }

        public async Task<OrderResult> CreateOrder(CreateOrderDto request)
        {
            var customer = await _customerRepository.GetByIdAsync(request.customerId);

            if (customer == null)
                return new OrderResult(404, "Cliente não encontrado");

            var order = new Order(customer);

            foreach(var item in request.orderItems)
            {
                var product = await _productRepository.GetProductByIdAsync(item.ProductId);
                var orderItem = new OrderItem(product, item.Quantity);
                if (orderItem.Invalid)
                    return new OrderResult(400, $"Houve um erro no produto {orderItem.Product.Title} do pedido", orderItem.Notifications);

                order.AddItem(orderItem);
            }

            if(order.Invalid)
                return new OrderResult(400, $"Houve um erro ao finalizar o pedido", order.Notifications);

            await _orderRepository.AddAsync(order);

            return new OrderResult(201, $"Pedido finalizado", new OrderResultData(order.Id.ToString(), customer.Name.ToString(), order.Date, order.Status, order.Installment.Price));
        }

        public async Task<OrderResult> GetOrderByIdAsync(string id)
        {
            var order = await _orderRepository.GetByIdAsync(id);

            if (order == null)
                return new OrderResult(404, "Pedido não encontrado");

            return new OrderResult(200, $"Pedido {order.Id}", new OrderResultData(order.Id.ToString(), order.Customer.Name.ToString(), order.Date, order.Status, order.Installment.Price));
        }

        public async Task<OrdersResult> ListOrdersAsync()
        {
            var orders = await _orderRepository.GetAllAsync();
            if (!orders.Any())
                return new OrdersResult(404, "Nenhum pedido encontrado :/");

            var ordersResult = new List<OrderResultData>();

            foreach(var order in orders)
            {
                var orderResultData = new OrderResultData(order.Id.ToString(), order.Customer.Name.ToString(), order.Date, order.Status, order.Installment.Price);
                ordersResult.Add(orderResultData);
            }

            return new OrdersResult(200, "Pedidos encontrados.", ordersResult);
        }

        public async Task<OrderResult> ParcelOrderAsync(ParcelOrderDto parcelRequest)
        {
            if(parcelRequest.Installments <= 0)
                return new OrderResult(400, "O número de parcelas informado não é válido");

            var order = await _orderRepository.GetByIdAsync(parcelRequest.Id);

            if(order == null)
                return new OrderResult(404, "Pedido não encontrado");

            order.Parcel(parcelRequest.Installments);
            _orderRepository.Update(order);

            return new OrderResult(200, "Parcelamento realizado!", new OrderResultData(order.Id.ToString(), order.Customer.Name.ToString(), order.Date, order.Status, order.Installment.Price));
        }

        public async Task<OrderResult> PayOrderAsync(PayOrderDto payRequest)
        {
            if(payRequest.Amount < 0)
                return  new OrderResult(400, "O valor informado não é válido");

            var order = await _orderRepository.GetByIdAsync(payRequest.Id);

            if (order == null)
                return new OrderResult(404, "Pedido não encontrado");

            order.Pay(payRequest.Amount);
            _orderRepository.Update(order);

            return new OrderResult(200, "Pagamento realizado!", new OrderResultData(order.Id.ToString(), order.Customer.Name.ToString(), order.Date, order.Status, order.Installment.Price));
        }
    }
}
