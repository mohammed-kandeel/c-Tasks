namespace C48_G02_OOP05
{
    internal abstract partial class Shipment : ITrackable, IInsurable
    {
        //fields
        private string trackingStatus;

        //meths
        public partial string GetTrackingStatus()
        {
            return trackingStatus;
        }
        private partial void OnTrackingStatusChanged(string newStatus)
        {
            trackingStatus = newStatus;
        }
        public partial void UpdateTrackingStatus()
        {
            if (trackingStatus == null)
                OnTrackingStatusChanged("In Transit");
            else if (trackingStatus == "In Transit")
                OnTrackingStatusChanged("Out For Delivery");
            else if (trackingStatus == "Out For Delivery")
                OnTrackingStatusChanged("Delivered");
            else
            {
                Console.WriteLine("The shipment has been delivered.\n");
                return;
            }
            Console.WriteLine($"Tracking status changed to: {trackingStatus}\n");
        }
    }
}
