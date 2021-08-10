using System;
using System.Collections.Generic;

namespace Lab5_2UsedCarLot
{
    class Program
    {
        static void Main(string[] args)
        {
            // CREATING A LIST OF NEW AND USED CARS
            List<Car> myList = new List<Car>();
            Car c = new NewCar(CarMake.Toyota, "Rav4", 2018, 24000m, true);
            myList.Add(c);
            c = new NewCar(CarMake.Honda, "Accord", 2021, 19500m, false);
            myList.Add(c);
            c = new NewCar(CarMake.Mercedes, "S Class", 2021, 109800m, true);
            myList.Add(c);
            c = new UsedCar(CarMake.Tesla, "Model X", 2015, 30000m, 2, 120000);
            myList.Add(c);
            c = new UsedCar(CarMake.Mazda, "Mazda3", 2010, 15700m, 3, 204000);
            myList.Add(c);
            c = new UsedCar(CarMake.Nissan, "Altima", 2005, 3500, 3, 415000);
            myList.Add(c);

            while(true)
            {
                Console.WriteLine("Welcome to the DevBuild Car Lot! Feel free to browse our inventory below:");
                foreach (Car _car in myList)
                {
                    Console.WriteLine(_car);
                }

                Console.WriteLine("\nPlease enter one of the following options:\n'A' to add a car to the inventory\n'P' to purchase a car\n'Q' to quit");
                string choice = Console.ReadLine().ToUpper();

                switch (choice)
                {
                    case "A":
                        AddCar(myList);
                        break;
                    case "P":
                        RemoveCar(myList);
                        break;
                    case "Q":
                        Console.WriteLine("Good Bye!");
                        return;
                }
            }
            
        }

        static void AddCar(List<Car> existingInventory)
        {
            // Variables
            CarMake make = CarMake.Toyota;
            string model = "";
            int year = 0;
            decimal price = 0.0m;
            bool extendedWarranty = false;
            int numberOfOwners = 0;
            int mileage = 0;

            Console.Write("New or Used? ");
            string input = Console.ReadLine().ToUpper();

            Console.WriteLine("\nPlease choose from the following Makes:\n1.  Ford\n2.  Chevrolet\n3.  Chrysler\n4.  Honda\n5.  Toyota\n6.  Nissan\n7.  Mazda\n8.  Mercedes\n9.  Hyundai\n10. Tesla\n11. Audi\n12. Rivian");
            int input2 = Int32.Parse(Console.ReadLine());
            input2 -= 1;
            make = (CarMake)input2;

            Console.Write("What is the model? ");
            model = Console.ReadLine();

            Console.Write("What is the year? ");
            year = Int32.Parse(Console.ReadLine());

            Console.Write("What is the price? ");
            price = Decimal.Parse(Console.ReadLine());

            if (input == "NEW")
            {
                Console.Write("Does it have an extended warranty? Enter 'Yes' or 'No': ");
                input = Console.ReadLine().ToUpper();

                if (input == "YES")
                {
                    extendedWarranty = true;
                }

                Car _car = new NewCar(make, model, year, price, extendedWarranty);
                existingInventory.Add(_car);

                Console.WriteLine("Your car has been added to the inventory!");
            }
            else if (input == "USED")
            {
                Console.Write("How many owners has your car had? ");
                numberOfOwners = Int32.Parse(Console.ReadLine());

                Console.Write("What is your car's mileage? ");
                mileage = Int32.Parse(Console.ReadLine());

                Car _car = new UsedCar(make, model, year, price, numberOfOwners, mileage);
                existingInventory.Add(_car);

                Console.WriteLine("Your car has been added to the inventory!");
            }
            else
            {
                Console.WriteLine("Not a valid input!");
            }
        }

        static void RemoveCar(List<Car> existingInventory)
        {
            bool inIventory = false;
            Car selectedCar = null;

            while (!inIventory)
            {
                Console.Write("Enter the model of the car you would like to purchase: ");
                string model = Console.ReadLine();

                foreach (Car _car in existingInventory)
                {
                    if (_car.GetModel() == model)
                    {
                        selectedCar = _car;
                        inIventory = true;
                        break;
                    }
                }

                if (!inIventory)
                {
                    Console.WriteLine($"{model} is not in our inventory!");
                }                
            }

            Console.WriteLine("Congrats on your purchase!");
            existingInventory.Remove(selectedCar);
        }
    }

    class Car
    {
        // FIELDS
        protected CarMake Make;
        protected string Model;
        protected int Year;
        protected decimal Price;

        // CONSTRUCTORS
        public Car(CarMake _make, string _model, int _year, decimal _price)
        {
            Make = _make;
            Model = _model;
            Year = _year;
            Price = _price;
        }

        // GETTERS AND SETTERS
        public string GetModel()
        {
            return Model;
        }
    }

    class NewCar : Car
    {
        // FIELDS
        protected bool ExtendedWarranty;
        
        // CONSTRUCTORS
        public NewCar(CarMake _make, string _model, int _year, decimal _price, bool _extendedWarranty) : base(_make, _model, _year, _price)
        {
            ExtendedWarranty = _extendedWarranty;
        }

        // METHODS
        public override string ToString()
        {
            if (ExtendedWarranty)
            {
                return $"\n{Year} {Make} {Model}\n--------------------------\n  Price: ${Price}\n  Extended Warranty: Yes";
            }
            else
            {
                return $"\n{Year} {Make} {Model}\n--------------------------\n  Price: ${Price}\n  Extended Warranty: No";
            }
        }
    }

    class UsedCar : Car
    {
        // FIELDS
        protected int NumberOfOwners;
        protected int Mileage;

        // CONSTRUCTORS
        public UsedCar(CarMake _make, string _model, int _year, decimal _price, int _numberOfOwners, int _mileage) : base(_make, _model, _year, _price)
        {
            NumberOfOwners = _numberOfOwners;
            Mileage = _mileage;
        }

        // METHODS
        public override string ToString()
        {
            return $"\n{Year} {Make} {Model}\n--------------------------\n  Price: ${Price}\n  Previous Owners: {NumberOfOwners}\n  Miles: {Mileage}";
        }
    }

    enum CarMake
    {
        Ford,
        Chevrolet,
        Chrysler,
        Honda,
        Toyota,
        Nissan,
        Mazda,
        Mercedes,
        Hyundai,
        Tesla,
        Audi,
        Rivian
    }
}
