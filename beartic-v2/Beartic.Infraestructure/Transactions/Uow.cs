using Beartic.Infraestructure.AuthContext.Data;
using Beartic.Infraestructure.BussinessContext.Data;

namespace Beartic.Infraestructure.Transactions
{
    public class Uow : IUow
    {
        private readonly BussinessData _bussinessCtx;
        private readonly AuthData _authCtx;

        public Uow(BussinessData Bussinessctx, AuthData authCtx)
        {
            _bussinessCtx = Bussinessctx;
            _authCtx = authCtx;
        }

        public async Task AuthCommit()
        {
            await _authCtx.SaveChangesAsync();
        }

        public async Task BussinessCommit()
        {
            await _bussinessCtx.SaveChangesAsync();
        }

        public void Rollback()
        {
            // Do nothing :)
        }
    }
}
