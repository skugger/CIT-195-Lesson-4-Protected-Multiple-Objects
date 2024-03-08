using System.ComponentModel.Design;

namespace CIS_195_Lesson_4_Private_Multiple_Objects
{
    class Aircraft
    {
        protected string _manufacturer;
        protected string _engineType;
        protected int _engineCount;
        protected string _gearType;

        public Aircraft()
        {
            _engineCount = 0;
            _engineType = string.Empty;
            _gearType = string.Empty;
            _manufacturer = string.Empty;
        }

        public Aircraft(string mfg, string engineType, int engineCount, string gearType)
        {
            _manufacturer = mfg;
            _engineCount = engineCount;
            _gearType = gearType;
            _engineType = engineType;
        }

        public virtual void addChange()
        {
            Console.Write("Manufacturer =");
            _manufacturer = (Console.ReadLine());
            Console.Write("Engine count =");
            _engineCount = (int.Parse(Console.ReadLine()));
            Console.Write("Engine Type =");
            _engineType = (Console.ReadLine());
            Console.Write("Gear Type =");
            _gearType = ((Console.ReadLine()));
        }
        public virtual void print()
        {
            Console.WriteLine();
            Console.WriteLine($"Manufacturer: {_manufacturer}");
            Console.WriteLine($" Engine Type: {_engineType}");
            Console.WriteLine($"Engine Count: {_engineCount}");
            Console.WriteLine($"Landing Gear: {_gearType}");
        }
    }
    class PassengerJet : Aircraft
    {
        protected int _seatCount;
        protected int _range;
        protected string _airline;

        public PassengerJet()
        {
            _engineCount = 0;
            _engineType = string.Empty;
            _gearType = string.Empty;
            _manufacturer = string.Empty;
            _seatCount = 0;
            _range = 0;
            _airline = string.Empty;
        }

        public PassengerJet(string mfg, string engineType, int engineCount, string gearType, int seatCount, int range, string airline)
            : base(mfg, engineType, engineCount, gearType)
        {
            _manufacturer = mfg;
            _engineCount = engineCount;
            _gearType = gearType;
            _engineType = engineType;
            _seatCount = seatCount;
            _range = range;
            _airline = airline;
        }

        public override void addChange()
        {
            Console.Write("Manufacturer =");
            _manufacturer = (Console.ReadLine());
            Console.Write("Engine count =");
            _engineCount = (int.Parse(Console.ReadLine()));
            Console.Write("Engine Type =");
            _engineType = (Console.ReadLine());
            Console.Write("Gear Type =");
            _gearType = ((Console.ReadLine()));
            Console.Write("Seat count: ");
            _seatCount = (int.Parse(Console.ReadLine()));
            Console.Write("Range: ");
            _range = (int.Parse(Console.ReadLine()));
            Console.Write("Airline name: ");
            _airline = (Console.ReadLine());
        }
        public override void print()
        {
            Console.WriteLine();
            Console.WriteLine($"Manufacturer: {_manufacturer}");
            Console.WriteLine($" Engine Type: {_engineType}");
            Console.WriteLine($"Engine Count: {_engineCount}");
            Console.WriteLine($"Landing Gear: {_gearType}");
            Console.WriteLine($"  Seat count: {_seatCount}");
            Console.WriteLine($"       Range: {_range}");
            Console.WriteLine($"     Airline: {_airline}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int daPlanes;
            Console.WriteLine("How many light aircraft will you be entering?");
            while (!int.TryParse(Console.ReadLine(), out daPlanes))
                Console.WriteLine("Try again, smart guy.");
            Aircraft[] planes = new Aircraft[daPlanes];

            int daHeavies;
            Console.WriteLine("How many passenger jets will you be entering?");
            while (!int.TryParse(Console.ReadLine(), out daHeavies))
                Console.WriteLine("Try again, my friend.");
            PassengerJet[] heavies = new PassengerJet[daHeavies];

            int choice, rec, type;
            int numPlanes = 0, numHeavies = 0;
            choice = Menu();
            while (choice != 4)
            {
                Console.WriteLine("Enter 1 for passenger jet, 2 for light aircraft.");
                while (!int.TryParse(Console.ReadLine(), out type))
                    Console.WriteLine("1 for big plane, 2 for small plane.");

                try
                {
                    switch (choice)
                    {
                        case 1:
                            if (type == 1)
                            {
                                if (numHeavies <= daHeavies)
                                {
                                    heavies[numHeavies] = new PassengerJet();
                                    heavies[numHeavies].addChange();
                                    numHeavies++;
                                }
                                else
                                    Console.WriteLine("you have added all the jets you said you would enter.");
                            }
                            else
                            {
                                if (numPlanes <= daPlanes)
                                {
                                    planes[numPlanes] = new Aircraft();
                                    planes[numPlanes].addChange();
                                    numPlanes++;
                                }
                                else
                                    Console.WriteLine("you have added all the light craft you said you would add.");
                            }
                            break;
                        case 2:
                            Console.Write("Enter which one you want to change: ");
                            while (!int.TryParse(Console.ReadLine(), out rec))
                                Console.Write("Enter which one you want to change: ");
                            rec--;
                            if (type == 1)
                            {
                                while (rec > numHeavies - 1 || rec < 0)
                                {
                                    Console.Write("The number you entered was out of range, try again");
                                    while (!int.TryParse(Console.ReadLine(), out rec))
                                        Console.Write("Enter the record number you want to change: ");
                                    rec--;
                                }
                                heavies[rec].addChange();
                            }
                            else
                            {
                                while (rec > numPlanes - 1 || rec < 0)
                                {
                                    Console.Write("The number you entered was out of range, try again");
                                    while (!int.TryParse(Console.ReadLine(), out rec))
                                        Console.Write("Enter the number you want to change: ");
                                    rec--;
                                }
                                planes[rec].addChange();
                            }
                            break;
                        case 3:
                            if (type == 1)
                            {
                                for (int i = 0; i < numHeavies; i++)
                                    heavies[i].print();
                            }
                            else
                            {
                                for (int i = 0; i < numPlanes; i++)
                                    planes[i].print();
                            }
                            break;
                        default:
                            Console.WriteLine("You made an invalid selection, please try again");
                            break;
                    }
                }


                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                choice = Menu();

            }
        }
        private static int Menu()
        {
            Console.WriteLine("Make a selection: ");
            Console.WriteLine("1-Add  2-Change  3-Print  4-Quit");
            int selection = 0;
            while (selection < 1 || selection > 4)
                while (!int.TryParse(Console.ReadLine(), out selection))
                    Console.WriteLine("1-Add  2-Change  3-Print  4-Quit");
            return selection;
        }
    }
}
