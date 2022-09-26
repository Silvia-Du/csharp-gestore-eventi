﻿// See https://aka.ms/new-console-template for more information
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
        
        //int rest = Math.Abs(availableSeat) - seat;
        if (availableSeat > 0)
        {
            if(availableSeat >= seat)
            {
                ReservedSeats += seat;
                
                Console.WriteLine($"I tuoi posti sono stati prenotati correttamente \n " +
                    $"Posti prenotati :{seat} \nPosti ancora disponibili :{availableSeat - ReservedSeats}");

            }
            else
            {
                Console.WriteLine($"I posti disponibili sono {availableSeat}, vuoi prenotarli?[y/n]");
                string response = Console.ReadLine();
                if (response.Contains("y"))
                {
                    ReservedSeats += availableSeat;
                    //Console.WriteLine("I tuoi posti sono stati prenotati correttamente");
                    Console.WriteLine($"I tuoi posti sono stati prenotati correttamente \n " +
                    $"Posti prenotati{availableSeat} \nNon ci sono altri posti disponibili");

                }
                else
                {
                    Console.WriteLine("Grazie per aver utilizzato il nostro servizio");
                }
            }
        }
        else if(availableSeat == 0)
        {
            Console.WriteLine("Non ci sono posti disponibili, ci dispiace molto!");
        }

        

    }

    //disdici posti

    public void cancelReservation(int requestSeat)
    {
        //int seat = requestSeat;
        int value = NowTime.CompareTo(EventDate);
        if (value >= 0)
        {
            //ECCEZIONEEE
            Console.WriteLine("L'evento è gia passato, ci dispiace molto!");
            //eventuale re indirizzamento
        }
 
        int rest = ReservedSeats - requestSeat;
        if (rest >= 0)
        {
            ReservedSeats -= requestSeat;
            Console.WriteLine($"Hai disdetto correttamente {requestSeat} posti");
            getAvailableSeats();
        }
        else
        {
            //ECCEZIONEEE
            Console.WriteLine("Non ci sono abbastanza posti da togliere! ci dispiace");
            getAvailableSeats();

        }

    }

    public void getAvailableSeats() 
    { 
        Console.WriteLine($"I posti disponibili sono: {MaxCapacity - ReservedSeats};" +
            $"\nI posti prenotati per l'evento sono :{ReservedSeats}");
    
    }


    public override string ToString()
    {
        return $"Data dell'evento: {EventDate.ToString()} \nNome dell'evento: {Title}";
    }



}