using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class CambioRepository
    {
        #region Singleton CambioService
        CambioService context = null;
        public CambioService Context
        {
            get
            {
                if (context == null)
                    context = new CambioService();
                return context;
            }
        }
        #endregion

        public List<Cambio> BuscarCambiosHistoricos(string cuentaId,string desde,string hasta, string adhesionId)
        {
            return Context.BuscarCambiosHistoricos(cuentaId,desde,hasta,adhesionId);
        }

    }
}
