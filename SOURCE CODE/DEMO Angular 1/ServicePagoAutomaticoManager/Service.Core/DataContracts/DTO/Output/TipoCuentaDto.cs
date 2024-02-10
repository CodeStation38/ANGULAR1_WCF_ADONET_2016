using System.Runtime.Serialization;

namespace Service.Core.DataContracts.DTO.Output
{
    [DataContract(Name = "TipoCuentaDto", Namespace = "Service.Core.DataContracts.DTO.Output")]
    public class TipoCuentaDto
    {
        [DataMember]
        public string codigo { get; set; }
        [DataMember]
        public string descripcion { get; set; }
    }
}
