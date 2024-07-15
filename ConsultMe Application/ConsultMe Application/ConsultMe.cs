using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsultMe
{
    public enum ConSultType
    {
        New,
        FollowUp,
        Referral
    }
    public abstract class Consultation
    {
        public DateTime DateTime { get; set; }
        public string ConsultantName { get; set; }

        public ConSultType ConsultType { get; set; }
        public int ServiceUserID { get; set; }
        public double FlatFee { get; set; }

        public Consultation(DateTime dateTime, string consultantName, ConSultType consultType, int serviceUserID, double flatFee)
        {
            DateTime = dateTime;
            ConsultantName = consultantName;
            ConsultType = consultType;
            ServiceUserID = serviceUserID;
            FlatFee = flatFee;
        }

        public virtual void Print()
        {
            Console.WriteLine($"Date: {DateTime}");
            Console.WriteLine($"Consultant name: {ConsultantName}");
            Console.WriteLine($"Consultant type: {ConsultType}");
            Console.WriteLine($"Service User ID: {ServiceUserID}");
            Console.WriteLine($"Flat fee: {FlatFee}");
        }
        public abstract double Calculate_Fee();
    }

    public class InPerson : Consultation
    {
        public string Site;
        public string Location;

        public InPerson(string site, string location, DateTime dateTime, string consultantName, ConSultType consultType, int serviceUserID, double flatFee) : base(dateTime, consultantName, consultType, serviceUserID, flatFee)
        {
            Site = site;
            Location = location;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Site: {Site}");
            Console.WriteLine($"Location: {Location}");
        }
        public override double Calculate_Fee()
        {
            double fee = 100;
            fee = (0.5 * fee) + fee;
            return fee;
        }


    }

    public abstract class Digital : Consultation
    {
        public string RecordingLink;
        public Digital(string recordinglink, DateTime dateTime, string consultantName, ConSultType consultType, int serviceUserID, double flatFee) : base(dateTime, consultantName, consultType, serviceUserID, flatFee)
        {
            RecordingLink = recordinglink;
        }
        public override void Print()
        {
            base.Print(); // Call the base class Print method to print shared properties
            Console.WriteLine("RecordingLink: " + RecordingLink); // Print the specific property
        }
    }


    public class VideoConsult : Digital
    {
        public string Platform;
        public string LinkToWaitingRoom;

        public VideoConsult(string platform, string linktowaitingroom, string recordinglink, DateTime dateTime, string consultantName, ConSultType consultType, int serviceUserID, double flatFee) : base(recordinglink, dateTime, consultantName, consultType, serviceUserID, flatFee)
        {
            Platform = platform;
            LinkToWaitingRoom = linktowaitingroom;
        }

        public override double Calculate_Fee()
        {
            double fee = 100;
            fee = fee * 0.8; //20% discount
            return fee;
        }
        public override void Print()
        {
            base.Print(); // Call the base class Print method to print shared properties
            Console.WriteLine("Platform: " + Platform); // Print the specific property
            Console.WriteLine("LinkToWaitingRoom: " + LinkToWaitingRoom); // Print the specific property

        }
    }



    public class PhoneConSult : Digital
    {
        public string CallerID;

        public PhoneConSult(string calllerid, string recordinglink, DateTime dateTime, string consultantName, ConSultType consultType, int serviceUserID, double flatFee) : base(recordinglink, dateTime, consultantName, consultType, serviceUserID, flatFee)
        {
            CallerID = calllerid;
        }

        public override double Calculate_Fee()
        {
            double fee = 100;
            fee = fee * 0.7; //30% discount
            return fee;
        }
        public override void Print()
        {
            base.Print(); // Call the base class Print method to print shared properties
            Console.WriteLine("CallerID: " + CallerID); // Print the specific property
        }
    }

}
