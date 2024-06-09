using System.Collections.Generic;
namespace CourseSchedule
{
    public class Solution 
    {
        // 1.广度图
        public bool CanFinish(int numCourses, int[][] prerequisites) 
        {
            // if (prerequisites.Length < 1) return true;
            var pre = new Queue<int>();
            var indegree = new int[numCourses]; //每个点的入度
            var dic = new Dictionary<int, List<int>>(); //每个点的所有后继
            for (int i = 0; i < prerequisites.Length; i++)
            {
                indegree[prerequisites[i][0]] ++;
                if (dic.ContainsKey(prerequisites[i][1])) {
                    dic[prerequisites[i][1]].Add(prerequisites[i][0]);
                }
                else
                {
                    dic.Add(prerequisites[i][1], new List<int>(){prerequisites[i][0]});
                }
                
            }
            for (int i = 0; i < indegree.Length; i++)
            {
                if (indegree[i] == 0)
                {
                    pre.Enqueue(i);
                }
            }
            while(pre.Count != 0)
            {
                var p = pre.Dequeue();
                numCourses --;
                if (dic.ContainsKey(p))
                {
                    foreach (var item in dic[p])
                    {
                        indegree[item] --;
                        if (indegree[item] == 0)
                        {
                            pre.Enqueue(item);
                        }
                    }
                }
            }
            return numCourses == 0;
        }
    }
}