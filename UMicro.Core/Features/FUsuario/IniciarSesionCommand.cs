using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using UMicro.Core.Interfaces;
using UMicro.Domain.Modelo;

namespace UMicro.Core.Features.FUsuario
{
    //command
    public class IniciarSesionCommand: IRequest<bool>
    { 
        public string email {  get; set; }
        public string password { get; set; }

    }
    //handler
    public class IniciarSesionCommandHanlder : IRequestHandler<IniciarSesionCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public IniciarSesionCommandHanlder(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(IniciarSesionCommand request, CancellationToken cancellationToken)
        {
            var user = await Task.Run(() =>
            _unitOfWork.RepositoryUsuario.GetAllE().SingleOrDefault(u => u.correo == request.email));

            if (user == null || user.password != request.password)
            {
                return false;
            }

            return true;
        }
    }
}
