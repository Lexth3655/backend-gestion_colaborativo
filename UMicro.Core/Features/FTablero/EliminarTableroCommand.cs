using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMicro.Core.Interfaces;
using UMicro.Domain.Modelo;

namespace UMicro.Core.Features.FTablero
{
    public class EliminarTableroCommand : IRequest<bool>
    {
        public int tableroID { get; set; }

    }

    public class EliminarTableroCommandHandler : IRequestHandler<EliminarTableroCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EliminarTableroCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(EliminarTableroCommand request, CancellationToken cancellationToken)
        {
            var tablero = await _unitOfWork.RepositoryTablero.GetByIdAsync(request.tableroID);
            if (tablero == null) return false;
            await _unitOfWork.RepositoryTablero.DeleteAsync(tablero);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }


}
