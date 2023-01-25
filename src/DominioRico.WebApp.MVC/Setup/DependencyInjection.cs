using DominioRico.Catalago.Data;
using DominioRico.Catalogo.Application.Services;
using DominioRico.Catalogo.Domain;
using DominioRico.Catalogo.Domain.Events;
using DominioRico.Core.Bus;
using DominioRico.Core.Messages.CommonMessages.Notifications;
using DominioRico.Vendas.Application.Commands;
using DominioRico.Vendas.Application.Events;
using DominioRico.Vendas.Application.Queries;
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
            services.AddScoped<VendasContext>();
            services.AddScoped<IPedidoQueries, PedidoQueries>();

            services.AddScoped<IRequestHandler<AdicionarItemPedidoCommand, bool>, PedidoCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarItemPedidoCommand, bool>, PedidoCommandHandler>();
            services.AddScoped<IRequestHandler<RemoverItemPedidoCommand, bool>, PedidoCommandHandler>();
            services.AddScoped<IRequestHandler<AplicarVoucherPedidoCommand, bool>, PedidoCommandHandler>();



            services.AddScoped<INotificationHandler<PedidoRascunhoIniciadoEvent>, PedidoEventHandler>();
            services.AddScoped<INotificationHandler<PedidoAtualizadoEvent>, PedidoEventHandler>();
            services.AddScoped<INotificationHandler<PedidoItemAdicionadoEvent>, PedidoEventHandler>();
        }
    }
}
