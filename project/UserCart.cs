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
using SQLite;

namespace project
{
    public class UserCart
    {
        [PrimaryKey, AutoIncrement]
        public int Cid { get; set; }
        public int Uid { get; set; }
        public int Fid { get; set; }

    }
}