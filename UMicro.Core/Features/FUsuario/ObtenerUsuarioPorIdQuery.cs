using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using UMicro.Core.Interfaces;
using UMicro.Domain.Modelo;

namespace UMicro.Core.Features.FUsuario
{
    public class ObtenerUsuarioPorIdQuery : IRequest<Usuario>
    {
        public int UsuarioId { get; set; }
    }

    public class ObtenerUsuarioPorIdQueryHandler : IRequestHandler<ObtenerUsuarioPorIdQuery, Usuario>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Mapper _mapper;

        public ObtenerUsuarioPorIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = (Mapper?)mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Usuario> Handle(ObtenerUsuarioPorIdQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.RepositoryUsuario.GetByIdAsync(request.UsuarioId);
        }
    }

}
