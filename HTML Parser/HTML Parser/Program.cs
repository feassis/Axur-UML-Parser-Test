
using System;
using System.Collections.Generic;
using System.Net.Http;
using HtmlAgilityPack;
using System.Threading.Tasks;




static async Task Main()
{
    Console.WriteLine("Starting parse...");
    /*string URL = "https://www.w3.org/TR/html5/";

    var deepestTexts = await HTMLParser.GetDeepestText(URL);

    Console.WriteLine("Deepest Text: ");

    foreach (var text in deepestTexts)
    {
        Console.WriteLine(text);
    }*/
}



class HTMLParser
{

    public static async Task<List<string>> GetDeepestText(string url)
    {
        try
        {
            var html = await new HttpClient().GetStringAsync(url);
            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            List<string> results = new List<string>();
            int maxDepth = 0;


            void DFS(HtmlNode node, int depth)
            {
                if (node.ChildNodes.Count == 0)
                {
                    if (depth > maxDepth)
                    {
                        maxDepth = depth;
                        results.Clear();
                    }
                    if (depth == maxDepth)
                    {
                        results.Add(node.InnerText.Trim());
                    }
                }
                foreach (var child in node.ChildNodes)
                {
                    DFS(child, depth + 1);
                }
            }

            return results;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return new List<string>();
        }
    }
}