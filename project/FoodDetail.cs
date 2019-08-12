using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;
using project.Database;

namespace project
{
    [Activity(Label = "FoodDetail")]
    public class FoodDetail : Activity
    {
        TextView food_name, food_price, food_description;
        ImageView food_image;
        CollapsingToolbarLayout collapsingToolbarLayout;
        FloatingActionButton btnCart;
        Button numberButton;
        DatabaseL db = new DatabaseL();
        PhotoAlbum foods;
        Photo currentFood;
        string Food_name;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_food_detail);
            food_name = FindViewById<TextView>(Resource.Id.food_name);
            food_price = FindViewById<TextView>(Resource.Id.food_price);
            food_description = FindViewById<TextView>(Resource.Id.food_description);
            food_image = FindViewById<ImageView>(Resource.Id.img_food);
            collapsingToolbarLayout = FindViewById<CollapsingToolbarLayout>(Resource.Id.collapsing);
            btnCart = FindViewById<FloatingActionButton>(Resource.Id.btnCart);
            numberButton = FindViewById<Button>(Resource.Id.number_button);
            Food_name = Intent.GetStringExtra("foodName").Trim();
            collapsingToolbarLayout.SetExpandedTitleTextAppearance(Resource.Style.ExpandedAppbar);
            collapsingToolbarLayout.SetExpandedTitleTextAppearance(Resource.Style.CollapsedAppbar);


            int foodid;
            bool res = int.TryParse(Food_name, out foodid);
            var data = db.selectallFood(); //Call Table 
            var data1 = data.Where(x => x.mFid == foodid).FirstOrDefault(); //Linq Query  
            food_name.Text = data1.mCaption;
            food_price.Text = data1.mPrice.ToString();
            food_description.Text = data1.mDescription;
            food_image.Id = data1.mPhotoID;

            //Cart button
            btnCart.Click += delegate
            {
                Intent cartIntent = new Intent(this, typeof(Cart));
                this.StartActivity(cartIntent);
            };

            // Add item button
            numberButton.Click += delegate
            {
                ISharedPreferences pref = Application.Context.GetSharedPreferences("UserInfo", FileCreationMode.Private);
                string userName = pref.GetString("Usermail", String.Empty);
                try
                {
                    var query = db.selectallUser();
                    var query1 = query.Where(x => x.Email == userName).FirstOrDefault();
                    UserCart cart = new UserCart()
                    {
                        Fid = foodid,
                        Uid = query1.Uid
                    };
                    db.insertUserCart(cart);
                    Toast.MakeText(Application.Context, data1.mCaption + " added to cart!", ToastLength.Short).Show();

                }
                catch (Exception ex)
                {
                    Toast.MakeText(Application.Context, ex.ToString(), ToastLength.Short).Show();
                }

            };
        }

        protected override void OnStart()
        {
            // TODO Auto-generated method stub
            base.OnStart();

        }

        protected override void OnResume()
        {
            // TODO Auto-generated method stub
            base.OnResume();

        }

        //        TextView food_name, food_price, food_description;
        //        ImageView food_image;
        //        CollapsingToolbarLayout collapsingToolbarLayout;
        //        FloatingActionButton btnCart;
        //        Button numberButton;
        //        FirebaseDatabase database;
        //        DatabaseReference foods;
        //        Food currentFood;

        //        String foodId = "";
        //        FirebaseRecyclerAdapter<Food, FoodViewHolder> adapter;

        //        @Override
        //    protected void onCreate(Bundle savedInstanceState)
        //        {
        //            super.onCreate(savedInstanceState);
        //            setContentView(R.layout.activity_food_detail);

        //            //Firebase
        //            database = FirebaseDatabase.getInstance();
        //            foods = database.getReference("Foods");

        //            //Init View
        //            numberButton = (ElegantNumberButton)findViewById(R.id.number_button);
        //            btnCart = (FloatingActionButton)findViewById(R.id.btnCart);

        //            btnCart.setOnClickListener(new View.OnClickListener() {
        //            @Override
        //            public void onClick(View v)
        //            {

        //                new Database(getBaseContext()).addToCart(new Order(
        //                        foodId,
        //                        currentFood.getName(),
        //                        numberButton.getNumber(),
        //                        currentFood.getPrice(),
        //                        currentFood.getDiscount()
        //                ));


        //            }
        //        });

        //        food_description = (TextView) findViewById(R.id.food_description);
        //        food_name = (TextView) findViewById(R.id.food_name);
        //        food_price = (TextView) findViewById(R.id.food_price);
        //        food_image = (ImageView) findViewById(R.id.img_food);

        //        collapsingToolbarLayout = (CollapsingToolbarLayout) findViewById(R.id.collapsing);
        //        collapsingToolbarLayout.setExpandedTitleTextAppearance(R.style.ExpandedAppbar);
        //        collapsingToolbarLayout.setCollapsedTitleTextAppearance(R.style.CollapsedAppbar);

        //        //Get food ID from Intent
        //        if(getIntent() != null)
        //            foodId = getIntent().getStringExtra("FoodId");
        //        if(!foodId.isEmpty()){
        //            getDetailFood(foodId);
        //    }

        //}

        //private void getDetailFood(String foodId)
        //{
        //    foods.child(foodId).addValueEventListener(new ValueEventListener(){
        //            @Override
        //            public void onDataChange(DataSnapshot dataSnapshot)
        //    {
        //        currentFood = dataSnapshot.getValue(Food.class);

        //                //Set Image
        //                Picasso.with(getBaseContext()).load(currentFood.getImage()).into(food_image);

        //collapsingToolbarLayout.setTitle(currentFood.getName());

        //                food_price.setText(currentFood.getPrice());

        //                food_name.setText(currentFood.getName());

        //                food_description.setText(currentFood.getDescription());

        //            }

        //            @Override
        //            public void onCancelled(DatabaseError databaseError)
        //{

        //}
        //        });

        //    }
    }
}