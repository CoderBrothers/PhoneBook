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
        public void RemoveAbonent(string name, string tel)
        {
            Abonent abonentToRemove = _list.Find(ab => ab.Name == name && ab.Tel == tel);
            if (abonentToRemove != null)
            {
                _list.Remove(abonentToRemove);
                Console.WriteLine("Abonent removed");
            }
            else
            {
                Console.WriteLine("We can not find this abonent");
            }
        }
    }
}
