using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Domain
{
    public class ClienteService : GenericService
    {
        
        public List<Cliente> buscarClientes(string apellido, string nombre, string tipoDocumento, string documento, string cuenta, string tarjeta)
        {
                List<Cliente> oClientes = new List<Cliente>();
                string conn = Properties.Settings.Default.conexionDB.ToString();

                apellido = asSQLParameter(apellido);
                nombre = asSQLParameter(nombre);
                tipoDocumento = asSQLParameter(tipoDocumento);
                documento = asSQLParameter(documento);
                cuenta = asSQLParameter(cuenta);
                tarjeta = asSQLParameter(tarjeta);

                try
                {
                    using (SqlConnection conexion = new SqlConnection(conn))
                    {
                        using (SqlCommand cmd = new SqlCommand("pa_cuentas_qry_sp", conexion))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Apellido", apellido);
                            cmd.Parameters.AddWithValue("@Nombre",nombre);
                            cmd.Parameters.AddWithValue("@TipoDocumento",tipoDocumento);
                            cmd.Parameters.AddWithValue("@Documento",documento);
                            cmd.Parameters.AddWithValue("@CuentaId",cuenta);
                            cmd.Parameters.AddWithValue("@Tarjeta",tarjeta);
                            
                            conexion.Open();
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    Cliente oCliente = new Cliente();

                                    oCliente.id = Int32.Parse(reader["cta_id"].ToString());
                                    oCliente.cuenta = reader["cta_numero_cuenta"].ToString();
                                    oCliente.apellido = reader["cte_apellido"].ToString();
                                    oCliente.nombre = reader["cte_nombre"].ToString();
                                    oCliente.tipoDocumento = reader["cte_tipo_doc"].ToString();
                                    oCliente.documento = reader["cte_documento"].ToString();
                                    oCliente.tarjeta = reader["cte_tarjeta"].ToString();

                                    oClientes.Add(oCliente);
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

                return oClientes;
        }

        public ClienteUnico buscarCliente(Int32 idCliente)
        {
            List<ClienteUnico> oClientes = new List<ClienteUnico>()
            {
            new ClienteUnico {
                id=1,cuenta="0988778",tipoCuenta="Standar",
                fechaCierre="01/02/2018",fechaCierrePosterior="01/03/2018",
                fechaVencimiento="10/02/2018",fechaVencimientoPosterior="10/03/2018",
                situacionCuenta="Buena",situacionMora="Buena",
                apellido="Tulio",nombre="Juan",
                tipoDocumento="DNI",documento="1232363234",email="tuliojuan@gmail.com",
                tarjeta="4111111111111111",tipoTarjeta="VISA"},
            new ClienteUnico {
                id=2,cuenta="453543",tipoCuenta="Standar",
                fechaCierre="01/02/2018",fechaCierrePosterior="01/03/2018",
                fechaVencimiento="10/02/2018",fechaVencimientoPosterior="10/03/2018",
                situacionCuenta="Buena",situacionMora="Buena",
                apellido="Lopez",nombre="Jose",
                tipoDocumento="DNI",documento="1232363234",email="lopezjose@hotmail.com",
                tarjeta="7567651111111111",tipoTarjeta="Fala"}
            };
            return oClientes[idCliente - 1];
            /*
            ClienteUnico oCliente = new ClienteUnico();
            string conn = Properties.Settings.Default.conexionDB.ToString();
            try
            {
                using (SqlConnection conexion = new SqlConnection(conn))
                {
                    using (SqlCommand cmd = new SqlCommand("pa_cliente_unico_qry_sp", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ClienteId", idCliente);

                        conexion.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                oCliente.id = Int32.Parse(reader["adh_id"].ToString());
                                oCliente.cuenta = reader["adh_fecha_alta"].ToString();

                                oCliente.apellido = reader["adh_fecha_alta"].ToString();
                                oCliente.nombre = reader["adh_fecha_alta"].ToString();
                                oCliente.tipoDocumento = reader["adh_fecha_alta"].ToString();
                                oCliente.documento = reader["adh_fecha_alta"].ToString();
                                oCliente.tarjeta = reader["adh_fecha_alta"].ToString();

                                oCliente.tipoCuenta = reader["adh_fecha_alta"].ToString();
                                oCliente.fechaVencimiento = reader["adh_fecha_alta"].ToString();
                                oCliente.fechaCierre = reader["adh_fecha_alta"].ToString();
                                oCliente.fechaVencimientoPosterior = reader["adh_fecha_alta"].ToString();
                                oCliente.fechaCierrePosterior = reader["adh_fecha_alta"].ToString();
                                oCliente.situacionCuenta = reader["adh_fecha_alta"].ToString();
                                oCliente.situacionMora = reader["adh_fecha_alta"].ToString();
                                oCliente.tipoTarjeta = reader["adh_fecha_alta"].ToString();
                                oCliente.email = reader["adh_fecha_alta"].ToString();

                            }
                        }
                    }
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                // loguear error
            }

            return oCliente;*/
        }

        public List<CuentaCliente> buscarCuentas(string idCtaNroCliente)
        {
            List<CuentaCliente> oCuentasCliente = new List<CuentaCliente>();
            string conn = Properties.Settings.Default.conexionDB.ToString();
            try
            {
                using (SqlConnection conexion = new SqlConnection(conn))
                {
                    using (SqlCommand cmd = new SqlCommand("pa_cuentasexistentes_qry_sp", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CtaNro", idCtaNroCliente);
                        conexion.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CuentaCliente oCuentaCliente = new CuentaCliente();
                                oCuentaCliente.CbuTitular = reader["adh_cbu_titular"].ToString();
                                oCuentaCliente.CbuNumero = reader["adh_cbu_numero"].ToString();
                                oCuentaCliente.banco = new Banco()
                                {
                                    codigo = reader["adh_cbu_banco"].ToString(),
                                    descripcion = reader["bco_descripcion"].ToString()
                                };
                                oCuentaCliente.CbuTitularCuit = reader["adh_cbu_titular_cuit"].ToString();
                                oCuentasCliente.Add(oCuentaCliente);
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
            return oCuentasCliente;

        }

        public CuentaCliente buscarCuentaSegunAdhesion(string idAdhesion) {
            
            CuentaCliente oCuentaCliente = new CuentaCliente();
            string conn = Properties.Settings.Default.conexionDB.ToString();
            try
            {
                using (SqlConnection conexion = new SqlConnection(conn))
                {
                    using (SqlCommand cmd = new SqlCommand("pa_cuentabancaria_by_adhesion_qry_sp", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@AdhesionId", idAdhesion);
                        conexion.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                oCuentaCliente.CbuTitular = reader["adh_cbu_titular"].ToString();
                                oCuentaCliente.CbuNumero = reader["adh_cbu_numero"].ToString();
                                
                                oCuentaCliente.mismoTitular = Boolean.Parse(reader["adh_Titular_CMR_es_titular_cbu"].ToString());
                                oCuentaCliente.banco = new Banco()
                                {
                                    codigo = reader["adh_cbu_banco"].ToString(),
                                    descripcion = reader["bco_descripcion"].ToString()
                                };
                                oCuentaCliente.tipoCuenta = reader["adh_cbu_tipo_cuenta"].ToString();
                                
                                oCuentaCliente.CbuTitularCuit = reader["adh_cbu_titular_cuit"].ToString();
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

            return oCuentaCliente;
        }

        public int buscarAdhesionVigenteRecurrente(string ctaClienteNro)
        {
            int hayAdhesionVigenteRecurrente = 0;
            string conn = Properties.Settings.Default.conexionDB.ToString();
            try
            {
                using (SqlConnection conexion = new SqlConnection(conn))
                {
                    using (SqlCommand cmd = new SqlCommand("pa_adhesvigrec_qry_sp", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@AdhesionCuenta", ctaClienteNro);
                        conexion.Open();
                        hayAdhesionVigenteRecurrente = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;// loguear error
            }
            return hayAdhesionVigenteRecurrente;
        }

        public DatosFechaDebitoPorVencimiento buscarFechaDebitoPorVencimiento(string clienteFDeb)
        {
            DatosFechaDebitoPorVencimiento oDatosFechaDebitoPorVencimiento = new DatosFechaDebitoPorVencimiento();
            string conn = Properties.Settings.Default.conexionDB.ToString();
            try
            {
                using (SqlConnection conexion = new SqlConnection(conn))
                {
                    using (SqlCommand cmd = new SqlCommand("pa_calcularFechaDebitoPorVencimiento_qry_sp", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@fechaDebitoCliente", clienteFDeb);
                        conexion.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            oDatosFechaDebitoPorVencimiento.FechaDebito = reader["FechaDebito"].ToString();
                            oDatosFechaDebitoPorVencimiento.EntraMesSiguiente = Convert.ToInt32(reader["EntraMesSiguiente"].ToString());
                        }
                    }
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;// loguear error
            }
            return oDatosFechaDebitoPorVencimiento;
        }

    }
}
