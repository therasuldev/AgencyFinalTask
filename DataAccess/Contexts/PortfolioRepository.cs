using Core.Entities;
using DataAccess.Interface;


namespace DataAccess.Contexts
{
    public class PortfolioRepository : Repository<PortfolioModel>, IPortfolioRepository
    {
        public PortfolioRepository(AppDbContext context) : base(context)
        {
        }
    }
}
