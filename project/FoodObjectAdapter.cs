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

namespace project
{
    public class FoodObjectAdapter : RecyclerView.Adapter
    {
        public event EventHandler<int> ItemClick;
        public FoodObject mFoodObject;
        public FoodObjectAdapter(FoodObject fudobj)
        {
            mFoodObject = fudobj;
        }
        public override int ItemCount
        {
            get { return mFoodObject.numPhoto; }
        }
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            FoodViewHolder vh = holder as FoodViewHolder;
            vh.Image.SetImageResource(mFoodObject[position].mPhotoID);
            vh.Caption.Text = mFoodObject[position].mCaption;
        }
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.PhotoCard, parent, false);
            FoodViewHolder vh = new FoodViewHolder(itemView, OnClick);
            return vh;
        }
        private void OnClick(int obj)
        {
            if (ItemClick != null)
                ItemClick(this, obj);
        }
    }
}