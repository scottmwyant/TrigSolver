namespace TrigSolver
{
    partial class Form1
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
            this.textBoxAlpha = new TrigSolver.MyTextBox();
            this.textBoxBeta = new TrigSolver.MyTextBox();
            this.textBoxGamma = new TrigSolver.MyTextBox();
            this.textBoxA = new TrigSolver.MyTextBox();
            this.textBoxB = new TrigSolver.MyTextBox();
            this.textBoxC = new TrigSolver.MyTextBox();
            this.labelAlpha = new System.Windows.Forms.Label();
            this.labelA = new System.Windows.Forms.Label();
            this.labelBeta = new System.Windows.Forms.Label();
            this.labelB = new System.Windows.Forms.Label();
            this.labelGamma = new System.Windows.Forms.Label();
            this.labelC = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelStatus1 = new System.Windows.Forms.Label();
            this.labelStatus2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inputsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sssToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.degToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.radToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxAlpha
            // 
            this.textBoxAlpha.Location = new System.Drawing.Point(19, 35);
            this.textBoxAlpha.Name = "textBoxAlpha";
            this.textBoxAlpha.Size = new System.Drawing.Size(75, 20);
            this.textBoxAlpha.TabIndex = 0;
            this.textBoxAlpha.Tag = "0";
            //this.textBoxAlpha.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.textBoxAlpha.FeatureType = "Angle";
            this.textBoxAlpha.Input = false;
            // 
            // textBoxBeta
            // 
            this.textBoxBeta.Location = new System.Drawing.Point(100, 35);
            this.textBoxBeta.Name = "textBoxBeta";
            this.textBoxBeta.Size = new System.Drawing.Size(75, 20);
            this.textBoxBeta.TabIndex = 1;
            this.textBoxBeta.Tag = "1";
            //this.textBoxBeta.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.textBoxBeta.FeatureType = "Angle";
            this.textBoxBeta.Input = false;
            // 
            // textBoxGamma
            // 
            this.textBoxGamma.Location = new System.Drawing.Point(181, 35);
            this.textBoxGamma.Name = "textBoxGamma";
            this.textBoxGamma.Size = new System.Drawing.Size(75, 20);
            this.textBoxGamma.TabIndex = 2;
            this.textBoxGamma.Tag = "2";
            //this.textBoxGamma.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.textBoxGamma.FeatureType = "Angle";
            this.textBoxGamma.Input = false;
            // 
            // textBoxA
            // 
            this.textBoxA.Location = new System.Drawing.Point(19, 35);
            this.textBoxA.Name = "textBoxA";
            this.textBoxA.Size = new System.Drawing.Size(75, 20);
            this.textBoxA.TabIndex = 3;
            this.textBoxA.Tag = "3";
            //this.textBoxA.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.textBoxA.FeatureType = "Side";
            this.textBoxA.Input = false;
            // 
            // textBoxB
            // 
            this.textBoxB.Location = new System.Drawing.Point(103, 35);
            this.textBoxB.Name = "textBoxB";
            this.textBoxB.Size = new System.Drawing.Size(75, 20);
            this.textBoxB.TabIndex = 4;
            this.textBoxB.Tag = "4";
            //this.textBoxB.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.textBoxB.FeatureType = "Side";
            this.textBoxB.Input = false;
            // 
            // textBoxC
            // 
            this.textBoxC.Location = new System.Drawing.Point(184, 35);
            this.textBoxC.Name = "textBoxC";
            this.textBoxC.Size = new System.Drawing.Size(75, 20);
            this.textBoxC.TabIndex = 5;
            this.textBoxC.Tag = "5";
            //this.textBoxC.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.textBoxC.FeatureType = "Side";
            this.textBoxC.Input = false;
            // 
            // labelAlpha
            // 
            this.labelAlpha.AutoSize = true;
            this.labelAlpha.Location = new System.Drawing.Point(19, 18);
            this.labelAlpha.Name = "labelAlpha";
            this.labelAlpha.Size = new System.Drawing.Size(14, 13);
            this.labelAlpha.TabIndex = 6;
            this.labelAlpha.Text = "α";
            // 
            // labelA
            // 
            this.labelA.AutoSize = true;
            this.labelA.Location = new System.Drawing.Point(19, 18);
            this.labelA.Name = "labelA";
            this.labelA.Size = new System.Drawing.Size(13, 13);
            this.labelA.TabIndex = 6;
            this.labelA.Text = "a";
            // 
            // labelBeta
            // 
            this.labelBeta.AutoSize = true;
            this.labelBeta.Location = new System.Drawing.Point(100, 18);
            this.labelBeta.Name = "labelBeta";
            this.labelBeta.Size = new System.Drawing.Size(13, 13);
            this.labelBeta.TabIndex = 7;
            this.labelBeta.Text = "β";
            // 
            // labelB
            // 
            this.labelB.AutoSize = true;
            this.labelB.Location = new System.Drawing.Point(103, 18);
            this.labelB.Name = "labelB";
            this.labelB.Size = new System.Drawing.Size(13, 13);
            this.labelB.TabIndex = 7;
            this.labelB.Text = "b";
            // 
            // labelGamma
            // 
            this.labelGamma.AutoSize = true;
            this.labelGamma.Location = new System.Drawing.Point(181, 18);
            this.labelGamma.Name = "labelGamma";
            this.labelGamma.Size = new System.Drawing.Size(13, 13);
            this.labelGamma.TabIndex = 7;
            this.labelGamma.Text = "γ";
            // 
            // labelC
            // 
            this.labelC.AutoSize = true;
            this.labelC.Location = new System.Drawing.Point(184, 18);
            this.labelC.Name = "labelC";
            this.labelC.Size = new System.Drawing.Size(13, 13);
            this.labelC.TabIndex = 7;
            this.labelC.Text = "c";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelGamma);
            this.groupBox1.Controls.Add(this.labelBeta);
            this.groupBox1.Controls.Add(this.labelAlpha);
            this.groupBox1.Controls.Add(this.textBoxGamma);
            this.groupBox1.Controls.Add(this.textBoxBeta);
            this.groupBox1.Controls.Add(this.textBoxAlpha);
            this.groupBox1.Location = new System.Drawing.Point(25, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(275, 70);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Angles";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxA);
            this.groupBox2.Controls.Add(this.textBoxB);
            this.groupBox2.Controls.Add(this.labelC);
            this.groupBox2.Controls.Add(this.textBoxC);
            this.groupBox2.Controls.Add(this.labelB);
            this.groupBox2.Controls.Add(this.labelA);
            this.groupBox2.Location = new System.Drawing.Point(25, 103);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(275, 70);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sides";
            // 
            // labelStatus1
            // 
            this.labelStatus1.BackColor = System.Drawing.SystemColors.Control;
            this.labelStatus1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.labelStatus1.Location = new System.Drawing.Point(2, 392);
            this.labelStatus1.Name = "labelStatus1";
            this.labelStatus1.Size = new System.Drawing.Size(40, 14);
            this.labelStatus1.TabIndex = 11;
            this.labelStatus1.Text = "Status: ";
            // 
            // labelStatus2
            // 
            this.labelStatus2.BackColor = System.Drawing.SystemColors.Control;
            this.labelStatus2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.labelStatus2.Location = new System.Drawing.Point(39, 392);
            this.labelStatus2.Name = "labelStatus2";
            this.labelStatus2.Size = new System.Drawing.Size(261, 14);
            this.labelStatus2.TabIndex = 12;
            this.labelStatus2.Text = "Waiting";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(325, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inputsToolStripMenuItem,
            this.unitsToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // inputsToolStripMenuItem
            // 
            this.inputsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aasToolStripMenuItem,
            this.asaToolStripMenuItem,
            this.sasToolStripMenuItem,
            this.sssToolStripMenuItem});
            this.inputsToolStripMenuItem.Name = "inputsToolStripMenuItem";
            this.inputsToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.inputsToolStripMenuItem.Text = "Inputs";
            this.inputsToolStripMenuItem.Click += new System.EventHandler(this.OptionsToolStripMenuItem_Click);
            // 
            // aasToolStripMenuItem
            // 
            this.aasToolStripMenuItem.Name = "aasToolStripMenuItem";
            this.aasToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.aasToolStripMenuItem.Text = "AAS (Angle-Angle-Side)";
            this.aasToolStripMenuItem.Click += new System.EventHandler(this.OptionsToolStripMenuItem_Click);
            // 
            // asaToolStripMenuItem
            // 
            this.asaToolStripMenuItem.Name = "asaToolStripMenuItem";
            this.asaToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.asaToolStripMenuItem.Text = "ASA (Angle-Side-Angle)";
            this.asaToolStripMenuItem.Click += new System.EventHandler(this.OptionsToolStripMenuItem_Click);
            // 
            // sasToolStripMenuItem
            // 
            this.sasToolStripMenuItem.Name = "sasToolStripMenuItem";
            this.sasToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.sasToolStripMenuItem.Text = "SAS (Side-Angle-Side)";
            this.sasToolStripMenuItem.Click += new System.EventHandler(this.OptionsToolStripMenuItem_Click);
            // 
            // sssToolStripMenuItem
            // 
            this.sssToolStripMenuItem.Name = "sssToolStripMenuItem";
            this.sssToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.sssToolStripMenuItem.Text = "SSS (Side-Side-Side)";
            this.sssToolStripMenuItem.Click += new System.EventHandler(this.OptionsToolStripMenuItem_Click);
            // 
            // unitsToolStripMenuItem
            // 
            this.unitsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.degToolStripMenuItem,
            this.radToolStripMenuItem});
            this.unitsToolStripMenuItem.Name = "unitsToolStripMenuItem";
            this.unitsToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.unitsToolStripMenuItem.Text = "Units";
            // 
            // degToolStripMenuItem
            // 
            this.degToolStripMenuItem.Name = "degToolStripMenuItem";
            this.degToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.degToolStripMenuItem.Text = "Degrees";
            this.degToolStripMenuItem.Click += new System.EventHandler(this.OptionsToolStripMenuItem_Click);
            // 
            // radToolStripMenuItem
            // 
            this.radToolStripMenuItem.Name = "radToolStripMenuItem";
            this.radToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.radToolStripMenuItem.Text = "Radians";
            this.radToolStripMenuItem.Click += new System.EventHandler(this.OptionsToolStripMenuItem_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(25, 179);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(275, 206);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sketch";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 412);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.labelStatus2);
            this.Controls.Add(this.labelStatus1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Trig Solver";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelAlpha;
        private System.Windows.Forms.Label labelA;
        private System.Windows.Forms.Label labelBeta;
        private System.Windows.Forms.Label labelB;
        private System.Windows.Forms.Label labelGamma;
        private System.Windows.Forms.Label labelC;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labelStatus1;
        private System.Windows.Forms.Label labelStatus2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unitsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem degToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem radToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inputsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sasToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ToolStripMenuItem sssToolStripMenuItem;
        private MyTextBox textBoxAlpha;
        private MyTextBox textBoxBeta;
        private MyTextBox textBoxGamma;
        private MyTextBox textBoxA;
        private MyTextBox textBoxB;
        private MyTextBox textBoxC;
    }
}

