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
    public partial class CapacitorControl : UserControl
    {
        public CapacitorControl()
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
                    CapacitorTextBox.ReadOnly = value;
                }
                else
                {
                    CapacitorTextBox.ReadOnly = value;
                }
            }
        }
        /// <summary>
        /// Обработка контроля
        /// </summary>
        public Capacitor Value
        {
            get
            {
                return new Capacitor() { Capacitance = Convert.ToInt32(CapacitorTextBox.Text) };
            }
            set
            {
                CapacitorTextBox.Text = value.Capacitance.ToString();
            }
        }
    }

}
