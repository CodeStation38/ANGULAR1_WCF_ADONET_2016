using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Domain
{
    public class CambioService : GenericService
    {
        public List<Cambio> BuscarCambiosHistoricos(string cuentaId, string desde,string hasta, string adhesionId)
        {
            List<Cambio> oCambios = new List<Cambio>();
            string conn = Properties.Settings.Default.conexionDB.ToString();

            cuentaId = asSQLParameter(cuentaId);
            desde = asSQLParameter(desde);
            hasta = asSQLParameter(hasta);
            adhesionId = asSQLParameter(adhesionId);

            try
            {
                using (SqlConnection conexion = new SqlConnection(conn))
                {
                    using (SqlCommand cmd = new SqlCommand("pa_cambios_qry_sp", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CuentaId", cuentaId);
                        cmd.Parameters.AddWithValue("@Desde", desde);
                        cmd.Parameters.AddWithValue("@Hasta", hasta);
                        cmd.Parameters.AddWithValue("@AdhesionId", adhesionId);
                        conexion.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Cambio oCambio = new Cambio();

                                oCambio.id = 1;
                                oCambio.codigo = "Mock";
                                oCambio.nroAdhesion = "Mock";
                                oCambio.nroTramite = "Mock";
                                oCambio.usuario = "Mock";
                                oCambio.canal = "Mock";
                                oCambio.descripcion = "Mock";
                                oCambio.fecha = "Mock";
                                oCambio.hora = "Mock";

                                oCambios.Add(oCambio);
                            }
                        }
                    }
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;// loguear error
            }

            return oCambios;
        }
    }
}
