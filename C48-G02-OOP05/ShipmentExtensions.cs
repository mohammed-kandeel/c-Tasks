namespace C48_G02_OOP05
{
    internal static class ShipmentExtensions
    {
        static public string GetSummary(this Shipment shipment)
        {
            if (shipment is null)
                throw new NullReferenceException();

            return $"{shipment.TrackingCode} | {shipment.GetType().Name.Replace("Shipment", "")} | {shipment.Weight} KG | {shipment.GetTrackingStatus()}";
        }
        static public bool IsDelivered(this Shipment shipment)
        {
            if (shipment is null)
                throw new NullReferenceException();

            return shipment.GetTrackingStatus().ToLower() == "Delivered".ToLower() ? true : false;
        }
    }
}
