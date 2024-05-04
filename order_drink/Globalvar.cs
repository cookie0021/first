using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace order_drink
{
     class Globalvar
    {
        public static int k=0;   //用來更改數量
        public static int i = 0; //產品數量
        public static ArrayList listItems= new ArrayList();
        public static List<ArrayList> purchaserOrderList = new List<ArrayList>();
        public static List<int> listSubTotal = new List<int>();
        public static string toppings { get; set; }
        public static string itemsSeries { get; set; }
        public static int LPrice { get; set; }
        public static int botPrice { get; set; }
        public static string size { get; set; }
        public static string itmeName { get; set; }
        public static int toppingPrice { get; set; }
        public static int subTotal { get; set; }
        public static int orderTotal { get; set; }
        public static string sweet { get; set; }
        public static string ice { get; set; }
        public static string qty { get; set; }
        public static int currentRowIndexInt { get; set; }
        public static string tel { get; set; }


        public static void listAdd()
        {
            if (i >= 1)
            {

              
                listItems.Add(itmeName);
                listItems.Add(LPrice);
                listItems.Add(sweet);
                listItems.Add(ice);
                listItems.Add(toppings);
                listItems.Add(qty);
                listItems.Add(subTotal);
                purchaserOrderList.Add(listItems);
                listItems = new ArrayList();
               

            }

        }

        public static void AddDIV(string name , FormOrder fgrid )
        {
            listAdd();
            k = 0;
            botPrice = 0;
            size = "L";
            qty = "1";
            sweet = "";
            ice = "";
            toppings = "";
            toppingPrice = 0;
            currentRowIndexInt = fgrid.DGV.Rows.Count - 1;
            fgrid.DGV.Rows.Add(name + "(L)");
            fgrid.DGV.CurrentCell = fgrid.DGV.Rows[currentRowIndexInt].Cells[0];
            itmeName = name;
        }

        public static void calcTotal()
        {
            orderTotal = 0;
            int qty = Convert.ToInt32(Globalvar.qty);
            if (size == "L")
            {
                subTotal = (LPrice + toppingPrice) * qty;
            }
            else if (size == "bottle")
            {
                 subTotal = (botPrice + toppingPrice) * qty;
            }           

            listSubTotal.Add(subTotal);
            foreach (int item in listSubTotal)
            {
               orderTotal += item;
            }
            
        }

    }
}
