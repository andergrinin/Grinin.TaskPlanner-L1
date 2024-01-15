using System;
using Grinin.TaskPlanner.Domain.Logic;
using Grinin.TaskPlanner.Domain.Models;
using Grinin.TaskPlanner.Domain.Models.Enums;

internal static class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the number of work items:");
        if (int.TryParse(Console.ReadLine(), out int itemCount))
        {
            var workItems = new WorkItem[itemCount];
            for (int i = 0; i < itemCount; i++)
            {
                workItems[i] = GetWorkItemFromUser();
            }

            var taskPlanner = new SimpleTaskPlanner();
            var plannedItems = taskPlanner.CreatePlan(workItems);

            Console.WriteLine("\nPlanned Work Items:");
            foreach (var item in plannedItems)
            {
                Console.WriteLine(item.ToString());
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }

    private static WorkItem GetWorkItemFromUser()
    {
        Console.WriteLine("Enter WorkItem details:");
        var workItem = new WorkItem
        {
            CreationDate = DateTime.Now,
            DueDate = DateTime.Parse(GetUserInput("Due Date (dd.MM.yyyy):")),
            Priority = Enum.Parse<Priority>(GetUserInput("Priority (None, Low, Medium, High, Urgent):")),
            Complexity = Enum.Parse<Complexity>(GetUserInput("Complexity (None, Minutes, Hours, Days, Weeks):")),
            Title = GetUserInput("Title:"),
            Description = GetUserInput("Description:"),
            IsCompleted = bool.Parse(GetUserInput("Is Completed (True/False):"))
        };
        return workItem;
    }

    private static string GetUserInput(string prompt)
    {
        Console.Write(prompt + " ");
        return Console.ReadLine();
    }
}
