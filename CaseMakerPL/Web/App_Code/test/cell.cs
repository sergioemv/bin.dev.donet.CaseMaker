using System;

namespace testCSharp
{
    public class cell
    {
        public cell(String n, String d)
        {
            name = n;
            description = d;
        }

        public string name;
        public string description;

        public string NAME
        {
            get { return name; }
            set { name = value; }
        }

        public string DESCRIPTION
        {
            get { return description; }
            set { description = value; }
        }
    }
}