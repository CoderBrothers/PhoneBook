namespace PhoneBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Мы умеем выводить абонента
            AbonentList abonentList = new AbonentList();
            abonentList.AddAbonent(new Abonent("Bob", "0"));
            abonentList.AddAbonent(new Abonent("Foo", "1"));
            abonentList.AddAbonent(new Abonent("Bob", "2"));
            abonentList.AddAbonent(new Abonent("Bob", "3"));
            abonentList.AddAbonent(new Abonent("Jack", "2"));
            var test = abonentList.ShowAllAbonents();
            foreach (var abonent in test)
            {
                Console.WriteLine(abonent.Name + " " + abonent.Tel);
            }
            abonentList.RemoveAbonent("Bob", "34");
            var test2 = abonentList.ShowAllAbonents();
            foreach (var abonent in test2)
            {
                Console.WriteLine(abonent.Name + " " + abonent.Tel);
            }
            abonentList.FindAbonentsByName("  ");
        }
    }
}
