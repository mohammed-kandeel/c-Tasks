namespace C48_G02_OOP05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region part 1
            #region q1 Object Copying 
            /*
                a) What happens when you assign one object variable to another object variable? 
                    --> The reference of the first object is assigned to the second object variable, so both variables point to the same object in memory.
            
                b) Does assigning one object to another create a new object? Explain. 
                    --> No, assigning one object to another does not create a new object. 
                        It simply copies the reference of the original object to the new variable, meaning both variables refer to the same object in memory.
                        Any changes made through one variable will affect the other since they point to the same instance.

                c) What is the difference between copying an object and copying its reference? 
                    --> Copying an object creates a new instance of the object with the same values, while copying its reference means that both variables point to the same instance in memory. 
                        Changes made to the object through one reference will be reflected in the other reference, whereas changes made to a copied object do not affect the original object.
            */
            #endregion

            #region q2 Shallow Copy vs Deep Copy 
            /*
                a) What is a Shallow Copy? 
                    --> A Shallow Copy creates a new object that is a copy of the original object, but it only copies the values of the fields of the original object. 
                        If the original object contains reference-type members (like objects or arrays), the shallow copy will copy the references to those members, not the actual objects they point to. 
                        This means that both the original and the shallow copy will share the same reference-type members.

                b) What is a Deep Copy? 
                    --> A Deep Copy creates a new object that is a copy of the original object, and it recursively copies all the fields and reference-type members of the original object. 
                        This means that the deep copy will have its own independent copies of all the referenced objects, so changes made to the deep copy will not affect the original object.

                c) What happens to reference-type members when a Shallow Copy is created? 
                    --> The references to the reference-type members are copied, but the actual objects they point to are not copied.
                        This means that both the original and the shallow copy will share the same reference-type members.

                d) What happens to reference-type members when a Deep Copy is created? 
                    --> The references to the reference-type members are copied, and the actual objects they point to are also copied recursively.
                        This means that the deep copy will have its own independent copies of all the referenced objects.
               
                e) Give one situation where Deep Copy would be safer than Shallow Copy. 
                    --> A situation where Deep Copy would be safer than Shallow Copy is when you have an object that contains mutable reference-type members,
                        and you want to ensure that changes made to one instance do not affect another instance.
            */
            #endregion

            #region q3 Static Members
            /*
                a) What is a static field, and how is it different from an instance field? 
                    --> A static field is a variable that belongs to the class itself rather than to any specific instance of the class. 
                        It is shared among all instances of the class, meaning that there is only one copy of the static field for the entire class. 
                        In contrast, an instance field is a variable that belongs to a specific instance of the class, and each instance has its own copy of the instance field.
               
                b) What is a static method? Can a static method directly access instance members? 
                    --> A static method is a method that belongs to the class itself rather than to any specific instance of the class. 
                        It cannot directly access instance members because it does not have access to the instance context. 
                        However, it can access other static members of the class.
                
                c) What is a static constructor, and when is it executed? 
                    --> A static constructor is a special constructor that is used to initialize any static data or perform a particular action that needs to be done only once. 
                        It is executed automatically before the first instance of the class is created or any static members are accessed.
                
                d) What is a static class? Can you create an object from a static class? 
                    --> A static class is a class that cannot be instantiated. 
                        It can only contain static members. 
                        Therefore, you cannot create an object from a static class.
             */
            #endregion

            #region q4 Extension Methods
            /*
                a) What is an Extension Method? 
                    --> An Extension Method is a special kind of static method that allows you to "add" new methods to existing types without modifying the original type or creating a new derived type. 
                        It is defined in a static class and uses the "this" keyword in its first parameter to specify the type it extends.
                
                b) What keyword must be used in the first parameter of an extension method? 
                    --> The "this" keyword must be used in the first parameter of an extension method to indicate the type that the method extends.
                
                c) Where must an extension method be declared? 
                    --> An extension method must be declared in a static class.
                
                d) Can an extension method access private members of the class it extends? 
                    --> No, an extension method cannot access private members of the class it extends.
            */
            #endregion

            #region q5 Partial Classes and Partial Methods 
            /*
                a) What is a Partial Class? 
                    --> A Partial Class is a class that can be split into multiple files, allowing multiple developers to work on the same class simultaneously or to organize code in a more manageable way. 
                        Each part of the partial class must use the "partial" keyword and have the same name and namespace.

                b) Why would a developer split one class into multiple files? 
                    --> A developer might split one class into multiple files to improve code organization, maintainability, and collaboration. 
                        It allows different developers to work on different parts of the class without causing merge conflicts, 
                        and it can make the code easier to navigate by separating concerns or functionality into distinct files.   

                c) What is a Partial Method? 
                    --> A Partial Method is a method that is declared in one part of a partial class and can be optionally implemented in another part of the same partial class. 
                        If the method is not implemented, the compiler removes the method declaration and any calls to it, resulting in no performance overhead.   

                d) What happens if a declared partial method has no implementation?
                    --> If a declared partial method has no implementation, the compiler removes the method declaration and any calls to it, resulting in no performance overhead. 
                        The method is effectively ignored, and it does not affect the compiled code.
             */
            #endregion
            #endregion


            #region part 2
            #region MyRegion

            string centerName = "Smart Delivery Management System";

            DeliveryUtilities.PrintSeparator();
            DeliveryUtilities.PrintSystemTitle(centerName);
            DeliveryUtilities.PrintSeparator();

            DeliveryCenter deliveryCenter = new DeliveryCenter();
            deliveryCenter.CenterName = centerName;
            deliveryCenter.Driver = new Driver("123", "Mohamed", "0123456");

            AddShipmentsDataForTest(deliveryCenter);
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Creating Shipments... ");
            DeliveryUtilities.PrintSeparator();

            Console.WriteLine();

            Console.WriteLine($"{deliveryCenter[0].GetType().Name} Shipment Created");
            Console.WriteLine($"{deliveryCenter[1].GetType().Name} Shipment Created");
            Console.WriteLine($"{deliveryCenter[2].GetType().Name} Shipment Created");


            Console.WriteLine();

            PrintTotalShipments();
            #endregion


            #region Object Copying 
            Console.WriteLine();
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Object Copying ");
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine();

            Shipment objectCopying = deliveryCenter[0];

            Console.WriteLine($"Original Shipment: {deliveryCenter[0].TrackingCode}");
            Console.WriteLine($"Assigned Shipment: {objectCopying.TrackingCode}");

            Console.WriteLine("\nSame Object : " + object.ReferenceEquals(deliveryCenter[0], objectCopying));
            #endregion

            #region Shallow Copy
            Console.WriteLine("\n------------------------------------------");
            Console.WriteLine("Shallow Copy");
            Console.WriteLine("------------------------------------------\n");

            objectCopying = deliveryCenter[0].ShallowCopy();

            Console.WriteLine($"Original Shipment Address: {(deliveryCenter[0].Destination).city}");
            Console.WriteLine($"Assigned Shipment Address: {(objectCopying.Destination).city}");

            Console.WriteLine("\nChanging copied shipment address....\n");

            DeliveryAddress d = objectCopying.Destination;
            d.city = "Giza";
            objectCopying.Destination = d;

            Console.WriteLine($"Original Shipment Address: {(deliveryCenter[0].Destination).city}");
            Console.WriteLine($"Assigned Shipment Address: {(objectCopying.Destination).city}");

            Console.WriteLine("\nSame DeliveryAddress Object  : " + object.ReferenceEquals(deliveryCenter[0].Destination, objectCopying.Destination));
            #endregion

            #region Deep Copy
            Console.WriteLine("\n------------------------------------------");
            Console.WriteLine("Deep Copy");
            Console.WriteLine("------------------------------------------\n");


            objectCopying = deliveryCenter[0].DeepCopy();

            Console.WriteLine($"Original Shipment Address: {(deliveryCenter[0].Destination).city}");
            Console.WriteLine($"Assigned Shipment Address: {(objectCopying.Destination).city}");

            Console.WriteLine("\nChanging copied shipment address....\n");

            d = objectCopying.Destination;
            d.city = "Giza";
            objectCopying.Destination = d;

            Console.WriteLine($"Original Shipment Address: {(deliveryCenter[0].Destination).city}");
            Console.WriteLine($"Assigned Shipment Address: {(objectCopying.Destination).city}");

            Console.WriteLine("\nSame DeliveryAddress Object  : " + object.ReferenceEquals(deliveryCenter[0].Destination, objectCopying.Destination));


            #endregion

            #region Extension Methods
            Console.WriteLine();
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Extension Methods");
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine();


            for (int i = 0; i < 20; i++)
            {
                if (deliveryCenter[i] is not null)
                    Console.WriteLine(deliveryCenter[i].GetSummary());
            }

            Console.WriteLine();

            for (int i = 0; i < 20; i++)
            {
                if (deliveryCenter[i] is not null)
                    Console.WriteLine($"{deliveryCenter[i].TrackingCode} Is Delivered : {deliveryCenter[i].IsDelivered()}");
            }
            #endregion

            #region Tracking Status 
            Console.WriteLine();
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Tracking Status ");
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine();

            for (int i = 0; i < 20; i++)
            {
                if (deliveryCenter[i] is not null)
                {
                    Console.WriteLine($"{deliveryCenter[i].TrackingCode}");
                    deliveryCenter[i].UpdateTrackingStatus();
                    Console.WriteLine();
                }
            }
            #endregion
            #endregion
        }
        #region meths
        static void PrintTotalShipments()
        {
            Console.WriteLine($"Total Shipments Created : {Shipment.GetTotalShipmentsCreated()}");
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
