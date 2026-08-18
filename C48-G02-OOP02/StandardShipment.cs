namespace C48_G02_OOP02
{
    internal class StandardShipment : Shipment
    {
        public StandardShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination) : base(trackingCode, description, weight, deliveryFee, destination)
        { }
        public override void PrintShipment()
        {
            Console.WriteLine("\nStandard Shipment\n");
            base.PrintShipment();
            Console.WriteLine($"Estimated Cost: ${EstimatedCost} EGP");
        }
    }

}
