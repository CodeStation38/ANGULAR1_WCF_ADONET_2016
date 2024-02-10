using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Cliente
    {
        #region Public Properties

        public Int32 id { get; set; }
        public String cuenta { get; set; }
        //Datos del Titular
        public String apellido {get;set;}
        public String nombre { get; set; }
        public String tipoDocumento { get; set; }
        public String documento { get; set; }
        public String tarjeta {get;set;}
   
        #endregion
    }
}
