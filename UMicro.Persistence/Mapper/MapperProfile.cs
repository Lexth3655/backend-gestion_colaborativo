using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMicro.Core.Features.FPermiso;
using UMicro.Core.Features.FRoles;
using UMicro.Core.Features.FTablero;
using UMicro.Core.Features.FUsuario;
using UMicro.Domain.Modelo;

namespace UMicro.Persistence.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            //automapper
            CreateMap<CrearRolCommand, Roles>();
            CreateMap<ActualizarRolCommand, Roles>();
            CreateMap<Roles, Roles>();
            CreateMap<Permiso, Permiso>();
            CreateMap<CrearPermisoCommand, Permiso>()
                .ForMember(dest => dest.id, opt => opt.Ignore());

            CreateMap<IniciarSesionCommand, Usuario>();

            CreateMap<AgregarTableroCommand, Tablero>();
            CreateMap<EliminarTableroCommand, Tablero>();
            CreateMap<GetTablerosByProyectoQuery, Tablero>();
            CreateMap<ModifcarTableroCommand, Tablero>();
            CreateMap<ObtenerTableroPorIDQuery, Tablero>();


            //CreateMap<CreateProyectoCommand, Proyecto>()
            //   .ForMember(x => x.fecha_creado, y => y.MapFrom(z => DateTime.Now))
            //   .ReverseMap();

            /*CreateMap<CreateUsuarioCommand, Usuario>()
                .ForMember(x => x.FechaCreacion, y => y.MapFrom(z => DateTime.Now))
                .ReverseMap();*/
        }
    }
}
