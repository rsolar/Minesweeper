using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Minesweeper {
  public partial class Form_Main : Form {

    public int nRow; //雷区行数
    public int nCol; //雷区列数
    public int nMineCnt; //地雷数量

    bool bMark; //是否使用问号标记

    int[,] nMine; //该格为地雷->-1 周围地雷数量->[0, 8]
    int[,] nState; //未点开->0 已点开->1 旗->2 问号->3

    int[] dx = new int[] { -1, 0, 0, 1, -1, -1, 1, 1 }; //纵向偏移量
    int[] dy = new int[] { 0, -1, 1, 0, -1, 1, -1, 1 }; //横向偏移量

    int nBGSize = 42; //雷区格子大小
    int nPicSize = 38; //图标大小
    int nBnkSize = 2; //间隔大小
    int nRadius = 4; //圆角矩形半径

    Point pMouseFocus; //当前高亮格
    bool bMouseLeft; //鼠标左键是否按下
    bool bMouseRight; //鼠标右键是否按下

    bool bGameEnd; //游戏是否结束

    public Form_Main() {
      InitializeComponent();
      //开启双缓冲以减少图形闪烁
      this.DoubleBuffered = true;
      //初始化高亮格
      pMouseFocus.X = 0;
      pMouseFocus.Y = 0;
      //默认难度
      setGame(Properties.Settings.Default.Row, Properties.Settings.Default.Column, Properties.Settings.Default.MineCount);
      //默认设置
      markToolStripMenuItem.Checked = bMark = Properties.Settings.Default.Mark;
    }

    /// <summary>
    /// 设定游戏参数
    /// </summary>
    /// <param name="row">雷区行数</param>
    /// <param name="col">雷区列数</param>
    /// <param name="mineCnt">地雷数量</param>
    private void setGame(int row, int col, int mineCnt) {
      nRow = row;
      nCol = col;
      nMineCnt = mineCnt;
      restartGame();
    }

    /// <summary>
    /// 设定游戏难度为初级
    /// </summary>
    private void setDiffEasy() {
      setGame(9, 9, 10);
    }

    /// <summary>
    /// 设定游戏难度为中级
    /// </summary>
    private void setDiffNormal() {
      setGame(16, 16, 40);
    }

    /// <summary>
    /// 设定游戏难度为高级
    /// </summary>
    private void setDiffHard() {
      setGame(16, 30, 99);
    }

    /// <summary>
    /// 修改窗口大小
    /// </summary>
    private void updateSize() {
      int nOffsetX = this.Width - this.ClientSize.Width; //横向边框宽度
      int nOffsetY = this.Height - this.ClientSize.Height; //纵向边框宽度
      int nAdditionY = menuStrip_Main.Height + tableLayoutPanel_Main.Height; //菜单栏及信息栏高度
      this.Width = nBGSize + (nBGSize + nBnkSize * 2) * nCol + nOffsetX; //窗口宽度
      this.Height = nBGSize + (nBGSize + nBnkSize * 2) * nRow + nOffsetY + nAdditionY; //窗口高度
    }

    /// <summary>
    /// 更新菜单难度选择
    /// </summary>
    private void updateMenuDiff() {
      if (nRow == 9 && nCol == 9 && nMineCnt == 10) { //初级
        easyToolStripMenuItem.Checked = true;
        normalToolStripMenuItem.Checked = false;
        hardToolStripMenuItem.Checked = false;
        customToolStripMenuItem.Checked = false;
      } else if (nRow == 16 && nCol == 16 && nMineCnt == 40) { //中级
        easyToolStripMenuItem.Checked = false;
        normalToolStripMenuItem.Checked = true;
        hardToolStripMenuItem.Checked = false;
        customToolStripMenuItem.Checked = false;
      } else if (nRow == 16 && nCol == 30 && nMineCnt == 99) { //高级
        easyToolStripMenuItem.Checked = false;
        normalToolStripMenuItem.Checked = false;
        hardToolStripMenuItem.Checked = true;
        customToolStripMenuItem.Checked = false;
      } else { //自定义
        easyToolStripMenuItem.Checked = false;
        normalToolStripMenuItem.Checked = false;
        hardToolStripMenuItem.Checked = false;
        customToolStripMenuItem.Checked = true;
      }
    }

    /// <summary>
    /// 绘制雷区
    /// </summary>
    /// <param name="g">Graphics实例</param>
    private void paintMine(Graphics g) {
      //清空雷区
      g.Clear(Color.FromArgb(242, 241, 240));

      int nOffsetX = nBGSize / 2; //左方偏移量
      int nOffsetY = nBGSize / 2 + menuStrip_Main.Height; //上方偏移量

      //格子背景颜色
      Brush BGBrush = new SolidBrush(Color.FromArgb(186, 189, 182));
      Brush BGHBrush = new SolidBrush(Color.FromArgb(211, 215, 207));
      Brush BGOBrush = new SolidBrush(Color.FromArgb(222, 222, 220));
      //逐格绘制雷区
      for (int i = 1; i <= nRow; i++) {
        for (int j = 1; j <= nCol; j++) {
          GraphicsPath p = RoundedRectangle.Create(nOffsetX + (nBGSize + nBnkSize * 2) * (j - 1) + nBnkSize,
                                                   nOffsetY + (nBGSize + nBnkSize * 2) * (i - 1) + nBnkSize,
                                                   nBGSize,
                                                   nBGSize,
                                                   nRadius);
          if (nState[i, j] != 1) { //未点开
            //绘制背景
            if (j == pMouseFocus.X && i == pMouseFocus.Y) { //高亮格
              g.FillPath(BGHBrush, p);
            } else { //非高亮格
              g.FillPath(BGBrush, p);
            }
            //绘制标记
            if (nState[i, j] == 2) { //旗
              g.DrawImage(Properties.Resources.flag,
                          nOffsetX + (nBGSize + nBnkSize * 2) * (j - 1) + nBnkSize * 2,
                          nOffsetY + (nBGSize + nBnkSize * 2) * (i - 1) + nBnkSize * 2,
                          nPicSize,
                          nPicSize);
            } else if (nState[i, j] == 3) { //问号
              g.DrawImage(Properties.Resources.maybe,
                          nOffsetX + (nBGSize + nBnkSize * 2) * (j - 1) + nBnkSize * 2,
                          nOffsetY + (nBGSize + nBnkSize * 2) * (i - 1) + nBnkSize * 2,
                          nPicSize,
                          nPicSize);
            }
          } else { //nState[i, j] == 1 已点开
            //绘制背景
            g.FillPath(BGOBrush, p);
            //绘制数字或地雷
            if (nMine[i, j] > 0) { //绘制数字
              g.DrawImage((Image)Properties.Resources.ResourceManager.GetObject("mines" + nMine[i, j]),
                          nOffsetX + (nBGSize + nBnkSize * 2) * (j - 1) + nBnkSize * 2,
                          nOffsetY + (nBGSize + nBnkSize * 2) * (i - 1) + nBnkSize * 2,
                          nPicSize,
                          nPicSize);
            } else if (nMine[i, j] == -1) { //绘制地雷
              g.DrawImage(Properties.Resources.mine,
                          nOffsetX + (nBGSize + nBnkSize * 2) * (j - 1) + nBnkSize * 2,
                          nOffsetY + (nBGSize + nBnkSize * 2) * (i - 1) + nBnkSize * 2,
                          nPicSize,
                          nPicSize);
            }
          }
        }
      }
    }

    /// <summary>
    /// 重置游戏
    /// </summary>
    private void restartGame() {
      //更新雷区大小及菜单
      updateSize();
      updateMenuDiff();
      //重新申请相应大小的状态数组
      nMine = new int[nRow + 2, nCol + 2];
      nState = new int[nRow + 2, nCol + 2];
      //重绘雷区
      this.Refresh();
      //随机填入指定数量的地雷
      Random rand = new Random();
      for (int i = 0; i < nMineCnt; i++) {
        int x = rand.Next(nRow) + 1;
        int y = rand.Next(nCol) + 1;
        if (nMine[x, y] == -1 || (x == pMouseFocus.Y && y == pMouseFocus.X)) {
          i--; continue;
        }
        nMine[x, y] = -1;
      }
      //对每格统计周围的地雷数量
      for (int i = 1; i <= nRow; i++) {
        for (int j = 1; j <= nCol; j++) {
          if (nMine[i, j] != -1) {
            for (int d = 0; d < 8; d++) {
              int x = i + dx[d];
              int y = j + dy[d];
              if (nMine[x, y] == -1) {
                nMine[i, j]++;
              }
            }
          }
        }
      }
      //初始化计数器
      timer_Main.Enabled = false;
      label_Mine.Text = nMineCnt.ToString();
      label_Timer.Text = "0";
      //开始游戏
      bGameEnd = false;
    }

    /// <summary>
    /// DFS用于打开相连的非地雷格子
    /// </summary>
    /// <param name="x">行号</param>
    /// <param name="y">列号</param>
    private void dfs(int x, int y) {
      nState[x, y] = 1; //点开当前格
      if (nMine[x, y] != 0) { //非0则不向四周扩展
        return;
      }
      //向四周搜索扩展
      for (int d = 0; d < 4; d++) {
        int xx = x + dx[d];
        int yy = y + dy[d];
        if (xx >= 1 && xx <= nRow && yy >= 1 && yy <= nCol && nState[xx, yy] != 1) { //判断边界 避免无限递归
          dfs(xx, yy);
        }
      }
    }

    /// <summary>
    /// 显示所有地雷
    /// </summary>
    private void openAllMine() {
      for (int i = 1; i <= nRow; i++) {
        for (int j = 1; j <= nCol; j++) {
          if (nMine[i, j] == -1) {
            nState[i, j] = 1;
          }
        }
      }
      this.Refresh();
    }

    /// <summary>
    /// 判断是否胜利
    /// </summary>
    private void gameWin() {
      if (bGameEnd) {
        return;
      }
      //统计已点开格子数量
      int nCount = 0;
      for (int i = 1; i <= nRow; i++) {
        for (int j = 1; j <= nCol; j++) {
          if (nState[i, j] == 1) {
            nCount++;
          }
        }
      }
      //判断是否胜利
      if (nCount == nRow * nCol - nMineCnt) {
        bGameEnd = true; //游戏结束
        timer_Main.Enabled = false; //计时停止
        openAllMine(); //显示所有地雷
        //更新记录
        if (nRow == 9 && nCol == 9 && nMineCnt == 10) {
          Properties.Settings.Default.EasyRecord = Math.Min(Properties.Settings.Default.EasyRecord, Convert.ToInt32(label_Timer.Text));
        } else if (nRow == 16 && nCol == 16 && nMineCnt == 40) {
          Properties.Settings.Default.NormalRecord = Math.Min(Properties.Settings.Default.NormalRecord, Convert.ToInt32(label_Timer.Text));
        } else if (nRow == 16 && nCol == 30 && nMineCnt == 99) {
          Properties.Settings.Default.HardRecord = Math.Min(Properties.Settings.Default.HardRecord, Convert.ToInt32(label_Timer.Text));
        }
        Properties.Settings.Default.Save();
        //弹出提示对话框
        DialogResult msgBoxRst = MessageBox.Show("恭喜您！游戏胜利！\n是否开始新游戏？",
                                                 "游戏胜利",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.None,
                                                 MessageBoxDefaultButton.Button1);
        if (msgBoxRst == DialogResult.Yes) {
          restartGame();
        }
      }
    }

    /// <summary>
    /// 游戏失败
    /// </summary>
    private void gameLost() {
      bGameEnd = true; //游戏结束
      timer_Main.Enabled = false; //计时停止
      openAllMine(); //显示所有地雷
      //弹出提示对话框
      DialogResult msgBoxRst = MessageBox.Show("游戏失败！\n是否开始新游戏？",
                                               "游戏失败",
                                               MessageBoxButtons.YesNo,
                                               MessageBoxIcon.None,
                                               MessageBoxDefaultButton.Button1);
      if (msgBoxRst == DialogResult.Yes) {
        restartGame();
      }
    }

    private void Form_Main_Paint(object sender, PaintEventArgs e) {
      paintMine(e.Graphics);
    }

    private void Form_Main_MouseMove(object sender, MouseEventArgs e) {
      if (e.X < nBGSize / 2 || e.X > nBGSize / 2 + nCol * (nBGSize + nBnkSize * 2) ||
          e.Y < nBGSize / 2 + menuStrip_Main.Height || e.Y > nBGSize / 2 + menuStrip_Main.Height + nRow * (nBGSize + nBnkSize * 2)) { //鼠标不在格子内
        pMouseFocus.X = 0;
        pMouseFocus.Y = 0;
      } else { //鼠标在格子内
        pMouseFocus.X = (e.X - nBGSize / 2) / (nBGSize + nBnkSize * 2) + 1;
        pMouseFocus.Y = (e.Y - nBGSize / 2 - menuStrip_Main.Height) / (nBGSize + nBnkSize * 2) + 1;
      }
      this.Refresh(); //重绘雷区
    }
    private void Form_Main_MouseDown(object sender, MouseEventArgs e) {
      if (e.Button == MouseButtons.Left) { //按下左键
        bMouseLeft = true;
      } else if (e.Button == MouseButtons.Right) { //按下右键
        bMouseRight = true;
      }
    }

    private void Form_Main_MouseUp(object sender, MouseEventArgs e) {
      if (pMouseFocus.X == 0 && pMouseFocus.Y == 0 || bGameEnd) { //鼠标不在格子上 或 游戏已结束 则无需响应
        return;
      }
      if (bMouseLeft) { //松开左键
        //使第一次点击打开不止一格区域 如不能则打开非地雷区域
        if (!timer_Main.Enabled && nState[pMouseFocus.Y, pMouseFocus.X] != 2) {
          while (nMine[pMouseFocus.Y, pMouseFocus.X] != 0) { //重新生成雷区直到当前格子周围无地雷
            restartGame();
            if (nRow * nCol - nMineCnt < 9 && nMine[pMouseFocus.Y, pMouseFocus.X] >= 0) { //如不能则打开非地雷区域
              break;
            }
          }
          timer_Main.Enabled = true; //开始计时
          Form_Main_MouseUp(sender, e); //重新处理点击事件
          return;
        }
        if (nMine[pMouseFocus.Y, pMouseFocus.X] != -1 && (nState[pMouseFocus.Y, pMouseFocus.X] == 0
          || nState[pMouseFocus.Y, pMouseFocus.X] == 3)) { //无地雷 且 (未点开 或 标记为问号) 的格子
          dfs(pMouseFocus.Y, pMouseFocus.X);
        } else if (nMine[pMouseFocus.Y, pMouseFocus.X] == -1 && nState[pMouseFocus.Y, pMouseFocus.X] != 2) { //含地雷 且 未标记为旗 的格子
          gameLost();
        }
      } else if (bMouseRight) { //松开右键
        if (bMark) { //启用了问号标记
          if (nState[pMouseFocus.Y, pMouseFocus.X] == 0) { //未点开->旗
            nState[pMouseFocus.Y, pMouseFocus.X] = 2;
            label_Mine.Text = Convert.ToString(Convert.ToInt32(label_Mine.Text) - 1);
          } else if (nState[pMouseFocus.Y, pMouseFocus.X] == 2) { //旗->问号
            nState[pMouseFocus.Y, pMouseFocus.X] = 3;
            label_Mine.Text = Convert.ToString(Convert.ToInt32(label_Mine.Text) + 1);
          } else if (nState[pMouseFocus.Y, pMouseFocus.X] == 3) { //问号->未点开
            nState[pMouseFocus.Y, pMouseFocus.X] = 0;
          }
        } else {
          if (nState[pMouseFocus.Y, pMouseFocus.X] == 0) { //未点开->旗
            nState[pMouseFocus.Y, pMouseFocus.X] = 2;
            label_Mine.Text = Convert.ToString(Convert.ToInt32(label_Mine.Text) - 1);
          } else if (nState[pMouseFocus.Y, pMouseFocus.X] == 2) { //旗->未点开
            nState[pMouseFocus.Y, pMouseFocus.X] = 0;
            label_Mine.Text = Convert.ToString(Convert.ToInt32(label_Mine.Text) + 1);
          }
        }
      }
      this.Refresh(); //重绘雷区
      gameWin(); //判断是否胜利
      bMouseLeft = bMouseRight = false;
    }

    private void newGameToolStripMenuItem_Click(object sender, EventArgs e) {
      restartGame();
    }

    private void easyToolStripMenuItem_Click(object sender, EventArgs e) {
      setDiffEasy();
    }

    private void normalToolStripMenuItem_Click(object sender, EventArgs e) {
      setDiffNormal();
    }

    private void hardToolStripMenuItem_Click(object sender, EventArgs e) {
      setDiffHard();
    }

    private void customToolStripMenuItem_Click(object sender, EventArgs e) {
      Form_Custom custom = new Form_Custom(this); //自身作为参数以传递设置信息
      custom.ShowDialog();
      if (custom.DialogResult == DialogResult.Yes) {
        restartGame();
      }
    }

    private void markToolStripMenuItem_Click(object sender, EventArgs e) {
      markToolStripMenuItem.Checked = bMark = !bMark;
    }

    private void rankingToolStripMenuItem_Click(object sender, EventArgs e) {
      Form_Rank rank = new Form_Rank();
      rank.ShowDialog();
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
      Application.Exit();
    }

    /// <summary>
    /// 系统关于对话框(API)
    /// </summary>
    /// <param name="hWnd">窗口句柄</param>
    /// <param name="szApp">标题文本</param>
    /// <param name="szOtherStuff">内容文本</param>
    /// <param name="hIcon">图标句柄</param>
    /// <returns></returns>
    [DllImport("shell32.dll")]
    public extern static int ShellAbout(IntPtr hWnd, string szApp, string szOtherStuff, IntPtr hIcon);
    private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
      ShellAbout(this.Handle, "扫雷", "只是个用C#编写的扫雷游戏。\n", this.Icon.Handle);
    }

    private void timer_Main_Tick(object sender, EventArgs e) {
      label_Timer.Text = Convert.ToString(Convert.ToInt32(label_Timer.Text) + 1);
    }

  }
}
