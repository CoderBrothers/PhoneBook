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
                                  "4. Search abonent\n5. Edit abonent\n6. Sort abonents\n0. Exit\n\n");

                var key = Console.ReadKey(intercept: true);
                if (!char.IsDigit(key.KeyChar))
                {
                    Console.WriteLine("\nIncorrect input. Please enter a valid option (0-6).");
                    Console.WriteLine("Press any key to return to the main menu...");
                    Console.ReadKey();
                    continue;
                }

                int choice = key.KeyChar - '0';

                if (choice < 0 || choice > 6)
                {
                    Console.WriteLine("\nIncorrect input. Please select a valid option (0-6).");
                    Console.WriteLine("Press any key to return to the main menu...");
                    Console.ReadKey();
                    continue;
                }

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
                        DeleteAbonent(abonentList);
                        break;
                    case 3:
                        ShowAllAbonents(abonentList);
                        break;
                    case 4:
                        FindAbonents(abonentList);
                        break;
                    case 5:
                        EditAbonent(abonentList);
                        break;
                    case 6:
                        SortAbonents(abonentList);
                        break;
                    default:
                        Console.WriteLine("Incorrect input");
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("\nPress any key to return to the main menu...");
                    Console.ReadKey();
                }
            }
        }

        static void AddAbonent(AbonentList abonentList)
        {
            Console.Clear();
            Console.WriteLine("Add new abonent:");
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Name cannot be empty.");
                return;
            }

            Console.Write("Enter phone: ");
            string phone = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(phone))
            {
                Console.WriteLine("Phone cannot be empty.");
                return;
            }

            abonentList.AddAbonent(new Abonent(name, phone));
        }

        static void DeleteAbonent(AbonentList abonentList)
        {
            Console.Clear();
            Console.Write("Enter name:");
            string name = Console.ReadLine();

            Console.Write("Enter phone number:");
            string tel = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(tel))
            {
                Console.WriteLine("Subscriber cannot be empty, and name and phone number cannot be empty or consist only of spaces.");
                return;
            }

            int indexToRemove = abonentList.ShowAllAbonents().FindIndex(ab => ab.Name == name && ab.Tel == tel);
            abonentList.RemoveAbonent(indexToRemove);
        }

        static void ShowAllAbonents(AbonentList abonentList)
        {
            Console.Clear();
            Console.WriteLine("All abonents:");

            var abonents = abonentList.ShowAllAbonents(); 
            if (abonents.Count == 0)
            {
                Console.WriteLine("No abonents in the list.");
                return;
            }

            foreach (var abonent in abonents)
            {
                Console.WriteLine(abonent.ToString()); 
            }
        }

        static void FindAbonents(AbonentList abonentList)
        {
            Console.Clear();
            Console.WriteLine("Find abonent by name:");
            Console.Write("Enter the name: ");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name) || name.Length < 2)
            {
                Console.WriteLine("Oops - Name cannot be empty or contain only spaces.");
                Console.WriteLine("Please enter at least 2 letters.");
                return;
            }
            name = name.ToLower();
            var abonents = abonentList.FindAbonentsByName(name);
            if (abonents.Count > 0)
            {
                Console.WriteLine("Found Abonents:");
                foreach (var abonent in abonents)
                {
                    Console.WriteLine(abonent.ToString());
                }
            }
            else
            {
                Console.WriteLine("No abonents found with that name.");
            }
        }

        static void EditAbonent(AbonentList abonentList)
        {
            Console.Clear();
            Console.WriteLine("Enter the current name of the abonent you want to edit:");
            string oldName = Console.ReadLine();

            Console.WriteLine("Enter the current phone number of the abonent you want to edit:");
            string oldTel = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(oldName) || string.IsNullOrWhiteSpace(oldTel))
            {
                Console.WriteLine("Old name and phone number cannot be empty or consist only of spaces.");
                return;
            }

            int indexToEdit = abonentList.ShowAllAbonents().FindIndex(ab => ab.Name == oldName && ab.Tel == oldTel);

            if (indexToEdit < 0)
            {
                Console.WriteLine("Abonent not found.");
                return;
            }

            Console.WriteLine("Enter new name (leave empty to keep current):");
            string newName = Console.ReadLine();

            Console.WriteLine("Enter new phone number (leave empty to keep current):");
            string newTel = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(newName) || string.IsNullOrWhiteSpace(newTel))
            {
                Console.WriteLine("Subscriber cannot be empty, and name and phone number cannot be empty or consist only of spaces.");
                return;
            }

            abonentList.EditAbonent(indexToEdit, newName, newTel);
        }

        static void SortAbonents(AbonentList abonentList)
        {
            Console.Clear();
            Console.WriteLine("Sort abonents alphabetically");

            abonentList.SortAbonents();
        }
    }
}
