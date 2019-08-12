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
    [Activity(Label = "FoodList")]
    public class FoodList : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
        }

//        FirebaseDatabase database;
//        DatabaseReference foodList;
//        RecyclerView recyclerView;
//        RecyclerView.LayoutManager layoutManager;

//        String categoryId = "";
//        FirebaseRecyclerAdapter<Food, FoodViewHolder> adapter;

//        @Override
//    protected void onCreate(Bundle savedInstanceState)
//        {
//            super.onCreate(savedInstanceState);
//            setContentView(R.layout.activity_food_list);
//            //Firebase
//            database = FirebaseDatabase.getInstance();
//            foodList = database.getReference("Foods");

//            recyclerView = (RecyclerView)findViewById(R.id.recycler_food);
//            recyclerView.setHasFixedSize(true);
//            layoutManager = new LinearLayoutManager(this);
//            recyclerView.setLayoutManager(layoutManager);

//            //Get Intent here
//            if (getIntent() != null)
//                categoryId = getIntent().getStringExtra("CategoryId");
//            if (!categoryId.isEmpty() && categoryId != null)
//            {
//                loadListFood(categoryId);
//            }


//        }

//        private void loadListFood(String categoryID)
//        {
//            adapter = new FirebaseRecyclerAdapter<Food, FoodViewHolder>(Food.class,
//                R.layout.food_item,
//                FoodViewHolder.class,
//                foodList.orderByChild("MenuId").equalTo(categoryId)) { //like Select * from Foods where MenuID =
//            @Override
//            protected void populateViewHolder(FoodViewHolder viewHolder, Food model, int position)
//        {
//            viewHolder.food_name.setText(model.getName());
//            Picasso.with(getBaseContext()).load(model.getImage()).into(viewHolder.food_image);

//            final Food local = model;
//            viewHolder.setItemClickListener(new ItemClickListener() {
//                    @Override
//                    public void onClick(View view, int position, boolean isLongClick)
//            {
//                //start new activity
//                Intent foodDetail = new Intent(FoodList.this, FoodDetail.class);
//                        foodDetail.putExtra("FoodId", adapter.getRef(position).getKey());
//                        startActivity(foodDetail);
//    }
//});
//            }
//        };
//        //Set Adapter
//        Log.d("TAG", ""+adapter.getItemCount());
//        recyclerView.setAdapter(adapter);
//    }
    }
}