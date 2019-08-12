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
    public class Request
    {
        private string phone;
        private string name;
        private string address;
        private string total;
        private string status;
        private List<Order> foods;
        private bool partial = false;

        public Request()
        {
        }

        public Request(string phone, string name, string address, string total, List<Order> foods)
        {
            this.phone = phone;
            this.name = name;
            this.address = address;
            this.total = total;
            this.foods = foods;
            this.status = "0"; //Default is 0, 0:Placed, 1: Shipping, 2: Shipped
        }

        public bool isPartial()
        {
            return partial;
        }

        public void setPartial(bool partial)
        {
            this.partial = partial;
        }

        public string getStatus()
        {
            return status;
        }

        public void setStatus(string status)
        {
            this.status = status;
        }

        public string getPhone()
        {
            return phone;
        }

        public void setPhone(string phone)
        {
            this.phone = phone;
        }

        public string getName()
        {
            return name;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public string getAddress()
        {
            return address;
        }

        public void setAddress(string address)
        {
            this.address = address;
        }

        public string getTotal()
        {
            return total;
        }

        public void setTotal(string total)
        {
            this.total = total;
        }

        public List<Order> getFoods()
        {
            return foods;
        }

        public void setFoods(List<Order> foods)
        {
            this.foods = foods;
        }
    }
}