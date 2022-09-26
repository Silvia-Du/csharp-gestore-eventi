// See https://aka.ms/new-console-template for more information
using System;

Console.WriteLine("Hello, World!");

//classe 


//DateOnly data1 = new (2022, 1, 1);
//DateOnly StartTime = DateOnly.FromDateTime(DateTime.Now);
//Console.WriteLine(StartTime);
//Console.WriteLine(data1);
//int chcek = StartTime.CompareTo(data1);
//Console.WriteLine(chcek);
//DateOnly title = DateOnly.FromDateTime(Console.ReadLine());



//int n = dt1.CompareTo(dt2);
//If n > 0, then dt1 > dt2; if n = 0, then dt1 = dt2; if n < 0, then dt1 < dt2.




public class Event
{
    string Title { get; set; }
    DateOnly EventDate { get; set; }
    int MaxCapacity { get;}
    int ReservedSeats { get;}

    public Event(string title, string eventDate, int maxCapacity)
    {
        Title = CheckTitle(title);
        EventDate = CheckDate(eventDate);
        MaxCapacity = maxCapacity;
        ReservedSeats = 0;

    }

    private string CheckTitle(string title)
    {
        while(title.Length < 4)
        {
            Console.WriteLine("il titolo deve avere almeno 5 caratteri");
            title = Console.ReadLine();
        }

        return title;

    }

    //verifica confronto tra date
    private DateOnly CheckDate(string eventDate)
    {

        DateOnly date = CheckFormatDate(eventDate);

        bool check = false;
        DateOnly NowTime = DateOnly.FromDateTime(DateTime.Now);
        int value = NowTime.CompareTo(date);
        while (!check)
        {
            value = NowTime.CompareTo(date);
            if (value >= 0)
            {
                Console.WriteLine("La data deve essere successiva la data di oggi!");
                string dateTocheck = Console.ReadLine();
                date = CheckFormatDate(dateTocheck);

            }
            else
            {
                check = true;
            }
        }

        return date;

    }


    //verifica formato stringa e conversione
    private DateOnly CheckFormatDate(string date)
    {
        DateTime dt;
        DateOnly eventDate = new();
        while (!DateTime.TryParseExact(date, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
        {
            Console.WriteLine("Data non valida, il formato deve essere dd/MM/YYYY");
            date = Console.ReadLine();
        }
        return eventDate = DateOnly.Parse(date);
    }


}