namespace C48_G02_OOP02
{
    internal enum ShipmentTypes
    {
        standardShipment,
        expressShipment,
        internationalShipment
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            #region PART 1
            #region q1
            //a)
            // What is the difference between a class and a struct?
            /*
                           ||             class                |               struct                                                                         
            ===============||==================================|=====================================
                 type      ||          ref type                |              value type                                                                          
            ---------------||----------------------------------|------------------------------------
             data storage  ||   holds a ref to data            |    holss data directly
                           ||   on the heap                    |                                                                                        
            ---------------||----------------------------------|------------------------------------
               store in    ||   heap                           |    stack
                           ||   [ref on stack]                 |
            ---------------||----------------------------------|------------------------------------
                assignment ||   passing the ref                |    copies the value                                                                                        
                 passing   ||                                  |    [data ites self]
            ---------------||----------------------------------|------------------------------------
               inheritance ||   supports inheritance           |    does not support inheritance
            ---------------||----------------------------------|------------------------------------
               default     ||   provide a defult ctor if       |    always exists parameterless ctor
             constructor   ||   not defined                    |
            ---------------||----------------------------------|------------------------------------
              nullability  ||   can be null                    |    cannot be null
                           ||                                  |    [unless nullable struct]                                                                         
            ---------------||----------------------------------|------------------------------------
                           ||   complex data with behsvoir     |    small simple data                                                                                       
              best for     ||   inheratence ,shared state      |                                                                       
            ---------------||----------------------------------|------------------------------------
             */




            //b)
            //Why are classes more suitable than structs for large applications?
            /*
             classes more stable than struct because the heap and stack behavior
               --> classes are reference types and are stored on the heap, which provides more flexibility and stability for large applications.
               --> structs are value types and are stored on the stack, which can lead to performance issues and memory leaks in large applications.
                
               class  
                    -supports all oop features[inheritance, polymorphism, encapsulation]
               strucrt
                    -does not support inheritance
                    -does not support polymorphism
             */
            #endregion

            #region q2
            // a) Which class is the parent class?
            // --> Shipment

            // b) Which class is the child class?
            // --> ExpressShipment

            // c) What members are inherited by ExpressShipment?
            // --> TrackingCode[property] 
            // --> and can say it also inherits the backing field of TrackingCode, but it is not accessible directly from the child class.

            // d) Why is inheritance better than duplicating the same code in multiple classes?
            //  --> Inheritance promotes code reusability and maintainability.
            //  --> applay consept of DRY (Don't Repeat Yourself)
            //  --> If we need to make changes to the shared functionality, we can do it in the parent class, and all child classes will automatically inherit the updated behavior.

            #endregion
            #endregion

            #region PART 2

            //DeliveryCenter deliveryCenter = new DeliveryCenter();

            //// get Center name
            //do
            //{
            //    Console.Clear();
            //    Console.WriteLine("Enter Delivery Center Name: ");
            //    deliveryCenter.CenterName = Console.ReadLine()!;
            //}
            //while (string.IsNullOrWhiteSpace(deliveryCenter.CenterName));

            //Console.Clear();
            //Console.WriteLine("\n===================================================================");
            //Console.WriteLine($"Delivery Center: {deliveryCenter.CenterName}");
            //Console.WriteLine("===================================================================");

            ////Standard
            //deliveryCenter.AddShipment(addShipmentData(ShipmentTypes.standardShipment, "Standard Shipmen"));
            ////Express 
            //deliveryCenter.AddShipment(addShipmentData(ShipmentTypes.expressShipment, "Express Shipmen"));
            ////International
            //deliveryCenter.AddShipment(addShipmentData(ShipmentTypes.internationalShipment, "International Shipmen"));
            ////print all
            //deliveryCenter.PrintAllShipments();

            ////Search for a shipment using the existing tracking code indexer.
            //SearchShipmentByTrackingCode(deliveryCenter);

            ////Remove one shipment using its tracking code.
            //RemoveShipment(ref deliveryCenter);

            ////Print the remaining shipments.
            //Console.WriteLine("\n===================================================================");
            //Console.WriteLine("remaining shipments");
            //Console.WriteLine("===================================================================");
            //deliveryCenter.PrintAllShipments();



            ////functions
            //Shipment addShipmentData(ShipmentTypes shipmentType, string shipmentName)
            //{
            //    Console.WriteLine($"\nEnter {shipmentName}\n");

            //    //Tracking Code
            //    Console.Write("Tracking Code: ");
            //    string trackingCode = Console.ReadLine() ?? string.Empty;

            //    //Destination
            //    Console.Write("Destination: ");
            //    string destination = Console.ReadLine() ?? string.Empty;

            //    //Weight
            //    decimal weight;
            //    do
            //    {
            //        Console.Write("Weight: ");
            //        if (decimal.TryParse(Console.ReadLine(), out weight))
            //        {
            //            break;
            //        }
            //        Console.WriteLine("Invalid input. Please enter a valid weight.");
            //    }
            //    while (true);

            //    //DeliveryFee
            //    decimal deliveryFee;
            //    do
            //    {
            //        Console.Write("Delivery Fee: ");
            //        if (decimal.TryParse(Console.ReadLine(), out deliveryFee))
            //        {
            //            break;
            //        }
            //        Console.WriteLine("Invalid input. Please enter a valid delivery fee.");
            //    }
            //    while (true);


            //    //ExtraFee --> Express Shipment
            //    decimal extraFee = 0;
            //    if (Enum.Equals(shipmentType, ShipmentTypes.expressShipment))
            //    {
            //        do
            //        {
            //            Console.Write("Extra Fee: ");
            //            if (decimal.TryParse(Console.ReadLine(), out extraFee))
            //            {
            //                break;
            //            }
            //            Console.WriteLine("Invalid input. Please enter a valid Extra fee.");
            //        }
            //        while (true);
            //    }

            //    //destination Country --> International Shipment
            //    string destinationCountry = "";
            //    if (Enum.Equals(shipmentType, ShipmentTypes.internationalShipment))
            //    {
            //        Console.Write("Destination Country: ");
            //        destinationCountry = Console.ReadLine() ?? string.Empty;
            //    }

            //    //customs Fee --> International Shipment
            //    decimal customsFee = 0;
            //    if (Enum.Equals(shipmentType, ShipmentTypes.internationalShipment))
            //    {
            //        do
            //        {
            //            Console.Write("Customs Fee: ");
            //            if (decimal.TryParse(Console.ReadLine(), out customsFee))
            //            {
            //                break;
            //            }
            //            Console.WriteLine("Invalid input. Please enter a valid Customs fee.");
            //        }
            //        while (true);
            //    }

            //    //city
            //    Console.Write("City: ");
            //    string city = Console.ReadLine() ?? string.Empty;

            //    //street
            //    Console.Write("Street: ");
            //    string street = Console.ReadLine() ?? string.Empty;

            //    //Building number
            //    int buildingNumber;
            //    do
            //    {
            //        Console.Write("Building Number: ");
            //        if (int.TryParse(Console.ReadLine(), out buildingNumber))
            //        {
            //            break;
            //        }
            //        Console.WriteLine("Invalid input. Please enter a valid building number.");
            //    }
            //    while (true);

            //    // reeturn Shipments
            //    if (Enum.Equals(shipmentType, ShipmentTypes.standardShipment))
            //        return new StandardShipment(trackingCode, destination, weight, deliveryFee, new DeliveryAddress(city, street, buildingNumber));
            //    else if (Enum.Equals(shipmentType, ShipmentTypes.expressShipment))
            //        return new ExpressShipment(extraFee, trackingCode, destination, weight, deliveryFee, new DeliveryAddress(city, street, buildingNumber));
            //    else
            //        return new InternationalShipment(destinationCountry, customsFee, trackingCode, destination, weight, deliveryFee, new DeliveryAddress(city, street, buildingNumber));
            //}
            //void SearchShipmentByTrackingCode(DeliveryCenter deliveryCenter)
            //{
            //    Console.Write("\nEnter a tracking code to search:");
            //    string trackingCode = Console.ReadLine()!;

            //    Shipment shipment = deliveryCenter[trackingCode];
            //    if (shipment is null)
            //    {
            //        Console.WriteLine("Shipment not found.");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Shipment found:");
            //        shipment.PrintShipment();
            //    }
            //}
            //void RemoveShipment(ref DeliveryCenter deliveryCenter)
            //{
            //    Console.Write("\nEnter a tracking code to remove:");
            //    string trackingCode = Console.ReadLine()!;

            //    Shipment shipment = deliveryCenter[trackingCode];
            //    if (shipment is not null && deliveryCenter.RemoveShipment(trackingCode))
            //        Console.WriteLine("Shipment Removed Successfully.");
            //    else
            //        Console.WriteLine("Field To Removed Shipment.");
            //}
            #endregion
        }
    }
}
