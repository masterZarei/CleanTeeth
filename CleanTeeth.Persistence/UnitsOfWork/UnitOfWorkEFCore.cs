using CleanTeeth.Application.Contracts.Persistence;

namespace CleanTeeth.Persistence.UnitsOfWork
{
    public class UnitOfWorkEFCore : IUnitOfWork
    {
        private readonly CleanTeethDbContext context;

        public UnitOfWorkEFCore(CleanTeethDbContext context)
        {
            this.context = context;
        }

        public async Task Commit()
        {
            await context.SaveChangesAsync();
        }

        public Task RollBack()
        {
            return Task.CompletedTask;
        }
    }
}
