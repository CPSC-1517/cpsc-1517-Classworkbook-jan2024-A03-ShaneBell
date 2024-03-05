namespace BlazerSampleApp.Data
{
    public class ServiceRequest
    {
        public string? ContactName { get; set; }
        public string? PhoneNumber { get; set; }
        public int YearsAsCustomer { get; set; }
        public bool IsCurrentCustomer { get; set; }
        public string? ServiceType { get; set; }
        public string? Reason { get; set; }
        public string? RequestDetails { get; set; }

        public ServiceRequest(string? contactName, string? phoneNumber, int yearsAsCustomer, bool isCurrentCustomer, string? serviceType, string? reason, string? requestDetails)
        {
            ContactName = contactName;
            PhoneNumber = phoneNumber;
            YearsAsCustomer = yearsAsCustomer;
            IsCurrentCustomer = isCurrentCustomer;
            ServiceType = serviceType;
            Reason = reason;
            RequestDetails = requestDetails;
        }

        public override string ToString()
        {
            return $"{ContactName},{PhoneNumber},{YearsAsCustomer},{IsCurrentCustomer},{ServiceType},{Reason},{RequestDetails}";
        }
    }
}
