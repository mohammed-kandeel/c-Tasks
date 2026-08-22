namespace C48_G02_OOP05
{
    internal sealed class CompletedShipment : Shipment
    {
        //ctots
        public CompletedShipment(string trackingCode) : base(trackingCode)
        { }
        public CompletedShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination) : base(trackingCode, description, weight, deliveryFee,"", destination)
        { }

        //meths
        public override decimal EstimatedCost => throw new NotImplementedException();

        public override decimal CalculateInsurance()
        {
            throw new NotImplementedException();
        }

        public override Shipment CopyShipment()
        {
            throw new NotImplementedException();
        }

        public override Shipment DeepCopy()
        {
            throw new NotImplementedException();
        }

        public override void PrintShipment()
        {
            throw new NotImplementedException();
        }

    }
}
