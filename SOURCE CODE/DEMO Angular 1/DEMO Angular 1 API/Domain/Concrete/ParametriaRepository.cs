using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;



namespace Domain
{
    public class ParametriaRepository
    {
        #region Singleton ParametriaService
        ParametriaService context = null;
        public ParametriaService Context
        {
            get
            {
                if (context == null)
                    context = new ParametriaService();
                return context;
            }
        }
        #endregion

        public List<TipoCuenta> buscarTiposCuenta()
        {
            return Context.buscarTiposCuenta();
        }
        public List<Banco> buscarBancos()
        {
            return Context.buscarBancos();
        }

        public List<TipoMonto> buscarTiposMonto()
        {
            return Context.buscarTiposMonto();
        }

        public List<TipoAdhesion> buscarTiposAdhesion()
        {
            return Context.buscarTiposAdhesion();
        }

        public List<TipoDocumento> buscarTiposDocumento()
        {
            return Context.buscarTiposDocumento();
        }

    }
}
