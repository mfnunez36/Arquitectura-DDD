using Aplicacion.Core;
using AutoMapper;

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
