using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RancharGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public int RanNum(int MinValue, int MaxValue)
        {
            try
            {
                Random rand = new Random(Guid.NewGuid().GetHashCode());
                return rand.Next(MinValue, MaxValue + 1);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        public string RanChar(string[] CustChar, int MinLength, int MaxLength)
        {
            try
            {
                string result = null;
                int Length = RanNum(MinLength, MaxLength);
                for (int i = 0; i < Length; i++)
                {
                    result += CustChar[RanNum(0, CustChar.Length - 1)];
                }
                return result;
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int MaxLength = Convert.ToInt32(textBox1.Text);
                int MinLength = Convert.ToInt32(textBox2.Text);
                if (MaxLength >= MinLength)
                {
                    richTextBox1.Text = RanChar(richTextBox2.Text.Split(','), MinLength, MaxLength);
                }
                else
                {
                    MessageBox.Show("\"最大长度\"不能小于\"最小长度\"。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception er)
            {
                MessageBox.Show(er.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void 撤销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void 剪切ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void 粘贴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void 全选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "文本文件|*.txt|文本文档|*.doc|所有文件|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs, Encoding.UTF8);
                richTextBox1.Text = sr.ReadToEnd();
                sr.Close();
                fs.Close();
            }
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "文本文件|*.txt|文本文档|*.doc|所有文件|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
                sw.Write(richTextBox1.Text);
                sw.Close();
                fs.Close();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox2.Undo();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            richTextBox2.Cut();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            richTextBox2.Copy();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            richTextBox2.Paste();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            richTextBox2.SelectAll();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "文本文件|*.txt|文本文档|*.doc|所有文件|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs, Encoding.UTF8);
                richTextBox2.Text = sr.ReadToEnd();
                sr.Close();
                fs.Close();
            }
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "文本文件|*.txt|文本文档|*.doc|所有文件|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
                sw.Write(richTextBox2.Text);
                sw.Close();
                fs.Close();
            }
        }
    }
}
