using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;



namespace Domain
{
    public class ParametriaService : GenericService
    {
        public List<TipoCuenta> buscarTiposCuenta()
        {
            List<TipoCuenta> oTiposCuenta = new List<TipoCuenta>();
            string conn = ""; // obtener la cadena de conexion!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            try
            {
                using (SqlConnection conexion = new SqlConnection(conn))
                {
                    using (SqlCommand cmd = new SqlCommand("pa_tipocuenta_qry_sp", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        conexion.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                TipoCuenta oTipoCuenta = new TipoCuenta();
                                oTipoCuenta.codigo = reader["btc_cod"].ToString();
                                oTipoCuenta.descripcion = reader["btc_descripcion"].ToString();
                                oTiposCuenta.Add(oTipoCuenta);
                            }
                        }
                    }
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex; // loguear error
            }
            return oTiposCuenta;
        }

        public List<Banco> buscarBancos()
        {
            List<Banco> oBancos = new List<Banco>();
            string conn = Properties.Settings.Default.conexionDB.ToString();
            try
            {
                using (SqlConnection conexion = new SqlConnection(conn))
                {
                    using (SqlCommand cmd = new SqlCommand("pa_bancos_qry_sp", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        conexion.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Banco oBanco = new Banco();
                                oBanco.codigo = reader["bco_cod"].ToString();
                                oBanco.descripcion = reader["bco_descripcion"].ToString();
                                oBancos.Add(oBanco);
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
            return oBancos;
        }

        public List<TipoMonto> buscarTiposMonto()
        {
            List<TipoMonto> oTiposMonto = new List<TipoMonto>();
            string conn = Properties.Settings.Default.conexionDB.ToString();
            try
            {
                using (SqlConnection conexion = new SqlConnection(conn))
                {
                    using (SqlCommand cmd = new SqlCommand("pa_tipomonto_qry_sp", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        conexion.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                TipoMonto oTipoMonto = new TipoMonto();
                                oTipoMonto.codigo = reader["tmo_cod"].ToString();
                                oTipoMonto.descripcion = reader["tmo_descripcion"].ToString();
                                oTiposMonto.Add(oTipoMonto);
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
            return oTiposMonto;

        }

        public List<TipoAdhesion> buscarTiposAdhesion()
        {
            List<TipoAdhesion> oTiposAdhesion = new List<TipoAdhesion>();
            string conn = Properties.Settings.Default.conexionDB.ToString();
            try
            {
                using (SqlConnection conexion = new SqlConnection(conn))
                {
                    using (SqlCommand cmd = new SqlCommand("pa_tipoadhesion_qry_sp", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        conexion.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                TipoAdhesion oTipoAdhesion = new TipoAdhesion();
                                oTipoAdhesion.codigo = reader["tad_cod"].ToString();
                                oTipoAdhesion.descripcion = reader["tad_descripcion"].ToString();
                                oTiposAdhesion.Add(oTipoAdhesion);
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
            return oTiposAdhesion;

        }
    
        public List<TipoDocumento> buscarTiposDocumento(){

          List<TipoDocumento> oDocumentos = new List<TipoDocumento>();
            string conn = Properties.Settings.Default.conexionDB.ToString();
            try
            {
                using (SqlConnection conexion = new SqlConnection(conn))
                {
                    using (SqlCommand cmd = new SqlCommand("pa_tipodocumento_qry_sp", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        conexion.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                TipoDocumento oTipoDocumento = new TipoDocumento();
                                oTipoDocumento.valor = reader["tdoc_id"].ToString();
                                oTipoDocumento.descripcion = reader["tdoc_descripcion"].ToString();
                                oDocumentos.Add(oTipoDocumento);
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

            return oDocumentos;

        }
    }
}
