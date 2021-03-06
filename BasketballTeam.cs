﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Assignment_Q1
{
    class BasketballTeam : ASystem, IComparable 
    {
        //-----data fields----
        protected int maxPlayers;
        protected int activePlayers;
        protected Stadium stadium; // the stadium where the soccer team plays

        //-----properties-----
        public Stadium Stadium
        {
            get { return stadium; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Null stadium Value is not allowed");
                stadium = value;
            }
        }
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
        public BasketballTeam (string name, DateTime established, int maxPlayers, int activePlayers,Stadium stadium): base (name, established)
        {
            MaxPlayers = maxPlayers;
            ActivePlayers = activePlayers;
            Stadium = stadium;
        }
        public BasketballTeam(string name, DateTime established, Stadium stadium) : base(name, established)
        {
            MaxPlayers = 20 ; // default value
            ActivePlayers = 0; //default value
            Stadium = stadium;
        }
        public BasketballTeam(int activePlayers ,string name, DateTime established, Stadium stadium) : base(name, established)
        {
            MaxPlayers = 20; // default value
            ActivePlayers = activePlayers;
            Stadium = stadium;
        }
            //
        public override string systemPurpose()
        {
           return base.ToString()+ " max player:"+ maxPlayers+" active players:"+activePlayers+ stadium.ToString();
        }

        //-----interface----
        public int CompareTo (object obj) //sort by basketball name group
        {
            if (!(obj is BasketballTeam))
                throw new Exception("Object is not a basketball team, Can not compare !");

            int result = String.Compare(((BasketballTeam)obj).SName, SName);
            if (result < 0) // Sname > basketballTeam.Sname
                return 1;
            if (result > 0) //Sname < basketballTeam.Sname
                return -1;
            return 0;  //Sname = basketballTeam.Sname
        }
    }
}
