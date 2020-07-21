using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Assignment_Q1
{
    class SoccerTeam: ASystem, IComparable
    {
        //----data fields----
        protected string coachName; //the name of the coach
        protected string sponsorship; // the sponsoship of the team

        //-----properties---
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
        public string Sponsorship
        {
            get { return sponsorship; }
            set 
            {
                if (value == null)
                    throw new ArgumentNullException("Null coach name Value is not allowed");
                sponsorship = value;
            }
        }

        //-----methods-----
        //constructors:
        public SoccerTeam (string name, DateTime established, string couchName, string sponsorship): base(name, established)
        {
            CoachName = couchName;
            Sponsorship = sponsorship;
        }
        public SoccerTeam(string name, DateTime established): base(name, established)
        {
            CoachName = "Not named yet"; // default value
            Sponsorship = "Not named yet"; // default value
        }
        public SoccerTeam(string name, DateTime established, string couchName) : base(name, established)
        {
            CoachName = couchName;
            Sponsorship = "Not named yet"; //default value
        }
             //
        public override string systemPurpose()
        {
            return base.ToString() + "name of the coach " + coachName + " name of the sponsorship " + sponsorship;
        }

        //-----interface----
        public int CompareTo(object obj) //sort by number of active players
        {
            if (!(obj is SoccerTeam))
                throw new Exception("Object is not a basketball team, Can not compare !");

            int result = String.Compare(((SoccerTeam)obj).coachName, coachName);
            if (result < 0) // coachName > SoccerTeam.coachName
                return 1;
            if (result > 0) //coachName < SoccerTeam.coachName
                return -1;
            return 0;  //coachName == SoccerTeam.coachName

        }
    }
}
