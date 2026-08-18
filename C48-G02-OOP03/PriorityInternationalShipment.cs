namespace C48_G02_OOP03
{
    internal class PriorityInternationalShipment : InternationalShipment
    {
        //ctors
        public PriorityInternationalShipment(string destinationCountry, decimal customsFee, string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination) : base(destinationCountry, customsFee, trackingCode, description, weight, deliveryFee, destination)
        { }
        public sealed override void GenerateCustomsReport()
        {
            Console.WriteLine("sealed override void GenerateCustomsReport");
        }
    }
}
