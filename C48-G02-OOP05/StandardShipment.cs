namespace C48_G02_OOP05
{
    internal class StandardShipment : Shipment
    {

        //prop
        public override decimal EstimatedCost
        {
            get { return DeliveryFee + (Weight * 5); }
        }

        //ctor
        public StandardShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination) : base(trackingCode, description, weight, deliveryFee, "In Transit", destination)
        { }

        //meths
        public override void PrintShipment()
        {
            Console.WriteLine("\nStandard Shipment\n");
            Console.WriteLine($"Tracking Code : {TrackingCode}");
            Console.WriteLine($"Description   : {Description}");
            Console.WriteLine($"Estimated Cost: ${EstimatedCost} EGP");
        }

    

        public override decimal CalculateInsurance()
        {
            return (5m / 100) * EstimatedCost;
        }


        public override Shipment CopyShipment()
        {
            return new StandardShipment(this.TrackingCode, this.Description, this.Weight, this.DeliveryFee, new DeliveryAddress(this.Destination.city, this.Destination.street, this.Destination.buildingNumber));
        }
        public override Shipment DeepCopy()
        {
            return new StandardShipment(this.TrackingCode, this.Description, this.Weight, this.DeliveryFee, new DeliveryAddress(this.Destination.city, this.Destination.street, this.Destination.buildingNumber));

        }
    }
}
