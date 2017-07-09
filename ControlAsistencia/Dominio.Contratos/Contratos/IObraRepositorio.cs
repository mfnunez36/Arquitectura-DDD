using Dominio.Core;
using System;

namespace Dominio.Contratos
{
    public interface IObraRepositorio : IRepositorioBase<Obra>, IDisposable
    {
    }
}
