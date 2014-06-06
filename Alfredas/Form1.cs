using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Alfredas
{
    public partial class Form1 : Form
    {
        int List1CheckedItemIndex;
        public Form1()
        {
            InitializeComponent();
            List1CheckedItemIndex = -1;
            FillListBoxWorkers();
        }
        public void FillListBoxWorkers()
        {
            listView1.Columns.Add("Vardas", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Bazinis atlyginimas", -2, HorizontalAlignment.Left);

            listView2.Columns.Add("Pavadinimas", -2, HorizontalAlignment.Left);
            listView2.Columns.Add("Bazinė reikšmė", -2, HorizontalAlignment.Left);
            listView2.Columns.Add("Faktinė reikšmė", -2, HorizontalAlignment.Left);
            listView2.Columns.Add("Tikslinė reikšmė", -2, HorizontalAlignment.Left);
            listView2.Columns.Add("Maks. kintama dalis", -2, HorizontalAlignment.Left);

            listView3.Columns.Add("Pavadinimas", -2, HorizontalAlignment.Left);
            listView3.Columns.Add("Maksimalus įvertinimas", -2, HorizontalAlignment.Left);
            listView3.Columns.Add("Įvertinimas", -2, HorizontalAlignment.Left);

            ListViewItem item = new ListViewItem("Marko");
            item.Checked = false;
            item.SubItems.Add("1000.00");
            listView1.Items.Add(item);

            item = new ListViewItem("Employee 2");
            item.Checked = false;
            item.SubItems.Add("2000.00");
            listView1.Items.Add(item);

            item = new ListViewItem("Employee 3");
            item.Checked = false;
            item.SubItems.Add("3000.00");
            listView1.Items.Add(item);

            item = new ListViewItem("PROFIT");
            item.Checked = false;
            item.SubItems.AddRange(new string[] {"100000.0", "130000.0","121000.0", "1200.0"});
            listView2.Items.Add(item);

            item = new ListViewItem("COSTS");
            item.Checked = false;
            item.SubItems.AddRange(new string[] { "500000.0", "450000.0", "480000.0", "800.0" });
            listView2.Items.Add(item);

            item = new ListViewItem("Indicator 3");
            item.Checked = false;
            item.SubItems.AddRange(new string[] { "2.0", "2.4", "4.0", "2.0" });
            listView2.Items.Add(item);

            item = new ListViewItem("Indicator 4");
            item.Checked = false;
            item.SubItems.AddRange(new string[] { "3.0", "3.6", "6.0", "3.0" });
            listView2.Items.Add(item);

            item = new ListViewItem("RELATIONSHIP WITH...");
            item.Checked = false;
            item.SubItems.AddRange(new string[] { "11.0", "9.0"});
            listView3.Items.Add(item);

            item = new ListViewItem("CUTTING ON THE RET...");
            item.Checked = false;
            item.SubItems.AddRange(new string[] { "9.0", "5.0" });
            listView3.Items.Add(item);

            item = new ListViewItem("IMPROVING PROFESS...");
            item.Checked = false;
            item.SubItems.AddRange(new string[] { "7.0", "6.0" });
            listView3.Items.Add(item);

            item = new ListViewItem("TASK 4");
            item.Checked = false;
            item.SubItems.AddRange(new string[] { "8.0", "7.0" });
            listView3.Items.Add(item);

            item = new ListViewItem("TASK 5");
            item.Checked = false;
            item.SubItems.AddRange(new string[] { "9.0", "8.0" });
            listView3.Items.Add(item);
        }
        private void listView1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (List1CheckedItemIndex != e.Index)
            {
                if (List1CheckedItemIndex != -1)
                {
                    listView1.Items[List1CheckedItemIndex].Checked = false;
                }
                List1CheckedItemIndex = e.Index;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem("Įveskite nauja varda čia!");
            item.Checked = false;
            item.SubItems.Add("0.00");
            listView1.Items.Add(item);
            for (int i = 0; i < listView1.Columns.Count; i++)
            {
                listView1.Columns[i].Width = -2;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem("Įveskite nauja pavadinima čia!");
            item.Checked = false;
            item.SubItems.AddRange(new string[] { "0.0", "0.0", "0.0", "0.0" });
            listView2.Items.Add(item);
            for (int i = 0; i < listView2.Columns.Count; i++)
            {
                listView2.Columns[i].Width = -2;
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem("Įveskite nauja pavadinima čia!");
            item.Checked = false;
            item.SubItems.AddRange(new string[] { "0.0", "0.0" });
            listView3.Items.Add(item);
            for (int i = 0; i < listView3.Columns.Count; i++)
            {
                listView3.Columns[i].Width = -2;
            }
        }
        private void listView1_KeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 46)
            {
                if (listView1.SelectedItems.Count != 0)
                {
                    foreach (ListViewItem itemSelected in listView1.SelectedItems)
                    {
                        listView1.Items.Remove(itemSelected);
                    }
                }
            }
        }
        private void listView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 46)
            {
                if (listView2.SelectedItems.Count != 0)
                {
                    foreach (ListViewItem itemSelected in listView2.SelectedItems)
                    {
                        listView2.Items.Remove(itemSelected);
                    }
                }
            }
        }
        private void listView3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 46)
            {
                if (listView3.SelectedItems.Count != 0)
                {
                    foreach (ListViewItem itemSelected in listView3.SelectedItems)
                    {
                        listView3.Items.Remove(itemSelected);
                    }
                }
            }
        }
        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                ListViewHitTestInfo info = listView1.HitTest(e.X, e.Y);
                ListViewItem.ListViewSubItem subitem = new ListViewItem.ListViewSubItem();
                if (listView1.SelectedItems[0] == info.Item)
                {
                    subitem = info.SubItem;
                }
                string text = subitem.Text;

            }
        }
    }
}
