using System;

namespace Ping_Pong
{
    class Program
    {
        static void Main()
        {
            int fps = 0;
            int desiredFPS = 30;
            double inverseDesiredFPS = 1.0 / desiredFPS;
            DateTime currentTime;
            TimeSpan deltaTime;
            int frameCount = 0;
            DateTime lastTime = DateTime.Now;
            double elapsedTime = 0;

            Game game = new Game();

            game.Initialize();

            while (true)
            {
                game.Input();
                game.Update();
                game.Draw();

                currentTime = DateTime.Now;
                deltaTime = currentTime - lastTime;

                elapsedTime += deltaTime.TotalSeconds;

                while (deltaTime.TotalSeconds <= inverseDesiredFPS)
                {
                    deltaTime = DateTime.Now - lastTime;
                }

                if (elapsedTime >= 1)
                {
                    fps = frameCount;
                    frameCount = 0;
                    elapsedTime--;
                }

                lastTime = currentTime;

                frameCount++;
            }
        }
    }
}
