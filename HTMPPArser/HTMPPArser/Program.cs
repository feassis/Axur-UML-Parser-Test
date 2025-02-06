// See https://aka.ms/new-console-template for more information
using System;

Console.WriteLine("Starting Parse");

string URL = "https://felipeassis2002.wixsite.com/felipeassisportifoli/";
List<string> deepestTexts = await HTMLParser.GetDeepestText(URL);

Console.WriteLine("Deepest Text: ");

foreach (var text in deepestTexts)
{
    Console.WriteLine(text);
}