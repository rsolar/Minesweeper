namespace Minesweeper
{
    partial class Form_Rank
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Rank));
            this.label_Easy = new System.Windows.Forms.Label();
            this.label_Normal = new System.Windows.Forms.Label();
            this.label_Hard = new System.Windows.Forms.Label();
            this.button_OK = new System.Windows.Forms.Button();
            this.button_Reset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_Easy
            // 
            this.label_Easy.AutoSize = true;
            this.label_Easy.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Easy.Location = new System.Drawing.Point(17, 23);
            this.label_Easy.Name = "label_Easy";
            this.label_Easy.Size = new System.Drawing.Size(57, 27);
            this.label_Easy.TabIndex = 0;
            this.label_Easy.Text = "初级:";
            this.label_Easy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Normal
            // 
            this.label_Normal.AutoSize = true;
            this.label_Normal.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Normal.Location = new System.Drawing.Point(17, 78);
            this.label_Normal.Name = "label_Normal";
            this.label_Normal.Size = new System.Drawing.Size(57, 27);
            this.label_Normal.TabIndex = 1;
            this.label_Normal.Text = "中级:";
            this.label_Normal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Hard
            // 
            this.label_Hard.AutoSize = true;
            this.label_Hard.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Hard.Location = new System.Drawing.Point(17, 133);
            this.label_Hard.Name = "label_Hard";
            this.label_Hard.Size = new System.Drawing.Size(57, 27);
            this.label_Hard.TabIndex = 2;
            this.label_Hard.Text = "高级:";
            this.label_Hard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button_OK
            // 
            this.button_OK.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_OK.Location = new System.Drawing.Point(32, 183);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(92, 40);
            this.button_OK.TabIndex = 3;
            this.button_OK.Text = "确认";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // button_Reset
            // 
            this.button_Reset.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Reset.Location = new System.Drawing.Point(160, 183);
            this.button_Reset.Name = "button_Reset";
            this.button_Reset.Size = new System.Drawing.Size(92, 40);
            this.button_Reset.TabIndex = 4;
            this.button_Reset.Text = "重置";
            this.button_Reset.UseVisualStyleBackColor = true;
            this.button_Reset.Click += new System.EventHandler(this.button_Reset_Click);
            // 
            // Form_Rank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(241)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(282, 233);
            this.Controls.Add(this.button_Reset);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.label_Hard);
            this.Controls.Add(this.label_Normal);
            this.Controls.Add(this.label_Easy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_Rank";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "记录";
            this.Load += new System.EventHandler(this.Form_Rank_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Easy;
        private System.Windows.Forms.Label label_Normal;
        private System.Windows.Forms.Label label_Hard;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button button_Reset;
    }
}