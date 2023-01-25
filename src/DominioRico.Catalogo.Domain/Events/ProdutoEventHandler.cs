using DominioRico.Core.Bus;
using DominioRico.Core.Messages.CommonMessages.IntegrationEvents;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DominioRico.Catalogo.Domain.Events
{
    public class ProdutoEventHandler :
       INotificationHandler<ProdutoAbaixoEstoqueEvent>,
       INotificationHandler<PedidoIniciadoEvent>,
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IEstoqueService _estoqueService;
        private readonly IMediatorHandler _mediatorHandler;

        public ProdutoEventHandler(IProdutoRepository produtoRepository,
                                   IEstoqueService estoqueService,
                                   IMediatorHandler mediatorHandler)
        {
            _produtoRepository = produtoRepository;
            _estoqueService = estoqueService;
            _mediatorHandler = mediatorHandler;
        }
        public async Task Handle(ProdutoAbaixoEstoqueEvent mensagem, CancellationToken cancellationToken)
        {
            var produto = _produtoRepository.ObterPorId(mensagem.AggregateId);

            //Fazer uma ação nessa demanda!
        }

        public async Task Handle(PedidoIniciadoEvent message, CancellationToken cancellationToken)
        {
            var result = await _estoqueService.DebitarListaProdutosPedido(message.ProdutosPedido);

            if (result)
            {
                await _mediatorHandler.PublicarEvent(new PedidoEstoqueConfirmadoEvent(message.PedidoId, message.ClienteId, message.Total, message.ProdutosPedido, message.NomeCartao, message.NumeroCartao, message.ExpiracaoCartao, message.CvvCartao));
            }
            else
            {
                await _mediatorHandler.PublicarEvent(new PedidoEstoqueRejeitadoEvent(message.PedidoId, message.ClienteId));
            }
        }
    }
}
