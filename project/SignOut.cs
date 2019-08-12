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

namespace project
{
    [Activity(Label = "SignOut")]
    public class SignOut : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            ISharedPreferences pref = Application.Context.GetSharedPreferences("UserInfo", FileCreationMode.Private);
            ISharedPreferencesEditor edit = pref.Edit();
            edit.Remove("Usernam");
            edit.Apply();
            StartActivity(new Intent(Application.Context, typeof(LoginActivity)));
            Toast.MakeText(Application.Context, "Sign Out Successfully !", ToastLength.Short).Show();
            Finish();
        }
    }
  
}