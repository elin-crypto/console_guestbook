using System;
using static System.Console;
using System.IO;
using System.Collections.Generic;

namespace guestbook
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // instansiate classes
            Menu menu = new Menu();
            FileControl serialize = new FileControl();

            Add addPost = new Add(); // create new post
            Delete deletePost = new Delete(); // delete post
            string jsonPath = @"posts.json";

            // create bool 
            bool showMenu = true;
            
            while(showMenu)
            {
                Clear();
                menu.WriteTitle();
                menu.Writemenu();
                if(!File.Exists(jsonPath))
                {
                    FileStream fs = File.Create(jsonPath);
                }

                menu.ReadPosts(); // write all posts to console
                
                // switch to handle different input from menu
                switch(ReadLine().ToLower())
                {
                    case "1": 
                        Clear();
                        addPost.createPost(); 
                        showMenu = false;
                        break;
                    case "2":
                        Clear();
                        deletePost.deletePost();
                        showMenu = false;
                        break;
                    case "x":
                        Clear();
                        ForegroundColor = ConsoleColor.DarkCyan;
                        WriteLine("\n\nTack för denna gång, hej då!\n");
                        showMenu = false;
                        break;
                    default:
                        WriteLine("Du måste välja 1 2 eller x");
                        break;
                }
            }
        }
    }
}
