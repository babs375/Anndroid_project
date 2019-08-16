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
using Android.Support.V7.Widget;
namespace project
{
    public class HomeMenuFragment : Fragment
    {
        RecyclerView mRecycleView, mRecycleView1;

        FoodObject1 mFoodObject1; FoodObject mFoodObject;

        FoodObjectAdapter mAdapter; FoodObjectAdapter1 mAdapter1;
        View myView;
        Activity myContext;
        public string userEmail;
        public HomeMenuFragment() { }
        public HomeMenuFragment(Activity context)
        {
            myContext = context;
        }
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            //return base.OnCreateView(inflater, container, savedInstanceState);

            myView = inflater.Inflate(Resource.Layout.homeMenu, container, false);

            //eatables
            mFoodObject = new FoodObject(); //passing category id
            mRecycleView = myView.FindViewById<RecyclerView>(Resource.Id.recyclerView);
            mRecycleView.SetLayoutManager(new LinearLayoutManager(myView.Context, LinearLayoutManager.Horizontal, false));
            mAdapter = new FoodObjectAdapter(mFoodObject);
            mAdapter.ItemClick += MAdapter_ItemClick;
            mRecycleView.SetAdapter(mAdapter);
            //

            //beverage
            mFoodObject1 = new FoodObject1(); //passing category id
            mRecycleView1 = myView.FindViewById<RecyclerView>(Resource.Id.recyclerView1);
            mRecycleView1.SetLayoutManager(new LinearLayoutManager(myView.Context, LinearLayoutManager.Horizontal, false));
            mAdapter1 = new FoodObjectAdapter1(mFoodObject1);
            mAdapter1.ItemClick += MAdapter_ItemClick1;
            mRecycleView1.SetAdapter(mAdapter1);
            //
            return myView;
        }
        private void MAdapter_ItemClick(object sender, int e)
        {
            int photoNum = e + 1;
            Toast.MakeText(myView.Context, "This is photo number " + photoNum, ToastLength.Short).Show();

            Intent food = new Intent(myContext, typeof(FoodDetail)); // on success loading book page
            int chk = mFoodObject[e].mFid;
            food.PutExtra("foodName", chk.ToString());
            StartActivity(food);
        }

        private void MAdapter_ItemClick1(object sender, int e)
        {
            int photoNum = e + 1;
            Toast.MakeText(myView.Context, "This is photo number " + photoNum, ToastLength.Short).Show();

            Intent food = new Intent(myContext, typeof(FoodDetail)); // on success loading book page
            int chk = mFoodObject1[e].mFid;
            food.PutExtra("foodName", chk.ToString());
            StartActivity(food);
        }
    }
}