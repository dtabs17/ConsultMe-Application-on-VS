using ConsultMe;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;

int option;
List<Consultation> customerconsultations = new();
do
{
    Console.WriteLine("Welcome! Please pick any of the following: ");
    Console.WriteLine("1. Set up data");
    Console.WriteLine("2. Display list of consultation details");
    Console.WriteLine("3. Digital Vs In-person");
    Console.WriteLine("4. Display consultations for the next 7 days");
    Console.WriteLine("5. Exit");
    option = Convert.ToInt32(Console.ReadLine());
    switch (option)
    {
        case 1:
            SetUpData(customerconsultations);
            break;
        case 2:
            DisplayData(customerconsultations);
            break;
        case 3:
            DvI(customerconsultations);
            // Add code to compare digital vs. in-person consultations
            break;
        case 4:
            // Add code to display consultations for the next 7 days
            break;
        default:
            Console.WriteLine("Invalid Option Entered. Please enter a digit between 1 and 4.");
            break;
    }
}
while (option != 5);

static void SetUpData(List<Consultation> cConsultations)
{
    DateTime date = DateTime.Now; // Correct date format
    InPerson P1 = new InPerson("SparkleTech Headquarters", "Limerick", DateTime.Now, "Max", ConSultType.New, 1, 0);
    P1.FlatFee = P1.Calculate_Fee();
    InPerson P2 = new InPerson("SparkleTech Headquarters 2", "Limerick", DateTime.Now.AddDays(2), "Philip", ConSultType.New, 2, 0);
    P2.FlatFee = P2.Calculate_Fee();
    InPerson P3 = new InPerson("SparkleTech Headquarters 3", "Limerick", date, "Connor", ConSultType.New, 3, 0);
    P3.FlatFee = P3.Calculate_Fee();
    cConsultations.Add(P1);
    cConsultations.Add(P2);
    cConsultations.Add(P3);
    //bad code lol+ l + cringe
    VideoConsult V1 = new VideoConsult("Youtube", "www.waitingroom.com", "https:/www.waitingroom.com", date, "Anna", ConSultType.New, 4, 0);
    V1.FlatFee = V1.Calculate_Fee();
    VideoConsult V2 = new VideoConsult("Youtube", "www.waitingroom1.com", "https:/www.waitingroom1.com", date, "Justas", ConSultType.New, 5, 0);
    V2.FlatFee = V2.Calculate_Fee();
    VideoConsult V3 = new VideoConsult("Youtube", "www.waitingroom2.com", "https:/www.waitingroom2.com", date, "Adam", ConSultType.New, 6, 0);
    V3.FlatFee = V3.Calculate_Fee();
    cConsultations.Add(V1);
    cConsultations.Add(V2);
    cConsultations.Add(V3);

    PhoneConSult PC1 = new PhoneConSult("1111", "https:/www.recordinglink.com", date, "Anna", ConSultType.New, 7, 0);
    PC1.FlatFee = PC1.Calculate_Fee();
    PhoneConSult PC2 = new PhoneConSult("1112", "https:/www.recordinglink1.com", date, "Justas", ConSultType.New, 8, 0);
    PC2.FlatFee = PC2.Calculate_Fee();
    PhoneConSult PC3 = new PhoneConSult("1113", "https:/www.recordinglink2.com", date, "Adam", ConSultType.New, 9, 0);
    PC3.FlatFee = PC3.Calculate_Fee();
    cConsultations.Add(PC1);
    cConsultations.Add(PC2);
    cConsultations.Add(PC3);
}

static void DisplayData(List<Consultation> cConsultations)
{
    foreach (Consultation c in cConsultations)
    {
        c.Print();
        Console.WriteLine();
    }
    
}

static void DvI(List<Consultation> cConsultations)
{
    double temp = 0;
    foreach (Consultation c in cConsultations)
    {
        if (c is InPerson)
        {
            temp = temp + c.FlatFee;
        }
    }
    Console.WriteLine(temp);
}

