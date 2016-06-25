using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace WindowsFormsApplication1
{
    public partial class SearchForm : Form
    {
       private List<ICircuit> _locallist = new List<ICircuit>();

        public SearchForm()
        {
            InitializeComponent();
        }

        public List<ICircuit> LocalList
        { set { _locallist = value; } }
        /// <summary>
        /// Кнопка поиска по данным введным с TextBox1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
        try
            {
                string search = textBox1.Text;
                if (search == String.Empty) { MessageBox.Show("Не было введенно ключевое слово."); return; }
                dataGridView1.Rows.Clear();
                foreach (var circuit in _locallist)
                {
                    if (circuit.Name.Contains(search))
                    {
                        dataGridView1.Rows.Add(circuit.Name, circuit.CalculateValue(1.0));
                    }
                }
                if(dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("Этого элемента нет в списке.");
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка.");
            }
        }
        /// <summary>
        /// Кнопка отмены
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
    }

