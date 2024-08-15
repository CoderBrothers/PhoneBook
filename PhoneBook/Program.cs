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
            Console.WriteLine("\t\tPHONE BOOK");
            Console.WriteLine("_______________________________________________");
            Console.WriteLine("\n1. Add abonent\n2. Delete abonent\n3. Show abonents\n" +
                "4. Search abonent\n5. Edit abonent\n0. Exit\n\n");
            int.TryParse(Console.ReadLine(), out int choice);
            switch (choice) 
            {
                case 0:
                    Console.WriteLine("There will be exit");
                    break;
                case 1: Console.WriteLine("In progress");
                    break;
                case 2:
                    Console.WriteLine("In progress");
                    break;
                case 3:
                    Console.WriteLine("In progress");
                    break;
                case 4:
                    Console.WriteLine("In progress");
                    break;
                case 5:
                    Console.WriteLine("In progress");
                    break;
                default:
                    Console.WriteLine("Incorrect input");
                    break ;
            }

        }
    }
}
