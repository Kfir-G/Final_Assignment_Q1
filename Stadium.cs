using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Assignment_Q1
{
    class Stadium: ASystem, IComparable
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
        public Stadium(string name, DateTime established, string stadiumName, int seats): base(name, established)
        {
            StadiumName = stadiumName;
            Seats = seats;
        }
        public Stadium(string name, DateTime established) : base(name, established)
        {
            StadiumName = "Not named yet"; //default value
            Seats = 0; // default value
        }
        public Stadium(string name, DateTime established, string stadiumName) : base(name, established)
        {
            StadiumName = stadiumName;
            Seats = 0; // default value
        }
            //
        public override string systemPurpose()
        {
            return base.ToString() + "the name of the stadium " + stadiumName + "number of seats" + seats;
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
