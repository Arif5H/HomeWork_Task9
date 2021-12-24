using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{   [Serializable]
    class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public uint Age { get; set; }
        public string School { get; set; }
        public string Class { get; set; }

        public override string ToString()
        {
            return $"{Name} \t {Surname} \t {Age}: \t {School} \t {Class}";
        }
    }
}
