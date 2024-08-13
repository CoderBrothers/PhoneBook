using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    public class Abonent
    {
        private string _name = "Unknown";
        private string _tel;
        public string Name
        {
            get => _name;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    _name = value;
            }
        }
        public string Tel
        {
            get => _tel;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    _tel = value;
            }
        }
        public Abonent(string name, string tel) => (Name, Tel) = (name, tel);

        public override string ToString() => $"{Name} {Tel}";
        public override bool Equals(object? obj)
        {
            if (obj is Abonent abonent)
            {
                return Name==abonent.Name && Tel==abonent.Tel;
            }
            return false;
        }
    }
}
