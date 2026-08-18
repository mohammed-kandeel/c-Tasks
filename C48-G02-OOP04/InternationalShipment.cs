namespace C48_G02_OOP04
{
    internal class InternationalShipment : Shipment, ITrackable, IInsurable
    {
        //fields
        private string destinationCountry;
        private decimal customsFee;

        //prop
        public string DestinationCountry
        {
            get
            { return destinationCountry; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    destinationCountry = value;
            }
        }
        public decimal CustomsFee
        {
            get { return customsFee; }
            set
            {
                if (value >= 0)
                    customsFee = value;
            }
        }
        public override decimal EstimatedCost
        {
            get { return DeliveryFee + (Weight * 5) + CustomsFee; }
        }

        //ctor
        public InternationalShipment(string destinationCountry, decimal customsFee, string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination) : base(trackingCode, description, weight, deliveryFee, destination)
        {
            this.destinationCountry = destinationCountry;
            CustomsFee = customsFee;
        }

        //meths
        public override void PrintShipment()
        {
            Console.WriteLine("\nInternational Shipment\n");
            Console.WriteLine($"Tracking Code       : {TrackingCode}");
            Console.WriteLine($"Destination Country : {destinationCountry}");
            Console.WriteLine($"Estimated Cost      : ${EstimatedCost} EGP");
        }
        public virtual void GenerateCustomsReport()
        {
            Console.WriteLine("virtual void GenerateCustomsReport");
        }

        public string GetTrackingStatus()
        {
            return $"Shipment {TrackingCode} is Out for Delivery. ";
        }

        public decimal CalculateInsurance()
        {
            return (12m / 100) * EstimatedCost;
        }
    }
}
