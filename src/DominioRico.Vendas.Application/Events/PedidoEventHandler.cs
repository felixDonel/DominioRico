using DominioRico.Core.Messages.CommonMessages.IntegrationEvents;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DominioRico.Vendas.Application.Events
{
    public class PedidoEventHandler :
                INotificationHandler<PedidoRascunhoIniciadoEvent>,
                INotificationHandler<PedidoItemAdicionadoEvent>,
                INotificationHandler<PedidoAtualizadoEvent>,
                INotificationHandler<PedidoEstoqueRejeitadoEvent>
    {
        public Task Handle(PedidoRascunhoIniciadoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
        public Task Handle(PedidoItemAdicionadoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
        public Task Handle(PedidoAtualizadoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(PedidoEstoqueRejeitadoEvent notification, CancellationToken cancellationToken)
        {
            //cancelar o processamento do pedido e retornar erro
            return Task.CompletedTask;
        }
    }
}
