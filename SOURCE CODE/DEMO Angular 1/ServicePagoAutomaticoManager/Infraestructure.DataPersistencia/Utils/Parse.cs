using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infraestructure.DataPersistencia.Utils
{
    public class Parse
    {
        public static T ParseDBValue<T>(object value)
        {
            if (value == null || value == DBNull.Value)
            {
                return default(T);
            }
            else
            {
                return (T)Convert.ChangeType(value, typeof(T));
            }
        }

        public static bool IsNumber(object obj)
        {
            try
            {
                Convert.ToInt64(obj);

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
