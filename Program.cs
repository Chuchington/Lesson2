﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lesson2
{
    class Program
    {
        // wheither or not exit
        static bool s_ExitGame = false;

        // Screen coord. Here we store where we want the player to be.
        // [0,0] [0,1] [0,2] [0,3] ...
        // [1,0] [1,1] [1,2] [1,3] ...
        static int s_PlayerXPos = 20;
        static int s_PlayerYPos = 10;

        // Screen coord. Here we are going to want to store the position of the bullet.
        static int s_bulletXPos = 40;
        static int s_bulletYPos = 3;

        static void Main(string[] args)
        {
            // this is the game loop... every frame until the game exits
            while (!s_ExitGame)
            {
                // update any game logic... ai's, input, etc...
                UpdateGameLogic();

                // draw all the graphics
                DrawGraphics();

                // to keep the program from running too fast, we will wait 1/60th of a sec
                System.Threading.Thread.Sleep(16); 
            }
        }

        static void UpdateGameLogic()
        {
            // we need to check if the user has pressed any keys
            if (Console.KeyAvailable)
            {
                // get the key that was pressed, if the key was escape
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)
                {
                    s_ExitGame = true;
                }

                // move the player based on the arrow keys pressed
                if (key.Key == ConsoleKey.DownArrow)
                {
                    s_PlayerYPos += 1;
                }
                if (key.Key == ConsoleKey.UpArrow)
                {
                    s_PlayerYPos -= 1;
                }
                if (key.Key == ConsoleKey.RightArrow)
                {
                    s_PlayerXPos += 1;
                }
                if (key.Key == ConsoleKey.LeftArrow)
                {
                    s_PlayerXPos -= 1;
                }

                // make sure the player position does not go off the screen
                if (s_PlayerXPos < 0)
                    s_PlayerXPos = 0;
                if (s_PlayerYPos < 0)
                    s_PlayerYPos = 0;
                if (s_PlayerXPos > 40)
                    s_PlayerXPos = 40;
                if (s_PlayerYPos > 20)
                    s_PlayerYPos = 20;
            }

            // now we are going to update the bullets movement
            s_bulletXPos -= 1;

            // if the bullet hits the end we want it to wrap around
            if (s_bulletXPos < 0)
                s_bulletXPos = 40;

            // now we can check if the bullet hit the player
            if (s_bulletXPos == s_PlayerXPos
                && s_bulletYPos == s_PlayerYPos)
            { 
                // there is a hit if they occupy the same space!
                // TODO: we will handle this in the next exercise.
            }
        }

        static void DrawGraphics()
        {
            // clear the screen
            Console.Clear();

            // move the cursor to the screen position 
            Console.SetCursorPosition(s_PlayerXPos, s_PlayerYPos);
            
            // Draw rhe player
            Console.Write("O");

            // now we need to draw the bullet
            Console.SetCursorPosition(s_bulletXPos, s_bulletYPos);
            Console.Write(".");
        }
    }
}
