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

        public event Action<string> OnMessage;

        public AbonentList()
        {
            _list = new List<Abonent>();
        }
        //перенести проверку сеттера в сеттеры абонента
        //заменить врайтлайн заменить на делегаты/события
        public void AddAbonent(Abonent ab)
        {
            if (ab == null || string.IsNullOrWhiteSpace(ab.Name) || string.IsNullOrWhiteSpace(ab.Tel))
            {
                OnMessage?.Invoke("You are an idiot: Subscriber cannot be empty, and name and phone number cannot be empty or consist only of spaces.");
                return;
            }
            _list.Add(ab);
            OnMessage?.Invoke("Abonent added");
        }

        public List<Abonent> ShowAllAbonents()
        {
            if (_list.Count == 0)
            {
                OnMessage?.Invoke("No abonents in the list.");
            }
            return _list;
        }
        //вынети логику из ремув
        public void RemoveAbonent(string name, string tel)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(tel))
            {
                OnMessage?.Invoke("You are an idiot: Subscriber cannot be empty, and name and phone number cannot be empty or consist only of spaces.");
                return;
            }

            Abonent abonentToRemove = _list.Find(ab => ab.Name == name && ab.Tel == tel);
            if (abonentToRemove != null)
            {
                _list.Remove(abonentToRemove);
                OnMessage?.Invoke("Abonent removed");
            }
            else
            {
                OnMessage?.Invoke("Oops - Abonent not found.");
            }
        }

        public void FindAbonentsByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                OnMessage?.Invoke("Oops - Name cannot be empty or contain only spaces.");
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
                OnMessage?.Invoke("Found Abonents:");
                foreach (Abonent ab in foundAbonents)
                {
                    OnMessage?.Invoke($"{ab.Name} - {ab.Tel}");
                }
            }
            else
            {
                OnMessage?.Invoke("No abonents found with that name.");
            }
        }
    }
}
