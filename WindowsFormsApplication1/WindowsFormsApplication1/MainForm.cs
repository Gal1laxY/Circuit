using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft;
using Model;
using System.IO;
using System.Numerics;


namespace WindowsFormsApplication1
{
    public partial class MainForm : Form
    {
        private DataTable _datatable;

        public MainForm()
        {
            InitializeComponent();
            CreateDatatable();
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        public class ListElement
        {
            public static List<ICircuit> list = new List<ICircuit>();
        }
        private void CreateDatatable()
        {
            _datatable = new DataTable();
            var column1 = new DataColumn("Элемент");
            {
                column1.Caption = "Element";
                column1.DataType = typeof(string);
                column1.ReadOnly = true;
            };
            var column2 = new DataColumn("Значение");
            {
                column2.Caption = "Value";
                column2.DataType = typeof(string);
                column2.ReadOnly = true;
            };
            _datatable.Columns.Add(column1);
            _datatable.Columns.Add(column2);
            dataGridView1.DataSource = _datatable;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            NewComponentForm ff = new NewComponentForm();

            ICircuit circuit = null;
            if (ff.ShowDialog() == DialogResult.OK)
            {
                circuit = ff.Circuit;
                ListElement.list.Add(circuit);
                var row = _datatable.NewRow();
                row[0] = circuit.Name;
                row[1] = Convert.ToString(circuit.CalculateValue(Convert.ToDouble(textBox1.Text)));
                _datatable.Rows.Add(row);
                dataGridView1.Update();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var serializer = new Newtonsoft.Json.JsonSerializer();
            serializer.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            serializer.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto;
            serializer.Formatting = Newtonsoft.Json.Formatting.Indented;

            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "MyElement | *.element";
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            var filename = saveFileDialog.FileName;

            using (StreamWriter streamwriter = new StreamWriter(filename)) 
            {
                using (Newtonsoft.Json.JsonWriter jwriter = new Newtonsoft.Json.JsonTextWriter(streamwriter))
                {
                    serializer.Serialize(jwriter, ListElement.list);
                }
                MessageBox.Show("Сохранено");
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var serializer = new Newtonsoft.Json.JsonSerializer();
            serializer.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            serializer.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto;
            serializer.Formatting = Newtonsoft.Json.Formatting.Indented;

            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "MyElement | *.element";
            if (openFileDialog.ShowDialog()== DialogResult.Cancel)
                return;
            var filename = openFileDialog.FileName;

            using (StreamReader streamReader = new StreamReader(filename))
            {
                using (Newtonsoft.Json.JsonReader jReader = new Newtonsoft.Json.JsonTextReader(streamReader))
                {
                    ListElement.list = serializer.Deserialize<List<ICircuit>>(jReader);
                    _datatable.Rows.Clear();
                    for (int i=0; i< ListElement.list.Count; i++)
                    {
                        var element = ListElement.list[i];
                        var row = _datatable.NewRow();
                        row[0] = element.Name;
                        row[1] = Convert.ToString(element.CalculateValue(Convert.ToDouble(textBox1.Text)));
                        _datatable.Rows.Add(row);
                    }
                }
                MessageBox.Show("Файл запущен");
            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
           DialogResult result = MessageBox.Show("Удалить строку?","Удалить", MessageBoxButtons.YesNo, 
            MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
           {
               foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
               {
                dataGridView1.Rows.RemoveAt(cell.RowIndex);
               }
           }   
            
           
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Все не сохраннёные данные могут быть потеряны. Создать новый файл?", "New", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            try
            {
                if (result == DialogResult.Yes)
                {
                    _datatable.Rows.Clear();
                    ListElement.list.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _datatable.Rows.Clear();
            for (int i = 0; i < ListElement.list.Count; i++)
            {
                var element = ListElement.list[i];
                var row = _datatable.NewRow();
                row[0] = element.Name;
                row[1] = Convert.ToString(element.CalculateValue(Convert.ToDouble(textBox1.Text)));
                _datatable.Rows.Add(row);
            };
             dataGridView1.Refresh();
        }
    }
}
        