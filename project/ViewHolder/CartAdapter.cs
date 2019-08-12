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
using Java.Text;
using Java.Util;
using project.Interface;
using project.Model;

namespace project.ViewHolder
{
    public class CartViewHolder //: RecyclerView.ViewHolder , View.OnClickListener, View.OnCreateContextMenuListener
    {

        //    public TextView txt_cart_name, txt_price;
        //    public ImageView img_cart_count;

        //    private ItemClickListener itemClickListener;

        //    public void setTxt_cart_name(TextView txt_cart_name)
        //    {
        //        this.txt_cart_name = txt_cart_name;
        //    }

        //    public CartViewHolder(View itemView)
        //    {
        //        super(itemView);
        //        txt_cart_name = itemView.findViewById(R.id.cart_item_name);
        //        txt_price = itemView.findViewById(R.id.cart_item_Price);
        //        img_cart_count = itemView.findViewById(R.id.cart_item_count);
        //        itemView.setOnCreateContextMenuListener(this);
        //    }

        //    @Override
        //    public void onClick(View view)
        //    {

        //    }

        //    @Override
        //    public void onCreateContextMenu(ContextMenu menu, View v, ContextMenu.ContextMenuInfo menuInfo)
        //    {
        //        menu.setHeaderTitle(Common.DELETE);

        //        menu.add(0, 0, getAdapterPosition(), Common.DELETE);
        //    }
        //}

        //    public class CartAdapter : RecyclerView.Adapter<CartViewHolder>
        //    {

        //        private List<Order> listData = new List<Order>();
        //        private Context context;

        //        public CartAdapter(List<Order> listData, Context context)
        //        {
        //            this.listData = listData;
        //            this.context = context;
        //        }

        //        @Override
        //            public CartViewHolder onCreateViewHolder(ViewGroup parent, int viewType)
        //        {
        //            LayoutInflater inflater = LayoutInflater.from(context);
        //            View itemView = inflater.inflate(R.layout.cart_layout, parent, false);
        //            return new CartViewHolder(itemView);
        //        }

        //        public void onBindViewHolder(CartViewHolder holder, int position)
        //        {
        //            TextDrawable drawable = TextDrawable.builder().buildRound("" + listData.get(position).getQuanlity(), Color.RED);
        //            holder.img_cart_count.setImageDrawable(drawable);

        //            Locale locale = new Locale("en", "US");
        //            NumberFormat fmt = NumberFormat.getCurrencyInstance(locale);
        //            int price = (Integer.parseInt(listData.get(position).getPrice())) * (Integer.parseInt(listData.get(position).getQuanlity()));
        //            holder.txt_price.setText(fmt.format(price));
        //            holder.txt_cart_name.setText(listData.get(position).getProductName());

        //        }

        //        public int getItemCount()
        //        {

        //            return listData.size();
        //        }
    }
}