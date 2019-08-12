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
using Android.Support.V4.App;
using Android.Widget;
using project.Database;
using project.Model;

namespace project
{
    public class SignUpTabFragment : Android.Support.V4.App.Fragment
    {
        EditText iEmail, iPassword, iName;
        TextView signinLink;
        Button btnSignUp;
        ProgressBar progressBar;
        DatabaseL db = new DatabaseL();

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here


        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var v = inflater.Inflate(Resource.Layout.fragment_signup, container, false);

            iEmail = v.FindViewById<EditText>(Resource.Id.input_email);
            iPassword = v.FindViewById<EditText>(Resource.Id.input_password);
            iName = v.FindViewById<EditText>(Resource.Id.input_name);
            signinLink = v.FindViewById<TextView>(Resource.Id.link_login);
            btnSignUp = v.FindViewById<Button>(Resource.Id.btn_signup);
            progressBar = v.FindViewById<ProgressBar>(Resource.Id.pbar);
            progressBar.Visibility = ViewStates.Invisible;

            btnSignUp.Click += BtnSignUp_Click;
            signinLink.Click += BtnSignIn_Click;
            return v;
        }

        private void BtnSignUp_Click(object sender, System.EventArgs e)
        {
            btnSignUp.Enabled = false;
            progressBar.Visibility = ViewStates.Visible;
            if (!Validate())
            {

            }
            else
            {
                try
                {
                    db.createDatabase();    //Create Database 

                    var data = db.selectallUser(); //Call Table  
                    string fName = iName.Text.Trim();
                    string fEmail = iEmail.Text.Trim();
                    string fPassword = iPassword.Text.Trim();
                    var data1 = data.Where(x => x.Email == fEmail).FirstOrDefault(); //Linq Query  
                    if (data1 != null)
                    {
                        Toast.MakeText(Application.Context, "Phone number already registered !", ToastLength.Short).Show();
                    }
                    else
                    {
                        User person = new User()
                        {
                            Name = fName,
                            Password = fPassword,
                            Email = fEmail
                        };
                        db.insertUser(person);

                        Toast.MakeText(Application.Context, "Sign Up Successfully !", ToastLength.Short).Show();

                        ISharedPreferences pref = Application.Context.GetSharedPreferences("UserInfo", FileCreationMode.Private);
                        ISharedPreferencesEditor edit = pref.Edit();
                        edit.PutString("Usernam", fName);
                        edit.PutString("Usermail", fEmail);
                        edit.Apply();

                        Intent home = new Intent(Application.Context, typeof(Home));
                        this.StartActivity(home);
                    }

                }
                catch (Exception ex)
                {
                    Toast.MakeText(Application.Context, ex.ToString(), ToastLength.Short).Show();
                }
            }

            progressBar.Visibility = ViewStates.Invisible;
            btnSignUp.Enabled = true;
        }

        private void BtnSignIn_Click(object sender, System.EventArgs e)
        {
            Toast.MakeText(Application.Context, "Textview Click Event", ToastLength.Short).Show();
            //Intent signup = new Intent(this, typeof(SignUp));

            //this.StartActivity(signup);

        }

        public bool Validate()
        {
            bool valid = true;

            string fName = iName.Text.Trim();
            string fEmail = iEmail.Text.Trim();
            string fPassword = iPassword.Text.Trim();
            string name = fEmail.ToString();
            string email = fEmail.ToString();
            string password = fPassword.ToString();

            if (string.IsNullOrEmpty(name) || name.Count() < 3)
            {
                iName.Error = "At least 3 characters";
                valid = false;
            }
            else
            {
                iName.Error = null;
            }

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