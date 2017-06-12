using System;

namespace Dominio.Core
{
    public interface IUnidadDeTrabajo : IDisposable
    {
        int Completar();//Confirmar, guardar cambios.
    }
}
