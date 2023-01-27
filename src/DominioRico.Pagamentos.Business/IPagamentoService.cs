using DominioRico.Core.DomainObjects.DTO;
using System;
using System.Threading.Tasks;

namespace DominioRico.Pagamentos.Business
{
    public interface IPagamentoService
    {
        Task<Transacao> RealizarPagamentoPedido(PagamentoPedido pagamentoPedido);
    }
}
