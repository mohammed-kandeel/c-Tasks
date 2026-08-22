namespace C48_G02_OOP05
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
            get { return DeliveryFee + (Weight * 5) + ExtraFee; }
        }

        //constractor
        public ExpressShipment(decimal extraFee, string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination) : base(trackingCode, description, weight, deliveryFee, "Out For Delivery", destination)
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
        public override decimal CalculateInsurance()
        {
            return (8m / 100) * EstimatedCost;
        }
        public override Shipment CopyShipment()
        {
            return new ExpressShipment(this.ExtraFee, this.TrackingCode, this.Description, this.Weight, this.DeliveryFee, new DeliveryAddress(this.Destination.city, this.Destination.street, this.Destination.buildingNumber));
        }
        public override Shipment DeepCopy()
        {
            return new ExpressShipment(this.ExtraFee, this.TrackingCode, this.Description, this.Weight, this.DeliveryFee, new DeliveryAddress(this.Destination.city, this.Destination.street, this.Destination.buildingNumber));
        }
    }
}
