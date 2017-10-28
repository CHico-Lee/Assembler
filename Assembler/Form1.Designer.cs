namespace Assembler
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ConvertBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanelHeader = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.binaryTxb = new System.Windows.Forms.TextBox();
            this.hex1Txb = new System.Windows.Forms.TextBox();
            this.hex2Txb = new System.Windows.Forms.TextBox();
            this.ReadFromText = new System.Windows.Forms.Button();
            this.binaryCopyBtn = new System.Windows.Forms.Button();
            this.hex1CopyBtn = new System.Windows.Forms.Button();
            this.hex2CopyBtn = new System.Windows.Forms.Button();
            this.varNameTxb = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.memHexTxb = new System.Windows.Forms.TextBox();
            this.memHexCopyBtn = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.nopNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.importBtn = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.ReadFromHex = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tableLayoutPanelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nopNumUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Location = new System.Drawing.Point(13, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(414, 412);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Location = new System.Drawing.Point(17, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(379, 112);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ConvertBtn
            // 
            this.ConvertBtn.Location = new System.Drawing.Point(446, 237);
            this.ConvertBtn.Name = "ConvertBtn";
            this.ConvertBtn.Size = new System.Drawing.Size(75, 42);
            this.ConvertBtn.TabIndex = 1;
            this.ConvertBtn.Text = "Convert to Binary >>";
            this.ConvertBtn.UseVisualStyleBackColor = true;
            this.ConvertBtn.Click += new System.EventHandler(this.ConvertBtn_Click);
            // 
            // tableLayoutPanelHeader
            // 
            this.tableLayoutPanelHeader.ColumnCount = 6;
            this.tableLayoutPanelHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanelHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanelHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanelHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelHeader.Controls.Add(this.label6, 5, 0);
            this.tableLayoutPanelHeader.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanelHeader.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanelHeader.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanelHeader.Controls.Add(this.label4, 3, 0);
            this.tableLayoutPanelHeader.Controls.Add(this.label5, 4, 0);
            this.tableLayoutPanelHeader.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tableLayoutPanelHeader.Location = new System.Drawing.Point(30, 13);
            this.tableLayoutPanelHeader.Name = "tableLayoutPanelHeader";
            this.tableLayoutPanelHeader.RowCount = 1;
            this.tableLayoutPanelHeader.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelHeader.Size = new System.Drawing.Size(379, 29);
            this.tableLayoutPanelHeader.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(273, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "(All number in HEX)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "PC";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Loop Label";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(93, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "OPCode";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(153, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "RD/RT";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(203, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 26);
            this.label5.TabIndex = 4;
            this.label5.Text = "RS/IMM/ Loop Label";
            // 
            // binaryTxb
            // 
            this.binaryTxb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.binaryTxb.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.binaryTxb.Location = new System.Drawing.Point(537, 12);
            this.binaryTxb.Multiline = true;
            this.binaryTxb.Name = "binaryTxb";
            this.binaryTxb.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.binaryTxb.Size = new System.Drawing.Size(321, 181);
            this.binaryTxb.TabIndex = 3;
            this.binaryTxb.Text = "PC   label   Opcode";
            // 
            // hex1Txb
            // 
            this.hex1Txb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hex1Txb.Location = new System.Drawing.Point(626, 228);
            this.hex1Txb.Multiline = true;
            this.hex1Txb.Name = "hex1Txb";
            this.hex1Txb.ReadOnly = true;
            this.hex1Txb.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.hex1Txb.Size = new System.Drawing.Size(232, 51);
            this.hex1Txb.TabIndex = 4;
            // 
            // hex2Txb
            // 
            this.hex2Txb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hex2Txb.Location = new System.Drawing.Point(626, 314);
            this.hex2Txb.Multiline = true;
            this.hex2Txb.Name = "hex2Txb";
            this.hex2Txb.ReadOnly = true;
            this.hex2Txb.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.hex2Txb.Size = new System.Drawing.Size(232, 120);
            this.hex2Txb.TabIndex = 5;
            // 
            // ReadFromText
            // 
            this.ReadFromText.Location = new System.Drawing.Point(446, 151);
            this.ReadFromText.Name = "ReadFromText";
            this.ReadFromText.Size = new System.Drawing.Size(75, 42);
            this.ReadFromText.TabIndex = 6;
            this.ReadFromText.Text = "Input to Assembly <<";
            this.ReadFromText.UseVisualStyleBackColor = true;
            this.ReadFromText.Click += new System.EventHandler(this.ReadFromText_Click);
            // 
            // binaryCopyBtn
            // 
            this.binaryCopyBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.binaryCopyBtn.Location = new System.Drawing.Point(788, 199);
            this.binaryCopyBtn.Name = "binaryCopyBtn";
            this.binaryCopyBtn.Size = new System.Drawing.Size(75, 23);
            this.binaryCopyBtn.TabIndex = 7;
            this.binaryCopyBtn.Text = "Copy All";
            this.binaryCopyBtn.UseVisualStyleBackColor = true;
            this.binaryCopyBtn.Click += new System.EventHandler(this.binaryCopyBtn_Click);
            // 
            // hex1CopyBtn
            // 
            this.hex1CopyBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.hex1CopyBtn.Location = new System.Drawing.Point(789, 285);
            this.hex1CopyBtn.Name = "hex1CopyBtn";
            this.hex1CopyBtn.Size = new System.Drawing.Size(75, 23);
            this.hex1CopyBtn.TabIndex = 8;
            this.hex1CopyBtn.Text = "Copy All";
            this.hex1CopyBtn.UseVisualStyleBackColor = true;
            this.hex1CopyBtn.Click += new System.EventHandler(this.hex1CopyBtn_Click);
            // 
            // hex2CopyBtn
            // 
            this.hex2CopyBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.hex2CopyBtn.Location = new System.Drawing.Point(788, 441);
            this.hex2CopyBtn.Name = "hex2CopyBtn";
            this.hex2CopyBtn.Size = new System.Drawing.Size(75, 23);
            this.hex2CopyBtn.TabIndex = 9;
            this.hex2CopyBtn.Text = "Copy All";
            this.hex2CopyBtn.UseVisualStyleBackColor = true;
            this.hex2CopyBtn.Click += new System.EventHandler(this.hex2CopyBtn_Click);
            // 
            // varNameTxb
            // 
            this.varNameTxb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.varNameTxb.Location = new System.Drawing.Point(704, 443);
            this.varNameTxb.Name = "varNameTxb";
            this.varNameTxb.Size = new System.Drawing.Size(80, 20);
            this.varNameTxb.TabIndex = 10;
            this.varNameTxb.Text = "m";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(623, 446);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Variable Name:";
            // 
            // memHexTxb
            // 
            this.memHexTxb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.memHexTxb.Location = new System.Drawing.Point(537, 199);
            this.memHexTxb.Multiline = true;
            this.memHexTxb.Name = "memHexTxb";
            this.memHexTxb.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.memHexTxb.Size = new System.Drawing.Size(80, 235);
            this.memHexTxb.TabIndex = 12;
            this.memHexTxb.Text = "Hex Code";
            // 
            // memHexCopyBtn
            // 
            this.memHexCopyBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.memHexCopyBtn.Location = new System.Drawing.Point(537, 441);
            this.memHexCopyBtn.Name = "memHexCopyBtn";
            this.memHexCopyBtn.Size = new System.Drawing.Size(75, 23);
            this.memHexCopyBtn.TabIndex = 13;
            this.memHexCopyBtn.Text = "Copy All";
            this.memHexCopyBtn.UseVisualStyleBackColor = true;
            this.memHexCopyBtn.Click += new System.EventHandler(this.memHexCopyBtn_Click);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(443, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 14);
            this.label8.TabIndex = 0;
            this.label8.Text = "NOPs: ";
            // 
            // nopNumUpDown
            // 
            this.nopNumUpDown.Location = new System.Drawing.Point(446, 36);
            this.nopNumUpDown.Name = "nopNumUpDown";
            this.nopNumUpDown.Size = new System.Drawing.Size(60, 20);
            this.nopNumUpDown.TabIndex = 15;
            this.nopNumUpDown.ValueChanged += new System.EventHandler(this.AddNop);
            // 
            // importBtn
            // 
            this.importBtn.Location = new System.Drawing.Point(446, 79);
            this.importBtn.Name = "importBtn";
            this.importBtn.Size = new System.Drawing.Size(75, 47);
            this.importBtn.TabIndex = 16;
            this.importBtn.Text = "Import from file";
            this.importBtn.UseVisualStyleBackColor = true;
            this.importBtn.Click += new System.EventHandler(this.importBtn_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // ReadFromHex
            // 
            this.ReadFromHex.Location = new System.Drawing.Point(446, 396);
            this.ReadFromHex.Name = "ReadFromHex";
            this.ReadFromHex.Size = new System.Drawing.Size(75, 54);
            this.ReadFromHex.TabIndex = 17;
            this.ReadFromHex.Text = "Input from Hex to Assembly <<";
            this.ReadFromHex.UseVisualStyleBackColor = true;
            this.ReadFromHex.Click += new System.EventHandler(this.ReadFromHex_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 474);
            this.Controls.Add(this.ReadFromHex);
            this.Controls.Add(this.importBtn);
            this.Controls.Add(this.nopNumUpDown);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.memHexCopyBtn);
            this.Controls.Add(this.memHexTxb);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.varNameTxb);
            this.Controls.Add(this.hex2CopyBtn);
            this.Controls.Add(this.hex1CopyBtn);
            this.Controls.Add(this.binaryCopyBtn);
            this.Controls.Add(this.ReadFromText);
            this.Controls.Add(this.hex2Txb);
            this.Controls.Add(this.hex1Txb);
            this.Controls.Add(this.binaryTxb);
            this.Controls.Add(this.tableLayoutPanelHeader);
            this.Controls.Add(this.ConvertBtn);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Assembler";
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanelHeader.ResumeLayout(false);
            this.tableLayoutPanelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nopNumUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button ConvertBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelHeader;
        private System.Windows.Forms.TextBox binaryTxb;
        private System.Windows.Forms.TextBox hex1Txb;
        private System.Windows.Forms.TextBox hex2Txb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button ReadFromText;
        private System.Windows.Forms.Button binaryCopyBtn;
        private System.Windows.Forms.Button hex1CopyBtn;
        private System.Windows.Forms.Button hex2CopyBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox varNameTxb;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox memHexTxb;
        private System.Windows.Forms.Button memHexCopyBtn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nopNumUpDown;
        private System.Windows.Forms.Button importBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button ReadFromHex;
    }
}

