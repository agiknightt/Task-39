using System;
using System.Linq;
namespace Task_39
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isExit = true;
            Offender[] offenders = {new Offender("Иванов Сергей Валерьевич", true, 175, 70, "Русский"), new Offender("Джон Смит", false, 190, 80, "Американец"),
                new Offender("Генадьев Людвик Аристархович", false, 160, 90, "Русский"), new Offender("Викторов Сергей Анатольевич", true, 175, 70, "Русский"), new Offender("Иванов Андрей Валерьевич", true, 160, 80, "Американец") };

            while (isExit)
            {
                Console.WriteLine("1 - Поиск преступника по базе\n\n2 - выйти из программы\n\n");
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        Console.WriteLine("Введите вес преступника : ");
                        int weight = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Введите рост преступника : ");
                        int height = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Введите национальность преступника : ");
                        string nationality = Console.ReadLine();

                        var newOffenders = from Offender offender in offenders where offender.Height == height && offender.Weight == weight && offender.Nationality.ToUpper() == nationality.ToUpper() && offender.InPrison != true select offender;

                        foreach (var offender in newOffenders)
                        {
                            offender.ShowInfo();
                        }
                        break;
                    case 2:
                        isExit = false;
                        break;
                }
                Console.WriteLine("Для продолжения нажмите любую клавишу...");
                Console.ReadKey();
                Console.Clear();                
            }    
        }
    }
        
    
    class Offender
    {
        public string FullName { get; private set; }
        public bool InPrison { get; private set; }
        public int Height { get; private set; }
        public int Weight { get; private set; }
        public string Nationality { get; private set; }
        public Offender(string fullName, bool inPrison, int height, int weight, string nationality)
        {
            FullName = fullName;
            InPrison = inPrison;
            Height = height;
            Weight = weight;
            Nationality = nationality;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"Полное имя - {FullName}\n\nрост - {Height}\n\nвес - {Weight}\n\nнациональность - {Nationality}");
        }
    }
}
