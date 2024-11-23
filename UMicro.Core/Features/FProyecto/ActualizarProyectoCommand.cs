using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMicro.Core.Interfaces;
using UMicro.Domain.Modelo;

namespace UMicro.Core.Features.FProyecto
{
    public class ActualizarProyectoCommand : IRequest<Proyecto>
    {
        public int proyectoID { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public DateTime fechaStar { get; set; }
        public DateTime fechaEnd { get; set; }
    }

    public class ActualizarProyectoCommandHandler : IRequestHandler<ActualizarProyectoCommand, Proyecto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ActualizarProyectoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Proyecto> Handle(ActualizarProyectoCommand request, CancellationToken cancellationToken)
        {
            // Obtener el proyecto por ID
            var proyecto = await _unitOfWork.RepositoryProyecto.GetByIdAsync(request.proyectoID);

            // Verificar si el proyecto existe
            if (proyecto == null)
            {
                return null; // O lanzar una excepción si prefieres
            }

            // Actualizar las propiedades del proyecto
            proyecto.nombreProyecto = request.nombre;
            proyecto.descripcionProyecto = request.descripcion;
            proyecto.fecha_inicio = request.fechaStar;
            proyecto.fecha_fin = request.fechaEnd;

            // Guardar los cambios en el repositorio
            await _unitOfWork.RepositoryProyecto.UpdateAsync(proyecto);
            await _unitOfWork.SaveChangesAsync();

            // Retornar el objeto actualizado
            return proyecto; // No es necesario usar AutoMapper
        }
    }

}
