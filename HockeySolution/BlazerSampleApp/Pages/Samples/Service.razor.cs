﻿namespace BlazerSampleApp.Pages.Samples
{
    public partial class Service
    {
        public string? ContactName { get; set; }
        public string? PhoneNumber { get; set; }
        public int YearsAsCustomer { get; set; }
        private bool IsCurrentCustomer { get; set; }
        private string? ServiceType { get; set; }
        public string? Reason { get; set; }
        public string? RequestDetails { get; set; }
        public string? Output { get; set; }
        public bool Success { get; set; } = false;

        //Instantiate a new Dictionary
        public Dictionary<string, string> Errorlist { get; set; } = new();

        public void DisplayInfo()
        {

            Success = false;

            Errorlist.Clear();
            //Validate Contact Name
            if(string.IsNullOrWhiteSpace(ContactName))
            {
                Errorlist.Add("contact_name", "Contact name cannot be empty");
            }

            if (Errorlist.Count == 0)
            {
                Success = true;
                Output = $"<strong>ContactName</strong>: {ContactName}, <strong>PhoneNumber:</strong> {PhoneNumber}, Years as Customer: {YearsAsCustomer}, Is Current Customer: {IsCurrentCustomer}, Service Type: {ServiceType}, Reason: {Reason}, Request Details: {RequestDetails}";

                //Reset the fields
                ContactName = "";
                PhoneNumber = "";
                YearsAsCustomer = 0;
                IsCurrentCustomer = false;
                ServiceType = null;
                Reason = "";
                RequestDetails = "";
            }
        }


    }
}
