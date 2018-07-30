using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2CapstoneTasks
{
    class Program
    {
        static List<ToDo> ListOfToDos = new List<ToDo>();
        
        static void Main(string[] args)
        {
            bool Quit = true;
            while (Quit == true)
            {
                var choice = Menu();

                switch (choice)
                {
                    case 1:
                        ListOutAllToDos();
                            break;
                    case 2:
                        ToDo newToDo = GetToDoFromUserInput();
                        ListOfToDos.Add(newToDo);
                        break;
                    case 3:
                        DeleteSelectedToDo();
                            break;
                    case 4:
                        MarkSelectedAsComplete();
                            break;
                    case 5:
                        Console.WriteLine("Woah! Are you sure!?");
                        var ValidInputYN = Console.ReadKey();
                        if (ValidInputYN.Key == ConsoleKey.Y)
                        {
                            Console.WriteLine("So long!");
                            Quit = false;
                        }
                        else if (ValidInputYN.Key == ConsoleKey.N)
                        {
                            Console.WriteLine("You got it");
                        }
                        else
                        {
                            Console.WriteLine("Try a Y, or an N instead");
                        }
                        break;
                    default:
                        break;
                }                
            }
        }
        static void DeleteSelectedToDo()
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
        static void MarkSelectedAsComplete()
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
        static void ListOutAllToDos()
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
                Console.WriteLine($"#{i+1}{ToDoDone,-15}{Item.DueDate,-15}{Item.Asignee, -20}{Item.Description, -30}\n\n");
            }
        }
        static ToDo GetToDoFromUserInput()
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
        static int Menu()
        {
            Console.WriteLine(
@"This is a Time Manager
    1.List Tasks
    2.Add Task
    3.Delete Task
    4.Mark Task Complete
    5.Quit
Whatchu wannna do???");
            string theOption = Console.ReadLine();
            if (int.TryParse(theOption, out var MenuNumber) && MenuNumber >= 1 && MenuNumber <= 5)
            {
                return MenuNumber;
            }
            else
            {
                Console.WriteLine("Try a number 1 through 5 instead of what you typed!");
                return Menu();
            }
        }
    }
}
