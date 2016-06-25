namespace WindowsFormsApplication1
{
    partial class ElementSelectionControl
    {
        /// <summary> 
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.ResistorButton1 = new System.Windows.Forms.RadioButton();
            this.CapacitorButton2 = new System.Windows.Forms.RadioButton();
            this.InductorButton3 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.inductorControl1 = new WindowsFormsApplication1.InductorControl();
            this.capacitorControl1 = new WindowsFormsApplication1.CapacitorControl();
            this.resistorControl1 = new WindowsFormsApplication1.ResistorControl();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // ResistorButton1
            // 
            this.ResistorButton1.AutoSize = true;
            this.ResistorButton1.Location = new System.Drawing.Point(6, 16);
            this.ResistorButton1.Name = "ResistorButton1";
            this.ResistorButton1.Size = new System.Drawing.Size(63, 17);
            this.ResistorButton1.TabIndex = 0;
            this.ResistorButton1.TabStop = true;
            this.ResistorButton1.Text = "Resistor";
            this.ResistorButton1.UseVisualStyleBackColor = true;
            this.ResistorButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged_1);
            // 
            // CapacitorButton2
            // 
            this.CapacitorButton2.AutoSize = true;
            this.CapacitorButton2.Location = new System.Drawing.Point(6, 39);
            this.CapacitorButton2.Name = "CapacitorButton2";
            this.CapacitorButton2.Size = new System.Drawing.Size(70, 17);
            this.CapacitorButton2.TabIndex = 1;
            this.CapacitorButton2.TabStop = true;
            this.CapacitorButton2.Text = "Capacitor";
            this.CapacitorButton2.UseVisualStyleBackColor = true;
            this.CapacitorButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged_1);
            // 
            // InductorButton3
            // 
            this.InductorButton3.AutoSize = true;
            this.InductorButton3.Location = new System.Drawing.Point(6, 62);
            this.InductorButton3.Name = "InductorButton3";
            this.InductorButton3.Size = new System.Drawing.Size(64, 17);
            this.InductorButton3.TabIndex = 2;
            this.InductorButton3.TabStop = true;
            this.InductorButton3.Text = "Inductor";
            this.InductorButton3.UseVisualStyleBackColor = true;
            this.InductorButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Element:";
            // 
            // inductorControl1
            // 
            this.inductorControl1.Location = new System.Drawing.Point(0, 235);
            this.inductorControl1.Name = "inductorControl1";
            this.inductorControl1.Size = new System.Drawing.Size(135, 83);
            this.inductorControl1.TabIndex = 6;
            // 
            // capacitorControl1
            // 
            this.capacitorControl1.Location = new System.Drawing.Point(0, 148);
            this.capacitorControl1.Name = "capacitorControl1";
            this.capacitorControl1.Size = new System.Drawing.Size(128, 92);
            this.capacitorControl1.TabIndex = 5;
            // 
            // resistorControl1
            // 
            this.resistorControl1.Location = new System.Drawing.Point(0, 85);
            this.resistorControl1.Name = "resistorControl1";
            this.resistorControl1.Size = new System.Drawing.Size(129, 69);
            this.resistorControl1.TabIndex = 4;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 16);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(63, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Resistor";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged_1);
            // 
            // ElementSelectionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.inductorControl1);
            this.Controls.Add(this.capacitorControl1);
            this.Controls.Add(this.resistorControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.InductorButton3);
            this.Controls.Add(this.CapacitorButton2);
            this.Controls.Add(this.ResistorButton1);
            this.Name = "ElementSelectionControl";
            this.Size = new System.Drawing.Size(143, 320);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton ResistorButton1;
        private System.Windows.Forms.RadioButton CapacitorButton2;
        private System.Windows.Forms.RadioButton InductorButton3;
        private System.Windows.Forms.Label label1;
        private ResistorControl resistorControl1;
        private CapacitorControl capacitorControl1;
        private InductorControl inductorControl1;
        private System.Windows.Forms.RadioButton radioButton1;

    }
}
