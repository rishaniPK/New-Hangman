using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace Hangman
{
    [Activity(Label = "Hangman", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class GameActivity : Activity
    {
        
        //Assign all Buttons, TextViews and ImageViews
        private Button A;
        private Button B;
        private Button C;
        private Button D;
        private Button E;
        private Button F;
        private Button G;
        private Button H;
        private Button I;
        private Button J;
        private Button K;
        private Button L;
        private Button M;
        private Button N;
        private Button O;
        private Button P;
        private Button Q;
        private Button R;
        private Button S;
        private Button T;
        private Button U;
        private Button V;
        private Button W;
        private Button X;
        private Button Y;
        private Button Z;
        //private TextView WordLine;
     
        private ImageView GamePic;
       


        List<string> WordList = new List<string>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            Player.letters = 0;

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Game);

            StartUp();
            //LoadWords();
        }

        private void StartUp()
        {
            A = FindViewById<Button>(Resource.Id.btnA);
            B = FindViewById<Button>(Resource.Id.btnB);
            C = FindViewById<Button>(Resource.Id.btnC);
            D = FindViewById<Button>(Resource.Id.btnD);
            E = FindViewById<Button>(Resource.Id.btnE);
            F = FindViewById<Button>(Resource.Id.btnF);
            G = FindViewById<Button>(Resource.Id.btnG);
            H = FindViewById<Button>(Resource.Id.btnH);
            I = FindViewById<Button>(Resource.Id.btnI);
            J = FindViewById<Button>(Resource.Id.btnJ);
            K = FindViewById<Button>(Resource.Id.btnK);
            L = FindViewById<Button>(Resource.Id.btnL);
            M = FindViewById<Button>(Resource.Id.btnM);
            N = FindViewById<Button>(Resource.Id.btnN);
            O = FindViewById<Button>(Resource.Id.btnO);
            P = FindViewById<Button>(Resource.Id.btnP);
            Q = FindViewById<Button>(Resource.Id.btnQ);
            R = FindViewById<Button>(Resource.Id.btnR);
            S = FindViewById<Button>(Resource.Id.btnS);
            T = FindViewById<Button>(Resource.Id.btnT);
            U = FindViewById<Button>(Resource.Id.btnU);
            V = FindViewById<Button>(Resource.Id.btnV);
            W = FindViewById<Button>(Resource.Id.btnW);
            X = FindViewById<Button>(Resource.Id.btnX);
            Y = FindViewById<Button>(Resource.Id.btnY);
            Z = FindViewById<Button>(Resource.Id.btnZ);
            


            GamePic = FindViewById<ImageView>(Resource.Id.ivHangman);
            WordGuess();
            Player.wrongGuesses = 0;
            Player.rightGuesses = 0;
            Player.Games++;
            //Toast.MakeText(this, "Lost " + Player.Lost.ToString(), ToastLength.Long).Show();

            A.Click += HangmanLetter;
            B.Click += HangmanLetter;
            C.Click += HangmanLetter;
            D.Click += HangmanLetter;
            E.Click += HangmanLetter;
            F.Click += HangmanLetter;
            G.Click += HangmanLetter;
            H.Click += HangmanLetter;
            I.Click += HangmanLetter;
            J.Click += HangmanLetter;
            K.Click += HangmanLetter;
            L.Click += HangmanLetter;
            M.Click += HangmanLetter;
            N.Click += HangmanLetter;
            O.Click += HangmanLetter;
            P.Click += HangmanLetter;
            Q.Click += HangmanLetter;
            R.Click += HangmanLetter;
            S.Click += HangmanLetter;
            T.Click += HangmanLetter;
            U.Click += HangmanLetter;
            V.Click += HangmanLetter;
            W.Click += HangmanLetter;
            X.Click += HangmanLetter;
            Y.Click += HangmanLetter;
            Z.Click += HangmanLetter;
        }



        private void WordGuess()
        {

            //Set initial background image2
            GamePic.SetImageResource(Resource.Drawable.Hangman7);
            
            //Provide words from string

            //Random random = new Random(DateTime.Now.Millisecond);
            //int Rnd = random.Next(1, 4);

            //string[] wordBank = { "Abolishment", "Cat", "Blacksmith", "Merino", "Banana" };
            
            //Toast.MakeText(this, Word, ToastLength.Long).Show();
            //Word = wordBank[random.Next(0, wordBank.Length)];
       
            int Low;
            int High;


            //Sort the lows and highs for each difficulty. Note that Easy, Medium & Hard have been changed to Short, Medium & Long due to some controversy.
            if (Player.Difficulty == 1)
            {
                Low = 2;
                High = 4;
            }
            else if (Player.Difficulty == 2)
            {
                Low = 5;
                High = 7;
            }
            else
            {
                Low = 8;
                High = 10;
            }



            var assets = Assets;

            //Pick a word from the 
            using (var sr = new StreamReader(assets.Open("hangmanwords.txt")))
            {
                while (!sr.EndOfStream)
                {
                    var text = sr.ReadLine();


                    if (text != string.Empty && text.Length >= Low && text.Length <= High) 
                    {
                        text = text.Trim();



                        var word = text;

                        word = word.Trim();

                        //cut out the stuff you don't want

                        if (!WordList.Contains(word))
                        {

                            WordList.Add(word);
                        }
                    }


                }
            }

            Random rand = new Random();

            //Picks a random number 
            int RndNumber = rand.Next(1, WordList.Count);
            
            //Picks a random word from the Wordlist
            Player.Word = WordList[RndNumber];

            //Uncomment line below for cheat mode
            //Toast.MakeText(this, Player.Word, ToastLength.Long).Show();


            //FindViewById<TextView>(Resource.Id.txtWord).Text = Word;

            char[] WordArray = new char[Player.Word.Length];

            char[] WordGuessArray;

            string copycurrentword = "";


            //Assigns a * to every letter in the word
            foreach (char letter in WordArray)
            {
                copycurrentword += "*";
                Player.letters++;
            }



            WordGuessArray = copycurrentword.ToArray();

            Player.WordGuess2 = WordGuessArray;


            //Post correct number of asterisks to view screen
            FindViewById<TextView>(Resource.Id.txtGuesses).Text = new string(Player.WordGuess2);
        }

        private void HangmanLetter(object sender, EventArgs e)
        {
            //make a fake button

            Button fakeBtn = (Button)sender;


            if (fakeBtn.Clickable)

            {
                fakeBtn.Enabled = false;

            }

            char letter = Convert.ToChar(fakeBtn.Text);
            LetterSorting(letter);


        }

        private void LetterSorting(char letter)
        {



            char[] WordArray = new char[Player.Word.Length];
            Player.WordArrays = WordArray;


            //Convert all letters to capitals.
            string WordUC = Player.Word.ToUpper();


            
            if (WordUC.Contains(letter))
            //If guess is correct
            {
                Toast.MakeText(this, letter + " is in the word", ToastLength.Long).Show();
                Player.rightGuesses++;
            }
            else
            //If guess is incorrect
            {
                Toast.MakeText(this, letter + " is not in the word", ToastLength.Long).Show();
                Player.wrongGuesses++;
            }

            
            for (int i = 0; i < Player.WordArrays.Length; i++)
            {


                if (WordUC[i] == letter)
                {
                    Player.WordGuess2[i] = letter;
                    Player.letters = Player.letters - 1;
                }
            }

            //Toast.MakeText(this, myClass.letters.ToString(), ToastLength.Long).Show();


            //Add updated word to screen
            FindViewById<TextView>(Resource.Id.txtGuesses).Text = new string(Player.WordGuess2);


            //If player has guessed every letter in the word
            if (Player.letters == 0)
            {

                Toast.MakeText(this, "Correct!", ToastLength.Long).Show();
                Toast.MakeText(this, Player.Word, ToastLength.Long).Show();
                Player.Won++;
                Player.rightGuesses++;
                MainScreen();
            }

            //Cycles through wrong guesses until the player loses changing the resulting hangman image to a different image per guess.

            //final wrong guess
            if (Player.wrongGuesses >= 6)
                {
                    
                    GamePic.SetImageResource(Resource.Drawable.Hangman1);
                    Toast.MakeText(this, "DEAD!", ToastLength.Long).Show();
                    Toast.MakeText(this, Player.Word, ToastLength.Long).Show();
                    Player.rightGuesses++;
                    Player.Lost++;
                    MainScreen();


                }
          
            //other wrong guesses
            else if (Player.wrongGuesses == 5)
            {
                GamePic.SetImageResource(Resource.Drawable.Hangman2);
            }
            else if (Player.wrongGuesses == 4)
            {
                GamePic.SetImageResource(Resource.Drawable.Hangman3);
            }
            else if (Player.wrongGuesses == 3)
                {
                    GamePic.SetImageResource(Resource.Drawable.Hangman4);
                }
                else if (Player.wrongGuesses == 2)
                {
                    GamePic.SetImageResource(Resource.Drawable.Hangman5);
                }
                else if (Player.wrongGuesses == 1)
            {
                    GamePic.SetImageResource(Resource.Drawable.Hangman6);
                }
            else
            {
                GamePic.SetImageResource(Resource.Drawable.Hangman7);
            }
                
            }


        private void MainScreen()
        {
            //Return to main screen
            var mainActivity = new Intent(this, typeof(MainActivity));
            StartActivity(mainActivity);
        }



        }
    
}




