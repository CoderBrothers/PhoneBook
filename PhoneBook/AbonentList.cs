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
        public int Count => _list.Count;

        public AbonentList()
        {
            _list = new List<Abonent>();
        }
        //перенести проверку сеттера в сеттеры абонента
        //заменить врайтлайн заменить на делегаты/события
        //Добавить сортировку по алфавиту
        public void AddAbonent(Abonent ab)
        {
            if (ab == null || string.IsNullOrWhiteSpace(ab.Name) || string.IsNullOrWhiteSpace(ab.Tel))
            {
                OnMessage?.Invoke("Subscriber cannot be empty, and name and phone number cannot be empty or consist only of spaces.");
                return;
            }
            ab.Id = Count + 1; 
            _list.Add(ab);
            OnMessage?.Invoke($"Abonent added with index {ab.Id}.");
        }

        public List<Abonent> ShowAllAbonents()
        {
            if (_list.Count == 0)
            {
                OnMessage?.Invoke("No abonents in the list.");
            }
            return _list;
        }
        //Переделать Remove
        public void RemoveAbonent(string name, string tel)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(tel))
            {
                OnMessage?.Invoke("You are an idiot: Subscriber cannot be empty, and name and phone number cannot be empty or consist only of spaces.");
                return;
            }

            int indexToRemove = _list.FindIndex(ab => ab.Name == name && ab.Tel == tel);
            if (indexToRemove >= 0)
            {
                _list.RemoveAt(indexToRemove);
                OnMessage?.Invoke("Abonent removed");
                ReassignIndexes();
            }
            else
            {
                OnMessage?.Invoke("Oops - Abonent not found.");
            }
        }

        public List<Abonent> FindAbonentsByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                OnMessage?.Invoke("Oops - Name cannot be empty or contain only spaces.");
                return new List<Abonent>();
            }

            List<Abonent> foundAbonents = new List<Abonent>();
            foreach (Abonent ab in _list)
            {
                if (ab.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
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

            return foundAbonents;
        }
        public void EditAbonent(string oldName, string oldTel, string newName, string newTel)
        {
            if (string.IsNullOrWhiteSpace(oldName) || string.IsNullOrWhiteSpace(oldTel))
            {
                OnMessage?.Invoke("Old name and phone number cannot be empty or consist only of spaces.");
                return;
            }

            var abonent = _list.Find(ab => ab.Name == oldName && ab.Tel == oldTel);

            if (abonent == null)
            {
                OnMessage?.Invoke("Abonent not found.");
                return;
            }

            if (!string.IsNullOrWhiteSpace(newName))
            {
                abonent.Name = newName;
            }

            if (!string.IsNullOrWhiteSpace(newTel))
            {
                abonent.Tel = newTel;
            }

            OnMessage?.Invoke("Abonent details updated.");
        }
        private void ReassignIndexes()
        {
            for (int i = 0; i < _list.Count; i++)
            {
                _list[i].Id = i + 1;
            }
        }
    }
}
