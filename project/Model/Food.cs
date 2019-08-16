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

namespace project.Model
{
    public class Food
    {
        [PrimaryKey, AutoIncrement]
        public int mFid { get; set; }
        public int mPhotoID { get; set; }
        public string mCaption { get; set; }
        public string mDescription { get; set; }
        public int mCatID { get; set; }
        public int mPrice { get; set; }
    }
}