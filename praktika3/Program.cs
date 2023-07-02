using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace ruslan
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в кафе \"Руслан\" \nЗабронируйте столик!");
            List<Users> users = new List<Users>();
            string Path = "data.csv";
            getData(Path, users);
            printData(users);
            RegUser(Path);
        }

        static void getData(string path, List<Users> L)
        {

            using (StreamReader sr = new StreamReader(path))
            {
                while (sr.EndOfStream != true)
                {
                    string[] array = sr.ReadLine().Split(';');
                    L.Add(new Users()
                    {
                        Surname = array[0],
                        Name = array[1],
                        Kolvo = Convert.ToString(array[2]),
                        Kolvo1 = Convert.ToInt32(array[3]),
                        Phone = Convert.ToString(array[4]),
                        Time = Convert.ToString(array[5]),
                        
                        
                    });
                }
            }
        }
        static void printData(List<Users> L)
        {
            foreach (Users u in L)
            {
                u.show();
            }
        }
        static public void RegUser(string Path)
        {
            
            string Surname = surname();
            string Name = name();
            string Kolvo = kolvo();
            int Kolvo1 = kolvo1();
            string Phone = phone();
            string Time = time();
            using (StreamWriter sr = new StreamWriter(File.Open(Path, FileMode.Append), Encoding.Default))
            {
                sr.Write($"{Surname};");
                sr.Write($"{Name};");
                sr.Write($"{Kolvo};");
                sr.Write($"{Kolvo1};");
                sr.Write($"{Phone};");
                sr.WriteLine($"{Time};");
            }
        }
        static string surname()
        {
            Regex r = new Regex(@"^([А-Я]{1,})([а-я]{1,})$");
            while (true)
            {
                Console.WriteLine("Введите фамилию");
                string Surname = Console.ReadLine();
                if (r.IsMatch(Surname) == true)
                {
                    return Surname;
                    break;
                }
                else
                {
                    Console.WriteLine("введены некорректные данные");
                }
            }
        }
        static string name()
        {
            Regex r1 = new Regex(@"^[А-Я][а-я]{1,}$");
            while (true)
            {
                Console.WriteLine("Введите имя");
                string Name = Console.ReadLine();
                if (r1.IsMatch(Name) == true)
                {
                    return Name;
                    break;
                }
                else
                {
                    Console.WriteLine("введены некорректные данные");
                }
            }
        }
        static string kolvo()
        {
            Regex r1 = new Regex(@"^(1|2|3|4|5|6|7|8|9|10)$");
            while (true)
            {
                Console.WriteLine("Введите номер столика");
                string Gender = Console.ReadLine();
                if (r1.IsMatch(Gender) == true)
                {
                    return Gender;
                    break;
                }
                else
                {
                    Console.WriteLine("введены некорректные данные");
                }
            }
        }
        static int kolvo1()
        {
            while (true)
            {
                Console.WriteLine("Введите количество человек");
                int Age = Convert.ToInt32(Console.ReadLine());
                return Age;
            }
        }
        static string phone()
        {
            Regex r2 = new Regex(@"^8\(9[0-9]{2}\)[0-9]{3}\-[0-9]{2}\-[0-9]{2}$");
            while (true)
            {
                Console.WriteLine("Введите номер телефона");
                string Phone = Console.ReadLine();
                if (r2.IsMatch(Phone) == true)
                {
                    return Phone;
                    break;
                }
                else
                {
                    Console.WriteLine("введены некорректные данные");
                }
            }
        }
        static string time()
        {
            Regex r2 = new Regex(@"[0-9]{2}\:[0-9]{2}");
            while (true)
            {
                Console.WriteLine("Введите время");
                string Time = Console.ReadLine();
                if (r2.IsMatch(Time) == true)
                {
                    return Time;
                    break;
                }
                else
                {
                    Console.WriteLine("введены некорректные данные");
                }
            }
        }

    }
    public struct Users
    {
        public string Surname;
        public string Name;
        public string Kolvo;
        public int Kolvo1;
        public string Phone;
        public string Time;


        public void show()
        {
            Console.WriteLine("{0, -10} {1, -10} {2, -10} {3, -10} {4, -10} {5}", Surname, Name, Kolvo, Kolvo1, Phone, Time);
        }
        public string concat()
        {
            return Surname + ";" + Name + ";" + Kolvo + ";" + Kolvo1 + ';' + Phone + ';' + Time;
        }
    }

}