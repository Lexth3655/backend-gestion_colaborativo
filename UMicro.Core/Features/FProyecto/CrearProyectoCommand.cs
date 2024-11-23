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
    public class CrearProyectoCommand : IRequest<Proyecto>
    {
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public DateTime fechaStar { get; set; }
        public DateTime fechaEnd { get; set; }
    }

    public class CrearProyectoCommandHandler : IRequestHandler<CrearProyectoCommand, Proyecto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CrearProyectoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Proyecto> Handle(CrearProyectoCommand request, CancellationToken cancellationToken)
        {
            var proyecto = new Proyecto
            {
                nombreProyecto = request.nombre,
                descripcionProyecto = request.descripcion,
                fecha_inicio = request.fechaStar,
                fecha_fin = request.fechaEnd,
                fecha_creado = DateTime.Now,
                activo = true
            };
            var p = _mapper.Map<Proyecto>(proyecto);
            await _unitOfWork.RepositoryProyecto.AddAsync(proyecto);
            await _unitOfWork.SaveChangesAsync();

            return p; // Retorna el ID del nuevo proyecto
        }
    }

}
