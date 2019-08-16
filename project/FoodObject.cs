using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using project.Database;
using project.Model;

namespace project
{

    public class FoodObject
    {

        private Food[] fud;
        Random random;
        public FoodObject()
        {
            try
            {
                DatabaseL db = new DatabaseL();
                var query = db.selectallFood();
                var query1 = query.Where(x => x.mCatID == 1);
                fud = query1.ToArray();
                //this.photos = listPhoto;
                random = new Random();
            }
            catch(Exception ex)
            {

            }
        }

        public int numPhoto
        {
            get
            {
                return fud.Length;
            }
        }
        public Food this[int i]
        {
            get { return fud[i]; }
        }
    }
    public class FoodObject1
    {

        private Food[] fud;
        Random random;
        public FoodObject1()
        {
            DatabaseL db = new DatabaseL();
            var query = db.selectallFood();
            var query1 = query.Where(x => x.mCatID == 2);
            fud = query1.ToArray();
            //this.photos = listPhoto;
            random = new Random();
        }

        public int numPhoto
        {
            get
            {
                return fud.Length;
            }
        }
        public Food this[int i]
        {
            get { return fud[i]; }
        }
    }
    public class FoodViewHolder : RecyclerView.ViewHolder
    {
        public ImageView Image { get; set; }
        public TextView Caption { get; set; }
        public FoodViewHolder(View itemview, Action<int> listener) : base(itemview)
        {
            Image = itemview.FindViewById<ImageView>(Resource.Id.imageView);
            Caption = itemview.FindViewById<TextView>(Resource.Id.textView);
            itemview.Click += (sender, e) => listener(base.Position);
        }
    }

    public class FoodViewHolder1 : RecyclerView.ViewHolder
    {
        public ImageView Image { get; set; }
        public TextView Caption { get; set; }
        public FoodViewHolder1(View itemview, Action<int> listener) : base(itemview)
        {
            Image = itemview.FindViewById<ImageView>(Resource.Id.imageView);
            Caption = itemview.FindViewById<TextView>(Resource.Id.textView);
            itemview.Click += (sender, e) => listener(base.Position);
        }
    }
}