using System;

namespace Final_Assignment_Q1
{
    class Program
    {
        static void Main(string[] args)
        {
            int idxBasketBallTeam = 0, idxSoccerTeam = 0, size = 10;

            Service service = new Service(size);

            Stadium stadium = new Stadium("Santiago", 80000);
            DateTime dateTime = new DateTime(1900, 1, 1);
            int activePlayers = 10;
            int maxPlayer = 20;
            service.addBasketballTeam(idxBasketBallTeam, "Real Madrid", dateTime, maxPlayer, activePlayers, stadium);
            idxBasketBallTeam++;

            DateTime dateTime2 = new DateTime(1920, 2, 2);
            service.addSoccerTeam(idxBasketBallTeam, "Napoli", dateTime2, "Avi", "Nike", false, 45);
            idxSoccerTeam++;

            DateTime dateTime3 = new DateTime(1930, 3, 3);
            service.addSoccerTeam(idxBasketBallTeam, "Dortmund", dateTime3, "Klopp", "Puma", true, 18);
            idxSoccerTeam++;

            CallForPrint(service);

            Searching(service);

            Delete(service);

            CallForPrint(service);

        }
        public static void Delete(Service service)
        {
            Console.WriteLine("Enter the type of the object you want to delete");
            Console.WriteLine("1- for basketball team\t2-for soccer team" );
            int choice = int.Parse(Console.ReadLine());
            switch(choice)
            {
                case 1:
                    Console.WriteLine("Enter the index");
                    service.deleteBasketballTeam(int.Parse(Console.ReadLine()));
                    break;
                case 2:
                    Console.WriteLine("Enter the index");
                    service.deleteSoccerTeam(int.Parse(Console.ReadLine()));
                    break;
                default:
                    Console.WriteLine("Worng input");
                    break;
            }
        }
        public static void CallForPrint(Service service)
        {
            Console.WriteLine("Enter:for print\t1-Basketball teams\t2=Soccer teams\t3-Youth soccer team\t4- ALL ");
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
                    service.printYouthSoccerTeams(service.soccerTeams);
                    break;
                case 4:
                    service.printService(service);
                    break;
                default:
                    Console.WriteLine("Worng Input");
                    break;
            }
        }
        public static void Searching(Service service)
        {
            Console.WriteLine("Enter 7 for sreaching soccer team \t 8 to basketball team\t9 to youth soccer team ");
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
                    Console.WriteLine("Enter the name of the youth soccer team");
                    service.searchYouthSoccerTeam(Console.ReadLine());
                    break;
                default:
                    Console.WriteLine("Wornd Input");
                    break;
            }
        }
    }
}
