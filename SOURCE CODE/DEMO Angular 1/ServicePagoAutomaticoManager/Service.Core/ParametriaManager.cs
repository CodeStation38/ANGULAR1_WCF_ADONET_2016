using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Core.DataContracts.DTO.Output;
using Service.Core.Mapper;
using System.Configuration;
using Infraestructure.DataPersistencia;
using Domain;


namespace Service.Core
{
    public interface IParametriaManager
    {
        List<atb_abm_tablaDto> buscarTablas(string ModuloCod);


    }
    public class ParametriaManager : IParametriaManager
    {
        private readonly IParametriaRepository _parametriaRepository;
        private readonly ITransformMapper _transformMapper;
        public ParametriaManager(ITransformMapper transformMapper, IParametriaRepository parametriaRepository)
        {
            _parametriaRepository = parametriaRepository;
            _transformMapper = transformMapper;
        }

        public List<atb_abm_tablaDto> buscarTablas(string moduloCod)
        {
            List<atb_abm_tabla> lt = new List<atb_abm_tabla>();
            try
            {
                lt = _parametriaRepository.buscarTablas(moduloCod);
                var tranform = _transformMapper.TransformToDto<List<atb_abm_tabla>, List<atb_abm_tablaDto>>(lt);
                return tranform;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


    }
}
