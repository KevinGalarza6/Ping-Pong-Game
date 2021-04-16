using System;
using System.Threading.Tasks;

namespace Ping_Pong
{
    class Game
    {
        private Camp _camp;
        private Player _playerLeft;
        private Player _playerRight;
        private Ball _ball;
        private Scoreboard _scoreboard;
        private int _leftPlayerPoint;
        private int _rightPlayerPoint;

        public Game()
        {
            _camp = new Camp();
            _ball = new Ball(_camp);
            _playerLeft = new Player(_camp, SidePlayer.Left);
            _playerRight = new Player(_camp, SidePlayer.Right);
            _scoreboard = new Scoreboard();
            _leftPlayerPoint = 0;
            _rightPlayerPoint = 0;
        }

        public void Initialize()
        {
            _camp.Initialize();
            _playerLeft.Initialize();
            _playerRight.Initialize();
            _ball.Initialize();
        }

        public void Input()
        {
            if (Console.KeyAvailable)
            {
                ReadMovement();
            }
        }

        public async void Update()
        {
            await Task.Delay(TimeSpan.FromMilliseconds(_ball.Speed));

            var item = GetNextBoardItem();

            if (item == Camp.Empty)
            {
                _ball.Move();
            }
            else if (item == Camp.PlayerLeft || item == Camp.PlayerRight)
            {
                _ball.OnPlayerChangeDirection();
            }
            else if (item == Camp.Roof)
            {
                _ball.OnRoofChangeDirection();
            }
            else if (item == Camp.Wall)
            {
                if (_ball.DirectionMovementX == DirectionMovementX.Left)
                {
                    _leftPlayerPoint++;
                }
                else if (_ball.DirectionMovementX == DirectionMovementX.Right)
                {
                    _rightPlayerPoint++;
                }

                _camp.Board[_ball.X, _ball.Y] = Camp.Empty;
                _ball.Initialize();
            }
        }

        private void ReadMovement()
        {
            var key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.W)
            {
                _playerLeft.Move(DirectionMovementY.Up);
            }
            else if (key.Key == ConsoleKey.S)
            {
                _playerLeft.Move(DirectionMovementY.Down);
            }
            else if (key.Key == ConsoleKey.UpArrow)
            {
                _playerRight.Move(DirectionMovementY.Up);
            }
            else if (key.Key == ConsoleKey.DownArrow)
            {
                _playerRight.Move(DirectionMovementY.Down);
            }
        }

        public void Draw()
        {
            _camp.Draw();
            _scoreboard.Draw(_leftPlayerPoint, _rightPlayerPoint);
        }

        public char GetNextBoardItem()
        {
            var tempX = _ball.X;
            var tempY = _ball.Y;

            if (_ball.DirectionMovementX == DirectionMovementX.Left && _ball.DirectionMovementY == DirectionMovementY.Up)
            {
                if (_ball.Elevation == _ball.ElevationCompare)
                {
                    tempX--;
                    tempY--;
                }
                else
                {
                    tempX--;
                }
            }
            else if (_ball.DirectionMovementX == DirectionMovementX.Right && _ball.DirectionMovementY == DirectionMovementY.Down)
            {
                if (_ball.Elevation == _ball.ElevationCompare)
                {
                    tempX++;
                    tempY++;
                }
                else
                {
                    tempX++;
                }
            }
            else if (_ball.DirectionMovementX == DirectionMovementX.Left && _ball.DirectionMovementY == DirectionMovementY.Down)
            {
                if (_ball.Elevation == _ball.ElevationCompare)
                {
                    tempX--;
                    tempY++;
                }
                else
                {
                    tempX--;
                }
            }
            else if (_ball.DirectionMovementX == DirectionMovementX.Right && _ball.DirectionMovementY == DirectionMovementY.Up)
            {
                if (_ball.Elevation == _ball.ElevationCompare)
                {
                    tempX++;
                    tempY--;
                }
                else
                {
                    tempX++;
                }
            }

            return _camp.Board[tempX, tempY];
        }
    }
}
