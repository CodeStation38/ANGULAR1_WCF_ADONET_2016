using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Cambio
    {
        #region Public Properties

        public Int32 id { get; set; }
        public String codigo { get; set; }
        public String nroAdhesion { get; set; }
        public String nroTramite { get; set; }
        public String descripcion { get; set; }
        public String usuario { get; set; }
        public String canal { get; set; }
        public String fecha { get; set; }
        public String hora { get; set; }
        
        #endregion
    }
}
