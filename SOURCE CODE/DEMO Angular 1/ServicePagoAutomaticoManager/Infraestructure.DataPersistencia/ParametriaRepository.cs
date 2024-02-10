using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Domain;


namespace Infraestructure.DataPersistencia
{
    public interface IParametriaRepository
    {
        List<atb_abm_tabla> buscarTablas(string moduloCod);

    }
    public class ParametriaRepository : AdoRepository, IParametriaRepository
    {
        private SqlConnection _sqlConnection;
        public ParametriaRepository(SqlConnection sqlConnection)
            : base(sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        #region ABM By H. BALCAZAR 

        public List<atb_abm_tabla> buscarTablas(string ModuloCod)
        {
            List<atb_abm_tabla> oTablass = new List<atb_abm_tabla>();
            try
            {
                var parameters = new List<SqlParameter>
                                 {
                                     new SqlParameter { ParameterName = "@ModuloCod", Value = ModuloCod},
                                 };

                using (SqlDataReader reader = ExecuteReader("tm_ABMTabla_Tabla_qry_sp", parameters))
                {
                    while (reader.Read())
                    {
                        oTablass.Add(new atb_abm_tabla
                        {
                            codigo = Utils.Parse.ParseDBValue<string>(reader["atb_cod"]),
                            nombre = Utils.Parse.ParseDBValue<string>(reader["atb_nombre"]),
                            descripcion = Utils.Parse.ParseDBValue<string>(reader["atb_descripcion"]),
                            tabla = Utils.Parse.ParseDBValue<string>(reader["atb_tabla"]),
                            moduloCodigo = Utils.Parse.ParseDBValue<string>(reader["mod_cod"]),
                            permiteAlta = Utils.Parse.ParseDBValue<Boolean>(reader["atb_permite_alta"]),
                            permiteBaja = Utils.Parse.ParseDBValue<Boolean>(reader["atb_permite_baja"])
                        }
                            );
                    }
                }
                return oTablass;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

    }
}

