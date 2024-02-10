using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Domain
{
    public class AdhesionService : GenericService
    {

        public List<Debito> BuscarDebitos(string adhesionId)
        {
            List<Debito> oDebitos = new List<Debito>();
            string conn = Properties.Settings.Default.conexionDB.ToString();
            try
            {
                using (SqlConnection conexion = new SqlConnection(conn))
                {
                    using (SqlCommand cmd = new SqlCommand("pa_debitos_qry_sp", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@AdhesionId", adhesionId);
                        conexion.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Debito oDebito = new Debito();
                                oDebito.fechaVencimiento_especifica = reader["deb_fecha_a_debitar"].ToString();
                                oDebito.fechaDebitoCuentaCliente = reader["deb_fecha_debito_estimada"].ToString();
                                oDebito.estadoDebito = reader["ebd_descripcion"].ToString();
                                oDebito.fechaEstadoDebito = reader["deb_estado_fecha"].ToString();
                                oDebito.motivoRechazo = reader["bre_desc_respuesta"].ToString();
                                oDebito.montoDebitado = reader["deb_monto"].ToString();
                                oDebitos.Add(oDebito);
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

            return oDebitos;
        }

        public Debito BuscarUltimoDebitoEnCurso(string adhesionId)
        {
            Debito oDebito = new Debito();
            string conn = Properties.Settings.Default.conexionDB.ToString();
            try
            {
                using (SqlConnection conexion = new SqlConnection(conn))
                {
                    using (SqlCommand cmd = new SqlCommand("pa_utlimo_debito_en_curso_qry_sp", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@AdhesionId", adhesionId);
                        conexion.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                oDebito.fechaVencimiento_especifica = reader["deb_fecha_a_debitar"].ToString();
                                oDebito.fechaDebitoCuentaCliente = reader["deb_fecha_debito_estimada"].ToString();
                                oDebito.estadoDebito = reader["ebd_descripcion"].ToString();
                                oDebito.fechaEstadoDebito = reader["deb_estado_fecha"].ToString();
                                oDebito.motivoRechazo = reader["bre_desc_respuesta"].ToString();
                                oDebito.montoDebitado = reader["deb_monto"].ToString();
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

            return oDebito;
        }

        public List<Adhesion> BuscarAdhesiones(Int32 clienteId) {
            List<Adhesion> oAdhesiones = new List<Adhesion>();
            string conn = Properties.Settings.Default.conexionDB.ToString();
            try
            {
                using (SqlConnection conexion = new SqlConnection(conn))
                {
                    using (SqlCommand cmd = new SqlCommand("pa_adhesiones_qry_sp", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CuentaId", clienteId);
                        conexion.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Adhesion oAdhesion = new Adhesion();

                                oAdhesion.numero = Int32.Parse(reader["adh_id"].ToString());
                                oAdhesion.fecha = reader["adh_fecha_alta"].ToString();
                                oAdhesion.tipo = new TipoAdhesion()
                                {
                                    codigo = reader["adh_tipo_adhesion"].ToString(),
                                    descripcion = reader["tad_descripcion"].ToString()
                                };
                                oAdhesion.tipoMonto = new TipoMonto()
                                {
                                    codigo = reader["adh_tipo_monto"].ToString(),
                                    descripcion = reader["tmo_descripcion"].ToString()
                                };
                                oAdhesion.tipoFechaDebito = new TipoFechaDebito()
                                {
                                    codigo = reader["adh_fecha_debito_tipo"].ToString(),
                                    descripcion = reader["fdt_descripcion"].ToString()
                                };
                                oAdhesion.montoDebito = reader["adh_monto"].ToString();
                                oAdhesion.fechaDebito = reader["adh_fecha_debito"].ToString();
                                oAdhesion.diaDebito = reader["adh_dia_debito"].ToString();
                                oAdhesion.tieneStopDebit = Boolean.Parse(reader["adh_tiene_stop_debit"].ToString());

                                oAdhesiones.Add(oAdhesion);
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

            return oAdhesiones;
        }

        public Adhesion BuscarAdhesion(Int32 adhesionId)
        {
            Adhesion oAdhesion = new Adhesion();
            string conn = Properties.Settings.Default.conexionDB.ToString();
            try
            {
                using (SqlConnection conexion = new SqlConnection(conn))
                {
                    using (SqlCommand cmd = new SqlCommand("pa_adhesion_qry_sp", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@AdhesionId", adhesionId);
                        conexion.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                oAdhesion.numero = Int32.Parse(reader["adh_id"].ToString());
                                oAdhesion.fecha = reader["adh_fecha_alta"].ToString();
                                oAdhesion.tipo = new TipoAdhesion()
                                {
                                    codigo = reader["adh_tipo_adhesion"].ToString(),
                                    descripcion = reader["tad_descripcion"].ToString()
                                };
                                oAdhesion.tipoMonto = new TipoMonto()
                                {
                                    codigo = reader["adh_tipo_monto"].ToString(),
                                    descripcion = reader["tmo_descripcion"].ToString()
                                };
                                oAdhesion.tipoFechaDebito = new TipoFechaDebito()
                                {
                                    codigo = reader["adh_fecha_debito_tipo"].ToString(),
                                    descripcion = reader["fdt_descripcion"].ToString()
                                };
                                oAdhesion.montoDebito = reader["adh_monto"].ToString();
                                oAdhesion.fechaDebito = reader["adh_fecha_debito"].ToString();
                                oAdhesion.diaDebito = reader["adh_dia_debito"].ToString();
                                oAdhesion.tieneStopDebit = Boolean.Parse(reader["adh_tiene_stop_debit"].ToString());
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

            return oAdhesion;
        }
    }
}
