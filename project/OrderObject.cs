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
using project.Model;

namespace project
{

    public class OrderObject
    {

        private Order[] odrlst;

        public OrderObject(int uid)
        {
            try
            {
                DatabaseL db = new DatabaseL();
                var query = db.selectallOrder();
                var query1 = query.Where(x => x.Uid == uid);
                odrlst = query.ToArray();
            }
            catch(Exception ex)
            {
            }
            
        }

        public int numPhoto
        {
            get
            {
                return odrlst.Length;
            }
        }
        public Order this[int i]
        {
            get { return odrlst[i]; }
        }
    }
    public class OrderViewHolder : RecyclerView.ViewHolder
    {
        public TextView OdrID { get; set; }
        public TextView OdrAmt { get; set; }
        public TextView OdrStat { get; set; }
        public TextView OdrAdd { get; set; }

        public OrderViewHolder(View itemview, Action<int> listener) : base(itemview)
        {
            OdrID = itemview.FindViewById<TextView>(Resource.Id.order_id);
            OdrStat = itemview.FindViewById<TextView>(Resource.Id.order_status);
            OdrAmt = itemview.FindViewById<TextView>(Resource.Id.order_amt);
            OdrAdd = itemview.FindViewById<TextView>(Resource.Id.order_address);

            itemview.Click += (sender, e) => listener(base.Position);
        }
    }
}