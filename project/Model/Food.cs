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
    public class Food
    {
        private string Name, Image, Description, Price, Discount, MenuId, FoodId, AvailabilityFlag;

        public Food()
        {
        }

        public Food(string name, string image, string description, string price, string discount, string menuId, string foodId, string availabilityFlag)
        {
            Name = name;
            Image = image;
            Description = description;
            Price = price;
            Discount = discount;
            MenuId = menuId;
            FoodId = foodId;
            AvailabilityFlag = availabilityFlag;
        }



        public string getName()
        {
            return Name;
        }

        public void setName(string name)
        {
            Name = name;
        }

        public string getImage()
        {
            return Image;
        }

        public void setImage(string image)
        {
            Image = image;
        }

        public string getDescription()
        {
            return Description;
        }

        public void setDescription(string description)
        {
            Description = description;
        }

        public string getPrice()
        {
            return Price;
        }

        public void setPrice(string price)
        {
            Price = price;
        }

        public string getDiscount()
        {
            return Discount;
        }

        public void setDiscount(string discount)
        {
            Discount = discount;
        }

        public string getMenuId()
        {
            return MenuId;
        }

        public void setMenuId(string menuId)
        {
            MenuId = menuId;
        }

        public string getFoodId()
        {
            return FoodId;
        }

        public void setFoodId(string foodId)
        {
            FoodId = foodId;
        }

        public string getAvailabilityFlag()
        {
            return AvailabilityFlag;
        }

        public void setAvailabilityFlag(string availabilityFlag)
        {
            AvailabilityFlag = availabilityFlag;
        }
    }
}