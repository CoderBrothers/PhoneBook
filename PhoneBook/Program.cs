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
                if (key.Key == ConsoleKey.Escape)
                {
                    continue;
                }
                var input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("\nIncorrect input. Please enter a valid option (0-6).");
                    Console.WriteLine("Press any key to return to the main menu...");
                    Console.ReadKey();
                    continue;
                }

                if (!int.TryParse(input, out int choice) || choice < 0 || choice > 6)
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
            Console.WriteLine("Add new abonent (Press ESC to cancel):");
            Console.Write("Enter name: ");
            string name = ReadInputWithEscape();
            if (name == null) return;

            Console.Write("Enter phone: ");
            string phone = ReadInputWithEscape();
            if (phone == null) return;

            abonentList.AddAbonent(new Abonent(name, phone));
        }

        static void DeleteAbonent(AbonentList abonentList)
        {
            Console.Clear();
            Console.WriteLine("Delete abonent (Press ESC to cancel):");
            Console.Write("Enter name: ");
            string nameToDelete = ReadInputWithEscape();
            if (nameToDelete == null) return;

            Console.Write("Enter phone: ");
            string phoneToDelete = ReadInputWithEscape();
            if (phoneToDelete == null) return;

            abonentList.RemoveAbonent(nameToDelete, phoneToDelete);
        }

        static void ShowAllAbonents(AbonentList abonentList)
        {
            Console.Clear();
            Console.WriteLine("Show all abonents (Press ESC to return):");
            abonentList.ShowAllAbonents();
        }

        static void FindAbonents(AbonentList abonentList)
        {
            Console.Clear();
            Console.WriteLine("Find abonent by name (Press ESC to cancel):");
            Console.Write("Enter the name: ");
            string name = ReadInputWithEscape();
            if (name == null) return;

            abonentList.FindAbonentsByName(name);
        }
        static void EditAbonent(AbonentList abonentList)
        {
            Console.Clear();
            Console.WriteLine("Edit abonent (Press ESC to cancel):");
            Console.Write("Enter old name: ");
            string oldName = ReadInputWithEscape();
            if (oldName == null) return;

            Console.Write("Enter old phone: ");
            string oldPhone = ReadInputWithEscape();
            if (oldPhone == null) return;

            Console.Write("Enter new name: ");
            string newName = ReadInputWithEscape();
            if (newName == null) return;

            Console.Write("Enter new phone: ");
            string newPhone = ReadInputWithEscape();
            if (newPhone == null) return;

            abonentList.EditAbonent(oldName, oldPhone, newName, newPhone);
        }

        static void SortAbonents(AbonentList abonentList)
        {
            Console.Clear();
            Console.WriteLine("Sort abonents alphabetically");

            abonentList.SortAbonents();
        }

        static string ReadInputWithEscape()
        {
            string input = "";
            while (true)
            {
                var key = Console.ReadKey(intercept: true);
                if (key.Key == ConsoleKey.Escape)
                {
                    return null;
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    return input;
                }
                if (key.Key == ConsoleKey.Backspace && input.Length > 0)
                {
                    input = input.Substring(0, input.Length - 1);
                    Console.Write("\b \b");
                }
                else if (!char.IsControl(key.KeyChar))
                {
                    input += key.KeyChar;
                    Console.Write(key.KeyChar);
                }
            }
        }
    }
}
