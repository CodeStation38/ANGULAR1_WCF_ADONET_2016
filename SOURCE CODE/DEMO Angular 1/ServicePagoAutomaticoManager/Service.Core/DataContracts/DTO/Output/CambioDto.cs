using System;
using System.Runtime.Serialization;

namespace Service.Core.DataContracts.DTO.Output
{
    [DataContract(Name = "CambioDto", Namespace = "Service.Core.DataContracts.DTO.Output")]
    public class CambioDto
    {
        #region Public Properties
        [DataMember]
        public Int32 id { get; set; }
        [DataMember]
        public String codigo { get; set; }
        [DataMember]
        public String nroAdhesion { get; set; }
        [DataMember]
        public String nroTramite { get; set; }
        [DataMember]
        public String descripcion { get; set; }
        [DataMember]
        public String usuario { get; set; }
        [DataMember]
        public String canal { get; set; }
        [DataMember]
        public String fecha { get; set; }
        [DataMember]
        public String hora { get; set; }

        #endregion
    }
}
