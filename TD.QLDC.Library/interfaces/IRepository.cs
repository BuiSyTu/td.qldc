using TD.Core.Api;

namespace TD.QLDC.Library.Interfaces
{
    public interface IRepository<T>: IRepository<T, int> where T: class, IEntity<int>
    {
    }
}
