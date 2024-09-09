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
            ab.Id = Count + 1; 
            _list.Add(ab);
            OnMessage?.Invoke($"Abonent added with index {ab.Id}.");
        }

        public List<Abonent> ShowAllAbonents() => _list;
    
        public void RemoveAbonent(int index)
        {
            if (index >= 0 && index < _list.Count)
            {
                _list.RemoveAt(index);
                OnMessage?.Invoke("Abonent removed.");
                ReassignIndexes(); 
            }
            else
            {
                OnMessage?.Invoke("Invalid index. Abonent not found.");
            }
        }

        public List<Abonent> FindAbonentsByName(string name)
        {
            var foundAbonents = _list
                .Where(ab => ab.Name.StartsWith(name, StringComparison.OrdinalIgnoreCase))
                .OrderBy(ab => ab.Name)
                .ToList();

            return foundAbonents;
        }
        public void EditAbonent(int index, string newName, string newTel)
        {
            if (index >= 0 && index < _list.Count)
            {
                var abonent = _list[index];
                abonent.Name = newName;
                abonent.Tel = newTel;
                OnMessage?.Invoke("Abonent details updated.");
            }
            else
            {
                OnMessage?.Invoke("Invalid index. Abonent not found.");
            }
        }
        public void SortAbonents()
        {
            _list = _list.OrderBy(ab => ab.Name).ToList();
            OnMessage?.Invoke("Abonents sorted alphabetically.");
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
