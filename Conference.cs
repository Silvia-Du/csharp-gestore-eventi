// See https://aka.ms/new-console-template for more information
//Creare una classe Conferenza che estende Evento, che ha anche gli attributi:
//● relatore: string
//● prezzo: double

public class Conference: Event
{
    private double _price;

    public string Speaker { get; private set; }
    public double Price { 
        get => _price;
        set
        {
            if (_price < 0) throw new Exception("Il prezzo deve essere per forza positivo");
            _price = value;
        }
    }


    public Conference(string title, DateOnly eventDate, int maxCapacity, string speaker, double price) 
    :base(title, eventDate, maxCapacity)
    {
        Speaker = speaker;
        Price = price;
    }

    private string SetPrice(double price)
    {
        return Price.ToString("0.00");
    }

    private string SetDateTime(DateOnly date)
    {
        string myDateTimeString;
        return myDateTimeString = date.ToString("yyyy-MM-dd hh:mm:ss");
    }


}



