using System.Runtime.Serialization;

namespace Service.Core.DataContracts.DTO.Output
{
    [DataContract(Name = "TipoDocumentoDto", Namespace = "Service.Core.DataContracts.DTO.Output")]
    public class TipoDocumentoDto
    {
        [DataMember]
        public string descripcion { get; set; }
        [DataMember]
        public string valor { get; set; }
    }
}
