namespace C48_G02_OOP05
{
    internal abstract partial class Shipment : ITrackable, IInsurable
    {
        //fields
        private string trackingCode;
        private string description;
        private decimal weight;
        private decimal deliveryFee;
        static protected int TotalShipmentsCreated;

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
        public decimal Weight
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
        public abstract decimal EstimatedCost { get; }

        //constractor
        public Shipment(string trackingCode) : this(trackingCode, "Unknown", 1, 50, "", new DeliveryAddress("Unknown", "Unknown", 0))
        { }
        public Shipment(string trackingCode, string description, decimal weight, decimal deliveryFee, string trackingStatus, DeliveryAddress destination)
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

            this.trackingStatus = trackingStatus;

            TotalShipmentsCreated++;
        }
        static Shipment()
        {
            Console.WriteLine("\nShipment System Initialized\n");
            TotalShipmentsCreated = 0;
        }

        //methods
        public void UpdateDeliveryFee(decimal newFee)
        {
            if (newFee > 0)
                DeliveryFee = newFee;
        }
        public void UpdateWeight(decimal newWeight)
        {
            weight = newWeight;
        }
        public void UpdateWeight(decimal weight, decimal packingWeight)
        {
            Weight = weight + packingWeight;
        }
        public Shipment ShallowCopy()
        {
            return (Shipment)this.MemberwiseClone();
        }
        static public int GetTotalShipmentsCreated()
        {
            return TotalShipmentsCreated;
        }

        // abstract meths 
        public abstract void PrintShipment();
        public abstract Shipment CopyShipment();
        public abstract Shipment DeepCopy();
        public abstract decimal CalculateInsurance();

        public partial string GetTrackingStatus();
        private partial void OnTrackingStatusChanged(string newStatus);
        public partial void UpdateTrackingStatus();
    }
}
