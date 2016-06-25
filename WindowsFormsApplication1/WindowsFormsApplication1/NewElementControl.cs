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
    public partial class NewElementControl : Form
    {
        public NewElementControl()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Запускает контрол
        /// </summary>
        public ICircuit Element
        {
            get
            {
                return elementSelectionControl1.Element;
            }
            set
            {
                elementSelectionControl1.Element = value;
            }
        }
        /// <summary>
        /// Кнопка окончания ввода новых данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newelement_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
        /// <summary>
        /// Кнопка отмены
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
