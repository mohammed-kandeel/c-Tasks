namespace C48_G02_OOP05
{
    internal class Driver
    {
        //prop
        public string Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }

        //ctor
        public Driver(string id, string fullName, string phoneNumber)
        {
            Id = id;
            FullName = fullName;
            PhoneNumber = phoneNumber;
        }
    }
}
