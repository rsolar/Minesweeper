using System;
using System.Windows.Forms;

namespace Minesweeper {
  public partial class Form_Custom : Form {

    Form_Main Main; //用于与父窗口通信

    public Form_Custom(Form_Main _Main) {
      InitializeComponent();
      Main = _Main;
    }

    private void Form_Custom_Load(object sender, EventArgs e) {
      numericUpDown_Row.Value = Convert.ToDecimal(Main.nRow);
      numericUpDown_Column.Value = Convert.ToDecimal(Main.nCol);
      numericUpDown_MineCnt.Value = Convert.ToDecimal(Main.nMineCnt);
    }

    private void button_OK_Click(object sender, EventArgs e) {
      Main.nRow = Convert.ToInt32(numericUpDown_Row.Value);
      Main.nCol = Convert.ToInt32(numericUpDown_Column.Value);
      Main.nMineCnt = Convert.ToInt32(numericUpDown_MineCnt.Value);
            DialogResult = DialogResult.Yes;
            Close();
    }

    private void button_Cancel_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.No;
            Close();
    }

    private void numericUpDown_Row_ValueChanged(object sender, EventArgs e) {
      //数值范围控制
      numericUpDown_MineCnt.Maximum = numericUpDown_Row.Value * numericUpDown_Column.Value * 8 / 10;
    }

    private void numericUpDown_Column_ValueChanged(object sender, EventArgs e) {
      //数值范围控制
      numericUpDown_MineCnt.Maximum = numericUpDown_Row.Value * numericUpDown_Column.Value * 8 / 10;
    }

  }
}
