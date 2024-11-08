using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMicro.Core.Features.FUsuario;
using UMicro.Domain.Modelo;

namespace UMicro.Persistence.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<IniciarSesionCommand, Usuario>();
       
            //CreateMap<CreateProyectoCommand, Proyecto>()
            //   .ForMember(x => x.fecha_creado, y => y.MapFrom(z => DateTime.Now))
            //   .ReverseMap();

            /*CreateMap<CreateUsuarioCommand, Usuario>()
                .ForMember(x => x.FechaCreacion, y => y.MapFrom(z => DateTime.Now))
                .ReverseMap();*/
        }
    }
}
