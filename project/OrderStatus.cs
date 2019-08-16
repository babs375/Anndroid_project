using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using project.Database;

namespace project
{
    [Activity(Label = "OrderStatus")]
    public class OrderStatus : Activity
    {
        public RecyclerView mRecycleView;
        public RecyclerView.LayoutManager mLayoutManager;
        OrderObject mOrderObject;
        OrderObjectAdapter mAdapter;
        DatabaseL db = new DatabaseL();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_order_status);

            ISharedPreferences pref = Application.Context.GetSharedPreferences("UserInfo", FileCreationMode.Private);
            string userName = pref.GetString("Usermail", String.Empty);
            try
            {

                var query = db.selectallUser();
                var query1 = query.Where(x => x.Email == userName).FirstOrDefault();
                int usrID = query1.Uid;
                mOrderObject = new OrderObject(usrID);
            }

            catch (Exception ex)
            {
                Toast.MakeText(Application.Context, ex.ToString(), ToastLength.Short).Show();
            }
            

            mRecycleView = FindViewById<RecyclerView>(Resource.Id.listOrders);
            mRecycleView.HasFixedSize = true;
            mLayoutManager = new LinearLayoutManager(this);
            mRecycleView.SetLayoutManager(mLayoutManager);
            mAdapter = new OrderObjectAdapter(mOrderObject);
            mAdapter.ItemClick += MAdapter_ItemClick;
            mRecycleView.SetAdapter(mAdapter);
        }

        private void MAdapter_ItemClick(object sender, int e)
        {
            //int photoNum = e + 1;
            //Toast.MakeText(this, "This is photo number " + photoNum, ToastLength.Short).Show();
        }


        //        FirebaseRecyclerAdapter<Request, OrderViewHolder> adapter;

        //        FirebaseDatabase database;
        //        DatabaseReference requests;

        //        @Override
        //    protected void onCreate(Bundle savedInstanceState)
        //        {
        //            super.onCreate(savedInstanceState);
        //            setContentView(R.layout.activity_order_status);

        //            //Firebase
        //            database = FirebaseDatabase.getInstance();
        //            requests = database.getReference("Requests");



        //            loadOrders(Common.currentUser.getPhone());

        //        }

        //        private void loadOrders(String phone)
        //        {
        //            adapter = new FirebaseRecyclerAdapter<Request, OrderViewHolder>(
        //                    Request.class,
        //                R.layout.order_layout,
        //                OrderViewHolder.class,
        //                requests.orderByChild("phone").equalTo(phone)
        //        ) {
        //            @Override
        //            protected void populateViewHolder(OrderViewHolder viewHolder, Request model, int position)
        //        {
        //            viewHolder.txtOrderId.setText(adapter.getRef(position).getKey());
        //            viewHolder.txtOrderStatus.setText(convertCodeToStatus(model.getStatus()));
        //            viewHolder.txtOrderAddress.setText(model.getAddress());
        //            viewHolder.txtOrderphone.setText(model.getPhone());

        //        }
        //    };

        //    recyclerView.setAdapter(adapter);

        //    }

        //private String convertCodeToStatus(String status)
        //{
        //    if (status.equals("0"))
        //        return "Placed";
        //    else if (status.equals("1"))
        //        return "Preparing";
        //    else if (status.equals("2"))
        //        return "Packaging";
        //    else
        //        return "Food Ready";
        //}
    }
}