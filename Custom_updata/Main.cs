using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Arong_Core;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Arong_Menu
{
	public partial class Custom_updata : Form
	{
		public Custom_updata()
		{
			InitializeComponent();
			textBox1.Text = Properties.Settings.Default.User_Updata;
			textBox2.Text = Properties.Settings.Default.Auto_Updata;

			textBox3.Text = Properties.Settings.Default.Inspect_File;
			textBox4.Text = Properties.Settings.Default.Standard_File;
			textBox5.Text = Properties.Settings.Default.Output_File;

			dateTimePicker1.Enabled = false;

			string zipname = "updata_" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second;
			textBox6.Text = zipname;


		}

		//删除
		private void button1_Click(object sender, EventArgs e)
		{
			listView1.Items.Clear();
			label6.Text = "0";
		}

		/// <summary>
		/// 生成
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button2_Click(object sender, EventArgs e)
		{
			//更新包文件路径
			string newpath = textBox1.Text;
			string[] oldname = new string[listView1.Items.Count];

			//先清空更新文件夹
			if (Directory.Exists(newpath))
			{
				if (!FIleInfo(newpath))
				{
					Directory.Delete(newpath, true);
				}
				else
				{
					MessageBox.Show("更新的文件夹路径已经打开，请先关闭再更新");
					return;
				}
			}

			//检查是否是空的
			if (listView1.Items.Count != 0)
			{
				//失败文件数量
				int errorfile = 0;

				for (int i = 0; i < listView1.Items.Count; i++)
				{
					//去除根目录
					oldname[i] = listView1.Items[i].Text.Substring(listView1.Items[i].Text.IndexOf("\\"));
					Directory.CreateDirectory(Arong_File.File_NewPath(newpath + oldname[i]));

					if (Directory.Exists(Arong_File.File_NewPath(newpath + oldname[i])) == true)
					{
						File.Copy(listView1.Items[i].Text, newpath + oldname[i], true);
						//检查文件是否有拷贝过去
						if (File.Exists(newpath + oldname[i]) == false)
						{
							Arong_Log.Oper_Log("复制失败的文件" + listView1.Items[i].Text);
							errorfile++;
						}
					}
				}
				//展示结果
				if (errorfile != 0)
				{
					string infofile = "拷贝过程中出现" + errorfile.ToString() + "个文件拷贝失败,详细详细见Oper_Log文件";
					MessageBox.Show(infofile);
				}
				MessageBox.Show("完成");
				Process.Start("explorer.exe", newpath);
			}
			else
			{
				MessageBox.Show("没有要复制的文件");
			}

		}

		//更新路径输入框
		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			//判断是否是根目录
			if (textBox1.Text.Length > 3)
			{
				Properties.Settings.Default.User_Updata = textBox1.Text;
				Properties.Settings.Default.Save();
			}
			else
			{
				MessageBox.Show("不可以指派至根目录");
				textBox1.Text = Properties.Settings.Default.User_Updata;
			}
		}

		/// <summary>
		/// 自动
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void radioButton2_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton2.Checked == true)
			{
				dateTimePicker1.Enabled = true;
			}
		}

		/// <summary>
		/// 手动
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton1.Checked == true)
			{
				dateTimePicker1.Enabled = false;
			}
		}

		/// <summary>
		/// 自动查找
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button3_Click(object sender, EventArgs e)
		{
			listView1.Items.Clear();

			if ((textBox2.Text.Length > 3) && (radioButton2.Checked == true))
			{
				string[] list = Directory.GetFiles(textBox2.Text, "*", SearchOption.AllDirectories);
				DateTime usertime = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day);
				for (int i = 0; i < list.Length; i++)
				{
					//对比时间
					DateTime listtime = Convert.ToDateTime(File.GetLastWriteTime(list[i]));
					if (listtime >= usertime)
					{
						listView1.Items.Add(new ListViewItem(new string[] { list[i], Convert.ToDateTime(File.GetLastWriteTime(list[i])).ToString() }));
					}
				}

				//适应列表
				listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

				//如果没有文件
				if (listView1.Items.Count == 0)
				{
					MessageBox.Show("当前设置的日期内没有修改的文件");
				}
				label6.Text = listView1.Items.Count.ToString();
			}
			if (textBox2.Text.Length <= 3)
			{
				MessageBox.Show("路径为空或者为根目录");
			}
			if (radioButton2.Checked == false)
			{
				MessageBox.Show("当前的查询类型不是自动");
			}
		}

		/// <summary>
		/// 移除
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button4_Click(object sender, EventArgs e)
		{
			if (listView1.Items.Count != 0)
			{
				//移除选择的项
				foreach (ListViewItem lvi in listView1.SelectedItems)
				{
					listView1.Items.RemoveAt(lvi.Index);
				}
			}
			else
			{
				MessageBox.Show("列表是空的");
			}
		}

		/// <summary>
		/// 按下esc退出
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Custom_updata_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				Close();
			}
		}

		/// <summary>
		/// 窗体加载程序
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Custom_updata_Load(object sender, EventArgs e)
		{
			listView1.Columns.Add("文件路径", 200);
			listView1.Columns.Add("文件日期", 200);
		}

		/// <summary>
		/// 列表视图 拖动
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void listView1_DragEnter(object sender, DragEventArgs e)
		{
			//接收文件
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
				for (int i = 0; i < files.Length; i++)
				{
					//拖入的是文件夹，则拷贝文件夹下所有文件
					if (Directory.Exists(files[i]) == true)
					{
						//用于接收文件夹内全部文件
						string[] filetemp = Directory.GetFiles(files[i], "*", SearchOption.AllDirectories);
						for (int f = 0; f < filetemp.Length; f++)
						{
							listView1.Items.Add(new ListViewItem(new string[] { filetemp[f], Convert.ToDateTime(File.GetLastWriteTime(filetemp[f])).ToString() }));
						}
					}
					else //识别不到的数据视为文件
					{
						listView1.Items.Add(new ListViewItem(new string[] { files[i], Convert.ToDateTime(File.GetLastWriteTime(files[i])).ToString() }));
					}
				}
				listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
			}
			label6.Text = listView1.Items.Count.ToString();
		}

		/// <summary>
		/// 自动提取地址的路径
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TextBox2_TextChanged(object sender, EventArgs e)
		{
			Properties.Settings.Default.Auto_Updata = textBox2.Text;
			Properties.Settings.Default.Save();
		}

		/// <summary>
		/// 判断当前文件夹是否打开的
		/// </summary>
		/// <param name="folderPath"></param>
		public bool FIleInfo(string folderPath)
		{
			Process[] processes = Process.GetProcessesByName("explorer");

			foreach (Process process in processes)
			{
				string processPath = GetExplorerProcessPath(process);

				if (processPath.Equals(folderPath, StringComparison.OrdinalIgnoreCase))
				{
					return true;
				}
			}
			return false;
		}

		public static string GetExplorerProcessPath(Process process)
		{
			try
			{
				return process.MainModule.FileName;
			}
			catch (Exception)
			{
				// 处理异常
				return string.Empty;
			}
		}

		/// <summary>
		/// 生成当前存在差异的文件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button6_Click(object sender, EventArgs e)
		{
			if (Directory.Exists(textBox5.Text))
			{
				Directory.Delete(textBox5.Text, true);
			}

			for (int i = 0; i < listBox1.Items.Count; i++)
			{
				Directory.CreateDirectory(Arong_File.File_NewPath(listBox1.Items[i].ToString().Replace(textBox4.Text, textBox5.Text)));
				File.Copy(listBox1.Items[i].ToString(), listBox1.Items[i].ToString().Replace(textBox4.Text, textBox5.Text), true);
			}
			MessageBox.Show("完成");
			Process.Start("explorer.exe", textBox5.Text);
		}

		/// <summary>
		/// 校验文件路径
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void textBox4_TextChanged(object sender, EventArgs e)
		{
			Properties.Settings.Default.Standard_File = textBox4.Text;
			Properties.Settings.Default.Save();
		}

		/// <summary>
		/// 差异文件路径
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void textBox3_TextChanged(object sender, EventArgs e)
		{
			Properties.Settings.Default.Inspect_File = textBox3.Text;
			Properties.Settings.Default.Save();
		}

		/// <summary>
		/// 剥离文件路径
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void textBox5_TextChanged(object sender, EventArgs e)
		{
			//判断是否是根目录
			if (textBox5.Text.Length > 3)
			{
				Properties.Settings.Default.Output_File = textBox5.Text;
				Properties.Settings.Default.Save();
			}
			else
			{
				MessageBox.Show("不可以指派至根目录");
				textBox5.Text = Properties.Settings.Default.Output_File;
			}
		}

		/// <summary>
		/// 查找文件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button5_Click(object sender, EventArgs e)
		{
			//得到这个路径下全部的文件，包含子路径下的全部文件,这个为基准文件
			string[] files1 = Directory.GetFiles(textBox4.Text, "*", SearchOption.AllDirectories);
			string[] temp = new string[files1.Length];
			for (int i = 0; i < files1.Length; i++)
			{
				temp[i] = files1[i].Replace(textBox4.Text, textBox3.Text);
				if (!File.Exists(temp[i]))
				{
					listBox1.Items.Add(files1[i]);
				}
			}

			if (listBox1.Items.Count == 0)
			{
				MessageBox.Show("没有缺少文件，文件齐全");
			}
			label11.Text = listBox1.Items.Count.ToString();
		}

		/// <summary>
		/// 清空
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button8_Click(object sender, EventArgs e)
		{
			listBox1.Items.Clear();
			label11.Text = "0";
		}

		/// <summary>
		/// 移除
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button7_Click(object sender, EventArgs e)
		{
			if (listBox1.Items.Count != 0)
			{
				//移除选择的项
				listBox1.Items.RemoveAt(listBox1.SelectedIndex);
			}
			else
			{
				MessageBox.Show("列表是空的");
			}
		}
	}
}
