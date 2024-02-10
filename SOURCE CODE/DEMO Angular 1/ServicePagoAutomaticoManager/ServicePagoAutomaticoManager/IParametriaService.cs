using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Domain;
using Service.Core.DataContracts.DTO.Output;

namespace ServicePagoAutomaticoManager
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IParametriaService" in both code and config file together.
    [ServiceContract]
    public interface IParametriaService
    {

        [OperationContract]
        List<atb_abm_tablaDto> buscarTablas(string modulo);

    }

}
