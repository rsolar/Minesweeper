namespace Minesweeper {
  partial class Form_Custom {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Custom));
      this.label_Row = new System.Windows.Forms.Label();
      this.numericUpDown_Row = new System.Windows.Forms.NumericUpDown();
      this.label_Column = new System.Windows.Forms.Label();
      this.numericUpDown_Column = new System.Windows.Forms.NumericUpDown();
      this.label_MineCnt = new System.Windows.Forms.Label();
      this.numericUpDown_MineCnt = new System.Windows.Forms.NumericUpDown();
      this.button_OK = new System.Windows.Forms.Button();
      this.button_Cancel = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Row)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Column)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_MineCnt)).BeginInit();
      this.SuspendLayout();
      // 
      // label_Row
      // 
      this.label_Row.AutoSize = true;
      this.label_Row.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.label_Row.Location = new System.Drawing.Point(12, 23);
      this.label_Row.Name = "label_Row";
      this.label_Row.Size = new System.Drawing.Size(116, 27);
      this.label_Row.TabIndex = 0;
      this.label_Row.Text = "行数(5-18):";
      this.label_Row.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // numericUpDown_Row
      // 
      this.numericUpDown_Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
      this.numericUpDown_Row.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.numericUpDown_Row.Location = new System.Drawing.Point(171, 21);
      this.numericUpDown_Row.Maximum = new decimal(new int[] {
            18,
            0,
            0,
            0});
      this.numericUpDown_Row.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
      this.numericUpDown_Row.Name = "numericUpDown_Row";
      this.numericUpDown_Row.Size = new System.Drawing.Size(107, 33);
      this.numericUpDown_Row.TabIndex = 1;
      this.numericUpDown_Row.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.numericUpDown_Row.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
      this.numericUpDown_Row.ValueChanged += new System.EventHandler(this.numericUpDown_Row_ValueChanged);
      // 
      // label_Column
      // 
      this.label_Column.AutoSize = true;
      this.label_Column.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.label_Column.Location = new System.Drawing.Point(12, 78);
      this.label_Column.Name = "label_Column";
      this.label_Column.Size = new System.Drawing.Size(116, 27);
      this.label_Column.TabIndex = 2;
      this.label_Column.Text = "列数(5-30):";
      this.label_Column.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // numericUpDown_Column
      // 
      this.numericUpDown_Column.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
      this.numericUpDown_Column.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.numericUpDown_Column.Location = new System.Drawing.Point(171, 76);
      this.numericUpDown_Column.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
      this.numericUpDown_Column.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
      this.numericUpDown_Column.Name = "numericUpDown_Column";
      this.numericUpDown_Column.Size = new System.Drawing.Size(107, 33);
      this.numericUpDown_Column.TabIndex = 3;
      this.numericUpDown_Column.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.numericUpDown_Column.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
      this.numericUpDown_Column.ValueChanged += new System.EventHandler(this.numericUpDown_Column_ValueChanged);
      // 
      // label_MineCnt
      // 
      this.label_MineCnt.AutoSize = true;
      this.label_MineCnt.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label_MineCnt.Location = new System.Drawing.Point(12, 133);
      this.label_MineCnt.Name = "label_MineCnt";
      this.label_MineCnt.Size = new System.Drawing.Size(156, 27);
      this.label_MineCnt.TabIndex = 4;
      this.label_MineCnt.Text = "地雷数量(1-99):";
      this.label_MineCnt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // numericUpDown_MineCnt
      // 
      this.numericUpDown_MineCnt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
      this.numericUpDown_MineCnt.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.numericUpDown_MineCnt.Location = new System.Drawing.Point(171, 131);
      this.numericUpDown_MineCnt.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
      this.numericUpDown_MineCnt.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.numericUpDown_MineCnt.Name = "numericUpDown_MineCnt";
      this.numericUpDown_MineCnt.Size = new System.Drawing.Size(107, 33);
      this.numericUpDown_MineCnt.TabIndex = 5;
      this.numericUpDown_MineCnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.numericUpDown_MineCnt.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
      // 
      // button_OK
      // 
      this.button_OK.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button_OK.Location = new System.Drawing.Point(36, 183);
      this.button_OK.Name = "button_OK";
      this.button_OK.Size = new System.Drawing.Size(92, 40);
      this.button_OK.TabIndex = 6;
      this.button_OK.Text = "确认";
      this.button_OK.UseVisualStyleBackColor = true;
      this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
      // 
      // button_Cancel
      // 
      this.button_Cancel.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button_Cancel.Location = new System.Drawing.Point(171, 183);
      this.button_Cancel.Name = "button_Cancel";
      this.button_Cancel.Size = new System.Drawing.Size(92, 40);
      this.button_Cancel.TabIndex = 7;
      this.button_Cancel.Text = "取消";
      this.button_Cancel.UseVisualStyleBackColor = true;
      this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
      // 
      // Form_Custom
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(241)))), ((int)(((byte)(240)))));
      this.ClientSize = new System.Drawing.Size(302, 233);
      this.Controls.Add(this.button_Cancel);
      this.Controls.Add(this.button_OK);
      this.Controls.Add(this.numericUpDown_MineCnt);
      this.Controls.Add(this.label_MineCnt);
      this.Controls.Add(this.numericUpDown_Column);
      this.Controls.Add(this.label_Column);
      this.Controls.Add(this.numericUpDown_Row);
      this.Controls.Add(this.label_Row);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.Name = "Form_Custom";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "自定义游戏";
      this.Load += new System.EventHandler(this.Form_Custom_Load);
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Row)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Column)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_MineCnt)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label_Row;
    private System.Windows.Forms.NumericUpDown numericUpDown_Row;
    private System.Windows.Forms.Label label_Column;
    private System.Windows.Forms.NumericUpDown numericUpDown_Column;
    private System.Windows.Forms.Label label_MineCnt;
    private System.Windows.Forms.NumericUpDown numericUpDown_MineCnt;
    private System.Windows.Forms.Button button_OK;
    private System.Windows.Forms.Button button_Cancel;
  }
}