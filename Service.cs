using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Assignment_Q1
{
    class Service
    {
        //----data fields----
        string teamName;
        DateTime established;
        public BasketballTeam[] basketballTeams;
        public SoccerTeam[] soccerTeams;
        public Stadium[] stadiums;

        //-----properties-----
        public DateTime Established { get => established; set => established = value; }
        public string TeamName { get => teamName; set => teamName = value; }

        //------methods------
        //constructors:
        public Service()
        {
            TeamName = "Not named yet"; //default value
            Established = DateTime.Now; //default value
            // 10 is default size
            basketballTeams = new BasketballTeam[10];
            soccerTeams = new SoccerTeam[10];
            stadiums = new Stadium[10];
        }
        public Service (int size, DateTime dateTime, string name)
        {
            TeamName = name;
            Established = dateTime;
            basketballTeams = new BasketballTeam[size];
            soccerTeams = new SoccerTeam[size];
            stadiums = new Stadium[size];
        }
        public Service(int sizeBasketballTeams, int sizeSoccerTeams, int sizeStadiums, DateTime dateTime, string name)
        {
            TeamName = name;
            Established = dateTime;
            basketballTeams = new BasketballTeam[sizeBasketballTeams];
            soccerTeams = new SoccerTeam[sizeSoccerTeams];
            stadiums = new Stadium[sizeStadiums];
        }
            //
        //prints:
        public void printBasketBallTeams(BasketballTeam[] basketballTeams)
        {
            for (int i = 0; i < basketballTeams.Length; i++)
                Console.WriteLine("{0}", basketballTeams[i].systemPurpose() ) ;
        }
        public void printSoccerTeams(SoccerTeam[] SoccerTeams)
        {
            for (int i = 0; i < SoccerTeams.Length; i++)
                Console.WriteLine("{0}", SoccerTeams[i].systemPurpose());
        }
        public void printStadiums(Stadium[] stadiums)
        {
            for (int i = 0; i < stadiums.Length; i++)
                Console.WriteLine("{0}", stadiums[i].systemPurpose());
        }
        public void printService(Service service)
        {
            Console.WriteLine("The name of the group{0} and established in ", teamName, established.ToString());
            printBasketBallTeams(service.basketballTeams);
            printSoccerTeams(service.soccerTeams);
            printStadiums(service.stadiums);
        }
            //
        // Add functions:
        public void addStadium(int idx)
        {
            Console.WriteLine("Enter stadium name");
            string stadiumName = Console.ReadLine();
            Console.WriteLine("Enter the number of the seats in the stadium");
            int seats = int.Parse(Console.ReadLine());
            stadiums[idx] = new Stadium(teamName, established, stadiumName, seats);
        }
        public void addBasketballTeam(int idx)
        {
            Console.WriteLine("Enter the number of max players");
            int maxPlayers = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the number of active player");
            int activePlayer = int.Parse(Console.ReadLine());
            addStadium(idx);
            basketballTeams[idx] = new BasketballTeam(teamName, established, maxPlayers, activePlayer, stadiums[idx]);
        }
        public void addSoccerTeam(int idx)
        {
            Console.WriteLine("Enter the name of the couch");
            string couchName = Console.ReadLine();
            Console.WriteLine("Enter the sponsership on the jersey");
            string sponsership = Console.ReadLine();

        }
    }
}
