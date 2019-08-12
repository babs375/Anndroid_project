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

namespace project.Model
{
    public class Category
    {
        private string Name;
        private string Image;

        public Category()
        {
        }

        public Category(string name, string image)
        {
            Name = name;
            Image = image;
        }

        public string getImage()
        {
            return Image;
        }

        public void setImage(string image)
        {
            Image = image;
        }

        public string getName()
        {
            return Name;
        }

        public void setName(string name)
        {
            Name = name;
        }
    }
}