using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Service.Core.DataContracts.DTO.Output;

namespace Service.Core.DataContracts.DTO.Output
{
    [DataContract(Name = "DatosFechaDebitoDto", Namespace = "Service.Core.DataContracts.DTO.Output")]
    public class DatosFechaDebitoDto
    {
        [DataMember]
        public int EntraMesSiguiente { get; set; }
        [DataMember]
        public string FechaDebito { get; set; }
        [DataMember]
        public string Fecha2 { get; set; }
        [DataMember]
        public int CambiarFecha { get; set; }
        [DataMember]
        public int DiasHabiles { get; set; }

    }
}
