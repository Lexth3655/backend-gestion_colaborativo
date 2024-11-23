using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMicro.Core.Features.FProyecto;
using UMicro.Core.Features.FUsuario;
using UMicro.Core.Features.FUsuariosProyectos;
using UMicro.Domain.Modelo;

namespace UMicro.Persistence.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            //Fproy
            CreateMap<ActualizarProyectoCommand, Proyecto>();
            CreateMap<CrearProyectoCommand, Proyecto>();
            CreateMap<EliminarProyectoCommand, Proyecto>();
            CreateMap<ObtenerProyectoPorIdQuery, Proyecto>();
            CreateMap<ListarProyectosDeUsuarioQuery, Proyecto>();

            //FUsuario
            CreateMap<IniciarSesionCommand, Usuario>();
            CreateMap<ActualizarUsuarioCommand, Usuario>();
            CreateMap<AsignarRolAUsuarioCommand, Usuario>();
            CreateMap<ObtenerUsuarioPorIdQuery, Usuario>();

            //FUsuario_Proye
            CreateMap<ActualizarRolUsuarioEnProyectoCommand, UsuarioProyecto>();
            CreateMap<AsignarUsuarioAProyectoCommand, UsuarioProyecto>();
            CreateMap<ConsultarUsuariosPorProyectoQuery, UsuarioProyecto>();
            CreateMap<EliminarUsuarioDeProyectoCommand, UsuarioProyecto>();




            //CreateMap<CreateProyectoCommand, Proyecto>()
            //   .ForMember(x => x.fecha_creado, y => y.MapFrom(z => DateTime.Now))
            //   .ReverseMap();

            /*CreateMap<CreateUsuarioCommand, Usuario>()
                .ForMember(x => x.FechaCreacion, y => y.MapFrom(z => DateTime.Now))
                .ReverseMap();*/
        }
    }
}
