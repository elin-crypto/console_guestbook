using System;
using static System.Console;
using System.IO;
using System.Collections.Generic;

namespace guestbook
{
    public class Delete
    {        
        FileControl serialize = new FileControl(); // instansiate class Filecontrol
        Menu menu = new Menu(); // instansiate class Menu
        
        public void deletePost()
        {
            bool delControl = true; 
            while(delControl) // while delControl is true, loop 
            {
                menu.WriteTitle();
                menu.ReadPosts();


                // deserialize json-data to list
                serialize.Deserialize(out string jsonData, out List<GuestPosts> userPosts);

                ForegroundColor = System.ConsoleColor.DarkGreen;
                WriteLine("Skriv id på det inlägg du vill radera");
                string chosenId = ReadLine();
                try
                {
                    int intId = int.Parse(chosenId) -1; // convert to integer and correct index number

                    ForegroundColor = System.ConsoleColor.DarkRed;
                    WriteLine($"Vill du radera inlägg {chosenId}?"); 
                    ForegroundColor = System.ConsoleColor.DarkYellow;
                    WriteLine("Tryck j för att fortsätta! \nFör att avbryta tryck på valfri knapp!");
                    ForegroundColor = System.ConsoleColor.DarkGray;
                    if(ReadLine() == "j")
                    {
                        userPosts.RemoveAt(intId);

                        // serialize list method
                        serialize.Serialize(jsonData, userPosts);
                        Clear();
                        menu.WriteTitle();
                        ForegroundColor = System.ConsoleColor.DarkCyan;
                        WriteLine("\nInlägget har raderats!\n");
                        menu.ReadPosts();
                        delControl = false; // get out of loop and quit
                    }
                    else
                    {
                        Clear();
                        ForegroundColor = System.ConsoleColor.DarkCyan;
                        WriteLine("\nHej då! Välkommen tillbaka!\n");
                        delControl = false; // get out of loop and quit
                    }
                   
                }
                catch(ArgumentOutOfRangeException) // if number isn't in list
                {
                    Clear();
                    ForegroundColor = System.ConsoleColor.DarkRed;
                    WriteLine("Du måste ange ett nummer som finns i listan. Försök igen");
                }
                catch(FormatException) // if input isn't a number
                {
                    Clear();
                    ForegroundColor = System.ConsoleColor.DarkRed;
                    WriteLine("Du måste ange en siffra. Försök igen");
                }      
            }
        }
    }
}