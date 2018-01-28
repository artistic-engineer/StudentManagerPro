using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web;

namespace Models.Ext
{
    public class StudentExt:Student
    {
        public string ClassName { get; set; }
        public string CSharp { get; set; }
        public string SQLServerDB { get; set; }
    }
}
