using System.Diagnostics;
using System.Xml.Linq;
using Microsoft.Win32.SafeHandles;
using XmlElementNuker;

Console.Clear();
Console.WriteLine("Starting XML Element Nuker...");

List<string> toBeRemoved = [];
string AppDir = AppDomain.CurrentDomain.BaseDirectory;
string NukeFolder = Path.Combine(AppDir, "ToNuke");
string FinishedFolder = Path.Combine(AppDir, "Nuked");
string ElementsFile = Path.Combine(AppDir, "Elements.txt");
bool keyPressMatch = false;

if (!File.Exists(ElementsFile))
{
    try
    {
        Console.WriteLine("Elements.txt file not found, creating one.");
        Console.WriteLine("Would you like the list populated with default items? [Y] or [N]");

        keyPressMatch = false;

        while (!keyPressMatch)
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.Y:
                    keyPressMatch = true;   
                    File.WriteAllText(ElementsFile, GetDefaultElements.AsString());
                    break;
                case ConsoleKey.N:
                    keyPressMatch = true;   
                    File.WriteAllText(ElementsFile, "");    
                    break;
                default:
                    break;       
            }
        }
    }
    catch (Exception e)
    {
        Console.WriteLine("Failed to create Elements.txt file.");
        Console.WriteLine(e);
        Environment.Exit(1);
    }
    
    Console.Clear();
    
    Console.WriteLine("Populate the Elements.txt file with each element you wish removed.  One element per line.");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("Example, adding the following");
    Console.WriteLine("PCU");
    Console.WriteLine("TieredUpdateTimes");
    Console.ResetColor();
    Console.WriteLine("Will remove all <PCU> and <TieredUpdateTimes> elements from the xml files.");
    
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine("You can enter the elements into the file now and then press [C] to continue, or press [X] to exit.");

    keyPressMatch = false;
    while (!keyPressMatch)
    {
        switch (Console.ReadKey(true).Key)
        {
            case ConsoleKey.X:
                keyPressMatch = true;
                Environment.Exit(0);
                break;
            case ConsoleKey.C:
                keyPressMatch = true;
                break;
            default:
                break;
        }
    }
    
    Console.Clear();
    
    Console.WriteLine("Loading elements to remove from Elements.txt");
    string[] lines = File.ReadAllLines(ElementsFile);
    foreach (string line in lines)
    {
        toBeRemoved.Add(line);
    }
}

if (!Directory.Exists(NukeFolder))
{
    Console.WriteLine("Creating directory ToNuke in the app directory, place the sbc files you wish processed in here.");
    Directory.CreateDirectory(NukeFolder);
}

if (!Directory.Exists(FinishedFolder))
    Directory.CreateDirectory(FinishedFolder);

string[] files = [];

bool retryToNukeFileCheck = true;
while (retryToNukeFileCheck)
{
    files = Directory.GetFiles(NukeFolder);
    if (files.Length == 0)
    {
        Console.WriteLine("No xml files to process in ToNuke folder.");
        Console.WriteLine("Press [X] to exit, or [R] to Retry...");

        keyPressMatch = false;
        while (!keyPressMatch)
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.X:
                    retryToNukeFileCheck = false; 
                    Environment.Exit(0);
                    break;
                case ConsoleKey.R:
                    Console.WriteLine("Retrying...");
                    keyPressMatch = true;
                    break;
                default:
                    break;
            }
        }
    } else retryToNukeFileCheck = false;
}

Console.Clear();

string[] finishedfiles = Directory.GetFiles(FinishedFolder);
if (finishedfiles.Length != 0)
{
    Console.WriteLine("XML files already exists in the Nuked folder.  They will be lost.");
    Console.WriteLine("Press [X] to exit, or [C] to Continue...");

    keyPressMatch = false;
    while (!keyPressMatch)
    {
        switch (Console.ReadKey(true).Key)
        {
            case ConsoleKey.X:
                keyPressMatch = true;
                Environment.Exit(0);
                break;
            case ConsoleKey.C:
            {
                keyPressMatch = true;
                foreach (string file in finishedfiles)
                {
                    try
                    {
                        File.Delete(file);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Failed to delete file: " + file);
                        Console.WriteLine(e);
                        Environment.Exit(1);
                    }
                }
                break;
            }
            default:
                break;
        }
    }
}

Console.Clear();

foreach (string file in files)
{
    try
    {
        Stopwatch sw = new ();
        sw.Start();
        
        if (!File.Exists(file)) continue;
        Console.WriteLine();
        XDocument doc = XDocument.Load(file);
        List<XElement> elementsToRemove = doc.Descendants()
            .Where(e => toBeRemoved.Contains(e.Name.LocalName))
            .ToList();
        
        foreach (XElement element in elementsToRemove)
        {
            element.Remove();
        }
        string newFileName = Path.ChangeExtension(Path.GetFileName(file), "xml");
        doc.Save(Path.Combine(FinishedFolder, newFileName));
        File.Delete(file);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write($"[{sw.Elapsed.TotalMilliseconds:N4}ms] ");
        Console.ResetColor();
        Console.WriteLine("Finished processing " + Path.GetFileName(file));
        sw.Stop();
    } catch (Exception e)
    {
        Console.WriteLine("Failed to process file: " + file);
        Console.WriteLine(e);
    }
}