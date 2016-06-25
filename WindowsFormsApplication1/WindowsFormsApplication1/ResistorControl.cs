using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;


namespace WindowsFormsApplication1
{
    public partial class ResistorControl : UserControl
    {
        public ResistorControl()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Функция чтения
        /// </summary>
        public bool ReadOnly
        {
            set
            {
                if (value)
                {
                    ResistorTextBox.ReadOnly = value;  
                }
                else
                {
                    ResistorTextBox.ReadOnly = value;  
                }
                //ResistorTextBox.ReadOnly = value;
            }
        }
        /// <summary>
        /// Обработка контроля
        /// </summary>
        public Resistor Value
        {
            get
            {
                return new Resistor() { Resistance = Convert.ToInt32(ResistorTextBox.Text) };
            }
            set
            {
                ResistorTextBox.Text = value.Resistance.ToString();
            }
        }
    }
}
