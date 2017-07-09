using Dominio.Core;
using System;

namespace Dominio.Contratos
{
    public interface ITrabajadorRepositorio : IRepositorioBase<Trabajador>, IDisposable
    {
    }
}
