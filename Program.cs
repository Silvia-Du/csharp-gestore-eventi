// See https://aka.ms/new-console-template for more information
using Microsoft.VisualBasic;
using System;
using System.Reflection.Metadata;

Console.WriteLine("crea la tua prima lista eventi! Inserisci il Nome della lista");
EventsProgram newProgram = new (Console.ReadLine());

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

    Event newEvent;
    bool check = false;
    while (!check)
    {
        try
        {
            Console.WriteLine("Inserisci il titolo dell'evento");
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
            reservation(newEvent);

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

}

void reservation(Event newEvent)
{
    Console.WriteLine("Vuoi prenotare un posto a questo evento?[y / n]");
    string res = Console.ReadLine();
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
                if (response.Contains("y"))
                {
                    Console.WriteLine("Quanti posti vorresti disdire?");
                    int request = Convert.ToInt32(Console.ReadLine());
                    string output = newEvent.cancelReservation(request);
                    Console.WriteLine(request);
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
        Console.WriteLine("Altre opzioni");

    }
    else
    {
        Console.WriteLine("risposta non valida");
    }

}

void deleteReservation(Event newEvent)
{
    
}


