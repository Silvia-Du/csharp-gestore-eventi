// See https://aka.ms/new-console-template for more information
//classe 

public class Event
{
    DateOnly NowTime = DateOnly.FromDateTime(DateTime.Now);

    private string _title;
    private DateOnly _date;
    private int _maxCapacity;


    public string Title
    {
        get => _title;
        set
        {
            if (value == "") throw new Exception("Il titolo deve essere maggiore di tot caratteri");

            _title = value;
        }
    }
    public DateOnly EventDate {
        get => _date;
        set
        {
            if(value < NowTime) throw new Exception("La data non può essere precedente alla data di oggi");

            _date = value;
        }
    }

    public int MaxCapacity { 
        get => _maxCapacity;
        set
        {
            if(value < 0 ) throw new Exception("Il numero di posti deve essere maggiore di 0");
            _maxCapacity = value;
        }
    }
    public int ReservedSeats { get; private set; }

    public Event(string title, DateOnly eventDate, int maxCapacity)
    {
        Title = title;
        EventDate = eventDate;
        MaxCapacity = maxCapacity;
        ReservedSeats = 0;

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
    public string setReservedSeat(int requestSeat)
    {
        int seat = requestSeat;
        string output ="null";
        if (EventDate < NowTime) throw new Exception("La data non può essere precedente alla data di oggi");

        int availableSeat = MaxCapacity - ReservedSeats;

        //int rest = Math.Abs(availableSeat) - seat;
        if (availableSeat < 0) throw new Exception("I posti disponibili non sono sufficeinti");
        else if (availableSeat == 0) output = "Non ci sono posti disponibili, ci dispiace molto!";
        else if (availableSeat > 0)
        {
            if (availableSeat >= seat)
            {
                ReservedSeats += seat;

                output = $"I tuoi posti sono stati prenotati correttamente \n " +
                    $"Posti prenotati :{seat} \nPosti ancora disponibili :{availableSeat - ReservedSeats}";

            }
            else throw new Exception($"I posti disponibili sono {availableSeat}, inserisci un numero consono alla prenotazione");
        }
        return output;

        

    }

    //disdici posti

    public string cancelReservation(int requestSeat)
    {
        //int seat = requestSeat;
        string output = "null";
        if (EventDate < NowTime) throw new Exception("La data non può essere precedente alla data di oggi");
 
        int rest = ReservedSeats - requestSeat;
        if (rest >= 0)
        {
            ReservedSeats -= requestSeat;
            output = $"Hai disdetto correttamente {requestSeat} posti";
        }
        else throw new Exception("Non ci sono abbastanza posti da togliere! ci dispiace");
        
        return output;

    }

    public string getAvailableSeats() 
    { 
        return $"I posti disponibili sono : {MaxCapacity - ReservedSeats};" +
            $"\nI posti prenotati per l'evento :{ReservedSeats}";
    
    }


    public override string ToString()
    {
        return $"Data dell'evento: {EventDate.ToString()} \nNome dell'evento: {Title}";
    }



}