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
        public Form1()
        {
            InitializeComponent();
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
            // tikrinti ar paspaudimas ant naujo ar seno jau checked (clear ir check kita arba tik clear)
        }
    }
    class Darbuotojas
    {
        string vardas;
        double atlyginimas;
    }
}
