using DominioRico.Core.Messages;
using System.Threading.Tasks;

namespace DominioRico.Core.Bus
{
    public interface IMediatrHandler 
    {
        Task PublicarEvent<T>(T evento) where T : Event;
    }
}
