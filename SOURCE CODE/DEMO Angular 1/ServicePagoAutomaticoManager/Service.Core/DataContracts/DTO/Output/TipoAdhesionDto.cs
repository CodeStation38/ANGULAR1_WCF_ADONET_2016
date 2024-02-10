using System.Runtime.Serialization;

namespace Service.Core.DataContracts.DTO.Output
{
    [DataContract(Name = "TipoAdhesionDto", Namespace = "Service.Core.DataContracts.DTO.Output")]
    public class TipoAdhesionDto
    {
        [DataMember]
        public string codigo { get; set; }
        [DataMember]
        public string descripcion { get; set; }
    }
}
