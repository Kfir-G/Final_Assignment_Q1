using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Assignment_Q1
{
    class SoccerTeam: ASystem, IComparable
    {
        //----data fields----
        protected string stadiumName; // name of the staium that the soccer team plays
        string coachName; //the name of the coach

        //-----properties---
        public string StadiumName
        {
            get { return stadiumName; }
            set 
            {
                if (value == null)
                    throw new ArgumentNullException("Null stadium name Value is not allowed");
                stadiumName = value; 
            }
        }
        public string CoachName
        {
            get { return coachName; }
            set 
            {
                if (value == null)
                    throw new ArgumentNullException("Null coach name Value is not allowed");
                coachName = value; 
            }
        }


    }
}
