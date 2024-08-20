//Создайте приложение "Телефонная книга".
//Необходимо хранить данные об абоненте (ФИО, домашний телефон, рабочий телефон, мобильный телефон, дополнительная информация о контакте)
//внутри соответствующего класса. Наполните класс переменными-членами, функциями-членами, конструкторами.
//Предоставьте пользователю возможность добавлять новых абонентов, удалять абонентов, искать абонентов по ФИО, показывать всех абонентов.



namespace PhoneBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var abonentList = new AbonentList();
            abonentList.OnMessage += Console.WriteLine;
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("\t\tPHONE BOOK");
                Console.WriteLine("_______________________________________________");
                Console.WriteLine("\n1. Add abonent\n2. Delete abonent\n3. Show abonents\n" +
                                  "4. Search abonent\n5. Edit abonent\n0. Exit\n\n");

                int.TryParse(Console.ReadLine(), out int choice);
                switch (choice)
                {
                    case 0:
                        exit = true;
                        Console.WriteLine("Exit");
                        break;
                    case 1:
                        AddAbonent(abonentList);
                        break;
                    case 2:
                        RemoveAbonent(abonentList);
                        break;
                    case 3:
                        ShowAbonents(abonentList);
                        break;
                    case 4:
                        SearchAbonent(abonentList);
                        break;
                    case 5:
                        EditAbonent(abonentList);
                        break;
                    default:
                        Console.WriteLine("Incorrect input");
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("\nPress any key to return to the menu");
                    Console.ReadKey();
                }
            }
        }

        static void AddAbonent(AbonentList abonentList)
        {
            Console.WriteLine("Enter name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter phone number:");
            string tel = Console.ReadLine();

            var abonent = new Abonent(name, tel);
            abonentList.AddAbonent(abonent);
        }

        static void RemoveAbonent(AbonentList abonentList)
        {
            Console.WriteLine("Enter name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter phone number:");
            string tel = Console.ReadLine();

            abonentList.RemoveAbonent(name, tel);
        }

        static void ShowAbonents(AbonentList abonentList)
        {
            var abonents = abonentList.ShowAllAbonents();
            if (abonents.Count > 0)
            {
                foreach (var abonent in abonents)
                {
                    Console.WriteLine(abonent);
                }
            }
        }

        static void SearchAbonent(AbonentList abonentList)
        {
            Console.WriteLine("Enter name to search:");
            string name = Console.ReadLine();
            abonentList.FindAbonentsByName(name);
        }

        static void EditAbonent(AbonentList abonentList)
        {
            Console.WriteLine("Enter the current name of the abonent you want to edit:");
            string oldName = Console.ReadLine();

            Console.WriteLine("Enter the current phone number of the abonent you want to edit:");
            string oldTel = Console.ReadLine();

            Console.WriteLine("Enter new name (leave empty to keep current):");
            string newName = Console.ReadLine();

            Console.WriteLine("Enter new phone number (leave empty to keep current):");
            string newTel = Console.ReadLine();

            abonentList.EditAbonent(oldName, oldTel, newName, newTel);
        }
    }
}
