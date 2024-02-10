using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class AbmTabla 
    {
        public IEnumerable<Dictionary<string, object>> datos { get; set; }
        public atb_abm_tabla tabla { get; set; }
        public List<acp_abm_campo> campos { get; set; }
        public List<tablasRelacionada> tablasRelacionadas { get; set; }
    }

    public class atb_abm_tabla
    {
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string tabla { get; set; }
        public string moduloCodigo { get; set; }
        public Boolean permiteAlta { get; set; }
        public Boolean permiteBaja { get; set; }
    }

    public class tablasRelacionada
    {
        public string nombre { get; set; }
        public List<camposTablasRelacionada> campos { get; set; }
    }

    public class camposTablasRelacionada
    {
        public string pkFK { get; set; }
        public string descFK { get; set; }
    }

    public class acp_abm_campo
    {
        public Int64 id { get; set; }
        public string codigoTabla { get; set; }
        public string nombreTabla { get; set; }
        public string nombreCampo { get; set; }
        public string etiqueta { get; set; }
        public Boolean permiteEdicion { get; set; }
        public string tipoDato { get; set; }
        public Int32 longitud { get; set; }
        public decimal cantidadDecimal { get; set; }
        public Int32 esPk { get; set; }
        public Boolean esIdentity { get; set; }
        public string tablaFK { get; set; }
        public string pkTablaFK { get; set; }
        public string descripcionFK { get; set; }
        public Int32 Orden { get; set; }

    }

}
