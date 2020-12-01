using static System.Console;
using System.IO;
using System.Collections.Generic;

namespace guestbook
{
    public class Add
    {
        FileControl serialize = new FileControl(); // instansiate class
        GuestPosts GuestPost = new GuestPosts();
        Menu menu = new Menu();

        public void createPost()
        {
            
            string name;
            string post;

            do
            {
                ForegroundColor = System.ConsoleColor.DarkGreen;
                menu.WriteTitle();
                WriteLine("Skriv in ditt namn: ");
                name = ReadLine();
                if(name == "")
                {
                    ForegroundColor = System.ConsoleColor.Red;
                    WriteLine("Du får inte lämna namnet tomt: ");
                    ForegroundColor = System.ConsoleColor.DarkGreen;
                    Write("Skriv ditt namn:");
                    name = ReadLine();
                }
                
                WriteLine("Skriv ett inlägg: ");
                post = ReadLine();
                if(post == "")
                {
                    ForegroundColor = System.ConsoleColor.Red;
                    WriteLine("Du måste skriva något i inlägget: ");
                    ForegroundColor = System.ConsoleColor.DarkGreen;
                    post = ReadLine();
                }
            }
            while(name == "" || post == "");
           
            // deserialize method
            serialize.Deserialize(out string jsonData, out List<GuestPosts> userPosts);

            // add new post to list
            // List<GuestPosts> GuestPosts = new List<GuestPosts>();
            userPosts.Add(new GuestPosts()
            {
                Name = name,
                Post = post,
            }); 

            // serialize list method
            serialize.Serialize(jsonData, userPosts);
            Clear();

            menu.WriteTitle();
            ForegroundColor = System.ConsoleColor.DarkCyan;
            WriteLine("Ditt inlägg har sparats!\n");
            menu.ReadPosts();
        }
    }
}