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
        Boolean FinishedLoading;
        public Form1()
        {
            FinishedLoading = false;
            List1HasChanged = false;
            List1CheckedItemIndex = -2;
            InitializeComponent();
            FillListBoxWorkers();
            List1CheckedItemIndex = -1;
            FinishedLoading = true;
        }
        public void FillListBoxWorkers()
        {
            dataGridView1.Rows.Add(false,"Marko", 1000.00, 0, 0, 1000.00);
            dataGridView1.Rows.Add(false, "Employee 2", 2000.00, 0, 0, 2000.00);
            dataGridView1.Rows.Add(false, "Employee 3", 3000.00, 0, 0, 3000.00);

            dataGridView2.Rows.Add(false, "PROFIT", 100000.0, 121000.0, 130000.0, 1200.0);
            dataGridView2.Rows.Add(false, "COSTS", 500000.0, 480000.0, 450000.0, 800.0);
            dataGridView2.Rows.Add(false, "Indicator 3", 2.0, 4.0, 2.4, 2.0);
            dataGridView2.Rows.Add(false, "Indicator 4", 3.0, 6.0, 3.6, 3.0);

            dataGridView3.Rows.Add(false, "RELATIONSHIP WITH...", 11.0, 9.0);
            dataGridView3.Rows.Add(false, "CUTTING ON THE RET...", 9.0, 5.0);
            dataGridView3.Rows.Add(false, "IMPROVING PROFESS...", 7.0, 6.0);
            dataGridView3.Rows.Add(false, "TASK 4", 8.0, 7.0);
            dataGridView3.Rows.Add(false, "TASK 5", 9.0, 8.0);
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (FinishedLoading == true)
            {
                if (e.ColumnIndex == 0)
                {
                    if (List1CheckedItemIndex != -2)
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
                else
                {
                    for (int i = 1; i < dataGridView1.Rows[e.RowIndex].Cells.Count; i++)
                    {
                        if (dataGridView1.Rows[e.RowIndex].Cells[i].Value is DBNull)
                        {
                            dataGridView1.Rows[e.RowIndex].Cells[i].Value = 0;
                        }
                    }
                    dataGridView1.Rows[e.RowIndex].Cells[5].Value = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[2].Value) + Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[3].Value) + Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
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
        private Tuple<int,int> calculateSalary() 
        {        
            
            // data1: 0 - boolean; 1 - vardas;      2 - Bazinis atlyginimas;    3 - Rodikliai;          4 - Uzduotys;           5 - Viso;
            // data2: 0 - boolean; 1 - pavadinimas; 2 - Bazine reiksme;         3 - Faktine reiksme;    4 - Tiksline reiksme;   5 - Maksimali kintama reiksme;
            // data3: 0 - boolean; 1 - pavadinimas; 2 - Maksimalus ivertinimas; 3 - Ivertinimas 
            int indicatorsSalary = 0;        
            int tasksSalary = 0;
            if(dataGridView2.Rows.Count != 0)
            {
                for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                {       
                    if((Boolean)dataGridView2.Rows[i].Cells[0].Value == true)
                    {
                        //Log.e(Config.TAG, "indicator.id: " + indicator.title);
                        if((double)dataGridView2.Rows[i].Cells[4].Value > (double)dataGridView2.Rows[i].Cells[2].Value)
                        {
                            if(((double)dataGridView2.Rows[i].Cells[2].Value <= (double)dataGridView2.Rows[i].Cells[3].Value) && ((double)dataGridView2.Rows[i].Cells[3].Value <= (double)dataGridView2.Rows[i].Cells[4].Value))
                            {
                                indicatorsSalary += Convert.ToInt32(Math.Ceiling((((double)dataGridView2.Rows[i].Cells[3].Value - (double)dataGridView2.Rows[i].Cells[2].Value) / ((double)dataGridView2.Rows[i].Cells[4].Value - (double)dataGridView2.Rows[i].Cells[2].Value)) * (double)dataGridView2.Rows[i].Cells[5].Value));
                            }
                            if((double)dataGridView2.Rows[i].Cells[3].Value > (double)dataGridView2.Rows[i].Cells[4].Value)
                            {
                                indicatorsSalary += Convert.ToInt32(Math.Ceiling((double)dataGridView2.Rows[i].Cells[5].Value));
                            }
                        }
                        else if((double)dataGridView2.Rows[i].Cells[4].Value < (double)dataGridView2.Rows[i].Cells[2].Value)
                        {
                            if(((double)dataGridView2.Rows[i].Cells[4].Value <= (double)dataGridView2.Rows[i].Cells[3].Value) && ((double)dataGridView2.Rows[i].Cells[3].Value <= (double)dataGridView2.Rows[i].Cells[2].Value))
                            {
                                indicatorsSalary += Convert.ToInt32(Math.Ceiling((((double)dataGridView2.Rows[i].Cells[3].Value - (double)dataGridView2.Rows[i].Cells[2].Value) / ((double)dataGridView2.Rows[i].Cells[4].Value - (double)dataGridView2.Rows[i].Cells[2].Value)) * (double)dataGridView2.Rows[i].Cells[5].Value));
                            }
                            if((double)dataGridView2.Rows[i].Cells[3].Value < (double)dataGridView2.Rows[i].Cells[4].Value)
                            {
                                indicatorsSalary += Convert.ToInt32(Math.Ceiling((double)dataGridView2.Rows[i].Cells[5].Value));
                            }
                        }
                    }
                }
            }
            double sfSum = 0;
            double sSum = 0;        
            if(dataGridView3.Rows.Count != 0)
            {
                for (int i = 0; i < dataGridView3.Rows.Count - 1; i++)
                {
                    if ((Boolean)dataGridView3.Rows[i].Cells[0].Value == true)
                    {
                        sfSum += (double)dataGridView3.Rows[i].Cells[3].Value; // ivertinimas
                        sSum += (double)dataGridView3.Rows[i].Cells[2].Value;   // maksimalus ivertinimas      
                    }   
                }        
            }
            if (sSum != 0)
            {
                tasksSalary = Convert.ToInt32(Math.Ceiling((sfSum / sSum) * Convert.ToDouble(textBox1.Text)));      // bendras ivertinimas visoms,  reiksmem maxKDU rasti
            }
            else
            {
                tasksSalary = 0;
            }
            return new Tuple<int, int>(indicatorsSalary, tasksSalary);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (TikrintiArPazymeti() == true)
            {
                Tuple<int, int> result = calculateSalary();
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    if ((Boolean)dataGridView1.Rows[i].Cells[0].Value == true)
                    {
                        if (dataGridView1.Rows[i].Cells[2].Value is DBNull)
                        {
                            dataGridView1.Rows[i].Cells[2].Value = 0.0;
                        }
                        dataGridView1.Rows[i].Cells[3].Value = result.Item1;
                        dataGridView1.Rows[i].Cells[4].Value = result.Item2;
                        dataGridView1.Rows[i].Cells[5].Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value) + result.Item1 + result.Item2;
                    }
                }
            }
        }
        private Boolean TikrintiArPazymeti()
        {
            Boolean rado = false;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                if ((Boolean)dataGridView1.Rows[i].Cells[0].Value == true)
                {
                    rado = true;
                }
            }
            if (rado == false)
            {
                return false;
            }

            rado = false;
            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {
                if ((Boolean)dataGridView2.Rows[i].Cells[0].Value == true)
                {
                    rado = true;
                }
            }
            if (rado == false)
            {
                return false;
            }

            rado = false;
            for (int i = 0; i < dataGridView3.Rows.Count - 1; i++)
            {
                if ((Boolean)dataGridView3.Rows[i].Cells[0].Value == true)
                {
                    rado = true;
                }
            }
            if (rado == false)
            {
                return false;
            }
            double rezult;
            if (Double.TryParse(textBox1.Text, out rezult) == false)
            {
                return false;
            }
            return true;
        }
        private void lietuviškaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FinishedLoading = false;

            archyvasToolStripMenuItem.Text = "Archyvas";
            apieToolStripMenuItem.Text = "Apie";
            pagalbaToolStripMenuItem.Text = "Pagalba";
            keistiKalbąToolStripMenuItem.Text = "Pasirinkti kalbą";

            label1.Text = "Darbuotojai";
            label2.Text = "Rodikliai";
            richTextBox1.Text = "Maksimali kintama dalis pagal užduotis:";
            label4.Text = "Užduotys";
            button1.Text = "Skaičiuoti";

            Pasirinkti_darbuotoja.HeaderText = "Pasirinkti darbuotoją";
            Vardas.HeaderText = "Vardas";
            Bazinis_atlyginimas.HeaderText = "Bazinis atlyginimas";
            Rodikliai.HeaderText = "Rodikliai";
            Užduotys.HeaderText = "Užduotys";
            Viso.HeaderText = "Viso";

            Rodiklio_pasirinkimas.HeaderText = "Pasirinkti rodiklį";
            Pavadinimas.HeaderText = "Pavadinimas";
            Bazinė_reikšmė.HeaderText = "Bazinė reikšmė";
            Faktinė_reikšmė.HeaderText = "Faktinė reikšmė";
            Tikslinė_reikšmė.HeaderText = "Tikslinė reikšmė";
            Maksimali_kintama_dalis.HeaderText = "Maksimali kintama dalis";

            Užduoties_pasirinkimas.HeaderText = "Pasirinkti užduotį";
            PavadinimasUzd.HeaderText = "Pavadinimas";
            Maksimalus_įvertinimas.HeaderText = "Maksimalus įvertinimas";
            Įvertinimas.HeaderText = "Įvertinimas";

            FinishedLoading = true;
        }
        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FinishedLoading = false;

            archyvasToolStripMenuItem.Text = "Archive";
            apieToolStripMenuItem.Text = "About";
            pagalbaToolStripMenuItem.Text = "Help";
            keistiKalbąToolStripMenuItem.Text = "Select language";

            label1.Text = "Employees";
            label2.Text = "Indicators";
            richTextBox1.Text = "Maximum task-related variable part:";
            label4.Text = "Tasks";
            button1.Text = "Calculate";

            Pasirinkti_darbuotoja.HeaderText = "Select an employee";
            Vardas.HeaderText = "Name";
            Bazinis_atlyginimas.HeaderText = "Basic Salary";
            Rodikliai.HeaderText = "Indicators";
            Užduotys.HeaderText = "Tasks";
            Viso.HeaderText = "Sum";

            Rodiklio_pasirinkimas.HeaderText = "Select indicator";
            Pavadinimas.HeaderText = "Title";
            Bazinė_reikšmė.HeaderText = "Baseline value";
            Faktinė_reikšmė.HeaderText = "Actual outcome";
            Tikslinė_reikšmė.HeaderText = "Target value";
            Maksimali_kintama_dalis.HeaderText = "Maximum variable part";

            Užduoties_pasirinkimas.HeaderText = "Select task";
            PavadinimasUzd.HeaderText = "Title";
            Maksimalus_įvertinimas.HeaderText = "Maximum evaluation";
            Įvertinimas.HeaderText = "Evaluation";

            FinishedLoading = true;
        }
        private void русскийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FinishedLoading = false;

            archyvasToolStripMenuItem.Text = "Архив";
            apieToolStripMenuItem.Text = "Описание";
            pagalbaToolStripMenuItem.Text = "Помощь";
            keistiKalbąToolStripMenuItem.Text = "Выберите язык";

            label1.Text = "Cотрудники";
            label2.Text = "Показатели";
            richTextBox1.Text = "Максимальная переменная часть в соответствии с заданиями:";
            label4.Text = "Задании";
            button1.Text = "Cчитать";

            Pasirinkti_darbuotoja.HeaderText = "Выберите сотрудника";
            Vardas.HeaderText = "Имя";
            Bazinis_atlyginimas.HeaderText = "Баз. зарплата";
            Rodikliai.HeaderText = "Показатели";
            Užduotys.HeaderText = "Задании";
            Viso.HeaderText = "Количество";

            Rodiklio_pasirinkimas.HeaderText = "Выберите скорость";
            Pavadinimas.HeaderText = "Название";
            Bazinė_reikšmė.HeaderText = "Базовое значение";
            Faktinė_reikšmė.HeaderText = "Фактический результат";
            Tikslinė_reikšmė.HeaderText = "Целевое значение";
            Maksimali_kintama_dalis.HeaderText = "Максимальная переменная часть";

            Užduoties_pasirinkimas.HeaderText = "Выберите задачу";
            PavadinimasUzd.HeaderText = "Название";
            Maksimalus_įvertinimas.HeaderText = "Максимальная оценка";
            Įvertinimas.HeaderText = "Oценка";

            FinishedLoading = true;
        }
        private void pagalbaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form form = new Form())
            {
                form.Text = pagalbaToolStripMenuItem.Text;
                form.ClientSize = new System.Drawing.Size(1000, 500);
                form.MinimumSize = new System.Drawing.Size(1000, 500);
                form.ShowDialog();
            } 
        }
        private void apieToolStripMenuItem_Click(object sender, EventArgs e)// PVZ kitom skiltim
        {
            using (Form form = new Form())
            {
                form.Text = apieToolStripMenuItem.Text;
                form.ClientSize = new System.Drawing.Size(1000, 500);
                form.MinimumSize = new System.Drawing.Size(1000, 500);
                RichTextBox about = new RichTextBox();
                about.Dock = DockStyle.Fill;
                about.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
                about.Location = new System.Drawing.Point(4, 4);
                about.ReadOnly = true;
                about.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
                if (apieToolStripMenuItem.Text == "Apie")
                {
                    about.Text = Alfredas.Properties.Resources.AboutLT;
                }
                else if (apieToolStripMenuItem.Text == "About")
                {
                    about.Text = Alfredas.Properties.Resources.AboutEN;
                }
                else if (apieToolStripMenuItem.Text == "Описание")
                {
                    about.Text = Alfredas.Properties.Resources.AboutRU;
                }
                form.Controls.Add(about);
                form.ShowDialog();
            }
        }
        private void archyvasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form form = new Form())
            {
                form.Text = archyvasToolStripMenuItem.Text;
                form.ClientSize = new System.Drawing.Size(1000, 500);
                form.MinimumSize = new System.Drawing.Size(1000, 500);
                form.ShowDialog();
            } 
        }
    }
}
