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

        //-----properties-----

        //------methods------
        //constructors:
        public Service()
        {
            // 10 is default size
            basketballTeams = new BasketballTeam[10];
            soccerTeams = new SoccerTeam[10];
        }
        public Service (int size)
        {
            basketballTeams = new BasketballTeam[size];
            soccerTeams = new SoccerTeam[size];
        }
        public Service(int sizeBasketballTeams, int sizeSoccerTeams)
        {
            basketballTeams = new BasketballTeam[sizeBasketballTeams];
            soccerTeams = new SoccerTeam[sizeSoccerTeams];
        }
            //
        //prints:
        public void printBasketBallTeams(BasketballTeam[] basketballTeams)
        {
            for (int i = 0; i < basketballTeams.Length; i++)
            {
                if (basketballTeams[i] != null)
                    Console.WriteLine("{0}", basketballTeams[i].systemPurpose());
            }
        }
        public void printSoccerTeams(SoccerTeam[] SoccerTeams)
        {
            for (int i = 0; i < SoccerTeams.Length; i++)
            {
                if (SoccerTeams[i] != null)
                    Console.WriteLine("{0}",SoccerTeams[i].systemPurpose() );
            }
        }
        public void printYouthSoccerTeams(SoccerTeam [] soccerTeams)
        {
            for (int i=0; i< soccerTeams.Length; i++)
            {
                if (soccerTeams[i] != null)
                {
                    if( soccerTeams[i] is  YouthSoccerTeam)
                        Console.WriteLine("{0}", ((YouthSoccerTeam)soccerTeams[i]).systemPurpose());
                }
            }
        }
        public void printService(Service service)
        {
            printBasketBallTeams(service.basketballTeams);
            printSoccerTeams(service.soccerTeams);
            printYouthSoccerTeams(service.soccerTeams);
        }
            //
        // Add functions:
        public void addBasketballTeam(int idx)
        {
            try
            {
                Console.WriteLine("Enter the number of max players");
                int maxPlayers = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the number of active player");
                int activePlayer = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the name of the group");
                string teamName = Console.ReadLine();
                Console.WriteLine("Enter the year of established after that the month and then the day");
                int year = int.Parse(Console.ReadLine());
                int month = int.Parse(Console.ReadLine());
                int day = int.Parse(Console.ReadLine());
                DateTime established = new DateTime(year, month, day);
                Console.WriteLine("Enter the name of the stadium where they play");
                string stadiumName = Console.ReadLine();
                Console.WriteLine("Enter the number of the seats in the stadium");
                int seatStadium =int.Parse(Console.ReadLine());
                Stadium stadiumNew = new Stadium(stadiumName, seatStadium);
                basketballTeams[idx] = new BasketballTeam(teamName, established, maxPlayers, activePlayer, stadiumNew);
            }
            catch(Exception e1)
            {
                Console.WriteLine("Worng Input " + e1.Message);
            }
        }
        public void addSoccerTeam(int idx)
        {
            try
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
                Console.WriteLine("The team is youth team? true/flase");
                bool youthTeam = bool.Parse(Console.ReadLine());
                if (youthTeam)
                {
                    Console.WriteLine("Enter the under age (limit)");
                    int underAge = int.Parse(Console.ReadLine());
                    soccerTeams[idx] = new YouthSoccerTeam(teamName, established, couchName, sponsership, underAge);
                }
                else
                {
                    soccerTeams[idx] = new SoccerTeam(teamName, established, couchName, sponsership);
                }
            }
            catch( Exception e2)
            {
                Console.WriteLine("Worng input "+ e2.Message);
            }
        }
            //
        //deletes:
        public void deleteBasketballTeam(int idx)
        {
            if (idx == basketballTeams.Length - 1)
            {
                basketballTeams[idx] = null;
                return;
            }
            for (int i = idx; i < basketballTeams.Length - 1; i++)
                basketballTeams[i] = basketballTeams[i + 1];
            basketballTeams[basketballTeams.Length - 1] = null; // the last
        }
        public void deleteSoccerTeam(int idx)
        {
            if(idx == soccerTeams.Length-1)
            {
                soccerTeams[idx] = null;
                return;
            }
            for (int i = idx; i < soccerTeams.Length - 1; i++)
                soccerTeams[i] = soccerTeams[i + 1];
            soccerTeams[soccerTeams.Length - 1] = null; // the last
        }
            //
        //search:
        public void searchBasketballTeam(string name) //search by the name of the basketball team
        {
            for(int i =0; i<basketballTeams.Length; i++)
            {
                if (basketballTeams[i] != null)
                {
                    if (String.Compare(name, basketballTeams[i].SName) == 0)
                    {
                        Console.WriteLine("Found! index {0}", i);
                        basketballTeams[i].systemPurpose();
                        return;
                    }
                }
            }
            Console.WriteLine("Didn't find!");
            return ; //didnt find
        }
        public void searchSoccerTeam(string name) //searching by the name of the soccer team
        {
            for(int i=0; i<soccerTeams.Length; i++)
            {
                if (soccerTeams[i] != null)
                {
                    if (String.Compare(name, soccerTeams[i].SName) == 0)
                    {
                        if (!(soccerTeams[i] is YouthSoccerTeam))
                        {
                            Console.WriteLine("Found! index {0}", i);
                            soccerTeams[i].systemPurpose();
                        }
                        return;
                    }
                }
            }
            Console.WriteLine("Didn't find");
            return; //didnt find
        }
        public void searchYouthSoccerTeam(string name)
        {
            for(int i = 0; i < soccerTeams.Length; i++)
            {
                if (soccerTeams[i] != null)
                {
                    if (String.Compare(name, soccerTeams[i].SName) == 0)
                    {
                        if (soccerTeams[i] is YouthSoccerTeam)
                        {
                            Console.WriteLine("Found! index {0}", i);
                            ((YouthSoccerTeam)soccerTeams[i]).systemPurpose();
                        }
                        return;
                    }
                }
            }
            Console.WriteLine("Didn't find");
            return; //didnt find
        }
    }
}
