using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Dominio.Core;

namespace Aplicacion.Core
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Obra, AsistenciaDTO>();
            CreateMap<AsistenciaDTO, Obra>();

            CreateMap<Perfil, PerfilDTO>();
            CreateMap<PerfilDTO, Perfil>();

            CreateMap<Trabajador, TrabajadorDTO>();
            CreateMap<TrabajadorDTO, Trabajador>();

            CreateMap<TrabajadorObra, TrabajadorObraDTO>();
            CreateMap<TrabajadorObraDTO, TrabajadorObra>();

            CreateMap<Obra, ObraDTO>();
            CreateMap<ObraDTO, Obra>();
        }
    }
}
