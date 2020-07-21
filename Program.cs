using System;

namespace Final_Assignment_Q1
{
    class Program
    {
        static void Main(string[] args)
        {
            int idxBasketBallTeam = 0, idxSoccerTeam = 0, choiceTemp;

            Console.WriteLine("Enter the amount of the teams");
            int size = int.Parse(Console.ReadLine());
            Service service = new Service(size);
            
            Menu();
            int choice = int.Parse(Console.ReadLine());
            switch(choice)
            {
                case 1:
                    CallForPrint(service);
                    break;
                case 2:
                    Searching(service);
                    break;
                case 3:
                    Delete(service);
                    break;
                case 4:
                    Console.WriteLine("Enter 7 to add a Basketball team\t8 to add a Soccer team");
                    choiceTemp = int.Parse(Console.ReadLine());
                    if (choiceTemp == 7)
                    {
                        service.addBasketballTeam(idxBasketBallTeam);
                        idxBasketBallTeam++;
                    }
                    if (choiceTemp == 8)
                    {
                        service.addSoccerTeam(idxSoccerTeam);
                        idxSoccerTeam++;
                    }
                    break;
                default:
                    Console.WriteLine("Worng input");
                    break;
                    
            }

        }
        public static void Menu()
        {
            Console.WriteLine("Enter:");
            Console.WriteLine("1\tto Print");
            Console.WriteLine("2\tto Search");
            Console.WriteLine("3\tto Delete");
            Console.WriteLine("4\tto Add item");
        }
        public static void Delete(Service service)
        {
            Console.WriteLine("Enter the type of the object you want to delete");
            Console.WriteLine("1- for basketball team\t2-for stadium\t3-for soccer team\t4-for youth soccer team" );
            int choice = int.Parse(Console.ReadLine());
            switch(choice)
            {
                case 1:
                    Console.WriteLine("Enter the index");
                    service.deleteBasketballTeam(int.Parse(Console.ReadLine()));
                    break;
                case 2:
                    Console.WriteLine("Enter the index");
                    service.deleteStadium(int.Parse(Console.ReadLine()));
                    break;
                case 3:
                    Console.WriteLine("Enter the index");
                    service.deleteSoccerTeam(int.Parse(Console.ReadLine()));
                    break;
                case 4:
                    Console.WriteLine("Enter the index");
                    service.deleteYouthSoccerTeam(int.Parse(Console.ReadLine()));
                    break;
                default:
                    Console.WriteLine("Worng input");
                    break;
            }
        }
        public static void CallForPrint(Service service)
        {
            Console.WriteLine("Enter:for print\t1-Basketball teams\t2=Soccer teams\t3-Youth soccer team\t4-Stadiums\t5- ALL ");
            int choice = int.Parse(Console.ReadLine());
            switch(choice)
            {
                case 1:
                    service.printBasketBallTeams(service.basketballTeams);
                    break;
                case 2:
                    service.printSoccerTeams(service.soccerTeams);
                    break;
                case 3:
                    service.printYouthSoccerTeams(service.youthSoccerTeams);
                    break;
                case 4:
                    service.printStadiums(service.stadiums);
                    break;
                case 5:
                    service.printService(service);
                    break;
                default:
                    Console.WriteLine("Worng Input");
                    break;
            }
        }
        public static void Searching(Service service)
        {
            Console.WriteLine("Enter 7 for sreaching soccer team \t 8 to basketball team\t9 to stadium ");
            int choice = int.Parse(Console.ReadLine());
            switch(choice)
            {
                case 7:
                    Console.WriteLine("Enter the name of the soccer team");
                    service.searchSoccerTeam(Console.ReadLine());
                    break;
                case 8:
                    Console.WriteLine("Enter the name of the basketball team");
                    service.searchBasketballTeam(Console.ReadLine());
                    break;
                case 9:
                    Console.WriteLine("Enter the name of the stadium");
                    service.searchStadium(Console.ReadLine());
                    break;
                default:
                    Console.WriteLine("Wornd Input");
                    break;
            }
        }
    }
}
