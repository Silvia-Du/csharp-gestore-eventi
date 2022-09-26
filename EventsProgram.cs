// See https://aka.ms/new-console-template for more information
//Nel costruttore valorizzare il titolo, passato come parametro, e inizializzate la lista di eventi
//come una nuova Lista vuota di eventi.

using System.Collections.Generic;

public class EventsProgram
{
    public string Title { get; private set; }
    public List<Event> Events;

    public EventsProgram(string title)
    {
        Title = title;
        Events = new();

    }

    public void AddNewEvent(Event newEvent)
    {
        
        Events.Add(newEvent);
        Console.WriteLine("Evento aggiunto correttamente alla lista");
    }

    public List<Event> GetEventsByDate(DateOnly date)
    {
        List<Event> eventsByDate = new();
        foreach (Event e in Events)
        {
            if(e.EventDate == date)
            {
                eventsByDate.Add(e);
            }
        }
        return eventsByDate;
        //il return mi serve per fare azioni di la 
    }

    //● un metodo statico che restituisca la rappresentazione in stringa della vostra lista di eventi.
    public static string GetEventsList(List<Event> list)
    {
            string events ="";
        if(list.Count >= 0)
        {
            events += "Ecco tutti gli eventi: \n";
            int count = 0;
            foreach (Event e in list)
            {
                ++count;
                events += $"-{count}: {e.ToString()}; \n {e.getAvailableSeats()}; \n";
            }
        }
        else
        {
            events = "Nessun evento programmato";
        }
        return events;
        
    }

    //un metodo che restituisce quanti eventi sono presenti nel programma eventi
    //attualmente.
    public int GetEventsNum()
    {
        return Events.Count();
    }

    //● un metodo che svuota la lista di eventi.
    public void SetEmptyList()
    {
        
        Events.Clear();
    }

//    ● un metodo che restituisce una stringa che mostra il titolo del programma e tutti gli
//eventi aggiunti alla lista.
    public string getFullProgram()
    {
        string output = $"\nNome programma evento: {Title}; \n";
        foreach (Event e in Events)
        {
            output += $"{e.EventDate} - {e.Title}; \n";
        }

        return output;
    }
}


