namespace C48_G02_OOP01
{
    internal struct DeliveryCenter
    {
        private Shipment[] shipments;

        public DeliveryCenter()
        {
            shipments = new Shipment[10];
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
                return default;
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
                        if (trackingCode == shipments[i].TrackingCode)
                        {
                            return shipments[i];
                        }
                    }
                }
                return default;
            }
        }

        //methods
        public bool AddShipment(Shipment shipment)
        {
            if (shipments is not null)
            {
                for (int i = 0; i < shipments.Length; i++)
                {
                    if (string.IsNullOrWhiteSpace(shipments[i].TrackingCode))
                    {
                        shipments[i] = shipment;
                        return true;
                    }
                }
            }
            return false;
        }

    }


}
