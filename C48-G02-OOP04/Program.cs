namespace C48_G02_OOP04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region PART 1
            #region q1
            /*
             a) What is Abstraction in Object-Oriented Programming? 
                --> the core principle of hiding complex internal code details and showing only the essential features to the user
             
             
             b)  Why is abstraction considered one of the four pillars of OOP? 
                --> Abstraction is a core pillar of object-oriented programming because it hides complex internal code details.
                    It shows only the important features to the user. 
                    This makes programs easier to use, update, and secure.
             */
            #endregion

            #region q2
            /*
            a)  What is the difference between an Abstract Class and an Interface? 
            -->classes 
                    can have both abstract and concrete methods
            --> interfaces
                    can only have abstract methods
            
            b)  When would you choose an Interface instead of an Abstract Class? 
                --> when want to provide acommon structure for related class
                --> when want to hide complex implementation details
                --> when expect future changes and want to keep code flexible
                --> when multiple classes should have the same behavior
            

            c)  \
             Can a class inherit from multiple abstract classes?
                --> no it cannot
            
            
             Can it implement multiple interfaces? 
                --> yes it can
             */
            #endregion


            #endregion

            #region PART 2
            #region q-(a,b,c,d,e)
            DeliveryCenter deliveryCenter = new DeliveryCenter();
            deliveryCenter.CenterName = "Delivery Center";
            deliveryCenter.Driver = new Driver("123", "Mohamed", "0123456");
            AddShipmentsDataForTest(deliveryCenter);

            ///////
            void AllRepetedData() => PrintAllRepetedData(deliveryCenter.CenterName, deliveryCenter.Driver.FullName);
            AllRepetedData();
            //////
            
            deliveryCenter.PrintAllShipments();
            #endregion

            #region q-(f)
            deliveryCenter.PrintTrackingStatuses();
            #endregion

            #region q-(g)
            deliveryCenter.PrintInsurable();
            #endregion

            #region q-(h)
            Console.WriteLine("\n===========================\n");
            Console.WriteLine("All Tracking Statuses\n");
            ITrackable[] trackables = { (StandardShipment)deliveryCenter[0], (ExpressShipment)deliveryCenter[1] , (InternationalShipment)deliveryCenter[2] };

            foreach (ITrackable t in trackables)
            {
                Console.WriteLine(t.GetTrackingStatus()+"\n");
            }
            #endregion

            #region q-(i)
            Console.WriteLine("\n===========================\n");
            Console.WriteLine("All Insurance Values\n");
            IInsurable[] insurables= { (StandardShipment)deliveryCenter[0], (ExpressShipment)deliveryCenter[1] , (InternationalShipment)deliveryCenter[2] };

            foreach (IInsurable i in insurables)
            {
                Console.WriteLine(i.CalculateInsurance()+"\n");
            }
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

        //////
        static Driver GetDriverData()
        {
            Console.WriteLine("\nEnter Driver Data\n");
            string id = GetText("id :");
            string fullName = GetText("Full Name: ");

            //!! add validation for Phone Number is --> number
            string phoneNumber = GetText("Phone Number: ");

            return new Driver(id, fullName, phoneNumber);
        }
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
        static void AddShipmentsDataForTest(DeliveryCenter d)
        {
            d.AddShipment(GetShipmentDataForTest(ShipmentTypes.standardShipment, "SH001", "laptop", 3, 80, 0, "", 0, "Alex", "Alex", 450));
            d.AddShipment(GetShipmentDataForTest(ShipmentTypes.expressShipment, "SH002", "Mobile Phone", 2, 60, 30, "", 0, "Cairo", "Cairo", 500));
            d.AddShipment(GetShipmentDataForTest(ShipmentTypes.internationalShipment, "SH003", "Television", 8, 120, 0, "Germany", 100, "Geza", "Geza", 200));
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
