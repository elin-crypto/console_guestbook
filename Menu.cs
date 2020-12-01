using static System.Console;
using System.Collections.Generic;

namespace guestbook 
{

    public class Menu
    {
        FileControl serialize = new FileControl();

        public void WriteTitle()
        {
            ForegroundColor = System.ConsoleColor.DarkGreen;
            WriteLine();
            WriteLine("E L I N S  G Ä S T B O K !");
            WriteLine("==========================\n");
        }
        
        public void Writemenu()
        {
            
            WriteLine("Skriv i gästboken (1)");
            WriteLine("Radera inlägg (2)");
            WriteLine("Avsluta! (x)");
        }

        public void ReadPosts()
        {
            // Deserialize existing posts
            serialize.Deserialize(out string jsonData, out List<GuestPosts> userPosts);


            if(userPosts.Count > 0)
            {
                // Loop through and Write existing posts to console
                ForegroundColor = System.ConsoleColor.DarkGray; // change color on posts
                WriteLine("\nInlägg:");
                WriteLine("ID \tANVÄNDARE \tINLÄGG");
                int id = 1;
                foreach(var post in userPosts)
                {
                    Write($"{id})\t{post.Name} \t\t{post.Post}\n");
                    id++;
                }
                WriteLine();
            }else
            {
                 ForegroundColor = System.ConsoleColor.DarkGray; // change color on posts
                 WriteLine("\nGästboken är tom");
            }

        }

    }
}