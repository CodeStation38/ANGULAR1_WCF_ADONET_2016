using System.Runtime.Serialization;

namespace Service.Core.DataContracts.DTO.Output
{
    [DataContract(Name = "TipoFechaDebitoDto", Namespace = "Service.Core.DataContracts.DTO.Output")]
    public class TipoFechaDebitoDto
    {
        [DataMember]
        public string codigo { get; set; }
        [DataMember]
        public string descripcion { get; set; }
    }
}
