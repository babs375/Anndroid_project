using Android.Util;
using SQLite;
using project.Model;
using System.Collections.Generic;
using System.Linq;
using System;

namespace project.Database
{
    public class DatabaseL
    {
        string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        public static Photo[] listPhoto =
        {
            new Photo() {mFid = 1, mPhotoID = Resource.Drawable.caesar_salad, mCaption = "Caesar Salad", mDescription = "Delicious", mCatID=1, mPrice = 10},
            new Photo() {mFid = 2, mPhotoID = Resource.Drawable.chicken_mcnuggets, mCaption = "Chicken Nuggets", mDescription = "Fried", mCatID=1, mPrice = 5},
            new Photo() {mFid = 3, mPhotoID = Resource.Drawable.chicken_mcwrap, mCaption = "Chicken Wrap", mDescription = "Mouth Watering", mCatID=1, mPrice = 15},
            new Photo() {mFid = 4, mPhotoID = Resource.Drawable.fish_and_chips, mCaption = "Fish_and Chips", mDescription = "Crispy", mCatID=1, mPrice = 8},
            new Photo() {mFid = 5, mPhotoID = Resource.Drawable.egg_cheese_mcgriddles, mCaption = "Egg Cheese Griddles", mDescription = "Smoked", mCatID=1, mPrice = 12},
            new Photo() {mFid = 6, mPhotoID = Resource.Drawable.cashew_salad, mCaption = "Cashew Salad", mDescription = "Tasty", mCatID=1, mPrice = 12},
            new Photo() {mFid = 7, mPhotoID = Resource.Drawable.hashbrowns, mCaption = "Hashbrowns", mDescription = "Crunchy", mCatID=1, mPrice = 7},
            new Photo() {mFid = 8, mPhotoID = Resource.Drawable.egg_mcmuffin, mCaption = "Egg Muffin", mDescription = "Protien Rich", mCatID=1, mPrice = 5},
            new Photo() {mFid = 9, mPhotoID = Resource.Drawable.egg_blt_bagel, mCaption = "Egg Bagel", mDescription = "Baked", mCatID=1, mPrice = 5},
            new Photo() {mFid = 10, mPhotoID = Resource.Drawable.egg_mcmuffin1, mCaption = "Jumbo Egg Muffin", mDescription = "Extra Eggy", mCatID=1, mPrice = 10},


            new Photo() {mFid = 11, mPhotoID = Resource.Drawable.caramel_latte_milk, mCaption = "Caramel Latte Milk", mDescription = "Delicious", mCatID=2, mPrice = 10},
            new Photo() {mFid = 12, mPhotoID = Resource.Drawable.coffee_frapp, mCaption = "Coffee Frapp", mDescription = "Refreshing", mCatID=2, mPrice = 5},
            new Photo() {mFid = 13, mPhotoID = Resource.Drawable.espresso, mCaption = "Espresso", mDescription = "Great Coffee", mCatID=2, mPrice = 15},
            new Photo() {mFid = 14, mPhotoID = Resource.Drawable.fruitopia_strawberry, mCaption = "Fruitopia Strawberry", mDescription = "Natural", mCatID=2, mPrice = 8},
            new Photo() {mFid = 15, mPhotoID = Resource.Drawable.hot_chocolate, mCaption = "Hot Chocolate", mDescription = "Richly Chocolate", mCatID=2, mPrice = 12},
            new Photo() {mFid = 16, mPhotoID = Resource.Drawable.iced_coffee, mCaption = "Iced Coffee", mDescription = "Chilled", mCatID=2, mPrice = 10},
            new Photo() {mFid = 17, mPhotoID = Resource.Drawable.mango_pineapple_smoothie, mCaption = "Mango Pineapple Smoothie", mDescription = "Fresh Pulp", mCatID=2, mPrice = 7},
            new Photo() {mFid = 18, mPhotoID = Resource.Drawable.mocha_milk, mCaption = "Mocha Milk", mDescription = "Protien Rich", mCatID=2, mPrice = 5},
            new Photo() {mFid = 19, mPhotoID = Resource.Drawable.pomegranate_smoothie, mCaption = "Pomegranate Smoothie", mDescription = "Cooled", mCatID=2, mPrice = 12},
            new Photo() {mFid = 20, mPhotoID = Resource.Drawable.pomegranate_yogurt, mCaption = "Pomegranate Yogurt", mDescription = "Energizing", mCatID=2, mPrice = 5},
        };
        public bool createDatabase()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "EatitDB.db")))
                {
                    connection.CreateTable<User>();
                    connection.CreateTable<UserCart>();
                    connection.CreateTable<Order>();
                    connection.CreateTable<Photo>();
                    foreach (Photo items in listPhoto)
                    {
                        insertFood(items);
                    }
                    //connection.Execute("INSERT INTO Photo(mFid, mPhotoID, mCaption, mDescription, mPrice, mCatID) VALUES(1,Resource.Drawable.ic_launcher, 'Food 1','Delicious',10,1)");
                    //connection.Execute("INSERT INTO Photo(mFid, mPhotoID, mCaption, mDescription, mPrice, mCatID) VALUES(2,Resource.Drawable.ic_launcher, 'Food 1','Delicious',10,1)");
                    //connection.Execute("INSERT INTO Photo(mFid, mPhotoID, mCaption, mDescription, mPrice, mCatID) VALUES(3,Resource.Drawable.ic_launcher, 'Food 1','Delicious',10,1)");
                    //connection.Execute("INSERT INTO Photo(mFid, mPhotoID, mCaption, mDescription, mPrice, mCatID) VALUES(4,Resource.Drawable.ic_launcher, 'Food 1','Delicious',10,1)");
                    //connection.Execute("INSERT INTO Photo(mFid, mPhotoID, mCaption, mDescription, mPrice, mCatID) VALUES(5,Resource.Drawable.ic_launcher, 'Food 1','Delicious',10,1)");
                    //connection.Execute("INSERT INTO Photo(mFid, mPhotoID, mCaption, mDescription, mPrice, mCatID) VALUES(6,Resource.Drawable.ic_launcher, 'Food 1','Delicious',10,1)");
                    //connection.Execute("INSERT INTO Photo(mFid, mPhotoID, mCaption, mDescription, mPrice, mCatID) VALUES(7,Resource.Drawable.ic_launcher, 'Food 1','Delicious',10,1)");
                    //connection.Execute("INSERT INTO Photo(mFid, mPhotoID, mCaption, mDescription, mPrice, mCatID) VALUES(8,Resource.Drawable.ic_launcher, 'Food 1','Delicious',10,1)");
                    //connection.Execute("INSERT INTO Photo(mFid, mPhotoID, mCaption, mDescription, mPrice, mCatID) VALUES(9,Resource.Drawable.ic_launcher, 'Food 1','Delicious',10,1)");
                    //connection.Execute("INSERT INTO Photo(mFid, mPhotoID, mCaption, mDescription, mPrice, mCatID) VALUES(10,Resource.Drawable.ic_launcher, 'Food 1','Delicious',10,1)");

                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }


        //Add or Insert Operation  

        // Food
        public bool insertFood(Photo food)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "EatitDB.db")))
                {
                    connection.Insert(food);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        // User
        public bool insertUser(User person)
            {
                try
                {
                    using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "EatitDB.db")))
                    {
                        connection.Insert(person);
                        return true;
                    }
                }
                catch (SQLiteException ex)
                {
                    Log.Info("SQLiteEx", ex.Message);
                    return false;
                }
            }

            // Usercart
            public bool insertUserCart(UserCart cart)
            {
                try
                {
                    using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "EatitDB.db")))
                    {
                        connection.Insert(cart);
                        return true;
                    }
                }
                catch (SQLiteException ex)
                {
                    Log.Info("SQLiteEx", ex.Message);
                    return false;
                }
            }

        // Usercart
        public bool insertOrder(Order odr)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "EatitDB.db")))
                {
                    connection.Insert(odr);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }



        // select all from table

        // Food
        public List<Photo> selectallFood()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "EatitDB.db")))
                {
                    return connection.Table<Photo>().ToList();
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
            }
        }

        //User
        public List<User> selectallUser()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "EatitDB.db")))
                {
                    return connection.Table<User>().ToList();
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
            }
            }

        //UserCart
        public List<UserCart> selectallUserCart()
            {
                try
                {
                    using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "EatitDB.db")))
                    {
                        return connection.Table<UserCart>().ToList();
                    }
                }
                catch (SQLiteException ex)
                {
                    Log.Info("SQLiteEx", ex.Message);
                    return null;
                }
            }

            //UserCart
            public List<Order> selectallOrder()
            {
                try
                {
                    using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "EatitDB.db")))
                    {
                        return connection.Table<Order>().ToList();
                    }
                }
                catch (SQLiteException ex)
                {
                    Log.Info("SQLiteEx", ex.Message);
                    return null;
                }
            }


        //Edit Operation  

            //User
            public bool updateUser(User person)
            {
                try
                {
                    using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "EatitDB.db")))
                    {
                        connection.Query<User>("UPDATE User set Name=?, Password=?, Email=? Where Uid=?", person.Name, person.Password, person.Email, person.Uid);
                        return true;
                    }
                }
                catch (SQLiteException ex)
                {
                    Log.Info("SQLiteEx", ex.Message);
                    return false;
                }
            }

            //Usercart
            public bool updateUserCart(UserCart cart)
            {
                try
                {
                    using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "EatitDB.db")))
                    {
                        connection.Query<UserCart>("UPDATE UserCart set Uid=?, Fid=?, Email=? Where Cid=?", cart.Uid, cart.Fid, cart.Cid);
                        return true;
                    }
                }
                catch (SQLiteException ex)
                {
                    Log.Info("SQLiteEx", ex.Message);
                    return false;
                }
            }

            //Orders
            public bool updateOrder(Order odr)
            {
                try
                {
                    using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "EatitDB.db")))
                    {
                        connection.Query<Order>("UPDATE Order set Uid=?, Fid=? Where Oid=?", odr.Uid, odr.Fid, odr.Oid);
                        return true;
                    }
                }
                catch (SQLiteException ex)
                {
                    Log.Info("SQLiteEx", ex.Message);
                    return false;
                }
            }

        //Delete Data Operation  

            //User
            public bool removeUser(User person)
            {
                try
                {
                    using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "EatitDB.db")))
                    {
                        connection.Delete(person);
                        return true;
                    }
                }
                catch (SQLiteException ex)
                {
                    Log.Info("SQLiteEx", ex.Message);
                    return false;
                }
            }

            //UserCart
            public bool removeUserCart(UserCart cart)
            {
                try
                {
                    using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "EatitDB.db")))
                    {
                        connection.Delete(cart);
                        return true;
                    }
                }
                catch (SQLiteException ex)
                {
                    Log.Info("SQLiteEx", ex.Message);
                    return false;
                }
            }

            //Order
            public bool removeUser(Order odr)
            {
                try
                {
                    using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "EatitDB.db")))
                    {
                        connection.Delete(odr);
                        return true;
                    }
                }
                catch (SQLiteException ex)
                {
                    Log.Info("SQLiteEx", ex.Message);
                    return false;
                }
            }

        //Select Operation  

             // Food
            public bool selectFood(int Fid)
            {
                try
                {
                    using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "EatitDB.db")))
                    {
                        connection.Query<User>("SELECT * FROM Photo Where mFid=?", Fid);
                        return true;
                    }
                }
                catch (SQLiteException ex)
                {
                    Log.Info("SQLiteEx", ex.Message);
                    return false;
                }
            }

            //User
            public bool selectUser(int Uid)
            {
                try
                {
                    using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "EatitDB.db")))
                    {
                        connection.Query<User>("SELECT * FROM User Where Uid=?", Uid);
                        return true;
                    }
                }
                catch (SQLiteException ex)
                {
                    Log.Info("SQLiteEx", ex.Message);
                    return false;
                }
            }

            //UserCart
            public bool selectUserCart(int Cid)
            {
                try
                {
                    using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "EatitDB.db")))
                    {
                        connection.Query<UserCart>("SELECT * FROM UserCart Where Uid=?", Cid);
                        return true;
                    }
                }
                catch (SQLiteException ex)
                {
                    Log.Info("SQLiteEx", ex.Message);
                    return false;
                }
            }

            //  Order
            public bool selectOrder(int oid)
            {
                try
                {
                    using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "EatitDB.db")))
                    {
                        connection.Query<Order>("SELECT * FROM Order Where Uid=?", oid);
                        return true;
                    }
                }
                catch (SQLiteException ex)
                {
                    Log.Info("SQLiteEx", ex.Message);
                    return false;
                }
            }

        //public List<Order> getCarts()
        //{

        //    SQLiteDatabase db = getReadableDatabase();
        //    SQLiteQueryBuilder qb = new SQLiteQueryBuilder();

        //    string[] sqlSelect = { "ProductName", "ProductId", "Quantity", "Price", "Discount" };
        //    string sqlTable = "OrderDetail";

        //    qb.setTables(sqlTable);
        //    Cursor c = qb.query(db, sqlSelect, null, null, null, null, null);

        //    final List<Order> result = new ArrayList<>();
        //    if (c.moveToFirst())
        //    {
        //        do
        //        {
        //            result.add(new Order(c.getstring(c.getColumnIndex("ProductId")),
        //                    c.getstring(c.getColumnIndex("ProductName")),
        //                    c.getstring(c.getColumnIndex("Quantity")),
        //                    c.getstring(c.getColumnIndex("Price")),
        //                    c.getstring(c.getColumnIndex("Discount"))
        //                    ));
        //        } while (c.moveToNext());
        //    }
        //    return result;
        //}

        //public void addToCart(Order order)
        //{
        //    SQLiteDatabase db = getReadableDatabase();
        //    string query = string.format("INSERT INTO OrderDetail(ProductId, ProductName, Quantity, Price, Discount) VALUES('%s','%s','%s','%s','%s');",
        //            order.getProductId(),
        //            order.getProductName(),
        //            order.getQuanlity(),
        //            order.getPrice(),
        //            order.getDiscount());

        //    db.execSQL(query);
        //}

        //public void removeFromCart(string order)
        //{

        //    SQLiteDatabase db = getReadableDatabase();

        //    string query = string.format("DELETE FROM OrderDetail WHERE ProductId='" + order + "'");
        //    db.execSQL(query);
        //}

        //public void cleanCart()
        //{
        //    SQLiteDatabase db = getReadableDatabase();
        //    string query = string.format("DELETE FROM OrderDetail");
        //    db.execSQL(query);
        //}
    }
}