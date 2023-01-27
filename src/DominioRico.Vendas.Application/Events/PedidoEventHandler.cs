using DominioRico.Core.Bus;
using DominioRico.Core.Messages.CommonMessages.IntegrationEvents;
using DominioRico.Vendas.Application.Commands;
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
                INotificationHandler<PedidoEstoqueRejeitadoEvent>,
                INotificationHandler<PagamentoRealizadoEvent>,
                INotificationHandler<PagamentoRecusadoEvent>
    {
        private readonly IMediatorHandler _mediatorHandler;
        public PedidoEventHandler(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }
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

        public async Task Handle(PagamentoRealizadoEvent message, CancellationToken cancellationToken)
        {
            await _mediatorHandler.EnviarComando(new FinalizarPedidoCommand(message.PedidoId,message.ClienteId));
        }

        public async Task Handle(PagamentoRecusadoEvent message, CancellationToken cancellationToken)
        {
            await _mediatorHandler.EnviarComando(new CancelarProcessamentoPedidoEstornarEstoqueCommand(message.PedidoId, message.ClienteId));
        }
    }
}
