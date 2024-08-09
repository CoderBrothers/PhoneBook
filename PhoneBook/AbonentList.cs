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
            if (ab == null || string.IsNullOrWhiteSpace(ab.Name) || string.IsNullOrWhiteSpace(ab.Tel))
            {
                Console.WriteLine("You are an idiot: Subscriber cannot be empty, and name and phone number cannot be empty or consist only of spaces.");
                return;
            }
            _list.Add(ab);
            Console.WriteLine("Abonent added");
        }

        public List<Abonent> ShowAllAbonents()
        {
            if (_list.Count == 0)
            {
                Console.WriteLine("No abonents in the list.");
            }
            return _list;
        }

        public void RemoveAbonent(string name, string tel)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(tel))
            {
                Console.WriteLine("You are an idiot: Subscriber cannot be empty, and name and phone number cannot be empty or consist only of spaces.");
                return;
            }

            Abonent abonentToRemove = _list.Find(ab => ab.Name == name && ab.Tel == tel);
            if (abonentToRemove != null)
            {
                _list.Remove(abonentToRemove);
                Console.WriteLine("Abonent removed");
            }
            else
            {
                Console.WriteLine("Oops - Abonent not found.");
            }
        }

        public void FindAbonentsByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Oops - Name cannot be empty or contain only spaces.");
                return;
            }

            List<Abonent> foundAbonents = new List<Abonent>();
            foreach (Abonent ab in _list)
            {
                if (ab.Name == name)
                {
                    foundAbonents.Add(ab);
                }
            }

            if (foundAbonents.Count > 0)
            {
                Console.WriteLine("Found Abonents:");
                foreach (Abonent ab in foundAbonents)
                {
                    Console.WriteLine($"{ab.Name} - {ab.Tel}");
                }
            }
            else
            {
                Console.WriteLine("No abonents found with that name.");
            }
        }
    }
}
