using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2CapstoneTasks
{
    public static class ToDoService
    {
        public static List<ToDo> ListOfToDos = new List<ToDo>();
        public static void DeleteSelectedToDo()
        {
            Console.WriteLine("Which one do you want to delete?");
            ListOutAllToDos();
            var Choice = Console.ReadLine();
            if (int.TryParse(Choice, out var NumbChoice) && NumbChoice >= 1 && NumbChoice <= ListOfToDos.Count)
            {
                Console.WriteLine("Woah! Are you sure!?");
                var ValidInputYN = Console.ReadKey();
                if (ValidInputYN.Key == ConsoleKey.Y)
                {
                    Console.WriteLine("So long task!");
                    ListOfToDos.RemoveAt(NumbChoice - 1);
                }
                else if (ValidInputYN.Key == ConsoleKey.N)
                {
                    Console.WriteLine("You got it");
                }
                else
                {
                    Console.WriteLine("Try a Y, or an N instead");
                    DeleteSelectedToDo();
                }

            }
            else
            {
                Console.WriteLine("I don't think that was one of the options");
                return;
            }
        }
        public static void MarkSelectedAsComplete()
        {
            Console.WriteLine("Which one do you want to mark as done?");
            ListOutAllToDos();
            var Choice = Console.ReadLine();
            if (int.TryParse(Choice, out var NumbChoice) && NumbChoice >= 1 && NumbChoice <= ListOfToDos.Count)
            {
                Console.WriteLine("Woah! Are you sure!?");
                var ValidInputYN = Console.ReadKey();
                if (ValidInputYN.Key == ConsoleKey.Y)
                {
                    Console.WriteLine("Okay, guess it's complete");
                    ListOfToDos[NumbChoice - 1].Done = true;
                }
                else if (ValidInputYN.Key == ConsoleKey.N)
                {
                    Console.WriteLine("You got it");
                }
                else
                {
                    Console.WriteLine("Try a Y, or an N instead");
                    MarkSelectedAsComplete();
                }

            }
            else
            {
                Console.WriteLine("I don't think that's a task, let alone complete");
                return;
            }
        }
        public static void ListOutAllToDos()
        {
            if (ListOfToDos.Count == 0)
            {
                Console.WriteLine("Not finding any tasks to list. Could you make one to start?\n");
                return;
            }
            Console.WriteLine($"{"Done?",-15}{"Due Date",-15}{"Member Name",-20}{"Description",-30}\n");
            for (int i = 0; i < ListOfToDos.Count; i++)
            {
                ToDo Item = ListOfToDos[i];
                string ToDoDone = null;
                if (Item.Done == true)
                {
                    ToDoDone = "Done";
                }
                else
                {
                    ToDoDone = "Not Done";
                }
                Console.WriteLine($"#{i + 1}{ToDoDone,-15}{Item.DueDate,-15}{Item.Asignee,-20}{Item.Description,-30}\n\n");
            }
        }
        public static ToDo GetToDoFromUserInput()
        {
            Console.WriteLine("Who's writing this up?");
            string Assignee = Console.ReadLine();
            Console.WriteLine($"Cool, {Assignee} what's the thing we need to do");
            string Description = Console.ReadLine();
            Console.WriteLine("What's the due date?");
            string DueDate = Console.ReadLine();
            var newTodo = new ToDo(Assignee, Description, DueDate);
            return newTodo;
        }
    }
}
