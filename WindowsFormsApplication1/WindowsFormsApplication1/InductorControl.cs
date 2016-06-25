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
    public partial class InductorControl : UserControl
    {
        public InductorControl()
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
                    InductorTextBox.ReadOnly = value;
                }
                else
                {
                    InductorTextBox.ReadOnly = value; 
                }

            }
        }
        /// <summary>
        /// Обработка контрола
        /// </summary>
        public Induct Value
        {
            get
            {
                return new Induct() {Inductance = Convert.ToInt32(InductorTextBox.Text)};
            }
            set
            {
                InductorTextBox.Text = value.Inductance.ToString();
            }
        }
    }
}
