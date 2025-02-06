using System;
using System.Collections.Generic;
using System.Net.Http;
using HtmlAgilityPack;
using System.Threading.Tasks;


class HTMLParser
{

    public static async Task<List<string>> GetDeepestText(string url)
    {
        Console.WriteLine("Parse Started");
        try
        {
            //Console.WriteLine("Entered Try");
            var html = await new HttpClient().GetStringAsync(url);
            
            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            List<string> results = new List<string>();
            int maxDepth = 0;


            void DFS(HtmlNode node, int depth)
            {
                //Console.WriteLine($"Entered DFS - depth: {depth}");
                if (node.ChildNodes.Count == 0)
                {
                    //Console.WriteLine($"Node inner Text: {node.InnerText}" );
                    if (depth > maxDepth)
                    {
                        maxDepth = depth;
                        results.Clear();
                    }
                    if (depth == maxDepth)
                    {
                        results.Add(node.InnerText);
                    }
                }
                foreach (var child in node.ChildNodes)
                {
                    DFS(child, depth + 1);
                }
            }

            DFS(doc.DocumentNode, 0);
            return results;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return new List<string>();
        }
    }
}
