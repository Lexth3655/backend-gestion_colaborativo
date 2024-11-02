using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMicro.Core.Interfaces;
using UMicro.Domain.Modelo;

namespace UMicro.Core.Features.FTableroKanban
{
    public class AddTableroToProyectoCommand: IRequest<TableroKanban>
    {
        public int _proyectoId {  get; set; }
        public string _nombreT {  get; set; }

        public AddTableroToProyectoCommand(int proyectoId, string nombreTablero)
        {
            _proyectoId = proyectoId;
            _nombreT= nombreTablero;
        }
    }

    public class AddTableroToProyectoHandler : IRequestHandler<AddTableroToProyectoCommand, TableroKanban>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddTableroToProyectoHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<TableroKanban> Handle(AddTableroToProyectoCommand request, CancellationToken cancellationToken)
        {
            //busca el proyecto en la base de datos

            var proyecto = await _unitOfWork.RepositoryProyecto.GetByIdAsync(request._proyectoId);
            if (proyecto == null)
            {
                //si no se encuentr el proyecto, retornara false
                return null;
            }

            //crea el tablero y se asigna al proyecto
            var newTablero = new TableroKanban
            {
                nombreTablero = request._nombreT,
                proyecto_id = proyecto.id,
            };

            //agrega el tablero atraves de repositorio de tableros
            await _unitOfWork.RepositoryTableroKanban.AddAsync(newTablero);

            //guarda los cambios en la base de datos
            await _unitOfWork.SaveChangesAsync();

            return newTablero;
            

        }


    }
}
