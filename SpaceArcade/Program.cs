﻿using System;
using OpenTK;

namespace SpaceArcade
{
    class Program
    {
        static void Main(string[] args) 
        {
            using (Window window = new Window()) 
            {
                window.Run();
            }
        }
    }
}