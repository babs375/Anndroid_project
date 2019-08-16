using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Timers;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Felipecsl.GifImageViewLib;

namespace project
{
    [Activity(Theme = "@style/AppTheme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : AppCompatActivity
    {
        private GifImageView gifImageView;
        ProgressBar progressBar;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SplashScreen);

            // Create your application here
            gifImageView = FindViewById<GifImageView>(Resource.Id.gifImageView);
            progressBar = FindViewById<ProgressBar>(Resource.Id.progressBar);

            Stream input = Assets.Open("giphy.gif");
            byte[] bytes = ConvertFileToByteArray(input);
            gifImageView.SetBytes(bytes);
            gifImageView.StartAnimation();

            //Wait for 3 seconds and start new Activity
            Timer timer = new Timer();
            timer.Interval = 15000;
            timer.AutoReset = false;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            ISharedPreferences pref = Application.Context.GetSharedPreferences("UserInfo", FileCreationMode.Private);
            string userName = pref.GetString("Usernam", String.Empty);

            if (string.IsNullOrEmpty(userName))
            {
                //No saved credentials, take user to login screen  
                //Intent intent = new Intent(this, typeof(MainActivity));
                //this.StartActivity(intent);

                StartActivity(new Intent(Application.Context, typeof(LoginActivity)));

            }
            else
            {
                StartActivity(new Intent(Application.Context, typeof(Home)));
            }
            OverridePendingTransition(Resource.Animation.fade_in, Resource.Animation.fade_out);
        }

        private byte[] ConvertFileToByteArray(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                    ms.Write(buffer, 0, read);
                return ms.ToArray();
            }
        }
    }
}

//    {
//        static readonly string TAG = "X:" + typeof(SplashActivity).Name;

//        protected override void OnCreate(Bundle savedInstanceState)
//        {
//            base.OnCreate(savedInstanceState);
//            SetContentView(Resource.Layout.activity_splash);
//            Log.Debug(TAG, "SplashActivity.OnCreate");
//        }

//        // Launches the startup task
//        protected override void OnResume()
//        {
//            base.OnResume();
//            Task startupWork = new Task(() => { SimulateStartup(); });
//            startupWork.Start();
//        }

//        // Prevent the back button from canceling the startup process
//        public override void OnBackPressed() { }

//        // Simulates background work that happens behind the splash screen
//        async void SimulateStartup()
//        {
//            Log.Debug(TAG, "Performing some startup work that takes a bit of time.");
//            await Task.Delay(3000); // Simulate a bit of startup work.
//            Log.Debug(TAG, "Startup work is finished - starting MainActivity.");

//            ISharedPreferences pref = Application.Context.GetSharedPreferences("UserInfo", FileCreationMode.Private);
//            string userName = pref.GetString("Usernam", String.Empty);
            
//            if (string.IsNullOrEmpty(userName))
//            {
//                //No saved credentials, take user to login screen  
//                //Intent intent = new Intent(this, typeof(MainActivity));
//                //this.StartActivity(intent);

//                StartActivity(new Intent(Application.Context, typeof(LoginActivity)));
                
//            }        
//            else
//            {
//                StartActivity(new Intent(Application.Context, typeof(Home)));
//            }
                
//        }
//    }
//}