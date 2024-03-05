using Hockey.Data;
using ValidationUtilities;

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

        public static ServiceRequest Parse(string line)
        {
            ServiceRequest request;
            if (Utilities.IsNullOrEmptyOrWhiteSpace(line))
            {
                throw new Exception("Line cannot be empty");
            }
            //Split the csv into the array
            string[] fields = line.Split(',');
            if (fields.Length != 7)
            {
                throw new Exception("Incorrect Number of fields");
            }
            try
            {                
                request = new ServiceRequest(fields[0], fields[1], int.Parse(fields[2]), bool.Parse(fields[3]), fields[4], fields[5],fields[6]);
            }
            catch
            {
                throw new Exception("Error while creaing the object");
            }
            return request;
        }
    }
}
