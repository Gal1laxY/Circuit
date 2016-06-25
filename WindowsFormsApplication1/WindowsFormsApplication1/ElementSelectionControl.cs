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
    public partial class ElementSelectionControl : UserControl
    {
        public ICircuit SelectionControl { get; set; }

        public ElementSelectionControl()
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
                //if (value)
                //{
                    ResistorButton1.Enabled = !value;
                    CapacitorButton2.Enabled = !value;
                    InductorButton3.Enabled = !value;
                    resistorControl1.ReadOnly = value;
                    capacitorControl1.ReadOnly = value;
                    inductorControl1.ReadOnly = value;
                //}
                //else
                //{
                //    ResistorButton1.Enabled = !value;
                //    CapacitorButton2.Enabled = !value;
                //    InductorButton3.Enabled = !value;
                //    resistorControl1.ReadOnly = value;
                //    capacitorControl1.ReadOnly = value;
                //    inductorControl1.ReadOnly = value;
                //}
               
            }
        }
        /// <summary>
        /// Функция выбора контрола при срабатывание radio_button
        /// </summary>
        public ICircuit Element
        {
            get
            {
                if (ResistorButton1.Checked)
                {
                    return resistorControl1.Value;
                }

                else if (CapacitorButton2.Checked)
                {
                    return capacitorControl1.Value;
                }

                else if (InductorButton3.Checked)
                {
                    return inductorControl1.Value;
                }
                throw new NotImplementedException();
            }
            set
            {
                if (value is Resistor)
                {
                    ResistorButton1.Checked = true;
                    CapacitorButton2.Checked = false;
                    InductorButton3.Checked = false;
                    resistorControl1.Value = (Resistor)value;
                }
                else if (value is Capacitor)
                {
                    ResistorButton1.Checked = false;
                    CapacitorButton2.Checked = true;
                    InductorButton3.Checked = false;
                    capacitorControl1.Value = (Capacitor)value;
                }
                else if (value is Induct)
                {
                    ResistorButton1.Checked = false;
                    CapacitorButton2.Checked = false;
                    InductorButton3.Checked = true;
                    inductorControl1.Value = (Induct)value;
                }
            }
        }
        /// <summary>
        /// Функция видимости контролей
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            resistorControl1.Visible = true;
            inductorControl1.Visible = false;
            capacitorControl1.Visible = false;
        }
        /// <summary>
        /// Функция видимости контролей
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            resistorControl1.Visible = false;
            inductorControl1.Visible = false;
            capacitorControl1.Visible = true;
        }
        /// <summary>
        /// Функция видимости контролей
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton3_CheckedChanged_1(object sender, EventArgs e)
        {
            resistorControl1.Visible = false;
            inductorControl1.Visible = true;
            capacitorControl1.Visible = false;
        }
    }
}
