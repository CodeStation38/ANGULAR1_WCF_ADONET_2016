using System.Runtime.Serialization;

namespace Service.Core.DataContracts.DTO.Output
{
    [DataContract(Name = "CuentaClienteDto", Namespace = "Service.Core.DataContracts.DTO.Output")]
    public class CuentaClienteDto
    {
        #region Public Properties

        [DataMember]
        public string CbuTitular { get; set; }
        [DataMember]
        public bool mismoTitular { get; set; }
        [DataMember]
        public string tipoCuenta { get; set; }
        [DataMember]
        public string CbuNumero { get; set; }
        [DataMember]
        public BancoDto banco { get; set; }        
        [DataMember]
        public string CbuTitularCuit { get; set; }

        [DataMember]
        public string Descripcion
        {
            get;
            set;

        }
        [DataMember]
        public string Codigo
        {
            get;
            set;

        }

        #endregion
    }
}
