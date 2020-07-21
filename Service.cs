using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Assignment_Q1
{
    class Service
    {
        //----data fields----
        public BasketballTeam[] basketballTeams;
        public SoccerTeam[] soccerTeams;
        public YouthSoccerTeam[] youthSoccerTeams;
        public Stadium[] stadiums;

        //-----properties-----

        //------methods------
        //constructors:
        public Service()
        {
            // 10 is default size
            basketballTeams = new BasketballTeam[10];
            soccerTeams = new SoccerTeam[10];
            youthSoccerTeams = new YouthSoccerTeam[10];
            stadiums = new Stadium[10];
        }
        public Service (int size)
        {
            basketballTeams = new BasketballTeam[size];
            soccerTeams = new SoccerTeam[size];
            youthSoccerTeams = new YouthSoccerTeam[size];
            stadiums = new Stadium[size];
        }
        public Service(int sizeBasketballTeams, int sizeSoccerTeams, int sizeStadiums)
        {
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
                Console.WriteLine("{0}", stadiums[i].ToString());
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
            stadiums[idx] = new Stadium(stadiumName, seats);
        }
        public void addBasketballTeam(int idx)
        {
            Console.WriteLine("Enter the number of max players");
            int maxPlayers = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the number of active player");
            int activePlayer = int.Parse(Console.ReadLine());
            addStadium(idx);
            Console.WriteLine("Enter the name of the group");
            string teamName = Console.ReadLine();
            Console.WriteLine("Enter the year of established after that the month and then the day");
            int year = int.Parse(Console.ReadLine());
            int month = int.Parse(Console.ReadLine());
            int day = int.Parse(Console.ReadLine());
            DateTime established = new DateTime(year, month, day);
            basketballTeams[idx] = new BasketballTeam(teamName, established, maxPlayers, activePlayer, stadiums[idx]);
        }
        public void addSoccerTeam(int idx)
        {
            Console.WriteLine("Enter the name of the couch");
            string couchName = Console.ReadLine();
            Console.WriteLine("Enter the sponsership on the jersey");
            string sponsership = Console.ReadLine();
            Console.WriteLine("Enter the name of the group");
            string teamName = Console.ReadLine();
            Console.WriteLine("Enter the year of established after that the month and then the day");
            int year = int.Parse(Console.ReadLine());
            int month = int.Parse(Console.ReadLine());
            int day = int.Parse(Console.ReadLine());
            DateTime established = new DateTime(year, month, day);
            soccerTeams[idx] = new SoccerTeam(teamName, established, couchName, sponsership);
            Console.WriteLine("The team have a youth team? true/flase");
            bool youthTeam = bool.Parse(Console.ReadLine());
            if (youthTeam)
                addYouthSoccerTeam(idx, couchName , sponsership,teamName, established);
        }
        public void addYouthSoccerTeam(int idx, string couchName, string sponsership, string teamName, DateTime established)
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
            //
        //search:
        public void searchBasketballTeam(string name) //search by name
        {
            for(int i =0; i<basketballTeams.Length; i++)
            {
                if (String.Compare(name, basketballTeams[i].SName) == 0)
                {
                    Console.WriteLine("Found! index {0}", i);
                    basketballTeams[i].systemPurpose();
                    return;
                }
            }
            Console.WriteLine("Didn't find!");
            return ; //didnt find
        }
        public void searchStadium(string stadiumName)
        {
            for(int i=0; i<stadiums.Length; i++)
            {
                if (String.Compare(stadiumName, stadiums[i].StadiumName) == 0)
                {
                    Console.WriteLine("Found! index {0}", i);
                    Console.WriteLine("{0}" ,stadiums[i].ToString());
                    return;
                }
            }
            Console.WriteLine("Did not find!");
            return; //didnt find
        }
        public void searchSoccerTeam(string name)
        {
            for(int i=0; i<soccerTeams.Length; i++)
            {
                if (String.Compare(name, soccerTeams[i].SName) == 0)
                {
                    Console.WriteLine("Found! index {0}", i);
                    soccerTeams[i].systemPurpose();
                    return;
                }
            }
            Console.WriteLine("Didn't find");
            return; //didnt find
        }
        /*public int searchYouthSoccerTeam(string name)
        {
            for(int i=0; i<youthSoccerTeams.Length; i++)
            {
                if (String.Compare(name, youthSoccerTeams[i].SName) == 0)
                    return i;
            }
            return -1; //didnt find
        }*/
        /*public void searchTeams(string name)
        {
            int idx = searchBasketballTeam(name);
            if (idx != -1)
            {
                Console.WriteLine("Found !");
                basketballTeams[idx].systemPurpose();
                return;
            }
            idx = searchSoccerTeam(name);
            if (idx != -1)
            {
                Console.WriteLine("Found !");
                soccerTeams[idx].systemPurpose();
                return;
            }
            Console.WriteLine("Did not find !");
            return;
        }*/
    }
}
