using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DominioRico.Core.DomainObjects
{
    //Trabalhar com o conceito de 1 Repository por Agregação
    public interface IRepository<T>: IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
