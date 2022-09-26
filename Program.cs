// See https://aka.ms/new-console-template for more information
using System;

List<Event> Events = new();

Console.WriteLine("Vuoi inserire un nuovo evento?[y/n]");
string res = Console.ReadLine();
if (res.Contains("y"))
{
    initProgram();
}
else
{
    Console.WriteLine("Altre opzioni");
}


void initProgram(){

    Console.WriteLine("Inserisci il titolo dell'evento");
    string title = Console.ReadLine();
    Console.WriteLine("Inserisci la data");
    string date = Console.ReadLine();
    Console.WriteLine("Inserisci il totale dei posti disponibili per l'evento");
    int availableSeats = Convert.ToInt32(Console.ReadLine());

    
        Event newEvent = new(title, date, availableSeats);  
        Events.Add(newEvent);
        string output = newEvent.ToString();
        Console.WriteLine($"Il tuo evento: \n{output}");

    //user
    Console.WriteLine("Vuoi prenotare un posto a questo evento?[y/n]");
    string res = Console.ReadLine();

    if (res.Contains("y"))
    {
        reservation(newEvent);
    }


}

void reservation(Event newEvent)
{
    Console.WriteLine("Quanti posti vorresti Prenotare?");
    int request = Convert.ToInt32(Console.ReadLine());
    newEvent.setReservedSeat(request);
}


