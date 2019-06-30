using Common;
using Common.NPinyin;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebDemo
{
    public partial class ShortcutTool : System.Web.UI.Page
    {
        BasicClass bc = new BasicClass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSure_Click(object sender, EventArgs e)
        {

            if (inputStart.Value.ToString() == "")
            {
                //提示
                Response.Write("<script>alert('【表名前缀】不能为空')</script>");
            }
            else if (inputName.Value.ToString() == "")
            {
                //提示
                Response.Write("<script>alert('【表名】不能为空')</script>");
            }
            else if (txtarea.InnerHtml == "")
            {
                //提示
                Response.Write("<script>alert('【中文字段部分】不能为空')</script>");
            }
            else
            {
                string str = "";
                if (AutoCodeCk.Checked == true)//自动编号
                {
                    string s = bc.GoToRemoveChar(txtarea.InnerHtml);
                    //转成拼音首字母
                    str = bc.GoToSpace(Pinyin.GetInitials(s)).ToUpper();
                    str += "\r\n";
                    str += txtarea.InnerHtml + "_${RunTime.CurYear}${RunTime.CurMonth}${RunTime.CurDay}{$AutoNum$}";
                }
                else//数据表
                {
                    str = GetTable();
                }

                showText.InnerHtml = str;
            }
            

            
        }


        /// <summary>
        /// 创建数据表
        /// </summary>
        /// <returns></returns>
        public string GetTable()
        {
            string newLine = "\r\n";
            string tableName = "";
            if (!string.IsNullOrEmpty(inputName.Value))
            {
                tableName = bc.GoToRemoveChar(inputName.Value);
                
            }
            List<string> listData = new List<string>();

            //字段名称
            string s = bc.GoToRemoveChar(txtarea.InnerHtml.Replace(newLine, ";"));
            //表名
            if (flowCk.Checked == true || ConventionalCk.Checked == true)//英语
            {
                tableName = GetData(tableName)[0];
                tableName = inputStart.Value + "_" + bc.GoToRemoveChar(bc.GoToSpace(bc.ConvertInitials(tableName)));
                
                //英文
                listData = GetData(s);
            }
            else if (flowCkPY.Checked == true || ConventionalCkPY.Checked == true)
            {
                tableName = GetPYData(tableName)[0];
                tableName = inputStart.Value + "_" + bc.GoToRemoveChar(bc.GoToSpace(tableName));

                //拼音
                listData = GetPYData(s);

            }
            //默认长度为nvarchar(200),时间为 datetime,主键为 int
            string charType = " [nvarchar](200)";
            string dataType = " [datetime]";
            string pramaryKeyType = " [int] IDENTITY(1,1) PRIMARY KEY  NOT NULL";

            List<string> filedList = new List<string>();
            string data = "";

            foreach (var item in listData)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    data = bc.GoToRemoveChar(item);
                    if (flowCk.Checked == true || ConventionalCk.Checked == true)//英语
                    {
                        //转成首字母大写
                        data = bc.ConvertInitials(bc.GoToRemoveChar(item));
                    }
                    //去除空格和异常字符
                    data = bc.GoToSpace(data);
                    filedList.Add(data);
                }
                else
                {
                    filedList.Add("空值");
                }
            }

            //组合数据表结构
            string sql = $"CREATE TABLE {tableName}{newLine}";
            sql += "(" + newLine;
            //主键
            sql += " [Id]" + pramaryKeyType + "," + newLine;
            //判断是否为流程表
            if (flowCk.Checked == true|| flowCkPY.Checked==true)
            {
                sql += " [FormTitle] [nvarchar](100)," + newLine;
                sql += " [FlowGuid] [nvarchar](50)," + newLine;
            }

            //遍历组合
            for (int i = 0; i < filedList.Count; i++)
            {
                if (filedList[i].Contains("Time") || filedList[i].Contains("Date"))
                {
                    sql += " [" + filedList[i] + "]" + dataType + ",";
                }
                else
                {
                    sql += " [" + filedList[i] + "]" + charType + ",";
                }
                sql += newLine;
            }
            sql += ")";

            return sql;
        }

        /// <summary>
        /// 中文翻译
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<string> GetData(string data)
        {
            List<string> list = new List<string>();

            if (!string.IsNullOrEmpty(data))
            {
                string url = "http://fanyi.youdao.com/translate?&doctype=json&type=ZH_CN2EN&i=" + data;
                string jsonText = bc.Get_Http(url, 6000);
                try
                {
                    //解析json
                    JObject jObjet = JObject.Parse(jsonText);
                    int i = 0;
                    foreach (var item in jObjet)
                    {
                        string key = item.Key;
                        if (key.Equals("translateResult"))
                        {
                            JToken jToken = item.Value[0];
                            foreach (var value in jToken)
                            {
                                string str = value["tgt"].ToString().Replace(";", "");
                                list.Add(str);
                            }

                        }
                        i++;
                    }
                }
                catch (Exception)
                {

                    throw;
                }

            }

            return list;
        }

        /// <summary>
        /// 中文转拼音
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<string> GetPYData(string data)
        {
            List<string> list = new List<string>();

            if (!string.IsNullOrEmpty(data))
            {
                string []arry = data.Split(';');

                foreach (var item in arry)
                {
                    string str=Pinyin.GetInitials(item).ToUpper();
                    list.Add(str);
                }
            }
            return list;
        }
    }
}