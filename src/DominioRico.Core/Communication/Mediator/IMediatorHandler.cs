using DominioRico.Core.Messages;
using DominioRico.Core.Messages.CommonMessages.Notifications;
using System.Threading.Tasks;

namespace DominioRico.Core.Bus
{
    public interface IMediatorHandler 
    {
        Task PublicarEvent<T>(T evento) where T : Event;
        Task<bool> EnviarComando<T>(T comando) where T : Command;
        Task PublicarNotificacao<T>(T notificacao) where T : DomainNotification;
    }
}
