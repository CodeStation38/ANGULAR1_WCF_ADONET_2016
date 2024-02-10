using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class CuentaCliente
    {
        #region Public Properties
        public string CbuTitular { get; set; }
        public string CbuNumero { get; set; }
        public string CbuTitularCuit { get; set; }
        public Banco banco { get; set; }
        //public string BancoDescripcion { get { return banco.descripcion; } }
        public bool mismoTitular { get; set; }
        public string tipoCuenta { get; set; }
        public string Descripcion
        {
            get
            {
                return CbuTitular + "; " + CbuNumero + "; " + banco.descripcion + "; " + CbuTitularCuit;
            }
        }

        public string Codigo
        {
            get
            {
                return CbuTitular + ";" + CbuTitularCuit;
            }
        }

        #endregion
    }
}
