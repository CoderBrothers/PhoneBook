using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    public class Abonent
    {
        public string Name {  get; set; }
        public string Tel { get; set; }
        public Abonent(string name, string tel) => (Name, Tel) = (name, tel);
    }
}
