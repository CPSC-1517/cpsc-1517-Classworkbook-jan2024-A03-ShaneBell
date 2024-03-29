﻿using BlazerSampleApp.Data;

namespace BlazerSampleApp.Pages.Samples
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

        public bool Show { get; set; } = false;
        //Create a property called ServiceRequests to hold a list of ServiceRequest objects
        public List<ServiceRequest> ServiceRequests { get; set; } = new();

        //Instantiate a new Dictionary
        public Dictionary<string, string> Errorlist { get; set; } = new();

        string csvFilePath = @".\Data\Requests.csv";

        public void DisplayInfo()
        {

            Success = false;

            Errorlist.Clear();
            //Validate Contact Name
            if (string.IsNullOrWhiteSpace(ContactName))
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
        public void AddToList()
        {
            Show = false;
            ServiceRequests.Add(new ServiceRequest(ContactName, PhoneNumber, YearsAsCustomer, IsCurrentCustomer, ServiceType, Reason, RequestDetails));
            //Reset the fields
            ContactName = "";
            PhoneNumber = "";
            YearsAsCustomer = 0;
            IsCurrentCustomer = false;
            ServiceType = null;
            Reason = "";
            RequestDetails = "";
        }
        public void DisplayList()
        {
            Errorlist.Clear();
            if (ServiceRequests.Count == 0)
            {
                Errorlist.Add("empty_list", "There is no data in the list");
            }
            else
            {
                Show = true;
            }
        }
        public void ClearList()
        {
            ServiceRequests.Clear();
            Show = false;
        }

        public void SaveListToFile()
        {
            //Loop through the list
            //Create a csv string of each object in the list
            //Write the csv to the file

            using (StreamWriter writer = new StreamWriter(csvFilePath, true))
            {
                foreach (ServiceRequest aRequest in ServiceRequests)
                {
                    writer.WriteLine(aRequest.ToString());
                }
            }
        }
        public void ReadFileToList()
        {
            string[] userData;
            userData= System.IO.File.ReadAllLines(csvFilePath);
            //Loop through the array
            //For each csv string in each element, parse to a Service Request object and Add to the ServiceRequests List
            foreach(string line in userData)
            {
                ServiceRequests.Add(ServiceRequest.Parse(line));
            }
        }

    }
}
