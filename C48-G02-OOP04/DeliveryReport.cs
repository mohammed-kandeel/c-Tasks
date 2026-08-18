namespace C48_G02_OOP04
{
    internal static class DeliveryReport
    {
        static public void PrintShipment(ITrackable shipment)
        {
            Console.WriteLine($"Tracking Status: {shipment.GetTrackingStatus()}");
            Console.WriteLine($"Hash Code: {shipment.GetHashCode()}");
        }
        static public void PrintInsurance(IInsurable shipment)
        {
            Console.WriteLine($"Insurance: {shipment.CalculateInsurance()}");
        }
    }
}
