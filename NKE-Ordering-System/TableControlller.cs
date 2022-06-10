using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKE_Ordering_System
{
    class TableController : ControllerInterface
    {
        NKEOrderDataContext db = new NKEOrderDataContext();
        public int Id { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public int Order_ID { get; set; }
        public bool exists { get; set; }

        public List<String> allAvailableTable = new List<String>();
        public List<String> allActiveTable = new List<String>();
        public List<String> allTable = new List<String>();

        public void showAllTable()
        {
            var queryTable =
                from table in db.Tables
                select table;

            foreach (var table in queryTable)
            {
                Name = table.TableName.ToString();
                allTable.Add(Name);
            }
        }

        public void showAvailableTable()
        {
            /*IEnumerable<Table> queryTable =
                from table in db.Tables
                select table;
*/
            var queryTable =
                from table in db.Tables
                where table.TableStatus == 0
                select table;

            foreach (var table in queryTable)
            {
                Name = table.TableName.ToString();
                allAvailableTable.Add(Name);
                /*allTable.Add(table.TableName);*/
                /*Id = table.TableID;
                Name = table.TableName.ToString();
                Status = int.Parse(table.TableStatus.ToString());*/
            }
        }

        public void showActiveTable()
        {
            var queryTable =
                from table in db.Tables
                where table.TableStatus == 1
                select table;

            foreach (var table in queryTable)
            {
                Name = table.TableName.ToString();
                allActiveTable.Add(Name);
            }
        }

        public void getTableID()
        {
            IEnumerable<Table> queryTable =
                from table in db.Tables
                where table.TableName == Name
                select table;

            foreach(Table table in queryTable)
            {
                Id = table.TableID;
            }
        }

        public void getOrderID()
        {
            IEnumerable<Order_Table> queryFindOrder =
                from o_table in db.Order_Tables
                join table in db.Tables on o_table.TableID equals table.TableID
                where table.TableStatus == 1
                where table.TableName == Name
                select o_table;

            foreach (Order_Table o in queryFindOrder)
            {
                Id = o.TableID;
                Order_ID = o.Order_Table_ID;
            }
        }

        public void Show()
        {
            
        }

        public void Store()
        {
            IEnumerable<Table> queryTable =
                from t in db.Tables
                where t.TableName == Name
                select t;

            if(queryTable.Count() != 0)
            {
                exists = true;
            }
            else
            {
                exists = false;

                Table table = new Table();
                table.TableID = Id;
                table.TableName = Name;
                table.TableStatus = Status;

                db.Tables.InsertOnSubmit(table);

                db.SubmitChanges();
            }
        }

        public void Update()
        {
            IEnumerable<Table> queryTable =
                from t in db.Tables
                where t.TableID == Id
                select t;

            foreach(Table table in queryTable)
            {
                table.TableName = Name;
            }

            db.SubmitChanges();
        }

        public void UpdateTableStatus()
        {
            IEnumerable<Table> queryTable =
                from table in db.Tables
                join o_table in db.Order_Tables on table.TableID equals o_table.TableID
                where table.TableID == Id
                select table;

            foreach(Table t in queryTable)
            {
                t.TableStatus = Status;
            }

            db.SubmitChanges();
        }

        public void Delete()
        {
            IEnumerable<Table> queryTable =
                from t in db.Tables
                where t.TableName == Name
                select t;

            foreach(Table table in queryTable)
            {
                db.Tables.DeleteOnSubmit(table);
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
