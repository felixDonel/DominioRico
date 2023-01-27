using DominioRico.Core.DomainObjects;
using System;

namespace DominioRico.Pagamentos.Business
{
    public interface IPagamentoRepository : IRepository<Pagamento>
    {
        void Adicionar(Pagamento pagamento);

        void AdicionarTransacao(Transacao transacao);
    }
}
