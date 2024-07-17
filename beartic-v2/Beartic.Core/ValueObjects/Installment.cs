namespace Beartic.Core.ValueObjects
{
    public class Installment : ValueObject
    {
        public Installment(decimal price, int installments, decimal installmentPrice)
        {
            Price = price;
            Installments = installments;
            InstallmentPrice = installmentPrice;
            ModifiedAt = DateTime.Now;

        }

        public decimal Price { get; private set; }
        public int Installments { get; private set; }
        public decimal InstallmentPrice { get; private set; }
        public DateTime ModifiedAt { get; private set; }

        public void PayDebit()
        {
            this.Installments = 0;
            this.Price = 0;
            this.InstallmentPrice = 0;
            this.ModifiedAt = DateTime.Now;
        }

        public void PayInstallment(decimal amount)
        {
            if(amount == InstallmentPrice)
            {
                this.Price -= this.InstallmentPrice;
                this.Installments--;
                this.ModifiedAt = DateTime.Now;
            }
            else
            {
                this.Price -= amount;

                Parcel(Installments);
            }

        }

        public void Parcel(int installments)
        {
            this.InstallmentPrice = this.Price / installments;
            this.Installments = installments;
            ModifiedAt = DateTime.Now;
        }
    }
}
