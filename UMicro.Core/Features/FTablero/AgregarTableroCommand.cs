using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMicro.Core.Features.FProyecto;
using UMicro.Core.Interfaces;
using UMicro.Domain.Modelo;

namespace UMicro.Core.Features.FTablero
{
    public class AgregarTableroCommand: IRequest<Tablero>
    {
        public int proyectoID { get; set; }
        public string nombrTablero { get; set; }
        public string tipo { get; set; }

    }

    public class AgregarTableroCommandHandler : IRequestHandler<AgregarTableroCommand, Tablero>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AgregarTableroCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Tablero> Handle(AgregarTableroCommand request, CancellationToken cancellationToken)
        {
            var tablero = new Tablero
            {
                proyectoID = request.proyectoID,
                nombreTablero = request.nombrTablero,
                tipo = request.tipo,
                fecha_creado = DateTime.Now,
                activo = true
            };
            var t = _mapper.Map<Tablero>(tablero);
            await _unitOfWork.RepositoryTablero.AddAsync(t);
            await _unitOfWork.SaveChangesAsync();

            return t; // Retorna el ID del nuevo proyecto
        }
    }
}
