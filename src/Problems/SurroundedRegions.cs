namespace SurroundedRegions
{
    //https://leetcode-cn.com/problems/surrounded-regions/
    public class Solution 
    {
        public char[][] Solve(char[][] board) 
        {
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    if (DFS(board, i, j, 1) && DFS(board, i, j, 2) && DFS(board, i, j, 3) && DFS(board, i, j, 4)) board[i][j] = 'X';
                }
            }
            return board;
        }
        public bool DFS(char[][] board, int x, int y, int direction)
        {
            if (board[x][y] == 'X') return true;
            else
            {
                if(x == 0 || x == board.Length - 1 || y == 0 || y == board[0].Length - 1) //边界
                {
                    return false;
                }
                switch (direction)
                {
                    case 1: 
                        return DFS(board, x, y - 1, direction);
                    case 2:
                        return DFS(board, x + 1, y, direction);
                    case 3:
                        return DFS(board, x, y + 1, direction);
                    case 4:
                        return DFS(board, x - 1, y, direction);
                    default:
                        return false;
                }
            }
        }
    }
}