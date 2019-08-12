using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using Android.Support.Design.Widget;
using Android.Support.V7.Widget;
using Android.Support.V4.View;

namespace project
{
    [Activity(Label = "HomeActivity")]
    public class HomeActivity : Activity//, NavigationView.IOnNavigationItemSelectedListener
    {
        //TextView txtFullName;
        //RecyclerView recycler_View;
        //RecyclerView.LayoutManager layoutManager;
        //DrawerLayout drawerLayout;
        //ActionBarDrawerToggle drawerToggle;
        //FloatingActionButton fab;
        //NavigationView navigationView;
        //Android.Support.V7.Widget.Toolbar toolbar;

        //protected override void OnCreate(Bundle savedInstanceState)
        //{
        //    base.OnCreate(savedInstanceState);
        //    SetContentView(Resource.Layout.activity_home);
        //    toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.home_tool_bar);
        //    SetSupportActionBar(toolbar);

        //    FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
        //    fab.Click += FabOnClick;

        //    DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
        //    ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(this, drawerLayout, toolbar, Resource.String.drawer_open, Resource.String.drawer_close);
        //    drawer.AddDrawerListener(toggle);
        //    toggle.SyncState();

        //    NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
        //    navigationView.SetNavigationItemSelectedListener(this);
        //}

        //public override void OnBackPressed()
        //{
        //    DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
        //    if (drawer.IsDrawerOpen(GravityCompat.Start))
        //    {
        //        drawer.CloseDrawer(GravityCompat.Start);
        //    }
        //    else
        //    {
        //        base.OnBackPressed();
        //    }
        //}

        //public override bool OnCreateOptionsMenu(IMenu menu)
        //{
        //    MenuInflater.Inflate(Resource.Menu.menu_main, menu);
        //    return true;
        //}

        //public override bool OnOptionsItemSelected(IMenuItem item)
        //{
        //    int id = item.ItemId;
        //    if (id == Resource.Id.action_search)
        //    {
        //        return true;
        //    }

        //    return base.OnOptionsItemSelected(item);
        //}

        //private void FabOnClick(object sender, EventArgs eventArgs)
        //{
        //    Intent cartIntent = new Intent(this, typeof(Cart));
        //    this.StartActivity(cartIntent);
        //    //View view = (View)sender;
        //    //Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
        //    //    .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        //}

        //public bool OnNavigationItemSelected(IMenuItem item)
        //{
        //    int id = item.ItemId;

        //    if (id == Resource.Id.nav_menu)
        //    {
        //        Intent home = new Intent(this, typeof(Home));
        //        this.StartActivity(home);
        //    }
        //    else if (id == Resource.Id.nav_cart)
        //    {
        //        Intent cartIntent = new Intent(this, typeof(Cart));
        //        this.StartActivity(cartIntent);
        //    }
        //    else if (id == Resource.Id.nav_orders)
        //    {
        //        Intent order = new Intent(this, typeof(OrderStatus));
        //        this.StartActivity(order);
        //    }
        //    else if (id == Resource.Id.nav_log_out)
        //    {
        //        Intent logout = new Intent(this, typeof(SignOut));
        //        this.StartActivity(logout);
        //    }

        //    DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
        //    drawer.CloseDrawer(GravityCompat.Start);
        //    return true;
        //}
    }
}