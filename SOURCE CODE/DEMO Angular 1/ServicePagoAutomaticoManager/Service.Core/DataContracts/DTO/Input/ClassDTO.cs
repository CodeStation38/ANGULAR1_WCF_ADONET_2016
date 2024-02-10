using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Service.Core
{
    [DataContract(Name = "ClassDTO", Namespace = "Service.Core")]
    public class ClassDTO
    {
         [DataMember]
         public int Id { get; set; }
    }
}