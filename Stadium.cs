using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Assignment_Q1
{
    class Stadium: IComparable
    {
        //-----data fields-----
        protected string stadiumName;
        protected int seats;

        //-----properties-----
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
        public int Seats
        {
            get { return seats; }
            set 
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Number of seats could not be negative");
                seats = value;
            }
        }

        //-----methods-----
        //constructors:
        public Stadium( string stadiumName, int seats)
        {
            StadiumName = stadiumName;
            Seats = seats;
        }
        public Stadium() 
        {
            StadiumName = "Not named yet"; //default value
            Seats = 0; // default value
        }
        public Stadium(string stadiumName) 
        {
            StadiumName = stadiumName;
            Seats = 0; // default value
        }
            //
        public override string ToString()
        {
            return " The name of the stadium " + stadiumName + " number of seats" + seats;
        }

        //-----interface-----
        public int CompareTo(object obj) //sort by stadium name
        {
            if (!(obj is Stadium))
                throw new Exception("Object is not a stadium, Can not compare !");

            int result = String.Compare(((Stadium)obj).stadiumName, stadiumName);
            if (result < 0) // stadiumName > Stadium.stadiumName
                return 1;
            if (result > 0) //staiumName < Stadium.stadiumName
                return -1;
            return 0;  //stadiumName == Stadium.stadiumName
        }
    }
}
