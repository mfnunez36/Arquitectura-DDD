using AutoMapper;
using Aplicacion.Core;

namespace Utilitarios.IoC
{
    public sealed class MapperInitializer
    {
        public static void ConfigurarMapeos()
        {
            Mapper.Initialize(map =>
            {
                map.AddProfile<MapperProfile>();
            });
        }
    }
}
