namespace C48_G02_OOP01
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region Part 01 - Smart Delivery Management System
            #region q1
            // a
            /*
                DeliveryAddress is a struct, and struct is a value type

                When a DeliveryAddress variable is copied, the copy is made by value
                Each variable has its own independent copy

                >> What happens when the copy is modified?
                   --> Only the copied variable changes
                   --> The original variable remains unchanged
            */

            // b
            /*
                Customer is a class, and class is a reference type

                When a Customer variable is copied, the reference is copied,
                not the object itself

                Both variables refer to the same object.

                >> What happens when one variable modifies the object?
                   --> The modification affects the same object
                   --> Therefore, the other variable will also see the change
            */


            #endregion

            #region q2
            // a
            /*
                1 - Can not protect data
                2 - No valedations
                3 - Con not allow read only or write only
                4 - Change field name , cuse rename all usege of it
             */

            // b
            /* 
                1 - Hide internal fields
                2 - Validate input
                3 - Control read/write access
                4 - Maintain object integrity
            */
            #endregion
            #endregion

            #region Part 02 : Smart Delivery Management System

            #region q1
            //DeliveryAddress deliveryAddress = new DeliveryAddress("Giza", "55", 1);
            //DeliveryAddress deliveryAddress2 = deliveryAddress;

            //deliveryAddress2.city = "Alex";
            //deliveryAddress2.street = "alex";
            //deliveryAddress2.buildingNumber = 50;

            //Console.WriteLine(deliveryAddress.GetFullAddress());
            //Console.WriteLine(deliveryAddress2.GetFullAddress());
            #endregion

            #region q6 (1 to 7)
            /*
            1 - Create a DeliveryCenter.
            2 - Read data for three shipments from the user
            3 - Create each Shipment and add it to the DeliveryCenter.
            4 - Print the three shipments using the integer indexer.

            5 - Ask the user to enter a tracking code.
            6 - Search for the shipment using the string indexer.
            7 - Print the shipment if found; otherwise print:Shipment not found
             */

            DeliveryCenter deliveryCenter = new DeliveryCenter();

            //////  ------   with out menu  ------ 
            #region with out menu
            //ReadThreeShipments(ref deliveryCenter);
            //PrintThreeShipment(deliveryCenter);
            //SearchShipmentByTrackingCode(deliveryCenter);
            #endregion


            //////  ------   with menu  ------ 
            #region with menu
            //bool exit = false;
            //do
            //{
            //    Console.WriteLine("\n\n-------- Options --------");
            //    Console.WriteLine("1 - Read Three Shipment Data");
            //    Console.WriteLine("2 - Print Three Shipment Data");
            //    Console.WriteLine("3 - Find Shipment By Tracking Code\n");

            //    Console.WriteLine("4 - Add Shipment");
            //    Console.WriteLine("5 - Print All Shipments\n");

            //    Console.WriteLine("6 - Exit");
            //    Console.Write("Choose an option: ");
            //    string choice = Console.ReadLine()!;
            //    Console.WriteLine();

            //    switch (choice)
            //    {
            //        case "1":
            //            ReadThreeShipments(ref deliveryCenter);
            //            break;
            //        case "2":
            //            PrintThreeShipment(deliveryCenter);
            //            break;
            //        case "3":
            //            SearchShipmentByTrackingCode(deliveryCenter);
            //            break;


            //        case "4":
            //            deliveryCenter.AddShipment(ReadShipmentData(0));
            //            break;
            //        case "5":
            //            PrintAllShipments(deliveryCenter);
            //            break;
            //        case "6":
            //            exit = true;
            //            break;
            //        default:
            //            Console.WriteLine("Invalid option. Please try again.");
            //            break;
            //    }
            //}
            //while (!exit);
            #endregion



            //functions
            void ReadThreeShipments(ref DeliveryCenter deliveryCenter)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (deliveryCenter.AddShipment(ReadShipmentData(i)))
                        Console.WriteLine("\nShipment added successfully.\n");
                    else
                        Console.WriteLine("Failed to add shipment.");
                }

            }
            void PrintThreeShipment(DeliveryCenter deliveryCenter)
            {
                Console.WriteLine("\n----- All Shipments -----\n");
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine($"Shipment {i + 1}:");
                    deliveryCenter[i].PrintShipment();
                    Console.WriteLine();
                }
            }
            void SearchShipmentByTrackingCode(DeliveryCenter deliveryCenter)
            {
                Console.Write("Enter a tracking code:");
                string trackingCode = Console.ReadLine()!;

                Shipment shipment = deliveryCenter[trackingCode];
                if (string.IsNullOrWhiteSpace(shipment.TrackingCode))
                {
                    Console.WriteLine("Shipment not found.");
                }
                else
                {
                    Console.WriteLine("Shipment found:");
                    shipment.PrintShipment();
                }
            }

            Shipment ReadShipmentData(int index)
            {
                Console.WriteLine($"Enter Shipment {index + 1} Data");

                //Tracking Code
                Console.Write("Tracking Code: ");
                string trackingCode = Console.ReadLine() ?? string.Empty;

                //Destination
                Console.Write("Destination: ");
                string destination = Console.ReadLine() ?? string.Empty;

                //Weight
                double weight;
                do
                {
                    Console.Write("Weight: ");
                    if (double.TryParse(Console.ReadLine(), out weight))
                    {
                        break;
                    }
                    Console.WriteLine("Invalid input. Please enter a valid weight.");
                }
                while (true);

                //DeliveryFee
                decimal deliveryFee;
                do
                {
                    Console.Write("Delivery Fee: ");
                    if (decimal.TryParse(Console.ReadLine(), out deliveryFee))
                    {
                        break;
                    }
                    Console.WriteLine("Invalid input. Please enter a valid delivery fee.");
                }
                while (true);

                //city
                Console.Write("City: ");
                string city = Console.ReadLine() ?? string.Empty;

                //street
                Console.Write("Street: ");
                string street = Console.ReadLine() ?? string.Empty;

                //DeliveryFee
                int buildingNumber;
                do
                {
                    Console.Write("Building Number: ");
                    if (int.TryParse(Console.ReadLine(), out buildingNumber))
                    {
                        break;
                    }
                    Console.WriteLine("Invalid input. Please enter a valid building number.");
                }
                while (true);


                return new Shipment(trackingCode, destination, weight, deliveryFee, new DeliveryAddress(city, street, buildingNumber));
            }
            void PrintAllShipments(DeliveryCenter deliveryCenter)
            {
                Console.WriteLine("\n----- All Shipments -----\n");
                int i = 0;
                while (!string.IsNullOrWhiteSpace(deliveryCenter[i].TrackingCode))
                {
                    Console.WriteLine($"Shipment {i + 1}:");
                    deliveryCenter[i].PrintShipment();
                    Console.WriteLine();
                    i++;
                }
            }

            #endregion

            #region q6 (8)
            ////// 8 - Demonstrate the DeliveryAddress struct copy behavior.
            //DeliveryAddress address1 = new DeliveryAddress("Giza", "55", 1);
            //DeliveryAddress address2 = address1;

            //address2.city = "Alex";
            //address2.street = "alex";
            //address2.buildingNumber = 50;

            //Console.WriteLine("Original Address:");
            //Console.WriteLine(address1.GetFullAddress());

            //Console.WriteLine("\n\nCopied & Modified Address:");
            //Console.WriteLine(address2.GetFullAddress());
            #endregion

            #endregion
        }

    }
}
