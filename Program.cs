// See https://aka.ms/new-console-template for more information
using Microsoft.VisualBasic;
using System;
using System.Reflection.Metadata;

Console.WriteLine("Crea il tuo primo programma di eventi! Inserisci il nome del programma :");
EventsProgram newProgram = new (Console.ReadLine());


Console.WriteLine("Quanti eventi vuoi inserire?");
int eventsNum = Convert.ToInt32(Console.ReadLine());

initProgram(eventsNum);

void initProgram(int num){
    for (int i = 0; i < num; i++)
    {
        Event newEvent;
        bool check = false;
        while (!check)
        {
            try
            {
                Console.WriteLine($"Inserisci il titolo del {i + 1}' evento");
                string title = Console.ReadLine();

                Console.WriteLine("Inserisci la data");
                DateOnly date = DateOnly.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None);

                Console.WriteLine("Inserisci il totale dei posti disponibili per l'evento");
                int availableSeats = Convert.ToInt32(Console.ReadLine());

                newEvent = new(title, date, availableSeats);

                newProgram.Events.Add(newEvent);
                string output = newEvent.ToString();
                Console.WriteLine($"Il tuo evento: \n{output}");
                check = true;
                //reservation(newEvent);
                //é la funzione che chiede se si vuole prenotare / disdire posti, l'ho commentata per testare il resto

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

}

//stampa numero eventi

Console.WriteLine($"\nIl totale degli eventi in prgramma: {newProgram.GetEventsNum()}");
Console.WriteLine(newProgram.getFullProgram());

Console.WriteLine("\nInserisci la data in cui cercare eventi");
DateOnly dateToCheck = DateOnly.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None);
List<Event> eventsByDate = newProgram.GetEventsByDate(dateToCheck);

Console.WriteLine(EventsProgram.GetEventsList(eventsByDate));
Console.WriteLine("Ora di addio a tutti i tuoi eventi");
newProgram.SetEmptyList();


//gestione prenotazioni
void reservation(Event newEvent)
{
    Console.WriteLine("Vuoi prenotare un posto a questo evento?[y / n]");
    string res = Console.ReadLine();
    while (!res.Contains("y") && !res.Contains("n"))
    {
        Console.WriteLine("risposta non valida, Vuoi prenotare dei posti per questo evento?[y / n]");
        res = Console.ReadLine();
    }
    if (res.Contains("y"))
    {
        bool check = false;
        while (!check)
        {
            try
            {
                Console.WriteLine("Quanti posti vorresti Prenotare?");
                int request = Convert.ToInt32(Console.ReadLine());
                 string output = newEvent.setReservedSeat(request);
                Console.WriteLine(output);

                check = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
        }

        bool check2 = false;
        while (!check2)
        {
            try
            {
                Console.WriteLine("Vuoi disdire dei posti per questo evento?[y / n]");
                string response = Console.ReadLine();
                while (!response.Contains("y") && !response.Contains("n"))
                {
                    Console.WriteLine("risposta non valida, Vuoi disdire dei posti per questo evento?[y / n]");
                    response = Console.ReadLine();
                }
                if (response.Contains("y"))
                {
                    Console.WriteLine("Quanti posti vorresti disdire?");
                    int request = Convert.ToInt32(Console.ReadLine());
                    string output = newEvent.cancelReservation(request);
                    Console.WriteLine(output);
                }
                check2 = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
        }

    }
    else if (res.Contains("n"))
    {
        Console.WriteLine("Grazie per aver usato il programma");

    }
 

}



