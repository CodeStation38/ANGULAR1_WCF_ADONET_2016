using System.Runtime.Serialization;

namespace Service.Core.DataContracts.DTO.Output
{
    [DataContract(Name = "EstadoAdhesionDto", Namespace = "Service.Core.DataContracts.DTO.Output")]
    public class EstadoAdhesionDto
    {
        [DataMember]
        public string valor { get; set; }
        [DataMember]
        public string descripcion { get; set; }
    }
}