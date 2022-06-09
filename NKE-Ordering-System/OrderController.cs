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

        public void Delete()
        {
            
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
            Order_Table table = new Order_Table();
            table.Order_Table_ID = Order_Table_ID;
            table.TableID = TableID;
            table.OrderID = OrderID;

            db.Order_Tables.InsertOnSubmit(table);

            db.SubmitChanges();
            // }
                
        }

        

        public void Update()
        {
            
        }

        public int generateID()
        {
            Random random = new Random();
            int newID = random.Next(1000, 9999);
            OrderID = newID;
            return OrderID;
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

            foreach (var item in queryItem)
            {
                decimal quantity = (decimal)item.Quantity;
                decimal price = (decimal)item.Price;

                Total_Price += price * quantity;
            }

            return Total_Price;
        }
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
