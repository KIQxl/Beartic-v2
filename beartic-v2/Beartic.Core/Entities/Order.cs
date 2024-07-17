using Beartic.Core.Enums;
using Beartic.Core.ValueObjects;

namespace Beartic.Core.Entities
{
    public class Order : BaseEntity
    {
        public Order(Customer customer)
        {
            AddNotifications(customer);

            Customer = customer;
            Date = DateTime.Now;
            ModifiedAt = DateTime.Now;
            Status = EOrderStatus.WaitingPayment;
            Items = new List<OrderItem>();
        }

        public Customer Customer { get; private set; }
        public DateTime Date { get; private set; }
        public DateTime ModifiedAt { get; private set; }
        public EOrderStatus Status { get; private set; }
        public Installment Installment { get; private set; }
        public IList<OrderItem> Items { get; private set; }

        public void AddItem(OrderItem item)
        {
            if (item.Invalid)
            {
                AddNotifications(item);
                return;
            }

            Items.Add(item);
            Installment = new Installment(Total(), 1, Total());
        }

        public decimal Total()
        {
            var total = Items.Sum(x => x.SubTotal());
            return total;
        }

        public void Pay(decimal amount)
        {
            if(Installment.Price == amount)
            {
                Installment.PayDebit();
                ModifiedAt = DateTime.Now;
                Status = EOrderStatus.Paid;
            }
            else
            {
                Installment.PayInstallment(amount);
            }
        }

        public void Cancel()
        {
            Status = EOrderStatus.Canceled;
            ModifiedAt = DateTime.Now;
        }

        public void Parcel(int installments)
        {
            Installment.Parcel(installments);
        }
    }
}
