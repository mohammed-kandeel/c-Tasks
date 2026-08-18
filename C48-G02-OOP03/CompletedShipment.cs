namespace C48_G02_OOP03
{
    internal sealed class CompletedShipment : Shipment
    {
        //ctots
        public CompletedShipment(string trackingCode) : base(trackingCode)
        { }
        public CompletedShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination) : base(trackingCode, description, weight, deliveryFee, destination)
        { }
    }
}
