﻿// See https://aka.ms/new-console-template for more information
using Microsoft.VisualBasic;
using System;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Runtime.ConstrainedExecution;
using System.Text.Json;

Console.WriteLine("Crea il tuo programma di eventi! Inserisci il nome:");
EventsProgram newProgram = new(Console.ReadLine());
initProgram();

void initProgram()
{
    string userChoice = "";
    while (!userChoice.Contains("1") && !userChoice.Contains("2") && !userChoice.Contains("3"))
    {
        Console.WriteLine("Inserisci un'evento generico[1], Inserisci una Conferenza[2], esci dal programma[3]");
        userChoice = Console.ReadLine();

    }
    switch (userChoice)
    {
        case "1":
            setEvents("Quanti eventi", "event");
            break;

        case "2":
            setEvents("Quante conferenze", "conference");
            break;
        case "3": 
            Console.WriteLine("grazie per aver usato il programma");
            break;
    }
}




//programma
void setEvents( string type, string mood){


    Console.WriteLine($"{type} vuoi inserire?");
    int num = Convert.ToInt32(Console.ReadLine());


    for (int i = 0; i < num; i++)
    {
        

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

                switch (mood)
                {
                    case "event":
                        Event newEvent = newEvent = new(title, date, availableSeats);
                        newProgram.Events.Add(newEvent);
                        Console.WriteLine($"Il tuo evento: \n{newEvent.ToString()}");


                        break;

                    case "conference":

                        Console.WriteLine("Inserisci lo speaker dell'evento");
                        string speaker = Console.ReadLine();

                        Console.WriteLine("Inserisci il prezzo d'ingresso");
                        double price = Convert.ToDouble(Console.ReadLine());

                        Conference newConference = new(title, date, availableSeats, speaker, price);
                        newProgram.Events.Add(newConference);
                        Console.WriteLine($"Il tuo evento: \n{newConference.ToString()}");

                        break;
                }

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


    Console.WriteLine($"\nIl totale degli eventi in prgramma: {newProgram.GetEventsNum()}");
    Console.WriteLine(newProgram.getFullProgram());

    string userChoice = "";
    while(!userChoice.Contains("1") && !userChoice.Contains("2"))
    {
        Console.WriteLine("crea altri eventi/conferenze[1], cerca un'evento per data[2]");
        userChoice = Console.ReadLine();
    }
    switch (userChoice)
    {
        case "1":
            initProgram();
            break;
        case "2":
            Console.WriteLine("inserisci il titolo dell'evento");
            break;
    }
}

//stampa numero eventi

void findEvent()
{

    Console.WriteLine("\nInserisci la data in cui cercare eventi");
    DateOnly dateToCheck = DateOnly.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None);

    List<Event> eventsByDate = newProgram.GetEventsByDate(dateToCheck);

    Console.WriteLine(EventsProgram.GetEventsList(eventsByDate));

    string makeReservation = "";
    while (!makeReservation.Contains("y") && !makeReservation.Contains("n"))
    {
       
        Console.WriteLine("vuoi effettuare una prenotazione?[y/n]");
        makeReservation = Console.ReadLine();
    }
    switch (makeReservation)
    {
        case "1":

            initProgram();
            break;
        case "2":
            bool check = false;
            while (!check)
            {
                Console.WriteLine("inserisci il titolo dell'evento");
                try
                {
                    Event searchedEvent = newProgram.getEvent(Console.ReadLine());
                    check = true;
                    reservation(searchedEvent);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            break;
            
    }
    //funzione per cancellare tutti gli eventi
    //Console.WriteLine("Ora di addio a tutti i tuoi eventi");
    //newProgram.SetEmptyList();
}


//gestione prenotazioni
void reservation(Event newEvent)
{
    string res = "";
    while (!res.Contains("y") && !res.Contains("n"))
    {
        Console.WriteLine("Vuoi prenotare dei posti per questo evento?[y / n]");
        res = Console.ReadLine();
    }
    switch (res)
    {
        case "y":
            bool check = false;
            while (!check)
            {
                try
                {
                    Console.WriteLine("Quanti posti vorresti Prenotare?");
                    int request = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(newEvent.setReservedSeat(request));

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
                    string response = "";
                    while (!response.Contains("y") && !response.Contains("n"))
                    {
                        Console.WriteLine("Vuoi disdire dei posti per questo evento?[y / n]");
                        response = Console.ReadLine();
                    }
                    switch (response)
                    {
                        case "y":
                            Console.WriteLine("Quanti posti vorresti disdire?");
                            int request = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine(newEvent.cancelReservation(request));
                            check2 = true;
                            break;

                            case "n":
                            Console.WriteLine("Grazie per aver utilizzato questo programma");
                            break;

                    }
                   
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                }
            }
            break;

            case "n":
            Console.WriteLine("Grazie per aver usato il programma");
            break;
    }

}
// fine gestione prenotazioni




