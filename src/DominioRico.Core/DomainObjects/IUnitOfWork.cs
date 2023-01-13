using System.Threading.Tasks;

namespace DominioRico.Core.DomainObjects
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
