using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Assignment_Q1
{
    class YouthSoccerTeam: SoccerTeam, IComparable
    {
        //-----data fields-----
        protected int underAge; //the limit of age who player can plays in the team like Under19
        protected Stack<int> jerseyNumbers;//stack of jersey numbers

        //------properties------
        public int UnderAge
        {
            get { return underAge; }
            set
            {
                if(value < 0)
                    throw new ArgumentOutOfRangeException("Age of the team could not be negative");
                underAge = value;
            }
        }
        public Stack<int> JerseyNumbers1 { get => jerseyNumbers; set => jerseyNumbers = value; }

        //-----methods-----
        //constructors:
        public YouthSoccerTeam(string name, DateTime established, string couchName, string sponsorship, int underAge, Stack<int> stack)
            :base(name, established,couchName,sponsorship)
        {
            UnderAge = underAge;
            for (int i = 99; i >= 0; i--) //pushing jersey numbers
                stack.Push(i);
        }
        public YouthSoccerTeam(string name, DateTime established, string couchName, string sponsorship, Stack<int> stack)
           : base(name, established, couchName, sponsorship)
        {
            UnderAge = 0; //default value
            for (int i = 99; i >= 0; i--) //pushing jersey numbers
                stack.Push(i);
        }
            //
        public override string systemPurpose()
        {
            return base.ToString() + "under age " + underAge;
        }

        //-----interface----
        public new int CompareTo(object obj) //sort by under age
        {
            if (!(obj is YouthSoccerTeam))
                throw new Exception("Object is not a youth soccer team, Can not compare !");

            YouthSoccerTeam youthSoccerTeam = (YouthSoccerTeam)obj;
            if (underAge == youthSoccerTeam.UnderAge)
                return 0;
            if (underAge < youthSoccerTeam.UnderAge)
                return -1;
            else
                return 1;
        }
    }
}
