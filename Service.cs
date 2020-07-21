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
        public YouthSoccerTeam[] youthSoccerTeams;
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
            youthSoccerTeams = new YouthSoccerTeam[10];
            stadiums = new Stadium[10];
        }
        public Service (int size, DateTime dateTime, string name)
        {
            TeamName = name;
            Established = dateTime;
            basketballTeams = new BasketballTeam[size];
            soccerTeams = new SoccerTeam[size];
            youthSoccerTeams = new YouthSoccerTeam[size];
            stadiums = new Stadium[size];
        }
        public Service(int sizeBasketballTeams, int sizeSoccerTeams, int sizeStadiums, DateTime dateTime, string name)
        {
            TeamName = name;
            Established = dateTime;
            basketballTeams = new BasketballTeam[sizeBasketballTeams];
            soccerTeams = new SoccerTeam[sizeSoccerTeams];
            youthSoccerTeams = new YouthSoccerTeam[sizeSoccerTeams];
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
        public void printYouthSoccerTeams(YouthSoccerTeam [] youthSoccerTeams)
        {
            for (int i=0; i< youthSoccerTeams.Length; i++)
            {
                if(youthSoccerTeams[i].UnderAge != 0)
                    Console.WriteLine("{0}", youthSoccerTeams[i].systemPurpose());
            }
        }
        public void printService(Service service)
        {
            Console.WriteLine("The name of the group{0} and established in ", teamName, established.ToString());
            printBasketBallTeams(service.basketballTeams);
            printSoccerTeams(service.soccerTeams);
            printYouthSoccerTeams(service.youthSoccerTeams);
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
            soccerTeams[idx] = new SoccerTeam(teamName, established, couchName, sponsership);
            Console.WriteLine("The team have a youth team? true/flase");
            bool youthTeam = bool.Parse(Console.ReadLine());
            if (youthTeam)
                addYouthSoccerTeam(idx, couchName , sponsership);
        }
        public void addYouthSoccerTeam(int idx, string couchName, string sponsership)
        {
            Console.WriteLine("Enter the under age (limit)");
            int underAge = int.Parse(Console.ReadLine());
            youthSoccerTeams[idx] = new YouthSoccerTeam(teamName, established, couchName, sponsership, underAge);
        }
            //
        //deletes:
        public void deleteBasketballTeam(int idx)
        {
            deleteStadium(idx);
            if (idx == basketballTeams.Length - 1)
            {
                basketballTeams[idx] = null;
                return;
            }
            for (int i = idx; i < basketballTeams.Length - 1; i++)
                basketballTeams[i] = basketballTeams[i + 1];
            basketballTeams[basketballTeams.Length - 1] = null; // the last
        }
        public void deleteStadium(int idx)
        {
            if (idx == stadiums.Length - 1) //if it is the last
            {
                stadiums[idx] = null;
                return;
            }
            for(int i= idx; i<stadiums.Length-1; i++)
                stadiums[i] = stadiums[i + 1];
            stadiums[stadiums.Length - 1] = null; //the last
        }
        public void deleteSoccerTeam(int idx)
        {
            deleteYouthSoccerTeam(idx);
            if(idx == soccerTeams.Length-1)
            {
                soccerTeams[idx] = null;
                return;
            }
            for (int i = idx; i < soccerTeams.Length - 1; i++)
                soccerTeams[i] = soccerTeams[i + 1];
            soccerTeams[soccerTeams.Length - 1] = null; // the last
        }
        public void deleteYouthSoccerTeam(int idx)
        {
            if (idx == youthSoccerTeams.Length - 1)
                youthSoccerTeams[idx] = null;
            for (int i = idx; i < youthSoccerTeams.Length - 1; i++)
                youthSoccerTeams[i] = youthSoccerTeams[i + 1];
            youthSoccerTeams[youthSoccerTeams.Length - 1] = null;
        }
    }
}
