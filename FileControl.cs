using static System.Console;
using Newtonsoft.Json;
using System.Collections.Generic;


namespace guestbook
{

    public class FileControl
    {
        public string jsonPath = @"posts.json"; // search path to json-file

        // serialize json-data
        public void Serialize(string jsonData, List<GuestPosts> userPosts)
        {
            // serialize data and save to json
            jsonData = JsonConvert.SerializeObject(userPosts);
            System.IO.File.WriteAllText(jsonPath, jsonData);
        
        }

        public void Deserialize(out string jsonData, out List<GuestPosts> userPosts)
        {
            var json = System.IO.File.ReadAllText(jsonPath);

            // deserialize and make list
            var DeserializedPost = JsonConvert.DeserializeObject<List<GuestPosts>>(json);

            jsonData = json;
            userPosts = DeserializedPost;
        }
    }
}