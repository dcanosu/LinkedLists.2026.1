using DoubleList;
using SimpleList;

var list = new DoubleLinkedList<string>();
var option = string.Empty;
var value = string.Empty;
var decorator = new string('-', 35);
var DoublelineBreak = new string('\n', 2);
var lineBreak = new string('\n', 0);
do
{
    
    option = Menu();
    switch (option)
    {
        case "1":
            Header("INSERT A VALUE");
            Console.Write("Enter a value: ");
            value = Console.ReadLine() ?? string.Empty;
            list.InsertOrdered(value);
            Console.WriteLine(lineBreak);
            Console.WriteLine($"* Value '{value}' has been inserted in the list.");
            Console.WriteLine(DoublelineBreak);
            break;
        case "2":
            Header("SHOW LIST");
            if (list.IsEmpty())
            {
                Console.WriteLine("* The list is empty. No values to display.");
                Console.WriteLine(DoublelineBreak);
                break;
            }
            Console.WriteLine(list);
            Console.WriteLine(DoublelineBreak);
            break;
        case "3":
            Header("SHOW LIST IN DESCENDING ORDER");
            if (list.IsEmpty())
            {
                Console.WriteLine("* The list is empty. No values to display.");
                Console.WriteLine(DoublelineBreak);
                break;
            }
            Console.WriteLine(list.ToStringReverse());
            Console.WriteLine(DoublelineBreak);
            break;
        case "4":
            Header("SORT LIST DESCENDING");
            if (list.IsEmpty())
            {
                Console.WriteLine("* The list is empty. No values to sort.");
                Console.WriteLine(DoublelineBreak);
                break;
            }
            list.SortDescending();
            Console.WriteLine(lineBreak);
            Console.WriteLine("* The list has been re-sorted.");
            Console.WriteLine(DoublelineBreak);
            break;
        case "5":
            Header("SHOW MODES");
            var modes = list.GetModes();
            if (modes.Count == 0)
            {
                Console.WriteLine("* The list is empty. No values to display.");
            }
            else
            {
                foreach (var mode in modes)
                {
                    Console.WriteLine(mode);
                }
            }
            Console.WriteLine(DoublelineBreak);
            break;
        case "6":
            Header("SHOW GRAPH");
            List<string> graph = list.GetGraph();
            if (graph.Count == 0)
            {
                Console.WriteLine("* The list is empty. No values to display.");
            }
            else
            {                
                foreach (string line in graph)
                {
                    Console.WriteLine(line);
                }
            }
            Console.WriteLine(DoublelineBreak);
            break;
        case "7":
            Header("SEARCH FOR A VALUE");
            if (list.IsEmpty())
            {
                Console.WriteLine("* The list is empty. No values to search.");
                Console.WriteLine(DoublelineBreak);
                break;
            }
            Console.Write("Enter a value: ");
            value = Console.ReadLine() ?? string.Empty;
            var exists = list.Contains(value);
            if (exists)
            {
                Console.WriteLine(lineBreak);
                Console.WriteLine($"* Value '{value}' found in the list.");
                Console.WriteLine(DoublelineBreak);
            }
            else
            {
                Console.WriteLine(lineBreak);
                Console.WriteLine($"* Value '{value}' not found in the list.");
                Console.WriteLine(DoublelineBreak);
            }
            break;
        case "8":
            Header("REMOVE AN OCCURRENCE");
            if (list.IsEmpty())
            {
                Console.WriteLine("* The list is empty. No values to remove.");
                Console.WriteLine(DoublelineBreak);
                break;
            }
            Console.Write("Enter a value: ");
            value = Console.ReadLine() ?? string.Empty;
            if (!list.Contains(value))
            {
                Console.WriteLine(lineBreak);
                Console.WriteLine($"* The value '{value}' doesn't exist in the list.");
                Console.WriteLine(DoublelineBreak);
            }
            else
            {
                list.Remove(value);
                Console.WriteLine(lineBreak);
                Console.WriteLine($"* The occurrence of value '{value}' have been removed from the list.");
            }
            Console.WriteLine(DoublelineBreak);
            break;
        case "9":
            Header("REMOVE ALL OCCURRENCES");
            if (list.IsEmpty())
            {
                Console.WriteLine("* The list is empty. No values to remove.");
                Console.WriteLine(DoublelineBreak);
                break;
            }
            Console.Write("Enter a value: ");
            value = Console.ReadLine() ?? string.Empty;
            if (!list.Contains(value))
            {
                Console.WriteLine($"* The value '{value}' doesn't exist in the list.");
            }
            else
            {
                list.RemoveAll(value);
                Console.WriteLine(lineBreak);
                Console.WriteLine($"* All occurrences of value '{value}' have been removed from the list.");
            }
            Console.WriteLine(DoublelineBreak);
            break;
        case "0":
            Console.WriteLine("Exiting...");
            Console.WriteLine(DoublelineBreak);
            break;
        default:
            Header("INVALID OPTION");
            Console.WriteLine("* Invalid option. Please try again.");
            Console.WriteLine(DoublelineBreak);
            break;
    }
} while (option != "0");

string Menu()
{
    Console.WriteLine(new string('=', 35));
    Console.WriteLine("MENU".PadLeft(20));
    Console.WriteLine(new string('=', 35));
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
    Console.WriteLine(new string('=', 35));
    Console.Write("Enter your option: ");
    return Console.ReadLine() ?? string.Empty;
}

void Header(string title)
{
    Console.WriteLine('\n' + decorator);
    Console.WriteLine(title.PadLeft(20));
    Console.WriteLine(decorator);
}
