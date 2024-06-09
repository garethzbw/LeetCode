using System.Collections.Generic;
using System.Linq;
namespace HOT100_207
{
    //拓扑排序
    //根据出度，也就是dfs
    //出度为0的节点一定在拓扑排序的最后面
    public class Solution
    {
        public List<List<int>> conns;
        public int[] visited; //0-未搜索 1-正在搜索 2-已搜索
        bool valid;
        public List<int> result;
        public List<int> CanFinish(int numCourses, int[][] prerequisites)
        {
            conns = new List<List<int>>();
            visited = new int[numCourses];
            result = new List<int>();
            valid = true;
            for (int i = 0; i < numCourses; i++)
            {
                conns.Add(new List<int>());
            }
            for (int i = 0; i < prerequisites.Length; i++)
            {
                conns[prerequisites[i][1]].Add(prerequisites[i][0]);
            }
            for (int i = 0; i < numCourses && valid; ++i)
            {
                if (visited[i] == 0)
                {
                    dfs(i);
                }
            }
            result.Reverse();
            return result;
        }
        public void dfs(int u)
        {
            visited[u] = 1;
            foreach (var v in conns[u])
            {
                if (visited[v] == 1)
                {
                    valid = false;
                    return;
                }
                else if (visited[v] == 0)
                {
                    dfs(v);
                    if (!valid) return;
                }
            }
            visited[u] = 2;
            result.Add(u);
        }
    }

    //根据入度，也就是bfs
    //入度为0的节点一定在拓扑排序的最前面
    public class Solution2
    {
        public List<List<int>> conns;
        public List<int> ins;//每个节点入度
        public List<int> result;
        public List<int> CanFinish(int numCourses, int[][] prerequisites)
        {
            int count = 0;
            conns = new List<List<int>>();
            result = new List<int>();
            ins = new List<int>();
            for (int i = 0; i < numCourses; i++)
            {
                conns.Add(new List<int>());
                ins.Add(0);
            }
            for (int i = 0; i < prerequisites.Length; i++)
            {
                conns[prerequisites[i][1]].Add(prerequisites[i][0]);
                ins[prerequisites[i][0]] ++;
            }

            var q = new Queue<int>();
            for(int i = 0; i < numCourses; i ++)
            {
                if (ins[i] == 0) q.Enqueue(i);
            }

            while (q.Any())
            {
                var n = q.Dequeue();
                result.Add(n);
                ++count;
                for (int i = 0; i < conns[n].Count; i++)
                {
                    --ins[conns[n][i]];
                    if (ins[conns[n][i]] == 0) //节点入度等于0
                    {
                        q.Enqueue(conns[n][i]);
                    }
                }
            }
            return result;
        }
    }
}