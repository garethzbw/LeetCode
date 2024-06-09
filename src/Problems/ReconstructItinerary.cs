using System.Diagnostics.Tracing;
using System.Linq;
namespace ReconstructItinerary
{
    using System.Collections.Generic;
    //https://leetcode-cn.com/problems/reconstruct-itinerary/
    public class Solution 
    {
        public IList<string> FindItinerary(IList<IList<string>> tickets) 
        {
            var ret = new List<string>();
            if (tickets == null) return ret;
            var map = new Dictionary<string, List<string>>();
            //初始化每个出发地对应的index
            for (int i = 0; i < tickets.Count; i++)
            {
                if (!map.ContainsKey(tickets[i][0]))
                {
                    map.Add(tickets[i][0], new List<string>(){tickets[i][1]});
                }
                else
                {
                    map[tickets[i][0]].Add(tickets[i][1]);
                }
            }

            string nextCity = "JFK";
            while (true)
            {
                ret.Add(nextCity);

                if (ret.Count == tickets.Count + 1) break;

                if (map[nextCity].Count == 1)
                {
                    nextCity = map[nextCity][0];
                }
                else
                {
                    string small = "";
                    var list = new List<string>(map[nextCity]){};
                    while(!map.ContainsKey(small))
                    {
                        small = GetSmallestCity(list);
                        list.Remove(small);
                    }
                    map[nextCity].Remove(small);
                    nextCity = small;
                }
            }
            return ret;
        }
        public string GetSmallestCity(List<string> cities)
        {
            return cities.Min();
        }
    }
}