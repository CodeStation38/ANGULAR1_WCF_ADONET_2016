using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Domain;
using Service.Core.DataContracts.DTO.Output;
using Service.Core;

namespace ServicePagoAutomaticoManager
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ParametriaService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ParametriaService.svc or ParametriaService.svc.cs at the Solution Explorer and start debugging.
    public class ParametriaService : IParametriaService
    {
        private readonly IParametriaManager _parametriaManager;

        public ParametriaService(IParametriaManager parametriaManager)
        {
            _parametriaManager = parametriaManager;
        }

        public List<atb_abm_tablaDto> buscarTablas(string ModuloCod)
        {
            try
            {
                return _parametriaManager.buscarTablas(ModuloCod);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

    }
}
