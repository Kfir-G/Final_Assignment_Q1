using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Assignment_Q1
{
    class BasketballTeam : ASystem, IComparable 
    {
        //-----data fields----
        protected int maxPlayers;
        protected int activePlayers;

        //-----properties-----
        public int MaxPlayers
        {
            get { return maxPlayers; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Max player in the group could not be negative or 0");
                maxPlayers = value;
            }
        }
        public int ActivePlayers
        {
            get { return activePlayers; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Max player in the group could not be negative");
                activePlayers = value;
            }
        }

        //-----methods-----
        //constructors:
        public BasketballTeam (string name, DateTime established, int maxPlayers, int activePlayers): base (name, established)
        {
            MaxPlayers = maxPlayers;
            ActivePlayers = activePlayers;
        }
        public BasketballTeam(string name, DateTime established) : base(name, established)
        {
            MaxPlayers = 20 ; // default value
            ActivePlayers = 0; //default value
        }
        public BasketballTeam(int activePlayers ,string name, DateTime established) : base(name, established)
        {
            MaxPlayers = 20; // default value
            ActivePlayers = activePlayers; 
        }
            //
        public override string systemPurpose()
        {
           return base.ToString()+ "max player:"+ maxPlayers+"active players:"+activePlayers;
        }

        //-----interface----
        public int CompareTo (object obj) //sort by number of active players
        {
            if (!(obj is BasketballTeam))
                throw new Exception("Object is not a basketball team, Can not compare !");

            BasketballTeam basketballTeam = (BasketballTeam)obj;
            if (activePlayers == basketballTeam.activePlayers)
                return 0;
            if (activePlayers < basketballTeam.activePlayers)
                return -1;
            else
                return 1;
        }
    }
}
