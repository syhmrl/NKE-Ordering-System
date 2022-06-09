using System;
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

        public void Show()
        {
            
        }

        public void getItemID()
        {
            IEnumerable<Item> queryItem =
                from item in db.Items
                where item.ItemName == Item_Name
                select item;

            foreach(Item item in queryItem)
            {
                Item_ID = item.ItemID;
            }
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
            Random random = new Random();
            int newID = random.Next(1000, 9999);
            return newID;
        }
    }
}
