namespace Ping_Pong
{
    class Player
    {
        private SidePlayer _sidePlayer;
        private Camp _camp;

        public int X { get; set; }
        public int Y { get; set; }

        public Player(Camp camp, SidePlayer side)
        {
            _camp = camp;
            _sidePlayer = side;
        }

        public void Initialize()
        {
            var centerY = Camp.BoardHeight / 2;

            if (_sidePlayer == SidePlayer.Left)
            {
                X = 2;
                Y = centerY;
                _camp.Board[X, Y] = Camp.PlayerLeft;
            }
            else
            {
                X = Camp.BoardWidth - 3;
                Y = centerY;
                _camp.Board[X, Y] = Camp.PlayerRight;
            }
        }

        public void Move(DirectionMovementY direction)
        {
            if (direction == DirectionMovementY.Up && Y - 1 > 0)
            {
                _camp.Board[X, Y] = Camp.Empty;
                Y--;
            }
            else if (direction == DirectionMovementY.Down && Y + 1 < Camp.BoardHeight - 1)
            {
                _camp.Board[X, Y] = Camp.Empty;
                Y++;
            }

            if (_sidePlayer == SidePlayer.Left)
            {
                _camp.Board[X, Y] = Camp.PlayerLeft;
            }
            else
            {
                _camp.Board[X, Y] = Camp.PlayerRight;
            }
        }
    }
}
