using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Hangman
{
    static class Player
    {

        public static int wrongGuesses { get; set; }
        public static String Word { get; set; }
        public static char[] WordArrays { get; set; }
        public static char[] WordGuess2 { get; set; }
        public static int rightGuesses { get; set; }
        public static int letters { get; set; }
        public static string TheWord { get; set; }
        public static char[] Wordz { get; set; }
        public static int Won { get; set; }
        public static int Lost { get; set; }
        public static int Games { get; set; }
        public static int Difficulty { get; set; }
        public static string wordguess2 { get; set; }
        public static bool Music { get; set; }

    }
}