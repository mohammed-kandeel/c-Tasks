namespace C48_G02_OOP04
{
    internal class DeliveryCenter
    {

        //field
        private Shipment[] shipments;
        private int size = 20;

        //prop
        public string CenterName { get; set; }
        public Driver Driver { get; set; }

        //
        public Shipment[] Shipments { get { return shipments; } }


        //ctor
        public DeliveryCenter()
        {
            shipments = new Shipment[size];
        }

        //Indexers
        public Shipment this[int index]
        {
            get
            {
                if (shipments is not null && index >= 0 && index < shipments.Length)
                {
                    return shipments[index];
                }
                return default!;
            }
            set
            {
                if (shipments is not null && index >= 0 && index < shipments.Length)
                    shipments[index] = value;
            }
        }
        public Shipment this[string trackingCode]
        {
            get
            {
                if (shipments is not null)
                {
                    for (int i = 0; i < shipments.Length; i++)
                    {
                        if (shipments[i] is not null && trackingCode == shipments[i].TrackingCode)
                        {
                            return shipments[i];
                        }
                    }
                }
                return default!;
            }
        }

        //methods
        public bool AddShipment(Shipment shipment)
        {
            if (shipments is not null)
            {
                for (int i = 0; i < shipments.Length; i++)
                {
                    if (shipments[i] is null)
                    {
                        shipments[i] = shipment;
                        return true;
                    }
                }
            }
            return false;
        }
        public bool RemoveShipment(string trackingCode)
        {
            if (shipments is not null)
            {
                for (int i = 0; i < size; i++)
                {
                    if (trackingCode == shipments[i].TrackingCode)
                    {
                        shipments[i] = default!;
                        return true;
                    }
                }

            }
            return false;
        }
        public void PrintAllShipments()
        {
            if (shipments is null) return;
            Console.WriteLine("\n----- All Shipments -----");
            foreach (Shipment shipment in shipments)
            {
                if (shipment is not null)
                {
                    shipment.PrintShipment();
                    Console.WriteLine("\n-------------------------");
                }
            }
        }
        public void PrintTrackingStatuses()
        {
            Console.WriteLine("\n=========================\n");
            Console.WriteLine("Tracking Status\n");
            foreach (ITrackable t in shipments)
            {
                if (t is not null)
                    Console.WriteLine(t.GetTrackingStatus() + "\n");
            }
        }
        public void PrintInsurable()
        {
            Console.WriteLine("\n=========================\n");
            Console.WriteLine("Insurance\n");
            foreach (IInsurable i in shipments)
            {
                if (i is not null)
                    Console.WriteLine($"{i.GetType().Name} Insurance : {i.CalculateInsurance()} EGP \n");
            }
        }
    }
}
