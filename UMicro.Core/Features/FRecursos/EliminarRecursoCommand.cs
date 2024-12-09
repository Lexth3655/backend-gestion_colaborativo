using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMicro.Core.Interfaces;
using UMicro.Domain.Modelo;

namespace UMicro.Core.Features.FRecursos
{
    public class EliminarRecursoCommand : IRequest<Recurso>
    {
        public int Id { get; set; }
    }
    public class EliminarRecursoCommandHandler : IRequest<EliminarRecursoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public EliminarRecursoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public class EliminarRecursoCommand : IRequest
        {
            public int RecursoID { get; set; }
        }
       

            public async Task<Unit> Handle(EliminarRecursoCommand request, CancellationToken cancellationToken)
            {
                var recurso = await _unitOfWork.RepositoryRecurso.GetByIdAsync(request.RecursoID);
                if (recurso == null)
                    throw new FileNotFoundException("Recurso no encontrado.");

            await _unitOfWork.RepositoryRecurso.DeleteAsync(recurso);
                await _unitOfWork.SaveChangesAsync();
                return Unit.Value;
            }
        }


    }

