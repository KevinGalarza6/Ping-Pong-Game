using System;

namespace Ping_Pong
{
    public class Ball
    {
        private Camp _camp;
        private Random _random = new Random();

        public DirectionMovementX DirectionMovementX;
        public DirectionMovementY DirectionMovementY;
        public int Elevation = 0;
        public int ElevationCompare = 3;
        public int Speed = 50;

        public int X { get; set; }
        public int Y { get; set; }

        public Ball(Camp camp)
        {
            _camp = camp;
        }

        public void Initialize()
        {
            X = Camp.BoardWidth / 2;
            Y = Camp.BoardHeight / 2;
            _camp.Board[X, Y] = Camp.Ball;
            DirectionMovementX = (DirectionMovementX)_random.Next(0, 2);
            DirectionMovementY = (DirectionMovementY)_random.Next(0, 2);
        }

        public void Move()
        {
            var tempX = X;
            var tempY = Y;

            if (DirectionMovementX == DirectionMovementX.Left && DirectionMovementY == DirectionMovementY.Up)
            {
                if (Elevation == ElevationCompare)
                {
                    tempX--;
                    tempY--;
                    Elevation = 0;
                }
                else
                {
                    tempX--;
                    Elevation++;
                }

                _camp.Board[X, Y] = Camp.Empty;
                _camp.Board[tempX, tempY] = Camp.Ball;
                X = tempX;
                Y = tempY;
            }
            else if (DirectionMovementX == DirectionMovementX.Right && DirectionMovementY == DirectionMovementY.Down)
            {
                if (Elevation == ElevationCompare)
                {
                    tempX++;
                    tempY++;
                    Elevation = 0;
                }
                else
                {
                    tempX++;
                    Elevation++;
                }

                _camp.Board[X, Y] = Camp.Empty;
                _camp.Board[tempX, tempY] = Camp.Ball;
                X = tempX;
                Y = tempY;
            }
            else if (DirectionMovementX == DirectionMovementX.Left && DirectionMovementY == DirectionMovementY.Down)
            {
                if (Elevation == ElevationCompare)
                {
                    tempX--;
                    tempY++;
                    Elevation = 0;
                }
                else
                {
                    tempX--;
                    Elevation++;
                }

                _camp.Board[X, Y] = Camp.Empty;
                _camp.Board[tempX, tempY] = Camp.Ball;
                X = tempX;
                Y = tempY;
            }
            else if (DirectionMovementX == DirectionMovementX.Right && DirectionMovementY == DirectionMovementY.Up)
            {
                if (Elevation == ElevationCompare)
                {
                    tempX++;
                    tempY--;
                    Elevation = 0;
                }
                else
                {
                    tempX++;
                    Elevation++;
                }

                _camp.Board[X, Y] = Camp.Empty;
                _camp.Board[tempX, tempY] = Camp.Ball;
                X = tempX;
                Y = tempY;
            }
        }

        public void OnRoofChangeDirection()
        {
            if (DirectionMovementY == DirectionMovementY.Up)
            {
                DirectionMovementY = DirectionMovementY.Down;
            }
            else if (DirectionMovementY == DirectionMovementY.Down)
            {
                DirectionMovementY = DirectionMovementY.Up;
            }
        }

        public void OnPlayerChangeDirection()
        {
            if (DirectionMovementX == DirectionMovementX.Right)
            {
                DirectionMovementX = DirectionMovementX.Left;
            }
            else if (DirectionMovementX == DirectionMovementX.Left)
            {
                DirectionMovementX = DirectionMovementX.Right;
            }
        }

        public char GetNextBoardItem()
        {
            var tempX = X;
            var tempY = Y;

            if (DirectionMovementX == DirectionMovementX.Left && DirectionMovementY == DirectionMovementY.Up)
            {
                if (Elevation == ElevationCompare)
                {
                    tempX--;
                    tempY--;
                    Elevation = 0;
                }
                else
                {
                    tempX--;
                    Elevation++;
                }
            }
            else if (DirectionMovementX == DirectionMovementX.Right && DirectionMovementY == DirectionMovementY.Down)
            {
                if (Elevation == ElevationCompare)
                {
                    tempX++;
                    tempY++;
                    Elevation = 0;
                }
                else
                {
                    tempX++;
                    Elevation++;
                }
            }
            else if (DirectionMovementX == DirectionMovementX.Left && DirectionMovementY == DirectionMovementY.Down)
            {
                if (Elevation == ElevationCompare)
                {
                    tempX--;
                    tempY++;
                    Elevation = 0;
                }
                else
                {
                    tempX--;
                    Elevation++;
                }
            }
            else if (DirectionMovementX == DirectionMovementX.Right && DirectionMovementY == DirectionMovementY.Up)
            {
                if (Elevation == ElevationCompare)
                {
                    tempX++;
                    tempY--;
                    Elevation = 0;
                }
                else
                {
                    tempX++;
                    Elevation++;
                }
            }

            return _camp.Board[tempX, tempY];
        }
    }
}