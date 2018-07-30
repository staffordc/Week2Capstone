using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2CapstoneTasks
{
    class Program
    {
        
        
        static void Main(string[] args)
        {
            bool Quit = true;
            while (Quit == true)
            {
                var choice = Menu();

                switch (choice)
                {
                    case 1:
                        ToDoService.ListOutAllToDos();
                            break;
                    case 2:
                        ToDo newToDo = ToDoService.GetToDoFromUserInput();
                        ToDoService.ListOfToDos.Add(newToDo);
                        break;
                    case 3:
                        ToDoService.DeleteSelectedToDo();
                            break;
                    case 4:
                        ToDoService.MarkSelectedAsComplete();
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
