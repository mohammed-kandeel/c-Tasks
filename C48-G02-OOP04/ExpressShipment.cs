namespace C48_G02_OOP04
{
    internal class ExpressShipment : Shipment, ITrackable, IInsurable
    {
        //fields
        private decimal extraFee;


        //prop
        public decimal ExtraFee
        {
            get { return extraFee; }
            set
            {
                if (value >= 0)
                {
                    extraFee = value;
                }
            }
        }
        public override decimal EstimatedCost
        {
            get { return DeliveryFee + (Weight * 5) + ExtraFee; }
        }

        //constractor
        public ExpressShipment(decimal extraFee, string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination) : base(trackingCode, description, weight, deliveryFee, destination)
        {
            ExtraFee = extraFee;
        }

        //methods
        public override void PrintShipment()
        {
            Console.WriteLine("\nExpress Shipment\n");
            Console.WriteLine($"Tracking Code : {TrackingCode}");
            Console.WriteLine($"Extra Fee     : ${ExtraFee} EGP");
            Console.WriteLine($"Estimated Cost: ${EstimatedCost} EGP");
        }

        public string GetTrackingStatus()
        {
            return $"Shipment {TrackingCode} has been Delivered..";
        }

        public decimal CalculateInsurance()
        {
            return (8m / 100) * EstimatedCost;
        }
    }
}
