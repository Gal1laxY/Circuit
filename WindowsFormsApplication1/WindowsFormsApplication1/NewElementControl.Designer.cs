namespace WindowsFormsApplication1
{
    partial class NewElementControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.elementSelectionControl1 = new WindowsFormsApplication1.ElementSelectionControl();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 341);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.newelement_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(93, 341);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.cancel_Click);
            // 
            // elementSelectionControl1
            // 
            this.elementSelectionControl1.Location = new System.Drawing.Point(13, 12);
            this.elementSelectionControl1.Name = "elementSelectionControl1";
            this.elementSelectionControl1.SelectionControl = null;
            this.elementSelectionControl1.Size = new System.Drawing.Size(146, 323);
            this.elementSelectionControl1.TabIndex = 5;
            // 
            // NewElementControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(177, 372);
            this.Controls.Add(this.elementSelectionControl1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "NewElementControl";
            this.Text = "NewElementControl";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private ElementSelectionControl elementSelectionControl1;
    }
}