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

namespace project
{
    [Activity(Label = "Home")]
    public class Home : AppCompatActivity
    {
        HomeMenuFragment f1;
        //CartMenuFragment f2;
        //OrderMenuFragment f3;
        //SettingsMenuFragment f4;
        //AboutUsFragment f4;


        TextView txtFullName;
        DrawerLayout drawerLayout;
        ActionBarDrawerToggle drawerToggle;
        FloatingActionButton fab;
        NavigationView navigationView;
        View navHeader;
        Android.Support.V7.Widget.Toolbar toolbar;

        // index to identify current nav menu item
        public static int navItemIndex = 0;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Set our view from the "home" layout resource  
            SetContentView(Resource.Layout.activity_home);

            // Create ActionBarDrawerToggle button and add it to the toolbar  
            toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.home_tool_bar);
            SetSupportActionBar(toolbar);

            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            fab = FindViewById<FloatingActionButton>(Resource.Id.fab);

            // Nav Header Value
            navHeader = navigationView.GetHeaderView(0);
            txtFullName = (TextView)navHeader.FindViewById(Resource.Id.txtFullName);
            ISharedPreferences pref = Application.Context.GetSharedPreferences("UserInfo", FileCreationMode.Private);
            string userName = pref.GetString("Usernam", String.Empty);
            txtFullName.Text = userName.Trim();

            fab.Click += delegate
            {
                Intent cartIntent = new Intent(this, typeof(Cart));
                this.StartActivity(cartIntent);
            };

            // initializing navigation menu

            drawerToggle = new ActionBarDrawerToggle(this, drawerLayout, toolbar, Resource.String.drawer_open, Resource.String.drawer_close);
            drawerLayout.AddDrawerListener(drawerToggle);
            drawerToggle.SyncState();

            navigationView.SetCheckedItem(Resource.Id.nav_menu); // Set your home screen                  
            navigationView.NavigationItemSelected += NavigationView_NavigationItemSelected;
            //setupDrawerContent(navigationView); //Calling Function  

            f1 = new HomeMenuFragment(this);
            //f2 = new MyLibraryMenuFragment(this, userName);
            //f3 = new StoreMenuFragment(this, userName);
            //f4 = new AboutusFragment(this, userName);
            setFragment(f1);
        }

        // show or hide the fab
        private void toggleFab()
        {
            if (navItemIndex == 0)
                fab.Show();
            else
                fab.Hide();
        }

        //define action for navigation menu selection
        void NavigationView_NavigationItemSelected(object sender, NavigationView.NavigationItemSelectedEventArgs e)
        {
            switch (e.MenuItem.ItemId)
            {
                case (Resource.Id.nav_menu):
                    e.MenuItem.SetCheckable(true);
                    setFragment(f1);
                    navItemIndex = 0;
                    toggleFab();
                    //Intent home = new Intent(this, typeof(Home));
                    //this.StartActivity(home);
                    break;

                case (Resource.Id.nav_cart):
                    e.MenuItem.SetCheckable(true);
                    Intent cartIntent = new Intent(this, typeof(Cart));
                    this.StartActivity(cartIntent);
                    navItemIndex = 1;
                    toggleFab();
                    break;

                case (Resource.Id.nav_orders):
                    e.MenuItem.SetCheckable(true);
                    Intent order = new Intent(this, typeof(OrderStatus));
                    this.StartActivity(order);
                    navItemIndex = 2;
                    toggleFab();

                    break;

                case (Resource.Id.nav_log_out):
                    e.MenuItem.SetCheckable(true);
                    Intent logout = new Intent(this, typeof(SignOut));
                    this.StartActivity(logout);
                    navItemIndex = 4;
                    toggleFab();
                    break;

                case (Resource.Id.nav_settings):
                    e.MenuItem.SetCheckable(true);
                    //Intent logout = new Intent(this, typeof(SignOut));
                    //this.StartActivity(logout);
                    navItemIndex = 5;
                    toggleFab();
                    break;

                case (Resource.Id.nav_about_us):
                    e.MenuItem.SetCheckable(true);
                    //Intent logout = new Intent(this, typeof(SignOut));
                    //this.StartActivity(logout);
                    navItemIndex = 6;
                    toggleFab();
                    break;

            }

            // Close drawer after the use
            drawerLayout.CloseDrawers();
        }

        void setupDrawerContent(NavigationView navigationView)
        {
            navigationView.NavigationItemSelected += (sender, e) =>
            {
                e.MenuItem.SetChecked(true);
                drawerLayout.CloseDrawers();
            };
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            //navigationView.InflateMenu(Resource.Menu.activity_home_drawer); //Navigation Drawer Layout Menu Creation 
            navigationView.InflateMenu(Resource.Menu.menu_main);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    drawerLayout.OpenDrawer(Android.Support.V4.View.GravityCompat.Start);
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }

        public override void OnBackPressed()
        {
            drawerLayout.CloseDrawers();
        }

        public void setFragment(Fragment fragment)
        {
            //FragmentTransaction fragmentTransaction = getSupportFragmentManager().beginTransaction();
            //fragmentTransaction.replace(Resource.Id.frameLayout1, fragment);
            //fragmentTransaction.commit();


            FragmentTransaction fragmentTransaction = FragmentManager.BeginTransaction();
            //fragmentTransaction.SetCustomAnimations(Resource.Animation.fade_in, Resource.Animation.fade_out);
            fragmentTransaction.Replace(Resource.Id.frameLayout, fragment);
            //fragmentTransaction.commitAllowingStateLoss();
            fragmentTransaction.Commit();

        }

        //        DrawerLayout drawer = (DrawerLayout)findViewById(R.id.drawer_layout);
        //ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(
        //        this, drawer, toolbar, R.string.navigation_drawer_open, R.string.navigation_drawer_close);
        //drawer.addDrawerListener(toggle);
        //        toggle.syncState();

        //        NavigationView navigationView = (NavigationView)findViewById(R.id.nav_view);
        //navigationView.setNavigationItemSelectedListener(this);

        //txtFullName = headerView.findViewById(R.id.txtFullName);
        ////Set Name for user
        //View headerView = navigationView.getHeaderView(0);
        //txtFullName.setText(Common.currentUser.getName());

        ////Load menu
        //recycler_View = findViewById(R.id.recycler_View);
        //recycler_View.setHasFixedSize(true);
        //layoutManager = new LinearLayoutManager(this);
        //recycler_View.setLayoutManager(layoutManager);

        //        loadMenu();

        //    }

        //    private void loadMenu()
        //{

        //    adapter = new FirebaseRecyclerAdapter<Category, MenuViewHolder>(Category.class,R.layout.menu_item,MenuViewHolder.class,category) {
        //            @Override
        //            protected void populateViewHolder(MenuViewHolder viewHolder, Category model, int position)
        //{
        //    viewHolder.txtMenuName.setText(model.getName());
        //    Picasso.with(getBaseContext()).load(model.getImage()).into(viewHolder.imageView);
        //    final Category clickItem = model;
        //    viewHolder.setItemClickListener(new ItemClickListener() {
        //                    @Override
        //                    public void onClick(View view, int position, boolean isLongClick)
        //    {
        //        //Get CategoryId and send to new Activity
        //        Intent foodList = new Intent(Home.this, FoodList.class);
        //                        //Because CategoryId is key, so we just get the key of this item
        //                        foodList.putExtra("CategoryId", adapter.getRef(position).getKey());
        //                        startActivity(foodList);
        //                    }
        //                });
        //            }
        //        };
        //        recycler_View.setAdapter(adapter);
        //    }

        //    @Override
        //    public void onBackPressed()
        //{
        //    DrawerLayout drawer = (DrawerLayout)findViewById(R.id.drawer_layout);
        //    if (drawer.isDrawerOpen(GravityCompat.START))
        //    {
        //        drawer.closeDrawer(GravityCompat.START);
        //    }
        //    else
        //    {
        //        super.onBackPressed();
        //    }
        //}

        //@Override
        //    public boolean onCreateOptionsMenu(Menu menu)
        //{
        //    // Inflate the menu; this adds items to the action bar if it is present.
        //    getMenuInflater().inflate(R.menu.home, menu);
        //    return true;
        //}

        //@Override
        //    public boolean onOptionsItemSelected(MenuItem item)
        //{

        //    return super.onOptionsItemSelected(item);
        //}

        //@SuppressWarnings("StatementWithEmptyBody")
        //    @Override
        //    public boolean onNavigationItemSelected(MenuItem item)
        //{
        //    // Handle navigation view item clicks here.
        //    int id = item.getItemId();

        //    if (id == R.id.nav_menu)
        //    {
        //        return true;
        //    }
        //    else if (id == R.id.nav_cart)
        //    {
        //        Intent cartIntent = new Intent(Home.this, Cart.class);
        //            startActivity(cartIntent);

        //        }else if(id == R.id.nav_orders){
        //            Intent orderIntent = new Intent(Home.this, OrderStatus.class);
        //            startActivity(orderIntent);

        //        }else if(id == R.id.nav_log_out){
        //            Intent signIn = new Intent(Home.this, SignIn.class);
        //            signIn.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
        //            startActivity(signIn);
        //        }

        //        DrawerLayout drawer = (DrawerLayout)findViewById(R.id.drawer_layout);
        //drawer.closeDrawer(GravityCompat.START);
        //        return true;
    }
}