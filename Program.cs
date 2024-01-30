using System;
using System.Collections.Generic;
using System.Linq;

class ToDoItem
{
    public string Name { get; set; }
    public int Priority { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
}

class Program
{
    static List<ToDoItem> toDoList = new List<ToDoItem>();

    static void Main(string[] args)
    {
        char choice;
        do
        {
            Console.WriteLine("1. Add a to-do");
            Console.WriteLine("2. Delete a to-do");
            Console.WriteLine("3. Update status of a to-do");
            Console.WriteLine("4. Search for a to-do");
            Console.WriteLine("5. Display to-dos by priority");
            Console.WriteLine("6. Display all to-dos");
            Console.WriteLine("Press any number from 1 to 6:");

            choice = Console.ReadKey().KeyChar;
            Console.WriteLine();

            switch (choice)
            {
                case '1':
                    AddToDo();
                    break;
                case '2':
                    DeleteToDo();
                    break;
                case '3':
                    UpdateToDoStatus();
                    break;
                case '4':
                    SearchToDo();
                    break;
                case '5':
                    DisplayToDosByPriority();
                    break;
                case '6':
                    DisplayAllToDos();
                    break;
                default:
                    break;
            }

            Console.WriteLine("Continue (Y/N)?");
            choice = Console.ReadKey().KeyChar;
            Console.WriteLine();
        } while (choice == 'Y' || choice == 'y');
    }

    static void AddToDo()
    {
        ToDoItem item = new ToDoItem();

        Console.WriteLine("Enter name of thing to do:");
        item.Name = Console.ReadLine();

        Console.WriteLine("Enter priority (1 to 5):");
        item.Priority = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter description:");
        item.Description = Console.ReadLine();

        Console.WriteLine("Enter status (ready to do, done, missed..etc.):");
        item.Status = Console.ReadLine();

        toDoList.Add(item);
    }

    static void DeleteToDo()
    {
        Console.WriteLine("Enter index of to-do to delete:");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < toDoList.Count)
        {
            toDoList.RemoveAt(index);
            Console.WriteLine("Deleted successfully!");
        }
        else
        {
            Console.WriteLine("Invalid index!");
        }
    }

    static void UpdateToDoStatus()
    {
        Console.WriteLine("Enter name of to-do to update status:");
        string name = Console.ReadLine();

        ToDoItem item = toDoList.FirstOrDefault(t => t.Name == name);

        if (item != null)
        {
            Console.WriteLine("Enter new status:");
            item.Status = Console.ReadLine();
            Console.WriteLine("Status updated successfully!");
        }
        else
        {
            Console.WriteLine("To-do not found!");
        }
    }

    static void SearchToDo()
    {
        Console.WriteLine("Enter name or priority to search:");
        string keyword = Console.ReadLine();

        var result = toDoList.Where(t => t.Name.Contains(keyword) || t.Priority.ToString() == keyword);

        if (result.Any())
        {
            Console.WriteLine("Search results:");
            foreach (var item in result)
            {
                Console.WriteLine($"Name: {item.Name}, Priority: {item.Priority}, Description: {item.Description}, Status: {item.Status}");
            }
        }
        else
        {
            Console.WriteLine("No matching to-do found!");
        }
    }

    static void DisplayToDosByPriority()
    {
        var sortedToDos = toDoList.OrderByDescending(t => t.Priority);

        Console.WriteLine("To-dos by priority (descending):");
        foreach (var item in sortedToDos)
        {
            Console.WriteLine($"Name: {item.Name}, Priority: {item.Priority}, Description: {item.Description}, Status: {item.Status}");
        }
    }

    static void DisplayAllToDos()
    {
        Console.WriteLine("All to-dos:");
        foreach (var item in toDoList)
        {
            Console.WriteLine($"Name: {item.Name}, Priority: {item.Priority}, Description: {item.Description}, Status: {item.Status}");
        }
    }
}
