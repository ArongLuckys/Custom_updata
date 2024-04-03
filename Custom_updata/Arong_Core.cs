using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.InteropServices;

namespace Arong_Core
{
	/// <summary>
	/// 功能测试类，提供方法
	/// </summary>
	public class Arong_Debug
	{

	}

	/// <summary>
	/// NX菜单创建类
	/// </summary>
	public class Arong_MenuS
	{
		/// <summary>
		/// 获得主菜单开头的信息部分
		/// </summary>
		/// <param name="sum">1=测试图标，2=测试功能</param>
		/// <returns></returns>
		public static string[] MenuHeaderFile(int sum)
		{
			string path;
			if (sum == 1)
			{
				path = Arong_New.Arong_str() + "\\ICO\\Data\\MenuHeaderFile.ar";
			}
			else
			{
				path = Arong_New.Arong_str() + "\\DebugTools\\Data\\MenuHeaderFile.ar";
			}

			string[] temp = File.ReadAllLines(path);
			string[] tempre = new string[temp.Length - 1];
			for (int i = 0; i < temp.Length - 1; i++)
			{
				tempre[i] = temp[i];
				if (tempre[i] == "ACTIONS IconAssistant.utd")
				{
					tempre[i] = tempre[i].Replace("ACTIONS IconAssistant.utd", "ACTIONS " + Arong_New.Arong_str() + "\\ICO\\startup\\IconAssistant.utd");
				}
				if (tempre[i] == "ACTIONS DebugTools.utd")
				{
					tempre[i] = tempre[i].Replace("ACTIONS DebugTools.utd", "ACTIONS " + Arong_New.Arong_str() + "\\DebugTools\\startup\\AutoDebuging.utd");
				}
			}
			return tempre;
		}

		/// <summary>
		/// 返回一个菜单结束字符串，例如 END_OF_MENU
		/// </summary>
		/// <returns></returns>
		public static string MenuHeaderFileEnd()
		{
			string path = Arong_New.Arong_str() + "\\ICO\\Data\\MenuHeaderFile.ar";
			string[] temp = File.ReadAllLines(path);
			return temp[10];
		}

		/// <summary>
		/// 传入数量，自动将内容叠加
		/// </summary>
		/// <param name="sum">功能数量</param>
		/// <returns></returns>
		public static string[] FunctionalGrouping(int sum, string bmpname)
		{
			string path = Arong_New.Arong_str() + "\\ICO\\Data\\FunctionalGrouping.ar";
			string[] temp = File.ReadAllLines(path);
			temp[0] = temp[0] + sum;
			temp[1] = temp[1] + sum;
			temp[2] = temp[2] + bmpname;
			temp[3] = temp[3] + sum;
			return temp;
		}

		/// <summary>
		/// 返回位图文件夹内的所有位图名称
		/// </summary>
		/// <returns></returns>
		public static string[] BmpFileName()
		{
			string path = Arong_New.Arong_str() + "\\ICO\\Application";
			string[] name = Directory.GetFiles(path, "*");
			for (int i = 0; i < name.Length; i++)
			{
				//带扩展名有问题，这里需要改成不带扩展名
				name[i] = Path.GetFileNameWithoutExtension(name[i]);
				name[i] = name[i].Replace(".lc", "");
			}
			return name;
		}

		/// <summary>
		/// 获得一个工具条的list
		/// </summary>
		/// <returns></returns>
		public static List<string> ToolsBar(List<string> value)
		{
			List<string> tools = new List<string>();
			for (int i = 0; i < value.Count; i++)
			{
				if (value[i].StartsWith("BUTTON"))
				{
					tools.Add(value[i]);
				}
				if (value[i].StartsWith("LABEL"))
				{
					tools.Add(value[i]);
				}
				if (value[i] == "LABEL 测试图标环境")
				{
					tools.Remove(value[i]);
				}
			}
			return tools;
		}

		/// <summary>
		/// 获得工具条菜单头
		/// </summary>
		/// <returns></returns>
		public static string[] ToolsBarStart()
		{
			string path = Arong_New.Arong_str() + "\\ICO\\Data\\ToolsBar.ar";
			string[] temp = File.ReadAllLines(path);
			return temp;
		}

		/// <summary>
		/// 获得一个功能区的list
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static List<string> Region(List<string> value)
		{
			List<string> region = new List<string>();
			for (int i = 0; i < value.Count; i++)
			{
				if (value[i].StartsWith("BUTTON"))
				{
					region.Add(value[i]);
				}
				if (value[i] == "LABEL 测试图标环境")
				{
					region.Remove(value[i]);
				}
			}
			return region;
		}

		/// <summary>
		/// 获得功能区菜单头
		/// </summary>
		/// <returns></returns>
		public static string[] RegionStart()
		{
			string path = Arong_New.Arong_str() + "\\ICO\\Data\\RegionStart.ar";
			string[] temp = File.ReadAllLines(path);
			return temp;
		}

		/// <summary>
		/// 获得命令集的菜单头
		/// </summary>
		/// <returns></returns>
		public static string[] FunctionalAssemblyStart(int sum)
		{
			string path;
			if (sum == 1)
			{
				path = Arong_New.Arong_str() + "\\ICO\\Data\\FunctionalAssembly.ar";
			}
			else
			{
				path = Arong_New.Arong_str() + "\\DebugTools\\Data\\FunctionalAssembly.ar";
			}
			string[] temp = File.ReadAllLines(path);
			return temp;
		}

		/// <summary>
		/// 获得一个命令集的list
		/// </summary>
		/// <param name="sum">名称</param>
		/// <param name="bmpname">位图</param>
		/// <param name="value">1=测试图标，2=测试功能</param>
		/// <returns></returns>
		public static string[] FunctionalAssembly(int sum, string bmpname, int value, string menu)
		{
			string path;
			if (value == 1)
			{
				path = Arong_New.Arong_str() + "\\ICO\\Data\\FunctionalAssemblyOne.ar";
			}
			else
			{
				path = Arong_New.Arong_str() + "\\DebugTools\\Data\\FunctionalAssemblyOne.ar";
			}
			string[] temp = File.ReadAllLines(path);
			temp[0] = temp[0] + sum;
			temp[1] = temp[1] + bmpname;
			temp[2] = temp[2];
			if (value == 1)
			{
				temp[3] = temp[3] + sum;
			}
			else
			{
				temp[3] = temp[3] + menu;
			}
			return temp;
		}
	}

	/// <summary>
	/// 文件路径类，回传所有的本软件路径地址,全部最后不含\
	/// </summary>
	public class Arong_Path
	{
		public static string Key = Arong_New.Arong_str() + "\\Key.Arong";
		public static string Bitmap = Arong_New.Arong_str() + "\\Data\\Bitmap";
		public static string Button = Arong_New.Arong_str() + "\\Data\\Button";
		public static string EV = Arong_New.Arong_str() + "\\Data\\EV";
		public static string Lic = Arong_New.Arong_str() + "\\Data\\Lic";
		public static string Nx = Arong_New.Arong_str() + "\\Data\\Nx";
		public static string Temp = Arong_New.Arong_str() + "\\Data\\Temp";

		public static string Temp_Nx_Ver = Arong_New.Arong_str() + "\\Data\\Temp\\Nx_Ver.ini";
		public static string Nx_Path_2_path = Arong_New.Arong_str() + "\\Data\\Nx\\custom_dirs.dat";
		public static string Nx_Path_2_index = Arong_New.Arong_str() + "\\Data\\Nx\\Nx_Use_Temp.ini";
		public static string Nx_Path_2_editpath = Arong_New.Arong_str() + "\\Data\\Nx\\Nx_Use.ini";
		public static string Updata_path = Arong_New.Arong_str() + "\\Data\\Temp\\DLL_Log.txt";
	}

	/// <summary>
	/// 负责重命名接口类
	/// </summary>
	public class Arong_Re
	{
		/// <summary>
		/// 许可更换，path为用户选择的set文件夹路径，names为用户变更的许可名称
		/// </summary>
		/// <param name="path"></param>
		/// <param name="names"></param>
		public static void Re(string path, string names)
		{
			//将set内的许可全部清空
			string[] fileList = Directory.GetFiles(path + "\\set", "*.viclic", SearchOption.TopDirectoryOnly);
			for (int i = 0; i < fileList.Length; i++)
			{
				File.Delete(fileList[i]);
			}
			//Arong工具箱内的许可完整路径
			string path1 = Arong_Path.Lic + "\\" + names + ".viclic";
			//用户指定的路径
			string path2 = path + "\\set\\" + names + ".viclic";
			//拷贝文件操作
			File.Copy(path1, path2);
		}

		/// <summary>
		/// 获取MD5
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public static string GetMd5Hash(String input)
		{
			if (input == null)
			{
				return null;
			}
			MD5 md5Hash = MD5.Create();
			// 将输入字符串转换为字节数组并计算哈希数据 
			byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
			// 创建一个 Stringbuilder 来收集字节并创建字符串 
			StringBuilder sBuilder = new StringBuilder();
			// 循环遍历哈希数据的每一个字节并格式化为十六进制字符串 
			for (int i = 0; i < data.Length; i++)
			{
				sBuilder.Append(data[i].ToString("x2"));
			}
			// 返回十六进制字符串 
			return sBuilder.ToString();
		}

		/// <summary>
		/// 环境变量更改接口
		/// </summary>
		/// <param name="name">为环境变量名称</param>
		/// <param name="value">为环境变量路径</param>
		/// <param name="dig">1为系统，0为用户</param>
		public static void Environment_Variable_v2(string name, string value, int dig)
		{
			if (dig != 0)
			{
				System.Environment.SetEnvironmentVariable(name, value, EnvironmentVariableTarget.Machine);
			}
			else
			{
				System.Environment.SetEnvironmentVariable(name, value, EnvironmentVariableTarget.User);
			}
		}

		/// <summary>
		/// 指派环境变量,添加
		/// </summary>
		public static void Nx_Ver_Environment_Variable()
		{
			string path = Arong_New.Arong_str() + "\\Data\\Nx\\custom_dirs.dat";
			System.Environment.SetEnvironmentVariable("UGII_CUSTOM_DIRECTORY_FILE", path, EnvironmentVariableTarget.Machine);
		}

		/// <summary>
		/// 指派环境变量,移除
		/// </summary>
		public static void Det_Nx_Ver_Environment_Variable()
		{
			System.Environment.SetEnvironmentVariable("UGII_CUSTOM_DIRECTORY_FILE", null, EnvironmentVariableTarget.Machine);
		}
	}

	/// <summary>
	/// 文件操作类
	/// </summary>
	public class Arong_File
	{
		/// <summary>
		/// 等号互转 得到等号前面的值
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public static string Data_Eq_front(string data)
		{
			return data.Substring(0, data.IndexOf("="));
		}

		/// <summary>
		/// 等号互转 得到等号后面面的值
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public static string Data_Eq_end(string data)
		{
			return data.Substring(data.IndexOf("=") + 1);
		}

		/// <summary>
		/// 函数返回对应的信息，可视化菜单专业dll path1 为对应的菜单文件所在，path2为dll文件夹所在
		/// </summary>
		/// <param name="path1"></param>
		/// <param name="path2"></param>
		/// <returns></returns>
		public static string[] View_Info(string path1, string path2)
		{
			//转码读取中文
			string[] name = File.ReadAllLines(path1, Encoding.GetEncoding("gb2312"));
			string[] temp = new string[name.Length];
			//得到全部功能名称
			int index = 0;
			for (int i = 0; i < name.Length; i++)
			{
				string a = "!";
				string b = "!+";
				string c = "\tACTIONS ${VICTOR_CAD_APPLICATION_FOLDER}\\";
				if (name[i] == "")
				{
				}
				else
				{
					if (name[i].Substring(0, 1) == a)
					{
						if (name[i].Substring(0, 2) == b)
						{
						}
						else
						{
							if (name[i + 1].Substring(0, 2) == "\tB")
							{
								temp[index] = name[i];
								if (name[i + 4] != "")
								{
									string time = File.GetLastWriteTime(path2 + name[i + 4].Replace(c, "")).ToString();
									temp[index + 1] = name[i + 4].Replace(c, "");
									temp[index + 2] = time;
								}
								else
								{
									if (name[i + 4] == "")
									{
										string time = File.GetLastWriteTime(path2 + name[i + 3].Replace(c, "")).ToString();
										temp[index + 1] = name[i + 3].Replace(c, "");
										temp[index + 2] = time;
									}
								}
								index = index + 3;
							}
							else
							{
							}
						}
					}
				}
			}
			int summ = 0;
			for (int i = 0; i < temp.Length; i++)
			{
				if (temp[i] != null)
				{
					summ++;
				}
			}
			string[] temps = new string[summ];
			for (int i = 0; i < temps.Length; i++)
			{
				temps[i] = temp[i];
			}
			return temps;
		}

		/// <summary>
		/// 函数返回对应路径,去除文件名称
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public static string File_NewPath(string path)
		{
			string name = "";
			name = path.Substring(path.LastIndexOf('\\') + 1);
			path = path.Replace(name, "");
			return path;
		}

		/// <summary>
		/// 返回更新时nx的版本
		/// </summary>
		/// <returns></returns>
		public static string[] File_Nx_Ver()
		{
			string[] Temp = File.ReadAllLines(Arong_Path.Temp_Nx_Ver);
			return Temp;
		}

		/// <summary>
		/// 这个接口用于获取设定路径文件内全部字符串数组
		/// </summary>
		/// <returns></returns>
		public static string[] Nx_Load()
		{
			string path = Arong_New.Arong_str() + "\\Data\\Nx\\Nx_Use.ini";
			string[] Temp = File.ReadAllLines(path);
			return Temp;
		}

		/// <summary>
		/// 这个接口用于获取设定路径文件内用户选择后的路径数组
		/// </summary>
		/// <returns></returns>
		/// <exception cref="Exception"></exception>
		public static string[] Nx_Load_Using()
		{
			string path = Arong_New.Arong_str() + "\\Data\\Nx\\Nx_Use_Temp.ini";
			if (File.Exists(path) == false)
			{
				throw new Exception("文件不存在");
			}
			else
			{
				string[] Temp = File.ReadAllLines(path);
				return Temp;
			}
		}

		/// <summary>
		/// 向一个文件写入字符串，默认换行
		/// </summary>
		/// <param name="path"></param>
		/// <param name="str"></param>
		public static void File_String(string path, string str)
		{
			if (!File.Exists(path))
			{
				File.Create(path);
			}
			File.AppendAllText(path, str + "\n");
		}

		/// <summary>
		/// 打开一个文件，清空这个文件内全部字符串
		/// </summary>
		/// <param name="path"></param>
		public static void File_String_Del(string path)
		{
			File.WriteAllText(path, String.Empty);
		}

		/// <summary>
		/// 返回当前版本的拼接路径；
		/// </summary>
		/// <param name="name"></param>
		/// <param name="ver"></param>
		/// <returns></returns>
		public static string NX_DLL_VER(string name, string ver)
		{
			string temp = "";
			if (ver == "x64")
			{
				if (name == "NX75")
				{
					temp = "\\application\\nx75\\x64";
				}
				if (name == "NX8")
				{
					temp = "\\application\\nx8\\x64";
				}
				if (name == "NX85")
				{
					temp = "\\application\\nx85\\x64";
				}
				if (name == "NX9")
				{
					temp = "\\application\\nx9\\x64";
				}
				if (name == "NX10")
				{
					temp = "\\application\\nx10\\x64";
				}
				if (name == "NX11")
				{
					temp = "\\application\\nx11\\x64";
				}
				if (name == "NX12")
				{
					temp = "\\application\\nx12\\x64";
				}
				if (name == "NX1847")
				{
					temp = "\\application\\nx1847\\x64";
				}
				if (name == "NX1872")
				{
					temp = "\\application\\nx1872\\x64";
				}
				if (name == "NX1899")
				{
					temp = "\\application\\nx1899\\x64";
				}
				if (name == "NX1926")
				{
					temp = "\\application\\nx1926\\x64";
				}
				if (name == "NX1953")
				{
					temp = "\\application\\nx1953\\x64";
				}
				if (name == "NX1980")
				{
					temp = "\\application\\nx1980\\x64";
				}
				if (name == "NX2007")
				{
					temp = "\\application\\nx2007\\x64";
				}
			}
			if (ver == "x32")
			{
				if (name == "NX75")
				{
					temp = "\\application\\nx75\\win32";
				}
				if (name == "NX8")
				{
					temp = "\\application\\nx8\\win32";
				}
				if (name == "NX85")
				{
					temp = "\\application\\nx85\\win32";
				}
			}
			return temp;
		}

		/// <summary>
		/// 这个接口会返回所有dlx的文件路径 1为更新前的文件夹路径 2为更新后的存放路径
		/// </summary>
		/// <param name="path1"></param>
		/// <param name="path2"></param>
		public static void Nx_Dlx(string path1, string path2)
		{
			DirectoryInfo dir = new DirectoryInfo(path1);
			//获得全部dlx文件全路径
			string[] fileList = Directory.GetFiles(path1, "*.dlx", SearchOption.TopDirectoryOnly);
			string temp_path = "";
			for (int i = 0; i < fileList.Length; i++)
			{
				temp_path = fileList[i].Replace(path1, path2);
				File.Copy(fileList[i], temp_path, true);
			}
		}

		/// <summary>
		/// 这个接口会返回所有dlg的文件路径 1为更新前的文件夹路径 2为更新后的存放路径
		/// </summary>
		/// <param name="path1"></param>
		/// <param name="path2"></param>
		public static void Nx_Dlg(string path1, string path2)
		{
			DirectoryInfo dir = new DirectoryInfo(path1);
			//获得全部dlx文件全路径
			string[] fileList = Directory.GetFiles(path1, "*.dlg", SearchOption.TopDirectoryOnly);
			string temp_path = "";
			for (int i = 0; i < fileList.Length; i++)
			{
				temp_path = fileList[i].Replace(path1, path2);
				File.Copy(fileList[i], temp_path, true);
			}
		}

		/// <summary>
		/// 这个接口会返回所有bmp的文件路径 1为更新前的文件夹路径 2为更新后的存放路径
		/// </summary>
		/// <param name="path1"></param>
		/// <param name="path2"></param>
		public static void Nx_Bmp(string path1, string path2)
		{
			DirectoryInfo dir = new DirectoryInfo(path1);
			//获得全部dlx文件全路径
			string[] fileList = Directory.GetFiles(path1, "*.bmp", SearchOption.TopDirectoryOnly);
			string temp_path = "";
			for (int i = 0; i < fileList.Length; i++)
			{
				temp_path = fileList[i].Replace(path1, path2);
				File.Copy(fileList[i], temp_path, true);
			}
		}

		/// <summary>
		/// 这个接口会拷贝对应的dll文件 1为更新前的文件夹路径 2为更新后的存放路径 3为名称
		/// </summary>
		/// <param name="path1"></param>
		/// <param name="path2"></param>
		/// <param name="name"></param>
		public static void Nx_Dll(string path1, string path2, string name)
		{
			string log = Arong_New.Arong_str() + "\\Data\\Temp\\DLL_Log.txt";
			string temp1 = path1 + name;
			string temp2 = path2 + name;
			if (File.Exists(temp1) == true)
			{
				File.Copy(temp1, temp2, true);
			}
			else
			{
				//如果这个文件不存在，则把这个路径写入log内
				Arong_File.File_String(log, "未找到dll;它的路径为" + temp1);
			}
		}

		/// <summary>
		/// 这个接口会返回当前文件夹中所有的客户文件夹数组
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public static string[] File_Find(string path)
		{
			string path2 = path + "\\customer\\";
			string[] output = null;
			if (Directory.Exists(path2) == true)
			{
				output = Directory.GetDirectories(path2);
				for (int i = 0; i < output.Length; i++)
				{
					output[i] = output[i].Replace(path2, "");
				}
			}
			return output;
		}

		/// <summary>
		/// 这个接口会返回指定目录内的所有文件 包含子文件的路径，但是不含根路径 然后再将对比的文件夹与基准的文件夹对比，取其中缺失的文件 path1为基准文件，path2为要对比的文件,bools决定要不要拷贝文件，path3为拷贝目的地
		/// </summary>
		/// <param name="path1"></param>
		/// <param name="path2"></param>
		/// <param name="bools"></param>
		/// <param name="path3"></param>
		public static void File_ALL(string path1, string path2, bool bools, string path3)
		{
			//得到这个路径下全部的文件，包含子路径下的全部文件,这个为基准文件
			string[] files1 = Directory.GetFiles(path1, "*", SearchOption.AllDirectories);
			//这个是日志文件路径
			string path_log = Arong_New.Arong_str() + "\\File_Log.txt";
			//临时互换数组
			string[] temp = new string[files1.Length];
			string pathss = "";
			//拷贝过去的文件地址路径
			string copypath = "";

			for (int i = 0; i < files1.Length; i++)
			{
				//将跟路径变更
				temp[i] = files1[i].Replace(path1, path2);
				if (File.Exists(temp[i]) == false)
				{
					//把这个缺少的文件写入到日志文件里面
					Arong_File.File_String(path_log, "不存在  " + files1[i]);
					if (bools == true)
					{
						pathss = path3 + "\\" + files1[i].Substring(files1[i].IndexOf("\\") + 1);
						copypath = pathss.Substring(0, pathss.LastIndexOf("\\"));
						Directory.CreateDirectory(copypath);
						File.Copy(files1[i], pathss, true);
					}
				}
			}
		}

		/// <summary>
		/// 这个接口会对比两个路径下存在的文件的MD5，如果是一样的，则判断一样 如果要对比的文件不存在，那么把这个文件信息记录到log文件里面 path1为基准文件，path2为要对比的文件 bool 为是否仅分析xls文件 pos 为格式
		/// </summary>
		/// <param name="path1"></param>
		/// <param name="path2"></param>
		/// <param name="bools"></param>
		/// <param name="pos"></param>
		public static void File_All_Dis(string path1, string path2, bool bools, string pos)
		{
			if (bools == true)
			{
				//得到这个路径下全部的文件，包含子路径下的全部pos给过来的文件,这个为基准文件
				string[] files1 = Directory.GetFiles(path1, pos, SearchOption.AllDirectories);
				//这个是日志文件路径
				string path_log = Arong_New.Arong_str() + "\\Temp\\File_Log.txt";

				for (int i = 0; i < files1.Length; i++)
				{
					//将基准文件的字符串读取出来
					string temp1 = File.ReadAllText(files1[i]);
					//转换为MD5码
					string temp2 = Arong_Re.GetMd5Hash(temp1);
					//将对比的文件夹路径进行转换
					files1[i] = files1[i].Replace(path1, path2);

					//判断转换后的文件夹是否存在，如果不存在，则写入日志
					if (File.Exists(files1[i]) == true)
					{
						//将要对比的字符串读取出来
						string temp3 = File.ReadAllText(files1[i]);
						//转换为MD5码
						string temp4 = Arong_Re.GetMd5Hash(temp3);
						//如果这个两个MD5对不上，则写入日志
						if (temp2 != temp4)
						{
							Arong_File.File_String(path_log, "该文件MD5码对比不符合  " + files1[i]);
						}
					}
					else
					{
						Arong_File.File_String(path_log, "不存在  " + files1[i]);
					}
				}
			}
			else
			{
				//得到这个路径下全部的文件，包含子路径下的全部文件,这个为基准文件
				string[] files1 = Directory.GetFiles(path1, "*", SearchOption.AllDirectories);
				//这个是日志文件路径
				string path_log = Arong_New.Arong_str() + "\\Temp\\File_Log.txt";

				for (int i = 0; i < files1.Length; i++)
				{
					//将基准文件的字符串读取出来
					string temp1 = File.ReadAllText(files1[i]);
					//转换为MD5码
					string temp2 = Arong_Re.GetMd5Hash(temp1);
					//将对比的文件夹路径进行转换
					files1[i] = files1[i].Replace(path1, path2);

					//判断转换后的文件夹是否存在，如果不存在，则写入日志
					if (File.Exists(files1[i]) == true)
					{
						//将要对比的字符串读取出来
						string temp3 = File.ReadAllText(files1[i]);
						//转换为MD5码
						string temp4 = Arong_Re.GetMd5Hash(temp3);
						//如果这个两个MD5对不上，则写入日志
						if (temp2 != temp4)
						{
							Arong_File.File_String(path_log, "该文件MD5码对比不符合  " + files1[i]);
						}
					}
					else
					{
						Arong_File.File_String(path_log, "不存在  " + files1[i]);
					}
				}
			}
		}
	}

	/// <summary>
	/// 基本类与路径
	/// </summary>
	public class Arong_New
	{
		/// <summary>
		/// 编辑功能
		/// </summary>
		/// <param name="arong_name"></param>
		/// <param name="arong_button"></param>
		/// <param name="arong_label"></param>
		/// <param name="arong_bitmap"></param>
		/// <param name="arong_actions"></param>
		/// <param name="message"></param>
		public static void New_path(string arong_name, string arong_button, string arong_label, string arong_bitmap, string arong_actions, string message)
		{
			//获取工具在文件夹中的位置,不包括exe
			string arong_str = Arong_str();
			//读取参考模板信息
			string[] Temp_Menu = File.ReadAllLines(arong_str + "\\Data\\Temp_Menu.txt");
			//功能注释名称
			string temp_1 = Temp_Menu[0] + arong_name;
			//功能按钮名称
			string temp_2 = Temp_Menu[1] + arong_button;
			//功能显示名称
			string temp_3 = Temp_Menu[2] + arong_label;
			//20230307新增一个MESSAGE 
			string temp_6 = Temp_Menu[3] + message;
			//功能位图名称
			string temp_4 = Temp_Menu[4] + arong_bitmap;
			//功能DLL路径
			string temp_5 = Temp_Menu[5] + arong_actions + Temp_Menu[6];
			//组合导出
			string arong_sum = temp_1 + "\n" + temp_2 + "\n" + temp_3 + "\n" + temp_6 + "\n" + temp_4 + "\n" + temp_5;
			//创建文件的路径
			string arong_Temp_Menu = arong_str + "\\Button\\" + arong_name + ".txt";
			//创建文件
			System.IO.File.WriteAllText(@arong_Temp_Menu, arong_sum);
		}

		/// <summary>
		/// 返回路径函数
		/// </summary>
		/// <returns></returns>
		public static string Arong_str()
		{
			string @path = System.Environment.CurrentDirectory;
			return @path;
		}
	}

	/// <summary>
	/// 语言转换类
	/// </summary>
	//这个接口有问题
	public class Arong_Lang
	{
		/// <summary>
		/// 语言主程序,path为翻译文件所在，pathname为要翻译的文件名称，如果有则返回对应的名称，如果没有，返回用来的名称
		/// </summary>
		/// <param name="path"></param>
		/// <param name="pathname"></param>
		/// <returns></returns>
		public static string Lang(string path, string pathname)
		{
			//读取翻译文件中的原始名称与翻译后的名称
			string[] file = File.ReadAllLines(path);
			string[] namey = new string[] { };
			string[] namef = new string[] { };
			string name = "";
			//先把翻译好的名称存储到数组内
			for (int i = 0; i < file.Length; i++)
			{
				//原始名称
				name = file[i].Substring(0, file[i].IndexOf("="));
				namey[i] = name;
				//翻译后的名称存储
				name = file[i].Substring(file[i].IndexOf("=") + 1);
				namef[i] = name;
			}
			if (pathname == namey[0])
			{
				name = namef[0];
			}
			else
			{
				//name = pathname[0];
			}
			return name;
		}

		/// <summary>
		/// 将输入的字符串过滤，然后返回对应的字符串
		/// </summary>
		/// <param name="name"></param>
		/// <param name="names"></param>
		/// <param name="s"></param>
		/// <returns></returns>
		public static string[] Find(string[] name, string names, int s)
		{
			string[] temp = new string[name.Length];
			int sum = 0;
			for (int i = 0; i < name.Length; i++)
			{
				if (name[i].Substring(0, s) == names)
				{
					temp[sum] = name[i].ToString();
					sum++;
				}
			}
			string[] temp2 = new string[sum];
			for (int i = 0; i < temp2.Length; i++)
			{
				temp2[i] = temp[i].ToString();
			}
			return temp2;
		}
	}

	/// <summary>
	/// 负责操作日志写入类
	/// </summary>
	public class Arong_Log
	{
		/// <summary>
		/// 传入字符串，将该字符串写入到日志内，包括时间，默认换行，无文件时自动创建文件
		/// </summary>
		/// <param name="str"></param>
		public static void Oper_Log(string str)
		{
			string path = Arong_New.Arong_str() + "\\Oper_Log.txt";
			string time = "[" + DateTime.Now.ToString() + "]";
			//如果不存在，则创建
			File.AppendAllText(path, time + str + "\n");
		}
	}
}
