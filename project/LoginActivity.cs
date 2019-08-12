using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Support.Design.Widget;
using V4Fragment = Android.Support.V4.App.Fragment;
using V4FragmentManager = Android.Support.V4.App.FragmentManager;
using System.Collections.Generic;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;


namespace project
{
    [Activity(Label = "LoginActivity")]
    public class LoginActivity : AppCompatActivity
    {
        private TabAdapter adapter;
        private TabLayout tabLayout;
        private ViewPager viewPager;
        private V7Toolbar toolbar;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_login);
            viewPager = FindViewById<Android.Support.V4.View.ViewPager>(Resource.Id.viewPager);
            tabLayout = FindViewById<TabLayout>(Resource.Id.tabLayout);
            adapter = new TabAdapter(SupportFragmentManager);
            adapter.AddFragment(new SignInTabFragment(), "Sign In");
            adapter.AddFragment(new SignUpTabFragment(), "Sign Up");
            tabLayout.SetupWithViewPager(viewPager);
            viewPager.Adapter = adapter;
            viewPager.OffscreenPageLimit = 0;
            viewPager.Adapter.NotifyDataSetChanged();


            ////SupportActionBar
            //toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
            //SetSupportActionBar(toolbar);
            //SupportActionBar.SetIcon(Resource.Drawable.logo);
            ////ViewPager  
            //viewPager = FindViewById<Android.Support.V4.View.ViewPager>(Resource.Id.viewpager);
            //setupViewPager(viewPager); //Calling SetupViewPager Method  
            //                           //TabLayout  
            //var tabLayout = FindViewById<TabLayout>(Resource.Id.tabLayout);
            //tabLayout.SetupWithViewPager(viewPager);
            //void setupViewPager(Android.Support.V4.View.ViewPager viewPager)
            //{
            //    var adapter = new TabAdapter(SupportFragmentManager);
            //    adapter.AddFragment(new SignInTabFragment(), "Sign In");
            //    adapter.AddFragment(new SignUpTabFragment(), "Sign Up");
            //    viewPager.Adapter = adapter;
            //    viewPager.Adapter.NotifyDataSetChanged();
            //}


            //******flash*****

            //// Instantiate the deck of flash cards:
            //FlashCardDeck flashCards = new FlashCardDeck();

            //// Instantiate the adapter and pass in the deck of flash cards:
            //FlashCardDeckAdapter adapter = new FlashCardDeckAdapter(SupportFragmentManager, flashCards);

            //// Find the ViewPager and plug in the adapter:
            //ViewPager pager = (ViewPager)FindViewById(Resource.Id.pager);
            //pager.Adapter = adapter;
        }
        // Prevent the back button from canceling the startup process
        public override void OnBackPressed()
        {
            Java.Lang.JavaSystem.Exit(0);
        }
    }
}

