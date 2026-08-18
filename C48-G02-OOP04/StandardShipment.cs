namespace C48_G02_OOP04
{
    internal class StandardShipment : Shipment, ITrackable, IInsurable
    {

        //prop
        public override decimal EstimatedCost
        {
            get { return DeliveryFee + (Weight * 5); }
        }

        //ctor
        public StandardShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination) : base(trackingCode, description, weight, deliveryFee, destination)
        { }

        //meths
        public override void PrintShipment()
        {
            Console.WriteLine("\nStandard Shipment\n");
            Console.WriteLine($"Tracking Code : {TrackingCode}");
            Console.WriteLine($"Description   : {Description}");
            Console.WriteLine($"Estimated Cost: ${EstimatedCost} EGP");
        }

        public string GetTrackingStatus()
        {
            return $"Shipment {TrackingCode} is Ready.";
        }

        public decimal CalculateInsurance()
        {
            return (5m / 100) * EstimatedCost; 
        }
    }
}
