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
    public class Photo1
    {
        public int mFid { get; set; }
        public int mPhotoID { get; set; }
        public string mCaption { get; set; }
        public string mDescription { get; set; }
        public int mCatID { get; set; }
        public int mPrice { get; set; }
    }
    public class PhotoAlbum1
    {
        //static Photo1[] listPhoto =
        //{
        //    new Photo1() {mFid = 1, mPhotoID = Resource.Drawable.caramel_latte_milk, mCaption = "Caramel Latte Milk", mDescription = "Delicious", mCatID=2, mPrice = 10},
        //    new Photo1() {mFid = 2, mPhotoID = Resource.Drawable.coffee_frapp, mCaption = "Coffee Frapp", mDescription = "Refreshing", mCatID=2, mPrice = 5},
        //    new Photo1() {mFid = 3, mPhotoID = Resource.Drawable.espresso, mCaption = "Espresso", mDescription = "Great Coffee", mCatID=2, mPrice = 15},
        //    new Photo1() {mFid = 4, mPhotoID = Resource.Drawable.fruitopia_strawberry, mCaption = "Fruitopia Strawberry", mDescription = "Natural", mCatID=2, mPrice = 8},
        //    new Photo1() {mFid = 5, mPhotoID = Resource.Drawable.hot_chocolate, mCaption = "Hot Chocolate", mDescription = "Richly Chocolate", mCatID=2, mPrice = 12},
        //    new Photo1() {mFid = 6, mPhotoID = Resource.Drawable.iced_coffee, mCaption = "Iced Coffee", mDescription = "Chilled", mCatID=2, mPrice = 10},
        //    new Photo1() {mFid = 7, mPhotoID = Resource.Drawable.mango_pineapple_smoothie, mCaption = "Mango Pineapple Smoothie", mDescription = "Fresh Pulp", mCatID=2, mPrice = 7},
        //    new Photo1() {mFid = 8, mPhotoID = Resource.Drawable.mocha_milk, mCaption = "Mocha Milk", mDescription = "Protien Rich", mCatID=2, mPrice = 5},
        //    new Photo1() {mFid = 9, mPhotoID = Resource.Drawable.pomegranate_smoothie, mCaption = "Pomegranate Smoothie", mDescription = "Cooled", mCatID=2, mPrice = 12},
        //    new Photo1() {mFid = 10, mPhotoID = Resource.Drawable.pomegranate_yogurt, mCaption = "Pomegranate Yogurt", mDescription = "Energizing", mCatID=2, mPrice = 5},
        //};
        private Photo[] photos;
        Random random;
        public PhotoAlbum1()
        {
            DatabaseL db = new DatabaseL();
            var query = db.selectallFood();
            var query1 = query.Where(x => x.mCatID == 2);
            photos = query1.ToArray();
            //this.photos = listPhoto;
            random = new Random();
        }
        public int numPhoto
        {
            get
            {
                return photos.Length;
            }
        }
        public Photo this[int i]
        {
            get { return photos[i]; }
        }
    }
    public class PhotoViewHolder1 : RecyclerView.ViewHolder
    {
        public ImageView Image { get; set; }
        public TextView Caption { get; set; }
        public PhotoViewHolder1(View itemview, Action<int> listener) : base(itemview)
        {
            Image = itemview.FindViewById<ImageView>(Resource.Id.imageView);
            Caption = itemview.FindViewById<TextView>(Resource.Id.textView);
            itemview.Click += (sender, e) => listener(base.Position);
        }
    }
}