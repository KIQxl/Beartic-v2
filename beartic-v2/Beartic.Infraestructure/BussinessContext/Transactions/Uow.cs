using Beartic.Infraestructure.BussinessContext.Data;

namespace Beartic.Infraestructure.BussinessContext.Transactions
{
    public class Uow : IUow
    {
        private readonly BussinessData _ctx;

        public Uow(BussinessData ctx)
        {
            _ctx = ctx;
        }

        public async Task Commit()
        {
            await _ctx.SaveChangesAsync();
        }

        public void Rollback()
        {
            // Do nothing :)
        }
    }
}
