using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMicro.Core.Features.FTablero;
using UMicro.Core.Interfaces;
using UMicro.Domain.Modelo;

namespace UMicro.Core.Features.FTablero
{
    public class ModifcarTableroCommand : IRequest<bool>
    {
        public int tableroID { get; set; }        
        public string nombrTablero { get; set; }

    }

    public class ModifcarTableroCommandHandler : IRequestHandler<ModifcarTableroCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ModifcarTableroCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(ModifcarTableroCommand request, CancellationToken cancellationToken)
        {
            var tablero = await _unitOfWork.RepositoryTablero.GetByIdAsync(request.tableroID);
            if (tablero == null) return false;
            tablero.nombreTablero = request.nombrTablero;
            tablero.fecha_modificado = DateTime.Now;
            var t = _mapper.Map<Tablero>(tablero);
            await _unitOfWork.RepositoryTablero.UpdateAsync (t);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
