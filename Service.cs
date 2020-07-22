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
        public void addBasketballTeam(int idx, string name, DateTime dateTime, int maxPlayers, int activePlayers, Stadium stadium)
        {
            try
            {
                basketballTeams[idx] = new BasketballTeam(name, dateTime, maxPlayers, activePlayers, stadium);
            }
            catch(Exception e1)
            {
                Console.WriteLine("Worng Input " + e1.Message);
            }
        }
        public void addSoccerTeam(int idx, string nameTeam, DateTime dateTime, string couchName, string sponsership, bool youthTeam, int underAge)
        {
            try
            {
                if (youthTeam)
                {
                    soccerTeams[idx] = new YouthSoccerTeam(nameTeam, dateTime, couchName, sponsership, underAge);
                }
                else
                {
                    soccerTeams[idx] = new SoccerTeam(nameTeam, dateTime, couchName, sponsership);
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
