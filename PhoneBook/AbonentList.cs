using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    public class AbonentList
    {
        private List<Abonent> _list;
        public AbonentList() 
        {
            _list = new List<Abonent>();
        }
        
        public void AddAbonent(Abonent ab)
        {
            _list.Add(ab);
            Console.WriteLine("Abonent added");
        }
        public List<Abonent> ShowAllAbonents() => _list;
    }
}
