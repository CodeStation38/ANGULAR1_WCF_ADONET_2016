using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ClienteUnico : Cliente
    {
        #region Public Properties

        public String tipoCuenta { get; set; }
        public String fechaVencimiento { get; set; }
        public String fechaCierre { get; set; }
        public String fechaVencimientoPosterior { get; set; }
        public String fechaCierrePosterior { get; set; }
        public String situacionCuenta { get; set; }
        public String situacionMora { get; set; }
        //Datos del Titular
        public String tipoTarjeta { get; set; }
        public String email { get; set; }

        #endregion
    }
}
