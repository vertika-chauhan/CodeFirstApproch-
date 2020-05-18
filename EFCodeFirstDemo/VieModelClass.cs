using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstDemo
{
    public class VieModelClass
    {

        public Employee employee { get; set; }
        public LevelAsPerDepartment levelAsPerDepartment { get; set; }

        public Department department { get; set; }
    }
}
