using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain
{
    public class ClienteRepository
    {
        //Ante timeout lógico de Chile, se switchea de context a un servicio que llame el WS de chile.
        #region Singleton ClienteService

        ClienteService context = null;

        public ClienteService Context
        {
            get
            {
                if (context == null)
                    context = new ClienteService();
                return context;
            }
        }
        #endregion

        public List<Cliente> buscarClientes(string apellido, string nombre, string tipoDocumento, string documento, string cuenta, string tarjeta)
        {
            return Context.buscarClientes( apellido, nombre, tipoDocumento, documento, cuenta, tarjeta);
        }
 
        public ClienteUnico buscarCliente(int idCliente)
        {
            return Context.buscarCliente(idCliente);
        }

        public List<CuentaCliente> buscarCuentas(string idCtaNroCliente)
        {
            return Context.buscarCuentas(idCtaNroCliente);

        }

        public CuentaCliente buscarCuentaSegunAdhesion(string idAdhesion)
        {
            return Context.buscarCuentaSegunAdhesion(idAdhesion);
        }

        public int buscarAdhesionVigenteRecurrente(string ctaClienteNro)
        {
            return Context.buscarAdhesionVigenteRecurrente(ctaClienteNro);
        }

        public DatosFechaDebitoPorVencimiento buscarFechaDebitoPorVencimiento(string clienteFDeb)
        {
            return Context.buscarFechaDebitoPorVencimiento(clienteFDeb);
        }


    }
}
