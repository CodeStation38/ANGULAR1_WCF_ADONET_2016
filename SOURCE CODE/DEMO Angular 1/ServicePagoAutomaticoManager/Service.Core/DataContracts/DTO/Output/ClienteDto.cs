using System;
using System.Runtime.Serialization;

namespace Service.Core.DataContracts.DTO.Output
{
    [DataContract(Name = "ClienteDto", Namespace = "Service.Core.DataContracts.DTO.Output")]
    public class ClienteDto
    {
        #region Public Properties
        [DataMember]
        public Int32 id { get; set; }
        [DataMember]
        public String cuenta { get; set; }
        [DataMember]
        public String apellido { get; set; }
        [DataMember]
        public String nombre { get; set; }
        [DataMember]
        public String tipoDocumento { get; set; }
        [DataMember]
        public String documento { get; set; }
        [DataMember]
        public String tarjeta { get; set; }

        #endregion
    }
}
