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
    [Activity(Label = "OrderStatus")]
    public class OrderStatus : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
        }

//        public RecyclerView recyclerView;
//        public RecyclerView.LayoutManager layoutManager;

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

//            recyclerView = findViewById(R.id.listOrders);
//            recyclerView.setHasFixedSize(true);
//            layoutManager = new LinearLayoutManager(this);
//            recyclerView.setLayoutManager(layoutManager);

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