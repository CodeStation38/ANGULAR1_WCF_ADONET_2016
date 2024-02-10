using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class GenericService
    {
        public string asSQLParameter(string parametro)
        {
           return parametro == null ? "%" : parametro;
        }
    }
}
