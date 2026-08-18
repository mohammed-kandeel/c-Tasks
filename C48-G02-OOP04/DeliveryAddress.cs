namespace C48_G02_OOP04
{
    internal struct DeliveryAddress
    {
        public string city;
        public string street;
        public int buildingNumber;

        public DeliveryAddress(string city, string street, int buildingNumber)
        {
            this.city = city;
            this.street = street;
            this.buildingNumber = buildingNumber;
        }

        public string GetFullAddress()
        {
            return $"City: {city} - Street: {street} - Building Number: {buildingNumber}";
        }

    }
}
