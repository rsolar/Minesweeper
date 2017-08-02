using System;
using System.Windows.Forms;

namespace Minesweeper {
  public partial class Form_Rank : Form {
    public Form_Rank() {
      InitializeComponent();
    }

    private void Form_Rank_Load(object sender, EventArgs e) {
      //初始化内容
      label_Easy.Text = string.Format("初级:            {0}", Properties.Settings.Default.EasyRecord);
      label_Normal.Text = string.Format("中级:            {0}", Properties.Settings.Default.NormalRecord);
      label_Hard.Text = string.Format("高级:            {0}", Properties.Settings.Default.HardRecord);
    }

    private void button_OK_Click(object sender, EventArgs e) {
            Close();
    }

    private void button_Reset_Click(object sender, EventArgs e) {
      //重置数据
      Properties.Settings.Default.EasyRecord = 9999;
      Properties.Settings.Default.NormalRecord = 9999;
      Properties.Settings.Default.HardRecord = 9999;
      Properties.Settings.Default.Save();
      //更新显示内容
      label_Easy.Text = string.Format("初级:            {0}", Properties.Settings.Default.EasyRecord);
      label_Normal.Text = string.Format("中级:            {0}", Properties.Settings.Default.NormalRecord);
      label_Hard.Text = string.Format("高级:            {0}", Properties.Settings.Default.HardRecord);
    }
  }
}
