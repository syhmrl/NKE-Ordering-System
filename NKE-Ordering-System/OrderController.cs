using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKE_Ordering_System
{
    class OrderController : TakeAway, ControllerInterface
    {
        NKEOrderDataContext db = new NKEOrderDataContext();
        public int OrderID { get; set; }
        public DateTime Order_Time { get; set; }
        public int Order_Status { get; set; }
        public int Order_Type { get; set; }
        public decimal Total_Price { get; set; } = 0;
        public int Order_Table_ID { get; set; }
        public int UserID { get; set; }
        public int TableID { get; set; }
        public bool exists { get; set; }

        /*public OrderController()
        {
            OrderID = OrderID;
            Order_Time = Order_Time;
            Order_Status = Order_Status;
            Order_Type = Order_Type;
            Total_Price = Total_Price;
            Order_Table_ID = Order_Table_ID;
            UserID = UserID;
            TableID = TableID;
        }*/

        public void getOrderID()
        {
            IEnumerable<Order_Table> querytable =
                from o_table in db.Order_Tables
                where o_table.TableID == TableID
                select o_table;

            foreach (Order_Table o in querytable)
                OrderID = o.OrderID;
        }

        public int generateID()
        {
            var SearchAny = db.Orders.Count();
            if (SearchAny != 0)
            {
                var MaxID = db.Orders.Max(i => i.OrderID);
                int newId = MaxID;
                return ++newId;
            }
            else
            {
                int newId = 1000;
                return newId;
            }
        }

        public int generateOrderTableID()
        {
            var SearchAny = db.Order_Tables.Count();
            if (SearchAny != 0)
            {
                var MaxID = db.Order_Tables.Max(i => i.Order_Table_ID);
                int newId = MaxID;
                return ++newId;
            }
            else
            {
                int newId = 1000;
                return newId;
            }
        }
        public void getTotalPrice()
        {
            IEnumerable<Order> queryOrder =
                from order in db.Orders
                where order.OrderID == OrderID
                select order;

            foreach (Order o in queryOrder)
                Total_Price = (decimal)o.OrderTotalPrice;
        }

        public void UpdateTotalPrice()
        {
            IEnumerable<Order> queryOrder =
                from order in db.Orders
                where order.OrderID == OrderID
                select order;

            foreach (Order order in queryOrder)
                order.OrderTotalPrice = Total_Price;

            db.SubmitChanges();
        }

        public decimal calculateTotalPrice()
        {

            /*IEnumerable<Item> queryItem =
                from item in db.Items
                join o_item in db.Order_Items on item.ItemID equals o_item.ItemID
                where o_item.OrderID == OrderID
                select new
                {
                    item.ItemPrice,
                    o_item.Quantity
                };*/

            /*var queryItem = db.Items.Join(db.Order_Items,
                                          ) */

            var queryItem =
                from item in db.Items
                join o_item in db.Order_Items on item.ItemID equals o_item.ItemID
                where o_item.OrderID == OrderID
                select new
                {
                    Price = item.ItemPrice,
                    Quantity = o_item.Quantity
                };

            Total_Price = 0;

            foreach (var item in queryItem)
            {
                int quantity = (int)item.Quantity;
                decimal price = (decimal)item.Price;

                Total_Price += price * quantity;
            }

            return Total_Price;
        }

        public void UpdateStatus()
        {
            IEnumerable<Order> queryOrder =
                from order in db.Orders
                where order.OrderID == OrderID
                select order;

            foreach (Order order in queryOrder)
                order.OrderStatus = Order_Status;

            db.SubmitChanges();
        }

        public void DeleteOrderTable()
        {
            IEnumerable<Order_Table> queryOrderTable =
                from o_table in db.Order_Tables
                where o_table.OrderID == OrderID
                select o_table;

            foreach (Order_Table ot in queryOrderTable)
                db.Order_Tables.DeleteOnSubmit(ot);

            db.SubmitChanges();
        }

        public void Delete()
        {
            IEnumerable<Order> queryOrder =
                from order in db.Orders
                where order.OrderID == OrderID
                select order;

            foreach (Order order in queryOrder)
                db.Orders.DeleteOnSubmit(order);

            IEnumerable<Order_Table> queryTable =
                from table in db.Order_Tables
                where table.OrderID == OrderID
                select table;

            foreach (Order_Table table in queryTable)
                db.Order_Tables.DeleteOnSubmit(table);

            db.SubmitChanges();
        }

        public void Show()
        {
            
        }

        public void Store()
        { 
            Order order = new Order();
            order.OrderID = OrderID;
            order.OrderTime = Order_Time;
            order.OrderStatus = Order_Status;
            order.OrderType = Order_Type;
            order.OrderTotalPrice = Total_Price;
            order.UserID = UserID;

            Order_Table table = new Order_Table();
            table.Order_Table_ID = Order_Table_ID;
            table.TableID = TableID;
            table.OrderID = OrderID;


            db.Orders.InsertOnSubmit(order);
            db.Order_Tables.InsertOnSubmit(table);

            db.SubmitChanges();
            
        }

        public void storeTable()
        {
            /*Table existingTable = db.Tables.FirstOrDefault(t => t.TableID == TableID);

            if (existingTable != null)
            {*/
            /*Order_Table table = new Order_Table();
            table.Order_Table_ID = Order_Table_ID;
            table.TableID = TableID;
            table.OrderID = OrderID;

            db.Order_Tables.InsertOnSubmit(table);

            db.SubmitChanges();*/
            // }
                
        }

        

        public void Update()
        {
            
        }

        /*public int debug()
        {
            *//*var queryItem =
                from item in db.Items
                join o_item in db.Order_Items on item.ItemID equals o_item.ItemID
                where o_item.OrderID == OrderID
                select new
                {
                    Price = item.ItemPrice,
                    Quantity = o_item.Quantity
                };*/

            /*var queryItem =
                from item in db.Items
                join o_item in db.Order_Items on item.ItemID equals o_item.ItemID
                where o_item.OrderID == OrderID
                select new
                {
                    Price = item.ItemPrice,
                    Quantity = o_item.Quantity
                };

            int count = queryItem.Count();

            return count;*//*
        }*/
        public override void storeTA()
        {

        }
        public override void deleteTA()
        {
            throw new NotImplementedException();
        }

        public override void updateTA()
        {
            throw new NotImplementedException();
        }

        public override void showTA()
        {
            throw new NotImplementedException();
        }

        public override int generateTA_ID()
        {
            throw new NotImplementedException();
        }



        /*public void getUser(string userName)
        {
            IEnumerable<User> queryUser =
                from user in db.Users
                where user.Name == userName
                select user;

            foreach(User user in queryUser)
            {
                UserID = user.UserID;
            }
        }*/
    }
}
