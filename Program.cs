// See https://aka.ms/new-console-template for more information
using System;

Console.WriteLine("Hello, World!");

//classe 


public class Event
{
    DateOnly NowTime = DateOnly.FromDateTime(DateTime.Now);

    public string Title { get; set; }
    public DateOnly EventDate { get; private set; }
    public int MaxCapacity { get;}
    public int ReservedSeats { get; private set; }

    public Event(string title, string eventDate, int maxCapacity)
    {
        Title = CheckTitle(title);
        EventDate = CheckDate(eventDate);
        MaxCapacity = maxCapacity > 0? maxCapacity: checkCapacity();
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

        //int n = dt1.CompareTo(dt2);
        //If n > 0, then dt1 > dt2; if n = 0, then dt1 = dt2; if n < 0, then dt1 < dt2.
        bool check = false;
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

    private int checkCapacity()
    {
        int newMaxcapacity = 0;
        while (newMaxcapacity <= 0)
        {
            Console.WriteLine("Il numero dei posti deisponibili deve essere positivo!");
            newMaxcapacity = Convert.ToInt32(Console.ReadLine());
        }
        return newMaxcapacity;
    }


    //riserva posti
    public void setReservedSeat(int requestSeat)
    {
        int seat = requestSeat;
        int value = NowTime.CompareTo(EventDate);
        if (value >= 0)
        {
            //ECCEZIONEEE
            string message1 =  "L'evento è gia passato, ci dispiace molto!";
            //eventuale re indirizzamento
        }


        int availableSeat = MaxCapacity - ReservedSeats;
        int rest = seat - Math.Abs(availableSeat);
        if (availableSeat > seat)
        {
            ReservedSeats += seat;
        }
        else if(rest != 0)
        {
            Console.WriteLine($"I posti disponibili sono {rest}, vuoi prenotarli?[y/n]");
            string resp = Console.ReadLine();
            if (resp.Contains("y"))
            {
                ReservedSeats += rest;
                Console.WriteLine("I tuoi posti sono stati prenotati correttamente");
            }
        }
        else
        {
            //ECCEZIONEEE
            string message1 = "Non ci sono posti disponibili, ci dispiace molto!";
        }

    }

    //disdici posti

    /*
     *  DisdiciPosti: riduce del i posti prenotati del numero di posti indicati come
        parametro. Se l’evento è già passato o non ci sono i posti da disdire
        sufficienti, deve sollevare un’eccezione.
     * 
     */
    public void cancelReservation(int requestSeat)
    {
        //int seat = requestSeat;
        int value = NowTime.CompareTo(EventDate);
        if (value >= 0)
        {
            //ECCEZIONEEE
            string message1 = "L'evento è gia passato, ci dispiace molto!";
            //eventuale re indirizzamento
        }

        //se i posti riservati sono inferirori a quelli da torgliere nn è possibile

        int rest = ReservedSeats - requestSeat;
        if (rest > 0)
        {
            ReservedSeats -= requestSeat;
        }
        else
        {
            //ECCEZIONEEE
            Console.WriteLine("Non ci sono abbastanza posti da togliere! ci dispiace");
        }

    }

    public override string ToString()
    {
        return $"Data dell'evento: {EventDate.ToString()} \nNome dell'evento: {Title}";
    }



}