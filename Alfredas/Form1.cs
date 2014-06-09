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
        Boolean List1HasChanged;
        public Form1()
        {
            List1HasChanged = false;
            List1CheckedItemIndex = -2;
            InitializeComponent();
            FillListBoxWorkers();
            List1CheckedItemIndex = -1;
        }
        public void FillListBoxWorkers()
        {
            dataGridView1.Rows.Add(false,"Marko", 1000.00, 0, 0);
            dataGridView1.Rows.Add(false, "Employee 2", 2000.00, 0, 0);
            dataGridView1.Rows.Add(false, "Employee 3", 3000.00, 0, 0);

            dataGridView2.Rows.Add(false, "PROFIT", 100000.0, 130000.0, 121000.0, 1200.0);
            dataGridView2.Rows.Add(false, "COSTS", 500000.0, 450000.0, 480000.0, 800.0);
            dataGridView2.Rows.Add(false, "Indicator 3", 2.0, 2.4, 4.0, 2.0);
            dataGridView2.Rows.Add(false, "Indicator 4", 3.0, 3.6, 6.0, 3.0);

            dataGridView3.Rows.Add(false, "RELATIONSHIP WITH...", 11.0, 9.0);
            dataGridView3.Rows.Add(false, "CUTTING ON THE RET...", 9.0, 5.0);
            dataGridView3.Rows.Add(false, "IMPROVING PROFESS...", 7.0, 6.0);
            dataGridView3.Rows.Add(false, "TASK 4", 8.0, 7.0);
            dataGridView3.Rows.Add(false, "TASK 5", 9.0, 8.0);
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (List1CheckedItemIndex != -2)
            {
                if (e.ColumnIndex == 0)
                {
                    if (List1CheckedItemIndex != e.RowIndex)
                    {
                        if (List1CheckedItemIndex != -1)
                        {
                            List1HasChanged = true;
                            dataGridView1.Rows[List1CheckedItemIndex].Cells[0].Value = false;
                        }
                        List1CheckedItemIndex = e.RowIndex;
                    }
                    else
                    {
                        if (List1HasChanged == true)
                        {
                            List1HasChanged = false;
                        }
                        else
                        {
                            List1CheckedItemIndex = -1;
                        }
                    }
                } 
            }
        }
        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                dataGridView1.EndEdit();
            }
        }
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (dataGridView1.SelectedCells.Count == 1 && dataGridView1.SelectedCells[0].ColumnIndex == 0 && dataGridView1.SelectedCells[0].RowIndex != -1 && e.KeyValue == 32)
            {
                dataGridView1.EndEdit(); // removes functionality from spacebar
            }
        }
        private void calculateSalary() 
        {        
            // data1: 0 - boolean; 1 - vardas;      2 - Bazinis atlyginimas;
            // data2: 0 - boolean; 1 - pavadinimas; 2 - Bazine reiksme;         3 - Faktine reiksme;    4 - Tiksline reiksme;   5 - Maksimali kintama reiksme;
            // data3: 0 - boolean; 1 - pavadinimas; 2 - Maksimalus ivertinimas; 3 - Ivertinimas 
            int indicatorsSalary = 0;        
            int tasksSalary = 0;
            if(dataGridView2.Rows.Count != 0)
            {            
                for(int i = 0; i < dataGridView2.Rows.Count; i++)
                {       
                    if((Boolean)dataGridView2.Rows[i].Cells[0].Value == true)
                    {
                        //Log.e(Config.TAG, "indicator.id: " + indicator.title);
                        if((double)dataGridView2.Rows[i].Cells[4].Value > (double)dataGridView2.Rows[i].Cells[2].Value)
                        {
                            if(((double)dataGridView2.Rows[i].Cells[2].Value <= (double)dataGridView2.Rows[i].Cells[3].Value) && ((double)dataGridView2.Rows[i].Cells[3].Value <= (double)dataGridView2.Rows[i].Cells[4].Value))
                            {
                                indicatorsSalary += Convert.ToInt32((((double)dataGridView2.Rows[i].Cells[3].Value - (double)dataGridView2.Rows[i].Cells[2].Value) / ((double)dataGridView2.Rows[i].Cells[4].Value - (double)dataGridView2.Rows[i].Cells[2].Value)) * (double)dataGridView2.Rows[i].Cells[5].Value);
                            }
                            if((double)dataGridView2.Rows[i].Cells[3].Value > (double)dataGridView2.Rows[i].Cells[4].Value)
                            {
                                indicatorsSalary += Convert.ToInt32((double)dataGridView2.Rows[i].Cells[5].Value);
                            }
                        }
                        else if((double)dataGridView2.Rows[i].Cells[4].Value < (double)dataGridView2.Rows[i].Cells[2].Value)
                        {
                            if(((double)dataGridView2.Rows[i].Cells[4].Value <= (double)dataGridView2.Rows[i].Cells[3].Value) && ((double)dataGridView2.Rows[i].Cells[3].Value <= (double)dataGridView2.Rows[i].Cells[2].Value))
                            {
                                indicatorsSalary += Convert.ToInt32((((double)dataGridView2.Rows[i].Cells[3].Value - (double)dataGridView2.Rows[i].Cells[2].Value) / ((double)dataGridView2.Rows[i].Cells[4].Value - (double)dataGridView2.Rows[i].Cells[2].Value)) * (double)dataGridView2.Rows[i].Cells[5].Value);
                            }
                            if((double)dataGridView2.Rows[i].Cells[3].Value < (double)dataGridView2.Rows[i].Cells[4].Value)
                            {
                                indicatorsSalary += Convert.ToInt32((double)dataGridView2.Rows[i].Cells[5].Value);
                            }
                        }
                    }
                }
            }        
            float sfSum = 0;        
            float sSum = 0;        
            if(dataGridView3.Rows.Count != 0)
            {
                for (int i = 0; i < dataGridView3.Rows.Count; i++)
                {
                    if ((Boolean)dataGridView2.Rows[i].Cells[0].Value == true)
                    {
                        sfSum += (float)dataGridView3.Rows[i].Cells[3].Value; // ivertinimas
                        sSum += (float)dataGridView3.Rows[i].Cells[2].Value;   // maksimalus ivertinimas      
                    }   
                }        
            }
            if (sSum != 0)
            {
                tasksSalary = Convert.ToInt32((sfSum / sSum)); //* maxKDU;        // bendras ivertinimas visoms,  reiksmem maxKDU rasti
            }
            else
            {
                tasksSalary = 0;
            }          
        }
    }
}
