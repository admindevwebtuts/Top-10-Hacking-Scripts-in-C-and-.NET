using System;
using System.Net;
using HtmlAgilityPack;

class Program
{
    static void Main()
    {
        var web = new HtmlWeb();
        var document = web.Load("https://example.com");
        var nodes = document.DocumentNode.SelectNodes("//img");

        WebClient client = new WebClient();

        int i = 1;
        foreach (var node in nodes)
        {
            string imageURL = node.GetAttributeValue("src", null);

            if (imageURL != null)
            {
                Console.WriteLine($"Downloading image: {imageURL}");
                client.DownloadFile(imageURL, $"Image{i}.jpg");
                i++;
            }
        }
    }
}
