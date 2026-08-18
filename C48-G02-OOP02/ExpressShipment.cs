namespace C48_G02_OOP02
{
    internal class ExpressShipment : Shipment
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
            get
            {
                return DeliveryFee + (Weight * 5) + ExtraFee;
            }
        }

        //constractor
        public ExpressShipment(decimal extraFee, string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination) : base(trackingCode, description, weight, deliveryFee, destination)
        {
            ExtraFee = extraFee;
        }

        public override void PrintShipment()
        {
            Console.WriteLine("\nExpress Shipment\n");

            base.PrintShipment();
            Console.WriteLine($"Extra Fee: ${ExtraFee} EGP");
            Console.WriteLine($"Estimated Cost: ${EstimatedCost} EGP");
        }
    }
}
