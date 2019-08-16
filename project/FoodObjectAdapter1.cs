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
    class FoodObjectAdapter1 : RecyclerView.Adapter
    {
        public event EventHandler<int> ItemClick;
    public FoodObject1 mFoodObject;
    public FoodObjectAdapter1(FoodObject1 fudobj)
    {
        mFoodObject = fudobj;
    }
    public override int ItemCount
    {
        get { return mFoodObject.numPhoto; }
    }
    public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
    {
        FoodViewHolder1 vh = holder as FoodViewHolder1;
        vh.Image.SetImageResource(mFoodObject[position].mPhotoID);
        vh.Caption.Text = mFoodObject[position].mCaption;
    }
    public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
    {
        View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.PhotoCard, parent, false);
        FoodViewHolder1 vh = new FoodViewHolder1(itemView, OnClick);
        return vh;
    }
    private void OnClick(int obj)
    {
        if (ItemClick != null)
            ItemClick(this, obj);
    }
}
}