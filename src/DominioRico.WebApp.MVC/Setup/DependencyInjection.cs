using DominioRico.Catalago.Data;
using DominioRico.Catalogo.Application.Services;
using DominioRico.Catalogo.Domain;
using DominioRico.Catalogo.Domain.Events;
using DominioRico.Core.Bus;
using DominioRico.Core.Messages.CommonMessages.Notifications;
using DominioRico.Vendas.Application.Commands;
using DominioRico.Vendas.Data;
using DominioRico.Vendas.Data.Repository;
using DominioRico.Vendas.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DominioRico.WebApp.MVC.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterService(this IServiceCollection services)
        {
            // Mediator
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            // Notification
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // Catalogo
            services.AddScoped<CatalogoContext>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoAppService, ProdutoAppService>();
            services.AddScoped<IEstoqueService, EstoqueService>();

            services.AddScoped<INotificationHandler<ProdutoAbaixoEstoqueEvent>, ProdutoEventHandler>();

            //vendas
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IRequestHandler<AdicionarItemPedidoCommand, bool>, PedidoCommandHandler>();
            services.AddScoped<VendasContext>();
        }
    }
}
