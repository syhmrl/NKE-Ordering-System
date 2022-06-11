using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKE_Ordering_System
{
    class ItemController : ControllerInterface
    {
        NKEOrderDataContext db = new NKEOrderDataContext();
        public int Item_ID { get; set; }
        public string Item_Name { get; set; }
        public decimal Item_Price { get; set; }
        public string Item_Type { get; set; }
        public int Order_Item_ID { get; set; }
        public int Order_ID { get; set; }
        public int Quantity { get; set; }
        public bool exist { get; set; }

        public List<String> allItem = new List<String>();
        public List<String> allItemType = new List<String>();
        public List<String> allOrder = new List<String>();

        // public string[,] order;
        public ItemController()
        {
            Item_ID = Item_ID;
            Item_Name = Item_Name;
            Item_Price = Item_Price;
            Item_Type = Item_Type;
            Order_Item_ID = Order_Item_ID;
            Order_ID = Order_ID;
            Quantity = Quantity;
        }
        public void showItem()
        {
            IEnumerable<Item> queryItem = 
                from item in db.Items
                where item.ItemType == Item_Type
                select item;

            foreach (Item item in queryItem)
            {
                Item_Name = item.ItemName.ToString();
                allItem.Add(Item_Name);
            }
        }

        public void getItemType()
        {
            /*IEnumerable<Item> queryGetType =
                (from item in db.Items
                 where item.ItemType == Item_Type
                 select item).Distinct();*/

            var query = db.Items.Select(item => item.ItemType).Distinct();

            foreach (var i in query)
            {
                Item_Type = i;
                allItemType.Add(Item_Type);
            }
        }

        public void getOrderID()
        {
            IEnumerable<Order_Item> queryFindOrder =
                from o_item in db.Order_Items
                where o_item.OrderID == Order_ID
                select o_item;

            foreach (Order_Item o in queryFindOrder)
            {
                Order_Item_ID = o.OrderItemID;
                Order_ID = o.OrderID;
            }
        }

        public void getItemData()
        {
            IEnumerable<Item> queryItem =
                from item in db.Items
                where item.ItemName == Item_Name
                select item;

            foreach(Item item in queryItem)
            {
                Item_Name = item.ItemName;
                decimal price = (decimal)item.ItemPrice;
                Item_Price = price;
            }
        }

        public void getItemID()
        {
            IEnumerable<Item> queryItem =
                from item in db.Items
                where item.ItemName == Item_Name
                select item;

            foreach (Item item in queryItem)
            {
                Item_ID = item.ItemID;
            }
        }

        public void getQuantity()
        {
            IEnumerable<Order_Item> queryOrderItem =
                from o_item in db.Order_Items
                where o_item.ItemID == Item_ID
                where o_item.OrderID == Order_ID
                select o_item;

            if(queryOrderItem.Count() != 0)
            {
                exist = true;

                foreach (Order_Item o in queryOrderItem)
                    Quantity = (int)o.Quantity;
            }
            else
            {
                exist = false;
            }
        }

        public void checkStatus()
        {
            IEnumerable<Order_Item> queryOrderItem =
                from o_item in db.Order_Items
                where o_item.OrderID == Order_ID
                select o_item;

            if(queryOrderItem.Count() != 0)
            {
                exist = true;
            }
            else
            {
                exist = false;
            }
        }

        public void DeleteAllOrder()
        {
            IEnumerable<Order_Item> queryOrderItem =
                from o_item in db.Order_Items
                where o_item.OrderID == Order_ID
                select o_item;

            foreach (Order_Item o in queryOrderItem)
                db.Order_Items.DeleteOnSubmit(o);

            db.SubmitChanges();
        }

        public void Show()
        {
            var queryItem =
                from item in db.Items
                join o_item in db.Order_Items on item.ItemID equals o_item.ItemID
                where o_item.OrderID == Order_ID
                select new
                {
                    Name = item.ItemName,
                    Type = item.ItemType,
                    Price = item.ItemPrice,
                    Quantity = o_item.Quantity
                };

            // int i = 1;



            foreach (var item in queryItem)
            {
                /*ItemController order = new ItemController();
                order.Item_Name = item.Name;
                order.Item_Type = item.Type;
                order.Item_Price = (decimal)item.Price;
                order.Quantity = (int)item.Quantity;

                Item_Name = item.Name;
                Item_Type = item.Type;
                Item_Price = (decimal)item.Price;
                Quantity = (int)item.Quantity;*/

                allOrder.Add(item.ToString());
                /*allOrder.Add(i.ToString());
                allOrder.Add(Item_Name);
                allOrder.Add(Item_Type);
                allOrder.Add(Item_Price.ToString());
                allOrder.Add(Quantity.ToString());
                order[i, 0] = item.Name;
                order[i, 1] = item.Type.ToString();
                order[i, 2] = item.Price.ToString();
                order[i, 3] = item.Quantity.ToString();*/
                // i++;
                // i++;
            }
        }

        /*public int debug()
        {
            // var MaxID = db.Order_Items.Max(i => i.OrderItemID);
            var SearchAny = db.Order_Items.Count();
            if(SearchAny != 0)
            {
                var MaxID = db.Order_Items.Max(i => i.OrderItemID);
                int newId = MaxID;
                return ++newId;
            }
            else
            {
                int newId = 1000;
                return newId;
            }
        }*/

        public void DeleteOrder()
        {
            IEnumerable<Order_Item> queryOrderItem =
                from o_item in db.Order_Items
                where o_item.OrderItemID == Order_Item_ID
                select o_item;

            foreach (Order_Item o in queryOrderItem)
                db.Order_Items.DeleteOnSubmit(o);

            db.SubmitChanges();
        }

        public void Store()
        {
            IEnumerable<Item> queryItem =
                from i in db.Items
                where i.ItemName == Item_Name
                select i;

            if(queryItem.Count() != 0)
            {
                exist = true;
            }
            else
            {
                exist = false;

                Item item = new Item();
                item.ItemID = Item_ID;
                item.ItemName = Item_Name;
                item.ItemPrice = Item_Price;
                item.ItemType = Item_Type;

                db.Items.InsertOnSubmit(item);
                db.SubmitChanges();
            }
        }

        public void StoreOrderItem()
        {

            Order_Item item = new Order_Item();
            item.OrderItemID = Order_Item_ID;
            item.OrderID = Order_ID;
            item.ItemID = Item_ID;
            item.Quantity = Quantity;

            db.Order_Items.InsertOnSubmit(item);

            db.SubmitChanges();
        }

        public void UpdateOrderItem()
        {
            IEnumerable<Order_Item> queryItem =
                from o_item in db.Order_Items
                where o_item.OrderID == Order_ID
                where o_item.ItemID == Item_ID
                select o_item;

            if(queryItem.Count() != 0)
            {
                exist = true;

                foreach (Order_Item o in queryItem)
                {
                    o.Quantity = Quantity;
                }

                db.SubmitChanges();
            }
            else
            {
                exist = false;
            }
        }

        public void Update()
        {
            IEnumerable<Item> queryItem =
                from i in db.Items
                where i.ItemID == Item_ID
                select i;

            foreach(Item item in queryItem)
            {
                item.ItemName = Item_Name;
                item.ItemType = Item_Type;
                item.ItemPrice = Item_Price;
            }

            db.SubmitChanges();
        }

        public void Delete()
        {
            IEnumerable<Item> queryItem =
                 from i in db.Items
                 where i.ItemName == Item_Name
                 select i;

            foreach(Item item in queryItem)
            {
                db.Items.DeleteOnSubmit(item);
            }

            db.SubmitChanges();
        }

        public int generateID()
        {
            var SearchAny = db.Items.Count();
            if (SearchAny != 0)
            {
                var MaxID = db.Items.Max(i => i.ItemID);
                int newId = MaxID;
                return ++newId;
            }
            else
            {
                int newId = 1000;
                return newId;
            }
            /*Random random = new Random();
            int newID = random.Next(1000, 9999);
            return newID;*/
        }

        public int generateOrderItemId()
        {
            var SearchAny = db.Order_Items.Count();
            if (SearchAny != 0)
            {
                var MaxID = db.Order_Items.Max(i => i.OrderItemID);
                int newId = MaxID;
                return ++newId;
            }
            else
            {
                int newId = 1000;
                return newId;
            }
        }
    }
}
