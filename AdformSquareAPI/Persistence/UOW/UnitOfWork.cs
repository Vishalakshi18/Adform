using AdformSquareAPI.Persistence.Repositories;
using AdformSquareAPI.Persitence;
using SquareApi.Core.Service;

namespace AdformSquareAPI.Persistence.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private SquareApiContext _context;

        public IPointService PointService { get; private set; }

        public UnitOfWork(SquareApiContext context)
        {
            _context = context;

            PointService = new PointRepository(_context);
        }


        public void CommitAsync()
        {
            _context.SaveChangesAsync();
        }
    }
}
