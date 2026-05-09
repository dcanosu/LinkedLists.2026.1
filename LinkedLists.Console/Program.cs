using DoubleList;
using SimpleList;

var list = new DoubleLinkedList<string>();
var option = string.Empty;
var value = string.Empty;
do
{
    option = Menu();
    switch (option)
    {
        case "1":
            Console.Write("Enter a value: ");
            value = Console.ReadLine() ?? string.Empty;
            list.InsertOrdered(value);
            break;
        case "2":
            Console.WriteLine(list);
            break;
        case "3":
            Console.WriteLine(list.ToStringReverse());
            break;
        case "4":
            list.SortDescending();
            break;
        case "5":
            var modes = list.GetModes();
            if (modes.Count == 0)
            {
                Console.WriteLine("No modes found.");
            }
            else
            {
                foreach (var mode in modes)
                {
                    Console.WriteLine(mode);
                }
            }
            break;
        case "6":
            List<string> graph = list.GetGraph();
            if (graph.Count == 0)
            {
                Console.WriteLine("The list is empty.");
            }
            else
            {                
                Console.WriteLine("Graph:");
                foreach (string line in graph)
                {
                    Console.WriteLine(line);
                }
            }
            break;
        case "7":
            Console.Write("Enter a value: ");
            value = Console.ReadLine() ?? string.Empty;
            var exists = list.Contains(value);
            if (exists)
            {
                Console.WriteLine($"Value '{value}' found in the list.");
            }
            else
            {
                Console.WriteLine($"Value '{value}' not found in the list.");
            }
            break;
        case "8":
            Console.Write("Enter a value: ");
            value = Console.ReadLine() ?? string.Empty;
            list.Remove(value);
            break;
        // case "9":
        //     Console.Write("Enter a value: ");
        //     value = Console.ReadLine() ?? string.Empty;
        //     list.RemoveAll(value);
        //     break;
        case "0":
            Console.WriteLine("Exiting...");
            break;
        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }
} while (option != "0");

string Menu()
{
    Console.WriteLine("1. Insert in ascending order");
    Console.WriteLine("2. Show list");
    Console.WriteLine("3. Show list in descending order");
    Console.WriteLine("4. Sort list descending");
    Console.WriteLine("5. Show modes");
    Console.WriteLine("6. Show graph");
    Console.WriteLine("7. Search for a value");
    Console.WriteLine("8. Remove an occurrence");
    Console.WriteLine("9. Remove all occurrences");
    Console.WriteLine("0. Exit");
    Console.Write("Enter your option: ");
    return Console.ReadLine() ?? string.Empty;
}