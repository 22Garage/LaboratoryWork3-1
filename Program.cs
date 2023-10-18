
using System.Diagnostics;
using System.Reflection;
using System.Threading.Channels;
using System.Linq;

namespace Лаба_по_проге_1
{
    interface IEventController
    {
        void sell(int number); // продать что-нибудь
        void announceDogmat(); // оглашение догмата
        void scaleArea(float multiplier); // масштабировать площадь
    } // интерфейс

    abstract class ReligionBuildings: IEventController
    {
        // свойства абстрактного класса
        public abstract string Name { get; set; } // название постройки
        public abstract int DateOfFound { get; set; } // дата постройки
        public abstract string City { get; set; } // город
        public abstract string Street { get; set; } // улица
        public abstract double Area { get; set; } // площадь
        public abstract int AvailableSpaces { get; set; } // количество мест
        public abstract double Budget { get; set; } // бюджет

        // метод абстрактного класса
        public abstract void printName(); // вывод имени класса
        public abstract string toString(int number);
        public abstract string toString(double number);
        public abstract void sell(int number);
        public abstract void announceDogmat();
        public abstract void scaleArea(float multiplier);
    } // абстрактный класс
    sealed class Sinagogue : ReligionBuildings
    {
        // объявляем поле класса
        private const string phrase = "Шалом, Братья и Сёстры!"; // традиционная фраза

        // свойство класса
        public double PriceOfMaza { get; } // цена за мацу

        // свойства абстрактоного класса
        public override string Name { get; set; }
        public override int DateOfFound { get; set; }
        public override string City { get; set; }
        public override string Street { get; set; }
        public override double Area { get; set; }
        public override int AvailableSpaces { get; set; }
        public override double Budget { get; set; }

        // конструкторы класса
        public Sinagogue() // по умолчанию
        {
            Name = "Big Sinagogue";
            DateOfFound = 1878;
            City = "Brussel";
            Street = "Rue de la Regence";
            Area = 1200;
            AvailableSpaces = 2000;
            PriceOfMaza = 3;
            Budget = 0;
        }
        public Sinagogue(string name, int date, double area, int spaces, double price) // без адреса
        {
            Name = name;
            DateOfFound = date;
            City = "UNNWN";
            Street = "UNNWN";
            Area = area;
            AvailableSpaces = spaces;
            PriceOfMaza = price;
            Budget = 0;
        }
        public Sinagogue(string name, int date, string city, string street, double area, int spaces,
            double price) // полная информация
        {
            Name = name;
            DateOfFound = date;
            City = city;
            Street = street;
            Area = area;
            AvailableSpaces = spaces;
            PriceOfMaza = price;
            Budget = 0;
        }
        public Sinagogue(ReligionBuildings srcB) // конструктор копирования
        {
            this.Name = srcB.Name;
            this.DateOfFound = srcB.DateOfFound;
            this.City = srcB.City;
            this.Street = srcB.Street;
            this.Area = srcB.Area;
            this.AvailableSpaces = srcB.AvailableSpaces;
            PriceOfMaza = 3;
            this.Budget = srcB.Budget;
        }

        // методы класса
        public static void arrangeCeremony()
        {
            Console.WriteLine("Ceremony has been arranged successfully! Jews are happy!");
        } // проведение церемонии
        public override void sell(int number)
        {
            Budget += PriceOfMaza * number;
            Console.WriteLine($"SUCCSESS! You've sold {number} maza for {PriceOfMaza * number} euros");
            Console.WriteLine($"Your new budget is {Budget} euros");
        } // продать мацу
        public override void scaleArea(float multiplier)
        {
            Area *= multiplier;
            Console.WriteLine($"Building\'s new area is {Area}");
        } // масштабировать площадь
        public override void announceDogmat()
        {
            Console.WriteLine(phrase);
        } // огласить догмат
        public override void printName()
        {
            Console.Write("This class is deriaved class. It's name ");
            Console.Write(this.GetType().Name);
            Console.Write(". The base class is called ");
            Console.Write(base.GetType().Name);
        } // вывод имени класса
        public override string toString(int number)
        {
            return number.ToString();
        } // метод toString с перегрузкой
        public override string toString(double number)
        {
            return number.ToString();
        } // метод toString с перегрузкой

        // перегрузка оператора !
        public static Cathedral operator !(Sinagogue sin)
        {
            Cathedral cathedral = new Cathedral();
            cathedral.Name = "The new Cathedral";
            cathedral.DateOfFound = sin.DateOfFound;
            cathedral.City = "Moscow";
            cathedral.Street = "Red Square";
            cathedral.Area = sin.Area;
            cathedral.AvailableSpaces = sin.AvailableSpaces;
            cathedral.PriceOfCandle = 0.5;
            return cathedral;
        }

        // перегрузка арифметического оператора
        public static Sinagogue operator +(Sinagogue sin1, Sinagogue sin2)
        {
            Sinagogue sinagogue = new Sinagogue();
            sinagogue.Name = $"{sin1.GetType().Name} and {sin2.GetType().Name}";
            sinagogue.DateOfFound = 2023;
            sinagogue.City = sin1.City;
            sinagogue.Street = sin2.Street;
            sinagogue.Area = sin1.Area + sin2.Area;
            sinagogue.AvailableSpaces = sin1.AvailableSpaces + sin2.AvailableSpaces;
            return sinagogue;
        }

    } // синагога

    sealed class Church : ReligionBuildings
    {
        // объявляем поле класса
        private const string phrase = "Аминь"; // традиционная фраза

        // свойство класса
        public double PriceOfCandle { get; } // цена за свечку

        // свойства абстрактоного класса
        public override string Name { get; set; }
        public override int DateOfFound { get; set; }
        public override string City { get; set; }
        public override string Street { get; set; }
        public override double Area { get; set; }
        public override int AvailableSpaces { get; set; }
        public override double Budget { get; set; }

        // конструкторы класса
        public Church() // по умолчанию
        {
            Name = "The Church of the Ascension";
            DateOfFound = 1530;
            City = "Moscow";
            Street = "Kolomenskoye";
            Area = 1200;
            AvailableSpaces = 2000;
            PriceOfCandle = 0.5;
            Budget = 0;
        }
        public Church(string name, int date, double area, int spaces, double price) // без адреса
        {
            Name = name;
            DateOfFound = date;
            City = "UNNWN";
            Street = "UNNWN";
            Area = area;
            AvailableSpaces = spaces;
            PriceOfCandle = price;
            Budget = 0;
        }
        public Church(string name, int date, string city, string street, double area, int spaces,
            double price) // полная информация
        {
            Name = name;
            DateOfFound = date;
            City = city;
            Street = street;
            Area = area;
            AvailableSpaces = spaces;
            PriceOfCandle = price;
            Budget = 0;
        }
        public Church(ReligionBuildings srcB) // конструктор копирования
        {
            this.Name = srcB.Name;
            this.DateOfFound = srcB.DateOfFound;
            this.City = srcB.City;
            this.Street = srcB.Street;
            this.Area = srcB.Area;
            this.AvailableSpaces = srcB.AvailableSpaces;
            PriceOfCandle = 0.5;
            this.Budget = srcB.Budget;
        }

        // методы класса
        public static void arrangeCeremony()
        {
            Console.WriteLine("Ceremony has been arranged successfully! Christians are happy!");
        } // проведение церемонии
        public override void sell(int number)
        {
            Budget += PriceOfCandle * number;
            Console.WriteLine($"SUCCSESS! You've sold {number} candles for {PriceOfCandle * number} euros");
            Console.WriteLine($"Your new budget is {Budget} euros");
        } // продать свечи
        public override void scaleArea(float multiplier)
        {
            Area *= multiplier;
            Console.WriteLine($"Building\'s new area is {Area}");
        } // масштабировать площадь
        public override void announceDogmat()
        {
            Console.WriteLine(phrase);
        } // огласить догмат
        public override void printName()
        {
            Console.Write("This class is deriaved class. It's name ");
            Console.Write(this.GetType().Name);
            Console.Write(". The base class is called ");
            Console.Write(base.GetType().Name);
        } // вывод имени класса
        public override string toString(int number)
        {
            return number.ToString();
        } // метод toString с перегрузкой
        public override string toString(double number)
        {
            return number.ToString();
        } // метод toString с перегрузкой

        // перегрузка арифметического оператора
        public static Church operator +(Church sin1, Church sin2)
        {
            Church sinagogue = new Church();
            sinagogue.DateOfFound = 2023;
            sinagogue.City = sin1.City;
            sinagogue.Street = sin2.Street;
            sinagogue.Area = sin1.Area + sin2.Area;
            sinagogue.AvailableSpaces = sin1.AvailableSpaces + sin2.AvailableSpaces;
            return sinagogue;
        }

    } // церковь

    sealed class Mosque : ReligionBuildings
    {
        // объявляем поле класса
        private const string phrase = "Извинись, дон"; // традиционная фраза

        // свойство класса
        public double PriceOfCarpet { get; } // цена за коврик

        // свойства абстрактоного класса
        public override string Name { get; set; }
        public override int DateOfFound { get; set; }
        public override string City { get; set; }
        public override string Street { get; set; }
        public override double Area { get; set; }
        public override int AvailableSpaces { get; set; }
        public override double Budget { get; set; }

        // конструкторы класса
        public Mosque() // по умолчанию
        {
            Name = "Taj Mahal";
            DateOfFound = 1640;
            City = "Agra";
            Street = "Yamuna River";
            Area = 170000;
            AvailableSpaces = 10000;
            PriceOfCarpet = 5;
            Budget = 0;
        }
        public Mosque(string name, int date, double area, int spaces, double price) // без адреса
        {
            Name = name;
            DateOfFound = date;
            City = "UNNWN";
            Street = "UNNWN";
            Area = area;
            AvailableSpaces = spaces;
            PriceOfCarpet = price;
            Budget = 0;
        }
        public Mosque(string name, int date, string city, string street, double area, int spaces,
            double price) // полная информация
        {
            Name = name;
            DateOfFound = date;
            City = city;
            Street = street;
            Area = area;
            AvailableSpaces = spaces;
            PriceOfCarpet = price;
            Budget = 0;
        }
        public Mosque(ReligionBuildings srcB) // конструктор копирования
        {
            this.Name = srcB.Name;
            this.DateOfFound = srcB.DateOfFound;
            this.City = srcB.City;
            this.Street = srcB.Street;
            this.Area = srcB.Area;
            this.AvailableSpaces = srcB.AvailableSpaces;
            PriceOfCarpet = 5;
            this.Budget = srcB.Budget;
        }

        // методы класса
        public static void arrangeCeremony()
        {
            Console.WriteLine("Ceremony has been arranged successfully! Muslims are happy!");
        } // проведение церемонии
        public override void sell(int number)
        {
            Budget += PriceOfCarpet * number;
            Console.WriteLine($"SUCCSESS! You've sold {number} carpet for {PriceOfCarpet * number} euros");
            Console.WriteLine($"Your new budget is {Budget} euros");
        } // продать коврик
        public override void scaleArea(float multiplier)
        {
            Area *= multiplier;
            Console.WriteLine($"Building\'s new area is {Area}");
        } // масштабировать площадь
        public override void announceDogmat()
        {
            Console.WriteLine(phrase);
        } // огласить догмат
        public override void printName()
        {
            Console.Write("This class is deriaved class. It's name ");
            Console.Write(this.GetType().Name);
            Console.Write(". The base class is called ");
            Console.Write(base.GetType().Name);
        } // вывод имени класса
        public override string toString(int number)
        {
            return number.ToString();
        } // метод toString с перегрузкой
        public override string toString(double number)
        {
            return number.ToString();
        } // метод toString с перегрузкой

        // перегрузка оператора !
        public static Cathedral operator !(Mosque sin)
        {
            Cathedral cathedral = new Cathedral();
            cathedral.Name = "The new Cathedral";
            cathedral.DateOfFound = sin.DateOfFound;
            cathedral.City = "Moscow";
            cathedral.Street = "Red Square";
            cathedral.Area = sin.Area;
            cathedral.AvailableSpaces = sin.AvailableSpaces;
            cathedral.PriceOfCandle = 0.5;
            return cathedral;
        }

        // перегрузка арифметического оператора
        public static Mosque operator +(Mosque sin1, Mosque sin2)
        {
            Mosque sinagogue = new Mosque();
            sinagogue.Name = $"{sin1.GetType().Name} and {sin2.GetType().Name}";
            sinagogue.DateOfFound = 2023;
            sinagogue.City = sin1.City;
            sinagogue.Street = sin2.Street;
            sinagogue.Area = sin1.Area + sin2.Area;
            sinagogue.AvailableSpaces = sin1.AvailableSpaces + sin2.AvailableSpaces;
            return sinagogue;
        }
    } // мечеть

    sealed class Cathedral : ReligionBuildings
    {
        // объявляем поле класса
        private const string phrase = "Аминь"; // традиционная фраза

        // свойство класса
        public double PriceOfCandle { get; set; } // цена за свечку

        // свойства абстрактоного класса
        public override string Name { get; set; }
        public override int DateOfFound { get; set; }
        public override string City { get; set; }
        public override string Street { get; set; }
        public override double Area { get; set; }
        public override int AvailableSpaces { get; set; }
        public override double Budget { get; set; }

        // конструкторы класса
        public Cathedral() // по умолчанию
        {
            Name = "Notre-Dame de-Paris";
            DateOfFound = 1163;
            City = "Paris";
            Street = "Parvis de Notre-Dame";
            Area = 1200;
            AvailableSpaces = 1000;
            PriceOfCandle = 0.5;
            Budget = 0;
        }
        public Cathedral(string name, int date, double area, int spaces, double price) // без адреса
        {
            Name = name;
            DateOfFound = date;
            City = "UNNWN";
            Street = "UNNWN";
            Area = area;
            AvailableSpaces = spaces;
            PriceOfCandle = price;
            Budget = 0;
        }
        public Cathedral(string name, int date, string city, string street, double area, int spaces,
            double price) // полная информация
        {
            Name = name;
            DateOfFound = date;
            City = city;
            Street = street;
            Area = area;
            AvailableSpaces = spaces;
            PriceOfCandle = price;
            Budget = 0;
        }
        public Cathedral(ReligionBuildings srcB) // конструктор копирования
        {
            this.Name = srcB.Name;
            this.DateOfFound = srcB.DateOfFound;
            this.City = srcB.City;
            this.Street = srcB.Street;
            this.Area = srcB.Area;
            this.AvailableSpaces = srcB.AvailableSpaces;
            PriceOfCandle = 3;
            this.Budget = srcB.Budget;
        }

        // методы класса
        public static void arrangeCeremony()
        {
            Console.WriteLine("Ceremony has been arranged successfully! Christians are happy!");
        } // проведение церемонии
        public override void sell(int number)
        {
            Budget += PriceOfCandle * number;
            Console.WriteLine($"SUCCSESS! You've sold {number} candles for {PriceOfCandle * number} euros");
            Console.WriteLine($"Your new budget is {Budget} euros");
        } // продать свечи
        public override void scaleArea(float multiplier)
        {
            Area *= multiplier;
            Console.WriteLine($"Building\'s new area is {Area}");
        } // масштабировать площадь
        public override void announceDogmat()
        {
            Console.WriteLine(phrase);
        } // огласить догмат
        public override void printName()
        {
            Console.Write("This class is deriaved class. It's name ");
            Console.Write(this.GetType().Name);
            Console.Write(". The base class is called ");
            Console.Write(base.GetType().Name);
        } // вывод имени класса
        public override string toString(int number)
        {
            return number.ToString();
        } // метод toString с перегрузкой
        public override string toString(double number)
        {
            return number.ToString();
        } // метод toString с перегрузкой

        // перегрузка арифметического оператора
        public static Cathedral operator +(Cathedral sin1, Cathedral sin2)
        {
            Cathedral sinagogue = new Cathedral();
            sinagogue.DateOfFound = 2023;
            sinagogue.City = sin1.City;
            sinagogue.Street = sin2.Street;
            sinagogue.Area = sin1.Area + sin2.Area;
            sinagogue.AvailableSpaces = sin1.AvailableSpaces + sin2.AvailableSpaces;
            return sinagogue;
        }
    } // собор

    class TeaCeremony : IEventController
    {
        // свойства класса
        public string Name { get; set; }
        public int NumberOfPeople { get; set; }
        public double Area { get; set; }
        private const string phrase = "Let's celebrate and suck some tea";

        // конструктор класса
        public TeaCeremony()
        {
            Random rand = new Random();
            Name = "BLA BLA BLA";
            NumberOfPeople = rand.Next();
            Area = rand.NextDouble();
        }

        // методы класса
        public static void arrangeCeremony()
        {
            Console.WriteLine("Ceremony is good, but cup of tea is better!");
        }
        public void sell(int number)
        {
            Console.WriteLine($"You have sold {number} cups of tea!");
        }
        public void announceDogmat()
        {
            Console.WriteLine(phrase);
        }
        public void scaleArea(float multiplier)
        {
            Area *= multiplier;
            Console.WriteLine($"Ceremony\'s new area is {Area}");
        }
    } // чайная церемония

    class Program
    {
        static void Main()
        {
            List<ReligionBuildings> listOfBuildings = new List<ReligionBuildings>();
            List<TeaCeremony> listOfTeaCeremonies = new List<TeaCeremony>();
            bool programmeIsRunning = true;
            bool buildingLoop = true;
            bool fisrtProgrammeIsRunning = false;
            bool secondProgrammeIsRunning = false;
            bool thirdProgrammeIsRunning = false;
            while (programmeIsRunning)
            {
                Console.Clear();
                printMenu(0);
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        fisrtProgrammeIsRunning = true;
                        Sinagogue sin = new Sinagogue();
                        bool isWasChanged = false;
                        while (fisrtProgrammeIsRunning)
                        {
                            Console.Clear();
                            printMenu(2);
                            switch (Console.ReadKey().Key)
                            {
                                case ConsoleKey.B:
                                    bool building = true;
                                    while (building)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Choose an option");
                                        Console.WriteLine("Press 1 to build a classic building");
                                        Console.WriteLine("Press 2 to build a building without an adress");
                                        Console.WriteLine("Press 3 to build a building with your own data");
                                        switch (Console.ReadKey().Key)
                                        {
                                            case ConsoleKey.D1:
                                                Console.Clear();
                                                Console.WriteLine("Press any button to go back");
                                                Console.WriteLine();
                                                Console.WriteLine("Classic version of building was created✅");
                                                Console.ReadKey();
                                                building = false;
                                                listOfBuildings.Add(new Sinagogue());
                                                isWasChanged = true;
                                                break;
                                            case ConsoleKey.D2:
                                                Console.Clear();
                                                Console.WriteLine("Okey. Enter the name of the building⬇️");
                                                string name = getData();
                                                Console.WriteLine("Got it!. Enter the year of found");
                                                int date = getYear(Console.ReadLine());
                                                Console.WriteLine("Enter the area of the building");
                                                double area = getArea(Console.ReadLine());
                                                Console.WriteLine("Print the number of the available places");
                                                int places = getPlaces(Console.ReadLine());
                                                Console.WriteLine("The last one! Print the price for a product");
                                                double price = getPrice(Console.ReadLine());
                                                listOfBuildings.Add(new Sinagogue(name, date, area, places, price));
                                                Console.Clear();
                                                Console.WriteLine("Press any button to go back");
                                                Console.WriteLine();
                                                Console.WriteLine("Building was created✅");
                                                Console.ReadKey();
                                                isWasChanged = true;
                                                building = false;
                                                break;
                                            case ConsoleKey.D3:
                                                Console.Clear();
                                                Console.WriteLine("Okey. Enter the name of the building⬇️");
                                                string name1 = getData();
                                                Console.WriteLine("Got it!. Enter the year of found");
                                                int date1 = getYear(Console.ReadLine());
                                                Console.WriteLine("Enter the city️");
                                                string city1 = getData();
                                                Console.WriteLine("Enter the street");
                                                string street1 = getData();
                                                Console.WriteLine("Enter the area of the building");
                                                double area1 = getArea(Console.ReadLine());
                                                Console.WriteLine("Print the number of the available places");
                                                int places1 = getPlaces(Console.ReadLine());
                                                Console.WriteLine("The last one! Print the price for a product");
                                                double price1 = getPrice(Console.ReadLine());
                                                listOfBuildings.Add(new Sinagogue(name1, date1, city1, street1, area1,
                                                    places1,
                                                    price1));

                                                Console.Clear();
                                                Console.WriteLine("Press any button to go back");
                                                Console.WriteLine();
                                                Console.WriteLine("Building was created✅");
                                                Console.ReadKey();
                                                isWasChanged = true;
                                                building = false;
                                                break;
                                        }
                                    }

                                    break;
                                case ConsoleKey.I:
                                    if (isWasChanged)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Press any button to go back");
                                        Console.WriteLine();
                                        showDataBuilding(listOfBuildings.FindLast(item =>
                                            item.GetType().Name == "Sinagogue"));
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Press any button to go back");
                                        Console.WriteLine();
                                        Console.WriteLine("You have not created any buildings");
                                        Console.ReadKey();
                                    }

                                    break;
                                case ConsoleKey.D1:
                                    Console.Clear();
                                    Console.WriteLine("Press any button to go back");
                                    Console.WriteLine();
                                    Sinagogue.arrangeCeremony();
                                    Console.ReadKey();
                                    break;
                                case ConsoleKey.D2:
                                    if (isWasChanged)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Print the number of products to sell");
                                        bool loop1 = true;
                                        while (loop1)
                                        {
                                            if (int.TryParse(Console.ReadLine(), out int pN))
                                            {
                                                Console.Clear();
                                                if (pN > 0 && pN < int.MaxValue)
                                                {
                                                    Console.WriteLine("Press any button to go back");
                                                    Console.WriteLine();
                                                    listOfBuildings.FindLast(item => item.GetType().Name == "Sinagogue")
                                                        ?.sell(pN);
                                                    Console.ReadKey();
                                                    loop1 = false;
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Print the correct number of products to sell");
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Press any button to go back");
                                        Console.WriteLine();
                                        Console.WriteLine("You have not created any buildings");
                                        Console.ReadKey();
                                    }

                                    break;
                                case ConsoleKey.D3:
                                    if (isWasChanged)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Press any button to go back");
                                        Console.WriteLine();
                                        sin.announceDogmat();
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Press any button to go back");
                                        Console.WriteLine();
                                        Console.WriteLine("You have not created any buildings");
                                        Console.ReadKey();
                                    }

                                    break;
                                case ConsoleKey.D4:
                                    if (isWasChanged)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Print the multiplier");
                                        bool loop2 = true;
                                        while (loop2)
                                        {
                                            if (float.TryParse(Console.ReadLine(), out float pN))
                                            {
                                                Console.Clear();
                                                if (pN > 0 && pN < float.MaxValue)
                                                {
                                                    Console.WriteLine("Press any button to go back");
                                                    Console.WriteLine();
                                                    listOfBuildings.FindLast(item => item.GetType().Name == "Sinagogue")
                                                        ?.scaleArea(pN);
                                                    Console.ReadKey();
                                                    loop2 = false;
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Print the correct number of the multiplier");
                                            }
                                        } 
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Press any button to go back");
                                        Console.WriteLine();
                                        Console.WriteLine("You have not created any buildings");
                                        Console.ReadKey();
                                    }
                                    

                                    break;
                                case ConsoleKey.E:
                                    fisrtProgrammeIsRunning = false;
                                    break;
                            }
                        }
                        break;
                    case ConsoleKey.D2:
                        secondProgrammeIsRunning = true;
                        while (secondProgrammeIsRunning)
                        {
                            Console.Clear();
                            printMenu(4);
                            switch (Console.ReadKey().Key)
                            {
                                case ConsoleKey.B:
                                    buildingLoop = true;
                                    while (buildingLoop)
                                    {
                                        Console.Clear();
                                        printTypes(2);
                                        switch (Console.ReadKey().Key)
                                        {
                                            case ConsoleKey.D1:
                                                listOfBuildings.Add(getDataOfBuilding(1));
                                                break;
                                            case ConsoleKey.D2:
                                                listOfBuildings.Add(getDataOfBuilding(2));
                                                break;
                                            case ConsoleKey.D3:
                                                listOfBuildings.Add(getDataOfBuilding(3));
                                                break;
                                            case ConsoleKey.D4:
                                                listOfBuildings.Add(getDataOfBuilding(4));
                                                break;
                                            case ConsoleKey.B:
                                                buildingLoop = false;
                                                break;
                                        }
                                    }

                                    break;
                                case ConsoleKey.C:
                                    Console.Clear();
                                    actionWithBuildings(listOfBuildings, listOfTeaCeremonies);
                                    break;
                                case ConsoleKey.E:
                                    secondProgrammeIsRunning = false;
                                    Console.Clear();
                                    break;
                            }
                        }
                        break;
                    case ConsoleKey.D3:
                        thirdProgrammeIsRunning = true;
                        while (thirdProgrammeIsRunning)
                        {
                            Console.Clear();
                            printMenu(1);
                            switch (Console.ReadKey().Key)
                            {
                                case ConsoleKey.B:
                                    buildingLoop = true;
                                    while (buildingLoop)
                                    {
                                        Console.Clear();
                                        printTypes(3);
                                        switch (Console.ReadKey().Key)
                                        {
                                            case ConsoleKey.D1:
                                                listOfBuildings.Add(getDataOfBuilding(1));
                                                break;
                                            case ConsoleKey.D2:
                                                listOfBuildings.Add(getDataOfBuilding(2));
                                                break;
                                            case ConsoleKey.D3:
                                                listOfBuildings.Add(getDataOfBuilding(3));
                                                break;
                                            case ConsoleKey.D4:
                                                listOfBuildings.Add(getDataOfBuilding(4));
                                                break;
                                            case ConsoleKey.D5:
                                                Console.Clear();
                                                Console.WriteLine("Press any button to go back");
                                                Console.WriteLine();
                                                Console.WriteLine("The ceremony was arranged!");
                                                listOfTeaCeremonies.Add(new TeaCeremony());
                                                Console.ReadKey();
                                                break;
                                            case ConsoleKey.B:
                                                buildingLoop = false;
                                                break;
                                        }
                                    }
                                    break;
                                case ConsoleKey.C:
                                    Console.Clear();
                                    actionWithBuildings(listOfBuildings, listOfTeaCeremonies);
                                    break;
                                case ConsoleKey.I:
                                    List<IEventController> iList = new List<IEventController>();
                                    foreach (var obj in listOfBuildings)
                                    {
                                        switch (obj.GetType().Name)
                                        {
                                            case "Cathedral":
                                                iList.Add(new Cathedral(obj));
                                                break;
                                            case "Church":
                                                iList.Add(new Church(obj));
                                                break;
                                            case "Sinagogue":
                                                iList.Add(new Sinagogue(obj));
                                                break;
                                            case "Mosque":
                                                iList.Add(new Mosque(obj));
                                                break;
                                        }
                                    }

                                    foreach (var obj in listOfTeaCeremonies)
                                    {
                                        iList.Add(new TeaCeremony());
                                    }

                                    bool loop = true;
                                    while (loop)
                                    {
                                        Console.Clear();
                                        Console.WriteLine(
                                            "Choose an implemented method to run it with all implemented classes");
                                        Console.WriteLine();
                                        Console.WriteLine("Press 1 to announce dogmat");
                                        Console.WriteLine("Press 2 to sell 10 products");
                                        Console.WriteLine("Press 3 to scale area in 3 times");
                                        Console.WriteLine("Press B to go back");
                                        switch (Console.ReadKey().Key)
                                        {
                                            case ConsoleKey.D1:
                                                Console.Clear();
                                                Console.WriteLine("Press any button to go back");
                                                Console.WriteLine();
                                                foreach (var obj in iList)
                                                {
                                                    IMethod(1, obj);
                                                }

                                                Console.ReadKey();
                                                break;
                                            case ConsoleKey.D2:
                                                Console.Clear();
                                                Console.WriteLine("Press any button to go back");
                                                Console.WriteLine();
                                                foreach (var obj in iList)
                                                {
                                                    IMethod(2, obj);
                                                }

                                                Console.ReadKey();
                                                break;
                                            case ConsoleKey.D3:
                                                Console.Clear();
                                                Console.WriteLine("Press any button to go back");
                                                Console.WriteLine();
                                                foreach (var obj in iList)
                                                {
                                                    IMethod(3, obj);
                                                }

                                                Console.ReadKey();
                                                break;
                                            case ConsoleKey.B:
                                                loop = false;
                                                break;
                                        }
                                    }

                                    break;
                                case ConsoleKey.A:
                                    showAllMethod(listOfBuildings, listOfTeaCeremonies);
                                    Console.ReadKey();
                                    break;
                                case ConsoleKey.E:
                                    thirdProgrammeIsRunning = false;
                                    Console.Clear();
                                    break;
                            }
                        }

                        break;
                    case ConsoleKey.E:
                        programmeIsRunning = false;
                        break;
                }
            }


        }
        static void printMenu(int number)
        {
            Console.WriteLine("Choose an option");
            Console.WriteLine();
            switch (number)
            {
                case 0:
                    Console.WriteLine("Press 1 to run the first programme");
                    Console.WriteLine("Press 2 to run the second programme");
                    Console.WriteLine("Press 3 to run the third programme");
                    Console.WriteLine("Press E to exit the programme");
                    break;
                case 1:
                    Console.WriteLine("Press B to build something");
                    Console.WriteLine("Press C to choose a building");
                    Console.WriteLine("Press I to run implemented interface method");
                    Console.WriteLine("Press A to show all classes");
                    Console.WriteLine("Press E to exit the third programme");
                    break;
                case 2:
                    Console.WriteLine("Print B to build a sinagogue");
                    Console.WriteLine("Print I to get info about sinagogues");
                    Console.WriteLine("Print 1 to run static method - arrange ceremony");
                    Console.WriteLine("Print 2 to sell something");
                    Console.WriteLine("Print 3 to announce dogmat");
                    Console.WriteLine("Print 4 to scale area");
                    Console.WriteLine("Print E to exit the first programme");
                    break;
                case 4:
                    Console.WriteLine("Press B to build something");
                    Console.WriteLine("Press C to choose a building");
                    Console.WriteLine("Press E to exit the second programme");
                    break;
            }
        } // вывод основного меню
        static string getData()
        {
            string? data = Console.ReadLine();
            data = checkIsNull(data);
            while (data == "UNNWN")
            {
                Console.WriteLine("Please, enter correct data");
                data = checkIsNull(Console.ReadLine());
            }

            return data;
        } // считывание строчной информации
        static string checkIsNull(string str)
        {
            if (!string.IsNullOrWhiteSpace(str))
            {
                return str;
            }
            else
            {
                return "UNNWN";
            }
        } // проверка строки на полноту
        static int getPlaces(string? places)
        {
            places = checkIsNull(places);
            while (true)
            {
                if (int.TryParse(places, out int intPlaces))
                {
                    if (intPlaces > 0 && intPlaces < int.MaxValue)
                    {
                        return intPlaces;
                    }
                    else
                    {
                        Console.WriteLine("Please, print the correct places");
                        places = Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Please, print the correct places");
                    places = Console.ReadLine();
                }
            }
        } // считывание мест
        static int getYear(string? year)
        {
            year = checkIsNull(year);
            while (true)
            {
                if (int.TryParse(year, out int intYear))
                {
                    if (intYear > 0 && intYear < 2024)
                    {
                        return intYear;
                    }
                    else
                    {
                        Console.WriteLine("Please, print the correct year");
                        year = Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Please, print the correct year");
                    year = Console.ReadLine();
                }
            }
        } // считывание года
        static double getArea(string? data)
        {
            data = checkIsNull(data);
            while (true)
            {
                if (double.TryParse(data, out double doubleData))
                {
                    if (doubleData > 0 && doubleData < Double.MaxValue)
                    {
                        return doubleData;
                        
                    }
                    else
                    {
                        Console.WriteLine("Please, print the correct data");
                        data = Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Please, print the correct data");
                    data = Console.ReadLine();
                }
            }
        } // считывание площади
        static double getPrice(string? data)
        {
            data = checkIsNull(data);
            while (true)
            {
                if (double.TryParse(data, out double doubleData))
                {
                    if (doubleData > 0 && doubleData < Double.MaxValue)
                    {
                        return doubleData;
                    }
                    else
                    {
                        Console.WriteLine("Please, print the correct data");
                        data = Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Please, print the correct data");
                    data = Console.ReadLine();
                }
            }
        } // считывание цены
        static void actionWithBuildings(List<ReligionBuildings> buildingList, List<TeaCeremony> teaList)
        {
            int i = 0;
            bool loopIsActive = true;
            bool isBuildingList = true;
            bool isBEmpty = false;
            bool isTEmpty = false;
            ConsoleKey key;
            if (buildingList.Count == 0)
            {
                isBEmpty = true;
            }
            if (teaList.Count == 0)
            {
                isTEmpty = true;
            }
            while (loopIsActive)
            {
                Console.Clear();
                Console.WriteLine("Press < or > to see different buildings. Press B to go back");
                Console.WriteLine();
                if (isBuildingList)
                {
                    Console.WriteLine($"Type: {buildingList[i].GetType()} Name: {buildingList[i].Name}");
                }
                else
                {
                    Console.WriteLine($"Type: {teaList[i].GetType()} Name: {teaList[i].Name}");
                }
                
                Console.WriteLine("Press I to get info");
                Console.WriteLine("Press M to run methods");
                key = Console.ReadKey().Key;
                if (key == ConsoleKey.RightArrow)
                {
                    i++;
                    if (i > buildingList.Count - 1 && isBuildingList && !isTEmpty)
                    {
                        i = 0;
                        isBuildingList = false;
                    }else if (i > buildingList.Count - 1 && isBuildingList && isTEmpty)
                    {
                        i = 0;
                        isBuildingList = true;
                    }else if (i > teaList.Count - 1 && !isBuildingList && !isBEmpty)
                    {
                        i = 0;
                        isBuildingList = true;
                    }else if (i > teaList.Count - 1 && !isBuildingList && isBEmpty)
                    {
                        i = 0;
                        isBuildingList = false;
                    }
                }
                else if (key == ConsoleKey.LeftArrow)
                {
                    i--;
                    if (i < 0 && isBuildingList && !isTEmpty)
                    {
                        i = teaList.Count - 1;
                        isBuildingList = false;
                    }else if (i < 0 && isBuildingList && isTEmpty)
                    {
                        i = buildingList.Count - 1;
                        isBuildingList = true;
                    }else if (i < 0 && !isBuildingList && !isBEmpty)
                    {
                        i = buildingList.Count - 1;
                        isBuildingList = true;
                    }else if (i < 0 && !isBuildingList && isBEmpty)
                    {
                        i = teaList.Count - 1;
                        isBuildingList = false;
                    }
                }
                else if (key == ConsoleKey.I)
                {
                    Console.Clear();
                    Console.WriteLine("Press B to go back");
                    Console.WriteLine();
                    if (isBuildingList)
                    {
                        showDataBuilding(buildingList[i]);
                    }
                    else
                    {
                        showDataTeaCeremony(teaList[i]);
                    }
                    while (Console.ReadKey().Key != ConsoleKey.B)
                    {
                    }
                }
                else if (key == ConsoleKey.M)
                {
                    if (isBuildingList)
                    {
                        bool loop = true;
                        while (loop)
                        {
                            Console.Clear();
                            Console.WriteLine("Choose an option");
                            Console.WriteLine();
                            showMethodsBuilding(buildingList[i]);
                            loop = runMethods(teaList, buildingList, buildingList[i]);
                        }
                    }
                    else
                    {
                        bool loop = true;
                        while (loop)
                        {
                            Console.Clear();
                            Console.WriteLine("Choose an option");
                            Console.WriteLine();
                            showMethodsTeaCeremony(teaList[i]);
                            ReligionBuildings temp = new Cathedral();
                            temp.DateOfFound = 228777;
                            loop = runMethods(teaList, buildingList, temp, teaList[i]);
                        }
                    }
                }
                else if (key == ConsoleKey.B)
                {
                    loopIsActive = false;
                }

            }

        } // открыть лист объектов
        static void showDataBuilding(ReligionBuildings building)
        {
            Console.WriteLine($"Type: {building.GetType()}");
            Console.WriteLine($"Name: {building.Name}");
            Console.WriteLine($"Date of found: {building.toString(building.DateOfFound)}");
            Console.WriteLine($"City: {building.City}");
            Console.WriteLine($"Street: {building.Street}");
            Console.WriteLine($"Area: {building.toString(building.Area)}");
            Console.WriteLine($"Available places: {building.AvailableSpaces}");
            Console.WriteLine($"Current budget: {building.Budget} $");
        } // показать информацию о текущем здании
        static void showDataTeaCeremony(TeaCeremony ceremony)
        {
            Console.WriteLine($"Type: {ceremony.GetType()}");
            Console.WriteLine($"Name: {ceremony.Name}");
            Console.WriteLine($"Number of people: {ceremony.NumberOfPeople}");
            Console.WriteLine($"Area: {ceremony.Area}");
        } // показать информацию о текущей церемонии
        static void printTypes(int number)
        {
            switch (number)
            {
                case 2:
                    Console.WriteLine("Press 1 to build a sinagogue");
                    Console.WriteLine("Press 2 to build a church");
                    Console.WriteLine("Press 3 to build a cathedral");
                    Console.WriteLine("Press 4 to build a mosque");
                    Console.WriteLine("Press B to go back");
                    break;
                case 3:
                    Console.WriteLine("Press 1 to build a sinagogue");
                    Console.WriteLine("Press 2 to build a church");
                    Console.WriteLine("Press 3 to build a cathedral");
                    Console.WriteLine("Press 4 to build a mosque");
                    Console.WriteLine("Press 5 to arrange a tea ceremony");
                    Console.WriteLine("Press B to go back");
                    break;
            }
        } // выводит типы зданий
        static ReligionBuildings getDataOfBuilding(int number)
        {
            bool loopIsActive = true;
            while (loopIsActive)
            {
                Console.Clear();
                Console.WriteLine("Choose an option");
                Console.WriteLine("Press 1 to build a classic building");
                Console.WriteLine("Press 2 to build a building without an adress");
                Console.WriteLine("Press 3 to build a building with your own data");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        Console.WriteLine("Press any button to go back");
                        Console.WriteLine();
                        Console.WriteLine("Classic version of building was created✅");
                        Console.ReadKey();
                        loopIsActive = false;
                        switch (number)
                        {
                            case 1:
                                return new Sinagogue();
                            case 2:
                                return new Church();
                            case 3:
                                return new Cathedral();
                            case 4:
                                return new Mosque();
                        }
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        Console.WriteLine("Okey. Enter the name of the building⬇️");
                        string name = getData();
                        Console.WriteLine("Got it!. Enter the year of found");
                        int date = getYear(Console.ReadLine());
                        Console.WriteLine("Enter the area of the building");
                        double area = getArea(Console.ReadLine());
                        Console.WriteLine("Print the number of the available places");
                        int places = getPlaces(Console.ReadLine());
                        Console.WriteLine("The last one! Print the price for a product");
                        double price = getPrice(Console.ReadLine());
                        switch (number)
                        {
                            case 1:
                                return new Sinagogue(name, date, area, places, price);
                            case 2:
                                return new Church(name, date, area, places, price);
                            case 3:
                                return new Cathedral(name, date, area, places, price);
                            case 4:
                                return new Mosque(name, date, area, places, price);
                        }
                        Console.Clear();
                        Console.WriteLine("Press any button to go back");
                        Console.WriteLine();
                        Console.WriteLine("Building was created✅");
                        Console.ReadKey();
                        loopIsActive = false;
                        break;
                    case ConsoleKey.D3:
                        Console.Clear();
                        Console.WriteLine("Okey. Enter the name of the building⬇️");
                        string name1 = getData();
                        Console.WriteLine("Got it!. Enter the year of found");
                        int date1 = getYear(Console.ReadLine());
                        Console.WriteLine("Enter the city️");
                        string city1 = getData();
                        Console.WriteLine("Enter the street");
                        string street1 = getData();
                        Console.WriteLine("Enter the area of the building");
                        double area1 = getArea(Console.ReadLine());
                        Console.WriteLine("Print the number of the available places");
                        int places1 = getPlaces(Console.ReadLine());
                        Console.WriteLine("The last one! Print the price for a product");
                        double price1 = getPrice(Console.ReadLine());
                        switch (number)
                        {
                            case 1:
                                return new Sinagogue(name1, date1, city1, street1, area1, places1,
                                    price1);
                            case 2:
                                return new Church(name1, date1, city1, street1, area1, places1,
                                    price1);
                            case 3:
                                return new Cathedral(name1, date1, city1, street1, area1, places1,
                                    price1);
                            case 4:
                                return new Mosque(name1, date1, city1, street1, area1, places1,
                                    price1);
                        }
                        Console.Clear();
                        Console.WriteLine("Press any button to go back");
                        Console.WriteLine();
                        Console.WriteLine("Building was created✅");
                        Console.ReadKey();
                        loopIsActive = false;
                        break;
                }
            }

            return new Church();
        } // обработка информации о здании
        static void showMethodsBuilding(ReligionBuildings building)
        {
            Cathedral cathedral = new Cathedral();
            Church church = new Church();
            if (Object.ReferenceEquals(building.GetType(), cathedral.GetType()) || Object.ReferenceEquals(building.GetType(), church.GetType()))
            {
                Console.WriteLine($"Type: {building.GetType()} Name: {building.Name}");
                Console.WriteLine("Press 1 to arrange ceremony(static method)");
                Console.WriteLine("Press 2 to announce dogmat");
                Console.WriteLine("Press 3 to sell products");
                Console.WriteLine("Press 4 to scale area");
                Console.WriteLine("Press 5 to combine two buildings(+ overload)");
                Console.WriteLine("Press B to go back");
            }
            else
            {
                Console.WriteLine($"Type: {building.GetType()} Name: {building.Name}");
                Console.WriteLine("Press 1 to arrange ceremony(static method)");
                Console.WriteLine("Press 2 to announce dogmat");
                Console.WriteLine("Press 3 to sell products");
                Console.WriteLine("Press 4 to scale area");
                Console.WriteLine("Press 5 to combine two buildings(+ overload)");
                Console.WriteLine("Press 6 to move building to Russia(! overload)");
                Console.WriteLine("Press B to go back");
            }
        } // показывает методы конкретного здания
        static void showMethodsTeaCeremony(TeaCeremony ceremony)
        {
            Console.WriteLine($"Type: {ceremony.GetType()} Name: {ceremony.Name}");
            Console.WriteLine("Press 1 to arrange ceremony(static method)");
            Console.WriteLine("Press 2 to announce dogmat");
            Console.WriteLine("Press 3 to sell products");
            Console.WriteLine("Press 4 to scale area");
        } // показывает методы церемонии
        static bool runMethods(List<TeaCeremony> listT, List<ReligionBuildings> list,ReligionBuildings building, TeaCeremony ceremony = null)
        {
            ConsoleKey key = Console.ReadKey().Key;
            Console.Clear();
            if (building.DateOfFound != 228777)
            {
                switch (key)
                {
                    case ConsoleKey.B:
                        return false;
                    case ConsoleKey.D1:
                        switch (building.GetType().Name)
                        {
                            case "Cathedral":
                                Console.WriteLine("Press any button to go back");
                                Console.WriteLine();
                                Cathedral.arrangeCeremony();
                                Console.ReadKey();
                                break;
                            case "Church":
                                Console.WriteLine("Press any button to go back");
                                Console.WriteLine();
                                Church.arrangeCeremony();
                                break;
                            case "Sinagogue":
                                Console.WriteLine("Press any button to go back");
                                Console.WriteLine();
                                Sinagogue.arrangeCeremony();
                                break;
                            case "Mosque":
                                Console.WriteLine("Press any button to go back");
                                Console.WriteLine();
                                Mosque.arrangeCeremony();
                                Console.ReadKey();
                                break;
                        }
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine("Press any button to go back");
                        Console.WriteLine();
                        building.announceDogmat();
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D4:
                        Console.Clear();
                        Console.WriteLine("Print the multiplier for the area");
                        bool loop = true;
                        while (loop)
                        {
                            if (float.TryParse(Console.ReadLine(), out float m))
                            {
                                Console.Clear();
                                if (m > 0 && m < float.MaxValue)
                                {
                                    Console.WriteLine("Press any button to go back");
                                    Console.WriteLine();
                                    building.scaleArea(m);
                                    Console.ReadKey();
                                    loop = false;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Print the correct multiplier");
                            }
                        }
                        break;
                    case ConsoleKey.D3:
                        Console.Clear();
                        Console.WriteLine("Print the number of products to sell");
                        bool loop1 = true;
                        while (loop1)
                        {
                            if (int.TryParse(Console.ReadLine(), out int pN))
                            {
                                Console.Clear();
                                if (pN > 0 && pN < int.MaxValue)
                                {
                                    Console.WriteLine("Press any button to go back");
                                    Console.WriteLine();
                                    building.sell(pN);
                                    Console.ReadKey();
                                    loop1 = false;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Print the correct number of products to sell");
                            }
                        }

                        break;
                    case ConsoleKey.D5:
                        Console.Clear();
                        int i = 0;
                        foreach (var b in list)
                        {
                            if (b.GetType().Name == building.GetType().Name)
                            {
                                i++;
                            }   
                        }
                        if (i <= 1)
                        {
                            Console.WriteLine("Press any button to go back");
                            Console.WriteLine();
                            Console.WriteLine("You have few buildings in the list to combine with!");
                            Console.ReadKey();
                            break;
                        }

                        ReligionBuildings buildingToCombine = showBuildings(list, building);
                        if (buildingToCombine.Name == "NO" || building.Name == buildingToCombine.Name)
                        {
                            Console.WriteLine("Press any button to go back");
                            Console.WriteLine();
                            Console.WriteLine("Error. You cannot do it!");
                            Console.ReadKey();
                            break;
                        }

                        switch (building.GetType().Name)
                        {
                            case "Cathedral":
                                Cathedral cathedral = new Cathedral(building) + new Cathedral(buildingToCombine);
                                list.Add(cathedral);
                                break;
                            case "Church":
                                Church church = new Church(building) + new Church(buildingToCombine);
                                list.Add(church);
                                break;
                            case "Mosque":
                                Mosque mosque = new Mosque(building) + new Mosque(buildingToCombine);
                                list.Add(mosque);
                                break;
                            case "Sinagogue":
                                Sinagogue sinagogue = new Sinagogue(building) + new Sinagogue(buildingToCombine);
                                list.Add(sinagogue);
                                break;
                        }
                        Console.Clear();
                        Console.WriteLine("Press any button to go back");
                        Console.WriteLine();
                        Console.WriteLine("HOOORAY! Buildings were combined!");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D6:
                        if (building.GetType().Name == "Cathedral" || building.GetType().Name == "Church")
                        {
                            Console.Clear();
                            Console.WriteLine("Press any button to go back");
                            Console.WriteLine();
                            Console.WriteLine("You can't transfer this object to Russia as its soul has already been in Russia🇷🇺");
                            Console.ReadKey();
                            break;
                        }
                        switch (building.GetType().Name)
                        {
                            case "Mosque":
                                Cathedral mosque = !new Mosque(building);
                                list.Remove(list.Find(item => item.Name == building.Name && item.AvailableSpaces == building.AvailableSpaces && item.DateOfFound == building.DateOfFound) ?? throw new InvalidOperationException());
                                list.Add(mosque);
                                Console.Clear();
                                Console.WriteLine("Press any button to go back");
                                Console.WriteLine();
                                Console.WriteLine("Mosque was moved to Moscow(haha)");
                                Console.ReadKey();
                                break;
                            case "Sinagogue":
                                Cathedral sinagogue = !new Sinagogue(building);
                                list.Remove(list.Find(item => item.Name == building.Name && item.AvailableSpaces == building.AvailableSpaces && item.DateOfFound == building.DateOfFound) ?? throw new InvalidOperationException());
                                list.Add(sinagogue);
                                Console.WriteLine("Press any button to go back");
                                Console.WriteLine();
                                Console.WriteLine("Sinagogue was moved to Russia");
                                Console.ReadKey();
                                break;
                        }
                        break;
                }
            }
            else
            {
                switch (key)
                {
                    case ConsoleKey.B:
                        return false;
                    case ConsoleKey.D1:
                        Console.Clear();
                        Console.WriteLine("Press any button to go back");
                        Console.WriteLine();
                        TeaCeremony.arrangeCeremony();
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        Console.WriteLine("Press any button to go back");
                        Console.WriteLine();
                        ceremony.announceDogmat();
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D3:
                        Console.WriteLine("Print the number of products to sell");
                        bool loop1 = true;
                        while (loop1)
                        {
                            if (int.TryParse(Console.ReadLine(), out int m))
                            {
                                Console.Clear();
                                Console.WriteLine("Press any button to go back");
                                Console.WriteLine();
                                ceremony.sell(m);
                                Console.ReadKey();
                                loop1 = false;
                            }
                            else
                            {
                                Console.WriteLine("Print the correct number of products to sell");
                            }
                        }

                        break;
                    case ConsoleKey.D4:
                        Console.WriteLine("Print the multiplier for the area");
                        bool loop = true;
                        while (loop)
                        {
                            if (float.TryParse(Console.ReadLine(), out float m))
                            {
                                Console.Clear();
                                Console.WriteLine("Press any button to go back");
                                Console.WriteLine();
                                ceremony.scaleArea(m);
                                Console.ReadKey();
                                loop = false;
                            }
                            else
                            {
                                Console.WriteLine("Print the correct multiplier");
                            }
                        }
                        break;
                }
            }

            return false;

        } // выполняет методы
        static ReligionBuildings showBuildings(List<ReligionBuildings> list, ReligionBuildings building)
        {
            bool loopIsActive = true;
            int i = 0;
            ConsoleKey key;
            while (loopIsActive)
            {
                if (list[i].GetType().Name != building.GetType().Name)
                {
                    i++;
                    break;
                }

                Console.Clear();
                Console.WriteLine("Press < or > to see different buildings. Press B to go back");
                Console.WriteLine();
                Console.WriteLine($"Type: {list[i].GetType()} Name: {list[i].Name}");
                Console.WriteLine("Press C to choose building");
                key = Console.ReadKey().Key;
                if (key == ConsoleKey.RightArrow)
                {
                    i++;
                    if (i > list.Count - 1)
                    {
                        i = 0;
                    }
                }
                else if (key == ConsoleKey.LeftArrow)
                {
                    i--;
                    if (i < 0)
                    {
                        i = list.Count - 1;
                    }
                }
                else if (key == ConsoleKey.C)
                {
                    return list[i];
                }
                else if (key == ConsoleKey.B)
                {
                    loopIsActive = false;
                }
            }

            return new Cathedral("NO", 777, 1000, 2000, 1000);
        } // показать строения
        static void IMethod(int i, IEventController obj)
        {
            Console.Write($"Type: {obj.GetType().Name}\t\t");
            switch (i)
            {
                case  1:
                    obj.announceDogmat();
                    break;
                case 2:
                    obj.sell(10);
                    break;
                case 3:
                    obj.scaleArea(3);
                    break;
            }
        } // выполняет методы интерфейса
        static void showAllMethod(List<ReligionBuildings> listRB, List<TeaCeremony> listTC)
        {
            Console.Clear();
            Console.WriteLine("Religion buildings:");
            foreach (var obj in listRB)
            {
                Console.WriteLine($"Type: {obj.GetType().Name} Name: {obj.Name}");
            }
            Console.WriteLine();
            Console.WriteLine("Tea ceremonies:");
            foreach (var obj in listTC)
            {
                Console.WriteLine($"Type: {obj.GetType().Name} Name: {obj.Name}");
            }

            Console.WriteLine();
            Console.WriteLine("Press any button to go back");
        }

    }
    
}