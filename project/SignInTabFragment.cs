using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using project.Database;

namespace project
{
    public class SignInTabFragment : Android.Support.V4.App.Fragment
    {
        EditText iEmail, iPassword;
        TextView signupLink;
        Button btnSignIn;
        ProgressBar progressBar;
        DatabaseL db = new DatabaseL();

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here


        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var v = inflater.Inflate(Resource.Layout.fragment_signin, container, false);
            iEmail = v.FindViewById<EditText>(Resource.Id.input_email);
            iPassword = v.FindViewById<EditText>(Resource.Id.input_password);
            signupLink = v.FindViewById<TextView>(Resource.Id.link_signup);
            btnSignIn = v.FindViewById<Button>(Resource.Id.btn_login);
            progressBar = v.FindViewById<ProgressBar>(Resource.Id.pbar);
            progressBar.Visibility = ViewStates.Invisible;

            btnSignIn.Click += BtnSignIn_Click;
            signupLink.Click += BtnSignUp_Click;
            return v;
        }

        private void BtnSignIn_Click(object sender, System.EventArgs e)
        {
            btnSignIn.Enabled = false;
            progressBar.Visibility = ViewStates.Visible;
            if (!Validate())
            {
                Toast.MakeText(Application.Context, "Login Failed", ToastLength.Short).Show();
            }
            else
            {
                try
                {
                    db.createDatabase();    //Create Database 

                    var data = db.selectallUser(); //Call Table  
                    string fEmail = iEmail.Text.Trim();
                    string fPassword = iPassword.Text.Trim();
                    var data1 = data.Where(x => x.Email == fEmail && x.Password == fPassword).FirstOrDefault(); //Linq Query  
                    if (data1 != null)
                    {
                        Toast.MakeText(Application.Context, "Login Success", ToastLength.Short).Show();
                        ISharedPreferences pref = Application.Context.GetSharedPreferences("UserInfo", FileCreationMode.Private);
                        ISharedPreferencesEditor edit = pref.Edit();
                        edit.PutString("Usernam", data1.Name.Trim());
                        edit.PutString("Usermail", data1.Email.Trim());
                        edit.Apply();

                        Intent home = new Intent(Application.Context, typeof(Home));
                        this.StartActivity(home);
                    }
                    else
                    {
                        Toast.MakeText(Application.Context, "Username or Password invalid", ToastLength.Short).Show();
                    }

                }
                catch (Exception ex)
                {
                    Toast.MakeText(Application.Context, ex.ToString(), ToastLength.Short).Show();
                }
            }

            progressBar.Visibility = ViewStates.Invisible;
            btnSignIn.Enabled = true;
        }

        private void BtnSignUp_Click(object sender, System.EventArgs e)
        {
            Intent signup = new Intent(Application.Context, typeof(LoginActivity));
            this.StartActivity(signup);
        }

        public bool Validate()
        {
            bool valid = true;

            string fEmail = iEmail.Text.Trim();
            string fPassword = iPassword.Text.Trim();
            string email = fEmail.ToString();
            string password = fPassword.ToString();

            if (string.IsNullOrEmpty(email) || !Android.Util.Patterns.EmailAddress.Matcher(email).Matches())
            {
                iEmail.Error = "Enter a valid email address";
                valid = false;
            }
            else
            {
                iEmail.Error = null;
            }

            if (string.IsNullOrEmpty(password) || password.Count() < 6 || password.Count() > 10)
            {
                iPassword.Error = "Between 6 and 10 alphanumeric characters";
                valid = false;
            }
            else
            {
                iPassword.Error = null;
            }

            return valid;
        }

    }
}