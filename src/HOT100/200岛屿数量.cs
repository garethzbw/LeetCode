namespace HOT100_200
{
    public class Solution
    {
        public int NumIslands(char[][] grid)
        {
            var num = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        num++;
                        dfs(grid, i, j);
                    }
                }
            }
            return num;
        }
        public void dfs(char[][] grid, int r, int c)
        {
            var row = grid.Length;
            var col = grid[0].Length;
            if (r >= row || c >= col || r < 0 || c < 0 || grid[r][c] == '0') return;
            grid[r][c] = '0';
            dfs(grid, r + 1, c);
            dfs(grid, r - 1, c);
            dfs(grid, r, c + 1);
            dfs(grid, r, c - 1);
        }
    }
}