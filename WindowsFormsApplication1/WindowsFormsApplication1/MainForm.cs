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
        /// <summary>
        /// Таблица содержащия все данные
        /// </summary>
        private DataTable _datatable;
        /// <summary>
        /// Глобальный список элементов со значениями
        /// </summary>
        private List<ICircuit> listCircuit = new List<ICircuit>();
        /// <summary>
        /// Форма поиска элементов
        /// </summary>
        private SearchForm _searchForm = new SearchForm();

        public MainForm()
        {
            InitializeComponent();
            CreateDatatable();
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            elementSelectionControl1.ReadOnly = true; //Включение режима чтения
        }
        /// <summary>
        /// Создание таблицы
        /// </summary>
        private void CreateDatatable()
        {
            _datatable = new DataTable();
            //Имя элемента цепи
            var column1 = new DataColumn("Элемент");
            {
                column1.Caption = "Element";
                column1.DataType = typeof(string);
                column1.ReadOnly = true;
            };
            //Значения элементов
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
        /// <summary>
        /// Добавление нового элемента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newelement_Click(object sender, EventArgs e)
        {
            //Добавление через контроль
            NewElementControl GG = new NewElementControl();
            //Добавление через форму
            //NewComponentForm ff = new NewComponentForm();
            ICircuit circuit = null;
            if (GG.ShowDialog() == DialogResult.OK)
            {
                circuit = GG.Element;
                listCircuit.Add(circuit);
                var row = _datatable.NewRow();
                row[0] = circuit.Name;
                row[1] = Convert.ToString(circuit.CalculateValue(Convert.ToDouble(FrequencyTextBox.Text)));
                _datatable.Rows.Add(row);
                dataGridView1.Update(); //Обновляем таблицу
            }
        }
        /// <summary>
        /// Выход из проекта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Сохранение текущей базы данных и таблицы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    serializer.Serialize(jwriter, listCircuit);
                }
                MessageBox.Show("Сохранено");
            }
        }
        /// <summary>
        /// Открытие ранее сохраненого проекта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    listCircuit = serializer.Deserialize<List<ICircuit>>(jReader);
                    _datatable.Rows.Clear();
                    for (int i = 0; i < listCircuit.Count; i++)
                    {
                        var element = listCircuit[i];
                        var row = _datatable.NewRow();
                        row[0] = element.Name;
                        row[1] = Convert.ToString(element.CalculateValue(Convert.ToDouble(FrequencyTextBox.Text)));
                        _datatable.Rows.Add(row);
                    }
                }
                MessageBox.Show("Файл запущен");
            }
        }
        /// <summary>
        /// Удаление строки из таблицы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void remove_Click(object sender, EventArgs e)
        {
           DialogResult result = MessageBox.Show("Удалить строку?","Удалить", MessageBoxButtons.YesNo, 
            MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
           {
               foreach (DataGridViewCell cell in dataGridView1.SelectedCells)//Заполняем таблицу    
               {
                dataGridView1.Rows.RemoveAt(cell.RowIndex);//Удаляет указанную строку по индексу
               }
           }         
        }
        /// <summary>
        /// Создание новой базы данных и таблицы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Все не сохраннёные данные могут быть потеряны. Создать новый файл?", "New", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            try
            {
                if (result == DialogResult.Yes)
                {
                    //Удаляет нынешнию таблицу
                    _datatable.Rows.Clear();
                    listCircuit.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Введениие частоты и обновление таблицы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Set_Click(object sender, EventArgs e)
        {
            _datatable.Rows.Clear();//Удаление всех строк из таблицы
            for (int i = 0; i < listCircuit.Count; i++)
            {
                var element = listCircuit[i];
                var row = _datatable.NewRow();
                row[0] = element.Name;
                row[1] = Convert.ToString(element.CalculateValue(Convert.ToDouble(FrequencyTextBox.Text)));
                _datatable.Rows.Add(row);//Добавление новых строк
            };
             dataGridView1.Refresh();//Обновление таблицы
        }
        /// <summary>
        /// Кнопка поиска
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void search_Click(object sender, EventArgs e)
        {
            _searchForm.LocalList = listCircuit.ToList();//Создание нового списка
            _searchForm.ShowDialog();//Вызов окна
        }
       /// <summary>
       /// Перечесление всех имен элементов
       /// </summary>
        private string[] element = { "Resistor", "Inductor", "Capacitor"};
       /// <summary>
       /// Кнопка рандомного элемента
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void randomelement_Click(object sender, EventArgs e)
        {
            ICircuit randomCircuit;
            var random = new Random();
            var elementType = random.Next(3);
            if (elementType == 0)
            {
                randomCircuit = new Resistor()
                {
                    Resistance = random.Next(500)
                };
            }
            else if (elementType ==1)
            {
                randomCircuit = new Capacitor()
                {
                    Capacitance = random.Next(9000000)
                };
            }
            else 
            {
                randomCircuit = new Induct()
                {
                    Inductance = random.Next(9000000)
                };
            }
            listCircuit.Add(randomCircuit);
            var row = _datatable.NewRow();
            row[0] = randomCircuit.Name;
            row[1] = Convert.ToString(randomCircuit.CalculateValue(Convert.ToDouble(FrequencyTextBox.Text)));
            _datatable.Rows.Add(row);//Добавление строки
            dataGridView1.Update();//Обновление таблицы
        }
        /// <summary>
        /// Параметр таблицы предназначенный для чтения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                elementSelectionControl1.Element = listCircuit[Convert.ToInt32(dataGridView1.CurrentRow.Index)];
            }
        }
    }
}
        