﻿using System;

namespace ATM
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayMenu Display = new DisplayMenu();
            Display.DisplayMenuOptions();
            var temp = Convert.ToInt32(Console.ReadLine());
            Display.Choice(temp);

        }
    }
}
