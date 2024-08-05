namespace PhoneBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AbonentList abonentList = new AbonentList();
            abonentList.AddAbonent(new Abonent("Bob", "0"));
            var test = abonentList.ShowAllAbonents();
            foreach (var abonent in test)
            {
                Console.WriteLine(abonent.Name + " " + abonent.Tel);
            }
            abonentList.RemoveAbonent("Bob", "0");
            var test2 = abonentList.ShowAllAbonents();
            foreach (var abonent in test2)
            {
                Console.WriteLine(abonent.Name + " " + abonent.Tel);
            }
        }
    }
}
