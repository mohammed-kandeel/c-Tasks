namespace C48_G02_OOP02
{
    internal class InternationalShipment : Shipment
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
                if (string.IsNullOrWhiteSpace(value))
                {
                    destinationCountry = value;
                }
            }
        }
        public decimal CustomsFee
        {
            get { return customsFee; }
            set
            {
                if (value >= 0)
                {
                    customsFee = value;
                }
            }
        }
        public override decimal EstimatedCost
        {
            get
            {
                return DeliveryFee + (Weight * 5) + CustomsFee;
            }
        }

        //ctor
        public InternationalShipment(string destinationCountry, decimal customsFee, string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination) : base(trackingCode, description, weight, deliveryFee, destination)
        {
            this.destinationCountry = destinationCountry;
            CustomsFee = customsFee;
        }
        public override void PrintShipment()
        {
            Console.WriteLine("\nInternational Shipment\n");

            base.PrintShipment();
            Console.WriteLine($"Destination Country: {destinationCountry}");
            Console.WriteLine($"Customs Fee: ${CustomsFee} EGP");
            Console.WriteLine($"Estimated Cost: ${EstimatedCost} EGP");

        }
    }
}
