using SquareApi.Core.Service;

namespace AdformSquareAPI.Persistence.UOW
{
    public interface IUnitOfWork
    {

        IPointService PointService { get; }

        void CommitAsync();
    }
}
