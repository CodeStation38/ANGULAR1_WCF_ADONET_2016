using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Service.Core.DataContracts.DTO.Output;

namespace Service.Core.DataContracts.DTO.Output
{
    [DataContract(Name = "ClienteUnicoDto", Namespace = "Service.Core.DataContracts.DTO.Output")]
    public class ClienteUnicoDto : ClienteDto
    {
        #region Public Properties
        [DataMember]
        public String tipoCuenta { get; set; }
        [DataMember]
        public String fechaVencimiento { get; set; }
        [DataMember]
        public String fechaCierre { get; set; }
        [DataMember]
        public String fechaVencimientoPosterior { get; set; }
        [DataMember]
        public String fechaCierrePosterior { get; set; }
        [DataMember]
        public String situacionCuenta { get; set; }
        [DataMember]
        public String situacionMora { get; set; }
        //Datos del Titular
        [DataMember]
        public String tipoTarjeta { get; set; }
        [DataMember]
        public String email { get; set; }

        #endregion
    }
}
