namespace Beartic.Infraestructure.BussinessContext.Transactions
{
    public interface IUow
    {
        public void Commit();
        public void Rollback();
    }
}
