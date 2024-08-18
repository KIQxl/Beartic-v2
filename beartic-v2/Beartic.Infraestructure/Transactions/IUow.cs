namespace Beartic.Infraestructure.Transactions
{
    public interface IUow
    {
        public Task BussinessCommit();
        public Task AuthCommit();
        public void Rollback();
    }
}
