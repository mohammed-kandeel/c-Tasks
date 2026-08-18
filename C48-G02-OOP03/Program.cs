namespace C48_G02_OOP03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region PART 1
            #region q1
            /*
            a) What is the difference between Method Overloading and Method Overriding?

            * Overloading
                - Allows multiple methods with the same name in the same class, but with different parameter lists.
                - Resolved at compile time.
                - Example: different number or types of parameters.

            * Overriding
                - Allows a derived class to provide a new implementation for a virtual or abstract method defined in its base class.
                - Uses the override keyword.
                - Resolved at runtime based on the actual object type.

            b) What is the difference between Static Binding and Dynamic Binding? 

            * Static Binding
              - early binding
              - resolved at compile time by the compiler
              - occurs with [method overloading , non vertual method , method hiding]
            


            * Dynamic Binding
              - late binding
              - resolve at runtime by the CLR
              - oocurs with [ methode ovverriding , abstract methods , ]
             */
            #endregion

            #region q2
            /*
            a) What is the purpose of the sealed keyword when applied to a class?
              -> The sealed keyword prevents a class from being inherited. It stops the inheritance chain completely.


            b) What is the difference between a sealed class and a sealed method?
              - Sealed class
                -> A class that cannot be inherited by another class.

              - Sealed method
                -> A method that cannot be overridden by further derived classes.
                   It must be an override of a virtual or abstract method.


            c) Can a sealed method be overridden? Why?
              -> No, a sealed method cannot be overridden because the sealed
                 keyword prevents further derived classes from overriding it.
            */
            #endregion
            #endregion

            #region PART 2
            #region q (a,b,c)
            DeliveryCenter deliveryCenter = new DeliveryCenter();

            // get Center name
            deliveryCenter.CenterName = GetText("Enter Delivery Center Name: ");

            // Center Name
            PrintCenterName(deliveryCenter.CenterName);

            // Get Driver Data
            deliveryCenter.Driver = GetDriverData();
            #endregion

            void AllRepetedData() => PrintAllRepetedData(deliveryCenter.CenterName, deliveryCenter.Driver.FullName);
            AllRepetedData();

            #region q (d,e,f,g,h)
            ////Standard
            //if (deliveryCenter.AddShipment(GetShipmentData(ShipmentTypes.standardShipment, "Standard Shipmen")))
            //    Console.WriteLine("Shipment Added Successfully.");
            //else Console.WriteLine("Fails To Add Shipment");

            ////Express 
            //if (deliveryCenter.AddShipment(GetShipmentData(ShipmentTypes.expressShipment, "Express Shipmen")))
            //    Console.WriteLine("Shipment Added Successfully.");
            //else Console.WriteLine("Fails To Add Shipment");

            ////International
            //if (deliveryCenter.AddShipment(GetShipmentData(ShipmentTypes.internationalShipment, "International Shipmen")))
            //    Console.WriteLine("Shipment Added Successfully.");
            //else Console.WriteLine("Fails To Add Shipment");
            ////print all
            //deliveryCenter.PrintAllShipments();
            #endregion

            #region q (i)
            //Console.WriteLine("Call DeliveryHelper.PrintShipmentDetails() for each shipment\n");
            //foreach (Shipment shipment in deliveryCenter.Shipments)
            //{
            //    DeliveryHelper.PrintShipmentDetails(shipment);
            //}
            #endregion

            #region q (j)
            //Console.WriteLine("Demonstrate both versions of UpdateWeight()n");
            //Console.WriteLine("befor updating");
            //deliveryCenter[0].PrintShipment();

            //Console.WriteLine("\nafter updating weight");
            //deliveryCenter[0].UpdateWeight(50);
            //deliveryCenter[0].PrintShipment();

            //Console.WriteLine("\nafter updating weight and puckge weight");
            //deliveryCenter[0].UpdateWeight(50, 0.5m);
            //deliveryCenter[0].PrintShipment();
            //Console.WriteLine("\n=======================================\n");
            #endregion

            #region q (k)
            //Console.WriteLine("Build a Shipment[] holding mixed types and print all of them in a loop. \n");
            //AddShipmentDataForTest(deliveryCenter);

            //Console.WriteLine("\n----- All Shipments -----");
            //for (int i = 0; i < 20; i++)
            //{
            //    if (deliveryCenter[i] is null)
            //        continue;
            //    deliveryCenter[i].PrintShipment();
            //    Console.WriteLine("\n-------------------------");
            //}
            #endregion

            #region q (l)
            /*
            //=====  seald class  =====

            class Parent {}

            class seald Child : Parent {}  --> seald class can inherate but stop the inherate chain completely

            class GrandChild : Child {}  --> Error [cannot derive from seald type] 


            //=====  seald method  =====

            class Parent {
                public virtual print() {
                    Console.WriteLine("Parent")
                }
            }


            class Child : Parent {
                public sealed override print() {
                    Console.WriteLine("Child")
                }
            }


            class GrandChild : Child {
                public new print() {
                    Console.WriteLine("Child")
                }
            }

            -------- main ---------
            Parent p = new GrandChild();
            GrandChild g = new GrandChild();

            p.Print(); -->  Child --> because The End of Chain end in Child Class 

            g.Print(); --> same ref and object type
                       --> GrandChild make a Override  with keyworde new
             */
            #endregion

            #endregion
        }

        #region meths
        // meths
        static double GetNumber(string InputName, bool isAllowedNegative = false)
        {
            double number;
            do
            {
                Console.Write($"{InputName}: ");
                bool isParsed = double.TryParse(Console.ReadLine(), out number);
                if (isParsed)
                {
                    if (!isAllowedNegative && number < 0)
                    {
                        Console.WriteLine($"Invalid input. Please enter a valid {InputName}.\n");
                        continue;
                    }
                    break;
                }
                Console.WriteLine($"Invalid input. Please enter a valid {InputName}.\n");

            }
            while (true);
            return number;

        }
        static string GetText(string msg, bool isAllowedNullable = false)
        {
            string text = default!;
            do
            {
                Console.Write(msg);
                text = Console.ReadLine()!;

                if (string.IsNullOrWhiteSpace(text) && !isAllowedNullable)
                {
                    Console.WriteLine("Invalid Input!\n");
                    continue;
                }
                break;

            }
            while (true);
            return text;
        }
        static Driver GetDriverData()
        {
            Console.WriteLine("\nEnter Driver Data\n");
            string id = GetText("id :");
            string fullName = GetText("Full Name: ");

            //!! add validation for Phone Number is --> number
            string phoneNumber = GetText("Phone Number: ");

            return new Driver(id, fullName, phoneNumber);
        }

        //////
        static Shipment GetShipmentData(ShipmentTypes shipmentType, string shipmentName)
        {
            Console.WriteLine($"\n{shipmentName}\n");

            //Tracking Code 
            string trackingCode = GetText("Tracking Code: ", true);

            //Destination
            string destination = GetText("Destination: ", true);

            //Weight
            decimal weight = (decimal)GetNumber("Weight");

            //DeliveryFee
            decimal deliveryFee = (decimal)GetNumber("Delivery Fee");

            //ExtraFee --> Express Shipment
            decimal extraFee = 0;
            if (Enum.Equals(shipmentType, ShipmentTypes.expressShipment))
                extraFee = (decimal)GetNumber("Extra Fee");

            //destination Country --> International Shipment
            string destinationCountry = "";
            if (Enum.Equals(shipmentType, ShipmentTypes.internationalShipment))
                destinationCountry = GetText("Destination Country: ", true);

            //customs Fee --> International Shipment
            decimal customsFee = 0;
            if (Enum.Equals(shipmentType, ShipmentTypes.internationalShipment))
                customsFee = (decimal)GetNumber("Customs Fee");

            //city
            string city = GetText("City: ", true);

            //street
            string street = GetText("Street: ", true);

            //Building number
            int buildingNumber = (int)GetNumber("Building Number");

            // reeturn Shipments
            if (Enum.Equals(shipmentType, ShipmentTypes.standardShipment))
                return new StandardShipment(trackingCode, destination, weight, deliveryFee, new DeliveryAddress(city, street, buildingNumber));
            else if (Enum.Equals(shipmentType, ShipmentTypes.expressShipment))
                return new ExpressShipment(extraFee, trackingCode, destination, weight, deliveryFee, new DeliveryAddress(city, street, buildingNumber));
            else
                return new InternationalShipment(destinationCountry, customsFee, trackingCode, destination, weight, deliveryFee, new DeliveryAddress(city, street, buildingNumber));
        }
        static void SearchShipmentByTrackingCode(DeliveryCenter deliveryCenter)
        {
            Console.Write("\nEnter a tracking code to search:");
            string trackingCode = Console.ReadLine()!;

            Shipment shipment = deliveryCenter[trackingCode];
            if (shipment is null)
            {
                Console.WriteLine("Shipment not found.");
            }
            else
            {
                Console.WriteLine("Shipment found:");
                shipment.PrintShipment();
            }
        }
        static void RemoveShipment(DeliveryCenter deliveryCenter)
        {
            Console.Write("\nEnter a tracking code to remove:");
            string trackingCode = Console.ReadLine()!;

            Shipment shipment = deliveryCenter[trackingCode];
            if (shipment is not null && deliveryCenter.RemoveShipment(trackingCode))
                Console.WriteLine("Shipment Removed Successfully.");
            else
                Console.WriteLine("Field To Removed Shipment.");
        }

        #region for Test (not important)
        static Shipment GetShipmentDataForTest(ShipmentTypes shipmentType, string trackingCode, string destination, decimal weight, decimal deliveryFee,
                decimal extraFee, string destinationCountry, decimal customsFee, string city, string street, int buildingNumber)
        {

            // reeturn Shipments
            if (Enum.Equals(shipmentType, ShipmentTypes.standardShipment))
                return new StandardShipment(trackingCode, destination, weight, deliveryFee, new DeliveryAddress(city, street, buildingNumber));
            else if (Enum.Equals(shipmentType, ShipmentTypes.expressShipment))
                return new ExpressShipment(extraFee, trackingCode, destination, weight, deliveryFee, new DeliveryAddress(city, street, buildingNumber));
            else
                return new InternationalShipment(destinationCountry, customsFee, trackingCode, destination, weight, deliveryFee, new DeliveryAddress(city, street, buildingNumber));
        }
        static void AddShipmentDataForTest(DeliveryCenter d)
        {
            d.AddShipment(GetShipmentDataForTest(ShipmentTypes.standardShipment, "SH001", "laptop", 3, 80, 0, "", 0, "Alex", "Alex", 450));
            d.AddShipment(GetShipmentDataForTest(ShipmentTypes.expressShipment, "SH002", "Mobile Phone", 2, 60, 60, "", 0, "Cairo", "Cairo", 500));
            d.AddShipment(GetShipmentDataForTest(ShipmentTypes.internationalShipment, "SH003", "Television", 8, 120, 0, "Germany", 100, "Geza", "Geza", 200));
            d.AddShipment(GetShipmentDataForTest(ShipmentTypes.standardShipment, "SH004", "laptop Dell", 6, 500, 0, "", 0, "Alexa", "Alexa", 40));
            d.AddShipment(GetShipmentDataForTest(ShipmentTypes.expressShipment, "SH005", "Mobile Phone Iphon", 4, 600, 100, "", 0, "Cairoo", "Cairoo", 50));
            d.AddShipment(GetShipmentDataForTest(ShipmentTypes.internationalShipment, "SH006", "Television", 10, 150, 0, "Germany", 150, "Gezaa", "Gezaa", 20));
        }
        static void PrintAllRepetedData(string name, string driverName)
        {
            PrintCenterName(name);
            Console.WriteLine($"Driver: {driverName}");
            Console.WriteLine("\n-------------------------------------------------------------------\n");

        }
        static void PrintCenterName(string name)
        {
            Console.Clear();
            Console.WriteLine("\n===================================================================");
            Console.WriteLine($"Delivery Center: {name}");
            Console.WriteLine("===================================================================\n");

        }
        //void run(DeliveryCenter deliveryCenter)
        //{
        //    bool exit = false;
        //    do
        //    {
        //        Console.WriteLine("\n\n-------- Options --------");
        //        Console.WriteLine("1 - Read Three Shipment Data");
        //        Console.WriteLine("2 - Print Three Shipment Data");
        //        Console.WriteLine("3 - Find Shipment By Tracking Code\n");

        //        Console.WriteLine("4 - Add Shipment");
        //        Console.WriteLine("5 - Print All Shipments\n");

        //        Console.WriteLine("6 - Exit");
        //        Console.Write("Choose an option: ");
        //        string choice = Console.ReadLine()!;
        //        Console.WriteLine();

        //        switch (choice)
        //        {
        //            case "1":

        //                break;
        //            case "2":
        //                PrintThreeShipment(deliveryCenter);
        //                break;
        //            case "3":
        //                SearchShipmentByTrackingCode(deliveryCenter);
        //                break;


        //            case "4":
        //                deliveryCenter.AddShipment(ReadShipmentData(0));
        //                break;
        //            case "5":
        //                PrintAllShipments(deliveryCenter);
        //                break;
        //            case "6":
        //                exit = true;
        //                break;
        //            default:
        //                Console.WriteLine("Invalid option. Please try again.");
        //                break;
        //        }
        //    }
        //    while (!exit);
        //}


        #endregion
        #endregion

        #region enum 
        internal enum ShipmentTypes
        {
            standardShipment,
            expressShipment,
            internationalShipment
        }
        #endregion
    }

}
