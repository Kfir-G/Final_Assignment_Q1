using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Assignment_Q1
{
    abstract class ASystem // Sport Group
    {
        //-----data fields---
        string sname;  // name of the sport group
        DateTime established; // Establishment date of the sport group

        //-----properties----
        public string SName
        {
            get { return sname; }
            set
            {
                if (value == null) 
                    throw new ArgumentNullException("Null name");
                sname = value;
            }
        }
        public DateTime Established
        {
            get { return established; }
            set
            {
                if (value == null) 
                    throw new ArgumentNullException("Null DateTime Value is not allowed");
                if (value > DateTime.Now)
                    throw new ArgumentException("You put a future date that are not allowed");
                established = value;
            }
        }

        //-----methods-----
        //constructors:
        public ASystem(string name, DateTime established)
        { SName = name; Established = established; }
        public ASystem(string name)
        { SName = name; established = DateTime.Now; }
            //
        public abstract string systemPurpose(); // string with information about system usage
        public override string ToString()
        { return sname + " exist since " + established.ToShortDateString(); }
    }

}
