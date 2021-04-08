using System.Collections.Generic;
using Iesi.Collections.Generic;

namespace CaseMaker.Entities.Utils
{
    public class IdSet
    {
        private ISet<int> ids;

        internal ISet<int> Ids
        {
            get
            {
                if (ids == null)
                    ids = new SortedSet<int>();
                return ids;
            }
            
        }

        public void RemoveId(int id)
        {
            Ids.Remove(id);
        }
        public void Clear()
        {
            Ids.Clear();
        }
        public void registerId(int pos)
        {
            if (Ids.Contains(pos)) return;
            if (pos > 0)
                Ids.Add(pos);
        }

        public void registerIds(IList<int> p_ids)
        {
            foreach (int i in p_ids)
            {
                registerId(i);
            }
            
        }
        public int NextValidId()
        {
    	    int i = 1;
    	    foreach (int id in Ids){
    		    if (id!=i) break;
    		    i++;
    	    }
    	    return i;
        }
         public int nextValidId(int pos)
         {
    	    int i = pos;
    	    if (i<=0) i=1;
    	    foreach (int id in Ids){
    		    if (id<i) continue;
    		    if (id!=i)  break;
    		    i++;
    	    }
    	return i;
        }
        public bool IdExist(int p_id)
        {
            return Ids.Contains(p_id);
        }
    }
}