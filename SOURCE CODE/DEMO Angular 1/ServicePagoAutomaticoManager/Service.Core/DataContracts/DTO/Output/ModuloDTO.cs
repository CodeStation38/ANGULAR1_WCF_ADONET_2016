using System.Runtime.Serialization;

namespace Service.Core.DataContracts.DTO.Output
{
   [DataContract(Name = "ModuloDto", Namespace = "Service.Core.DataContracts.DTO.Output")]
   public class ModuloDTO
    {
        [DataMember]
        public string codigo { get; set; }
        [DataMember]
        public string descripcion { get; set; }
    }
}
