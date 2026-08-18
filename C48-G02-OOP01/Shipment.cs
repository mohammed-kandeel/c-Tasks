namespace C48_G02_OOP01
{
    internal struct Shipment
    {
        //fields
        private string trackingCode;
        private string description;
        private double weight;
        private decimal deliveryFee;


        //prop
        public DeliveryAddress Destination { get; set; }

        public string TrackingCode
        {
            get { return trackingCode; }
            private set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    trackingCode = value;
            }
        }
        public string Description
        {
            get { return description; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    description = value;
            }
        }
        public double Weight
        {
            get { return weight; }
            set
            {
                if (value > 0)
                    weight = value;
            }
        }
        public decimal DeliveryFee
        {
            get { return deliveryFee; }
            private set
            {
                if (value > 0)
                    deliveryFee = value;
            }
        }
        public double EstimatedCost
        {
            get
            {
                return (double)deliveryFee + (weight * 5);
            }
        }

        //constractor
        public Shipment(string trackingCode)
            : this(trackingCode, "Unknown", 1, 50, new DeliveryAddress("Unknown", "Unknown", 0))
        { }
        public Shipment(string trackingCode, string description, double weight, decimal deliveryFee, DeliveryAddress destination)
        {
            this.trackingCode = "Unknown";
            this.description = "Unknown";
            this.weight = 1;
            this.deliveryFee = 50;

            if (string.IsNullOrWhiteSpace(destination.city))
                destination.city = "Unknown";

            if (string.IsNullOrWhiteSpace(destination.street))
                destination.street = "Unknown";

            TrackingCode = trackingCode;
            Description = description;
            Weight = weight;
            DeliveryFee = deliveryFee;
            Destination = destination;
        }

        //methods
        public void UpdateDeliveryFee(decimal newFee)
        {
            if (newFee > 0)
                DeliveryFee = newFee;
        }
        public void PrintShipment()
        {
            Console.WriteLine($"Tracking Code: {TrackingCode}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Weight: {Weight} kg");
            Console.WriteLine($"Delivery Fee: ${DeliveryFee} EGP");
            Console.WriteLine($"Destination: {Destination.GetFullAddress()}");
            Console.WriteLine($"Estimated Cost: ${EstimatedCost} EGP");
        }
    }

}
