using System;
using OpenTK;

namespace SpaceArcade
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = 1440;
            int height = 1080;
            int refreshRate = 144;
            int resolutionMode;
            int devMode = 1;

            if (devMode == 0)
            {
                Console.WriteLine("Choose your resolution mode (Enter \"1\" for 1080p or \"2\" for 1440p)");
                Console.WriteLine("1: 1080p");
                Console.WriteLine("2: 1440p");
                resolutionMode = Convert.ToInt32(Console.ReadLine());

                if (resolutionMode == 1)
                {
                    width = 1440;
                    height = 1080;
                }

                if (resolutionMode == 2)
                {
                    width = 1920;
                    height = 1440;
                }

                Console.WriteLine("Choose your refresh rate (for example, type \"60\" for 60Hz, or \"144\" for 144Hz and so on.)");
                refreshRate = Convert.ToInt32(Console.ReadLine());
            }

            using (Window window = new Window(width,height,refreshRate))
            {
                window.Run();
            }
        }
    }
}