namespace Beartic.Infraestructure.BussinessContext.Transactions
{
    public interface IUow
    {
        public Task Commit();
        public void Rollback();
    }
}
