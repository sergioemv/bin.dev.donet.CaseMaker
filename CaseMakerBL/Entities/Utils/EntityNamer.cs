//Author Sergio Moreno
//Business Innovations
using System;
using System.Collections;
using System.Reflection;

namespace CaseMaker.Entities.Utils
{
    public class EntityNamer
    {
        private readonly IList existingItems;
        private readonly string prefix;

        public EntityNamer(IList existingItems, string prefix)
        {
            this.existingItems = existingItems;
            this.prefix = prefix+ " Untitled ";
        }
        public string GenerateName()
        {
            // counter of how many "prefixed" elements are
            int l_Counter = 1;
            // search the last "prefixed" element
            if (existingItems == null) return prefix;
            foreach (object ob in existingItems)
            {
                if (ob ==null) continue;
                Type type = ob.GetType();
                string name = (string) type.InvokeMember("Name",BindingFlags.Default | BindingFlags.GetProperty,null,ob , null);
                // if the name starts with the specified prefix
                if (name == null) continue; 
                if (name.StartsWith(prefix))
                {
                    //get the rest of the string not  included in the prefix
                    String candidateSufix = name.Substring(prefix.Length);

                    int candidateSufixint;
                    //try to convert the suffix to int
                    try
                    {
                        candidateSufixint = int.Parse(candidateSufix);
                    }
                    catch (Exception )
                    {
                        // continue with the next element
                        continue;
                    }
                    // if the converted to int sufix is greater than the counter assign it plus 1
                    if (l_Counter <= candidateSufixint)
                        l_Counter = int.Parse(candidateSufix) + 1;
                }

            }
          
            //return the concatenated string
            return prefix + l_Counter;
        }
    }
}