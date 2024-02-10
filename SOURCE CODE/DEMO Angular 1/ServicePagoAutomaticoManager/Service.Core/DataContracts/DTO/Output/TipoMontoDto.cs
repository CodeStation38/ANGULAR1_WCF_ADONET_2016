using System.Runtime.Serialization;

namespace Service.Core.DataContracts.DTO.Output
{
    [DataContract(Name = "TipoMontoDto", Namespace = "Service.Core.DataContracts.DTO.Output")]
    public class TipoMontoDto
    {
        [DataMember]
        public string codigo { get; set; }
        [DataMember]
        public string descripcion { get; set; }
    }
}
