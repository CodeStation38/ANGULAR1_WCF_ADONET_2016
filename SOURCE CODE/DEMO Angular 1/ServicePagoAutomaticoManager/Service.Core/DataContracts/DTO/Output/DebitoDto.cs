using System.Runtime.Serialization;

namespace Service.Core.DataContracts.DTO.Output
{
    [DataContract(Name = "DebitoDto", Namespace = "Service.Core.DataContracts.DTO.Output")]
    public class DebitoDto
    {
        [DataMember]
        public string fechaVencimiento_especifica;
        [DataMember]
        public string fechaDebitoCuentaCliente;
        [DataMember]
        public string estadoDebito;
        [DataMember]
        public string fechaEstadoDebito;
        [DataMember]
        public string motivoRechazo;
        [DataMember]
        public string montoDebitado;

    }
}
