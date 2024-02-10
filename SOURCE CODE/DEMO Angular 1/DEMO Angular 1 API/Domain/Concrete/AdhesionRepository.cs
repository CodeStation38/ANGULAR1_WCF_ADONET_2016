using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace Domain
{
    public class AdhesionRepository
    {
        #region Singleton AdhesionService
        AdhesionService context = null;
        public AdhesionService Context
        {
            get
            {
                if (context == null)
                    context = new AdhesionService();
                return context;
            }
        }
        #endregion

        public List<Debito> BuscarDebitos(string adhesionId)
        {
            return Context.BuscarDebitos(adhesionId);
        }

        public Debito BuscarUltimoDebitoEnCurso(string adhesionId)
        {
            return Context.BuscarUltimoDebitoEnCurso(adhesionId);
        }

        public List<Adhesion> BuscarAdhesiones(Int32 clienteId) {
            return Context.BuscarAdhesiones(clienteId);
        }

        public Adhesion BuscarAdhesion(Int32 adhesionId)
        {
            return Context.BuscarAdhesion(adhesionId);
        }
    }
}
