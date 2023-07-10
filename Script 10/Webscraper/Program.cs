using System;
using HtmlAgilityPack;

class Program
{
    static void Main()
    {
        var web = new HtmlWeb();
        var document = web.Load("https://example.com");
        var nodes = document.DocumentNode.SelectNodes("//p");

        foreach (var node in nodes)
        {
            Console.WriteLine(node.InnerHtml);
        }
    }
}
