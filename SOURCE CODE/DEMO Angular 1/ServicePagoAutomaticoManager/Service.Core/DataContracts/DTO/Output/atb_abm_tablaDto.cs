using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Domain;

namespace Service.Core.DataContracts.DTO.Output
{
    [DataContract(Name = "atb_abm_tablaDto", Namespace = "Service.Core.DataContracts.DTO.Output")]
    public class atb_abm_tablaDto
    {
        [DataMember]
        public string codigo { get; set; }
        [DataMember]
        public string nombre { get; set; }
        [DataMember]
        public string descripcion { get; set; }
        [DataMember]
        public string tabla { get; set; }
        [DataMember]
        public string moduloCodigo { get; set; }
        [DataMember]
        public Boolean permiteAlta { get; set; }
        [DataMember]
        public Boolean permiteBaja { get; set; }
    }
}
