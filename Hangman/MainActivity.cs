using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Views;
using Android.Widget;
using System;

namespace Hangman
{
    [Activity(Label = "Hangman", MainLauncher = true, Icon =
        "@drawable/CS", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]


    public class MainActivity : Activity


    {


        private Button btnEasy;
        private Button btnMedium;
        private Button btnHard;

        MediaPlayer _player;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);


            //Display how many Gmaes have been played, and how many have been won and lost. 
            Toast.MakeText(this, "Games " + Player.Games.ToString(), ToastLength.Long).Show();
            Toast.MakeText(this, "Won " + Player.Won.ToString(), ToastLength.Long).Show();
            Toast.MakeText(this, "Lost " + Player.Lost.ToString(), ToastLength.Long).Show();


            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            StartUp();

        }

        private void StartUp()
        {
            //Define buttons
            btnEasy = FindViewById<Button>(Resource.Id.btnEasy);
            btnMedium = FindViewById<Button>(Resource.Id.btnMedium);
            btnHard = FindViewById<Button>(Resource.Id.btnHard);


            btnEasy.Click += onEasy_Click;
            btnMedium.Click += onMedium_Click;
            btnHard.Click += onHard_Click;


        }


        private void onEasy_Click(object sender, EventArgs e)
        {

            Player.Difficulty = 1;
            Start();




        }

        private void onMedium_Click(object sender, EventArgs e)
        {

            Player.Difficulty = 2;
            Start();




        }

        private void onHard_Click(object sender, EventArgs e)
        {

            Player.Difficulty = 3;
            Start();

        }

        private void Start()
        {
            var gameActivity = new Intent(this, typeof(GameActivity));


            //run the inent and start the other screen passing over the data
            StartActivity(gameActivity);
        }

    }
}
