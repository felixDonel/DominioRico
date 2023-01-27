using DominioRico.Core.Bus;
using DominioRico.Core.DomainObjects;
using System.Linq;
using System.Threading.Tasks;

namespace DominioRico.Pagamentos.Data
{
    public static class MediatorExtension
    {
        public static async Task PublicarEventos(this IMediatorHandler mediator, PagamentoContext ctx)
        {
            var domainEntities = ctx.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.Notificacoes != null && x.Entity.Notificacoes.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.Notificacoes)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.LimparEventos());

            var tasks = domainEvents
                .Select(async (domainEvent) => {
                    await mediator.PublicarEvent(domainEvent);
                });

            await Task.WhenAll(tasks);
        }
    }
}
