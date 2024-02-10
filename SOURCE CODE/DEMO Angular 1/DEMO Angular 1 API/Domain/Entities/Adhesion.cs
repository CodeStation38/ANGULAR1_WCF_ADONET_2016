using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain
{
   public class Adhesion
   {
       #region Public Properties
       
       public Int32 numero { get; set; }
       public string fecha { get; set; }
       public TipoAdhesion tipo { get; set; }
       public TipoMonto tipoMonto { get; set; }
       private string MontoDebito { get; set; }
       public string montoDebito
       {
           get
           {
               if (tipoMonto.codigo == "F")
               {
                   return MontoDebito;
               }
               else
               {
                   return tipoMonto.descripcion;
               }
           }
           set
           {
               MontoDebito = value;
           }
       }
       public TipoFechaDebito tipoFechaDebito { get; set; }
       private string FechaDebito { get; set; }
       public string fechaDebito { 
           get { 
                switch (tipoFechaDebito.codigo){
                    case "F":
                        return FechaDebito;
                    case "D":
                        return diaDebito;
                    default:
                        return tipoFechaDebito.descripcion;
                    }
           }
           set {
               FechaDebito = value;
           }
       }
       public string diaDebito { get; set; }
       public bool tieneStopDebit { get; set; }
       public bool aplicaStopDebit
       {
           get
           {
               return (tipo.codigo != "P");
           }
       }
       public EstadoAdhesion estado { get; set; }
       public string fechaModificacion { get; set; }
       public string fechaAplicaModificacion { get; set; }

       #endregion
   }
}
