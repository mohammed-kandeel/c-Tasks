namespace C48_G02_OOP04
{
    internal static class DeliveryHelper
    {
        static public void PrintShipmentDetails(Shipment shipment)
        {
            if (shipment is not null)
                shipment.PrintShipment();
        }
    }
}
