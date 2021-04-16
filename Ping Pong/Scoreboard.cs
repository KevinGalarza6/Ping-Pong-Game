using System;

namespace Ping_Pong
{
    public class Scoreboard
    {
        public void Draw(int scoreLeft, int scoreRight)
        {
            Console.SetCursorPosition((Camp.BoardWidth / 2) - (Camp.BoardWidth / 10), Camp.BoardHeight + 2);
            Console.Write(scoreLeft);

            Console.SetCursorPosition((Camp.BoardWidth / 2) + (Camp.BoardWidth / 10), Camp.BoardHeight + 2);
            Console.Write(scoreRight);
        }
    }
}
