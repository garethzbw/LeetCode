namespace RobotReturnToOrigin
{
    public class Solution 
    {
        public bool JudgeCircle(string moves) 
        {
            var origin = (0, 0);
            foreach (var item in moves)
            {
                origin = Move(item, origin);
            }
            return origin == (0, 0);
        }
        public (int, int) Move(char dir, (int, int) pos)
        {
            int x = pos.Item1, y = pos.Item2;
            switch (dir)
            {
                case 'U':
                    y += 1;
                    break;
                case 'D':
                    y -= 1;
                    break;
                case 'L':
                    x -= 1;
                    break;
                case 'R':
                    x += 1;
                    break;
            }
            return (x, y);
        }
    }
}