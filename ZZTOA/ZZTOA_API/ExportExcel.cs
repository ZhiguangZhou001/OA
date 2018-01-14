using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZTOA_Model;
using System.Data;
using System.Reflection;
using System.Web.Mvc;
namespace ZZTOA_API
{
    public class ExportExcel
    {
        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="obj">数据源 List<相关类>类型</param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static MemoryStream Export(IList list,int type)
        {
            int code = 0;
            string msg = "";
            string excelName = "";
            DataTable dt;
            try
            {
                switch (type)
                {
                    case (int)ExcelType.人员信息:
                        excelName = "人员信息";
                        break;
                    default:
                        code = 1;
                        msg = "找不到相关导出类型";
                        break;
                }
                dt = ToDataTable(list);//将数据源转换为datatable类型
                //创建Excel文件的对象
                NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();
                //添加一个sheet
                NPOI.SS.UserModel.ISheet sheet1 = book.CreateSheet("Sheet1");
                //给sheet1添加第一行的头部标题
                NPOI.SS.UserModel.IRow row1 = sheet1.CreateRow(0);
                int i = 0;
                foreach (DataColumn column in dt.Columns)
                {
                    row1.CreateCell(i).SetCellValue(column.ColumnName);
                    i++;
                }
                i = 0;
                int j = 0;
                foreach(DataRow dr in dt.Rows)
                {
                    NPOI.SS.UserModel.IRow rowtemp = sheet1.CreateRow(j + 1);
                    for(; i<dt.Columns.Count;i++)
                    {
                        rowtemp.CreateCell(i).SetCellValue(dr[i].ToString());
                    }
                    j++;
                }
                //写入到客户端
                MemoryStream ms = new MemoryStream();
                book.Write(ms);
                ms.Seek(0, SeekOrigin.Begin);
                return ms;
            }
            catch(Exception ex)
            {
                return null;
            }          
        }
        /// <summary>    
        /// 将集合类转换成DataTable    
        /// </summary>    
        /// <param name="list">集合</param>    
        /// <returns></returns>    
        private static DataTable ToDataTable(IList list)
        {
            DataTable result = new DataTable();
            if (list.Count > 0)
            {
                PropertyInfo[] propertys = list[0].GetType().GetProperties();

                foreach (PropertyInfo pi in propertys)
                {
                    result.Columns.Add(pi.Name, pi.PropertyType);
                }
                foreach (object t in list)
                {
                    ArrayList tempList = new ArrayList();
                    foreach (PropertyInfo pi in propertys)
                    {
                        object obj = pi.GetValue(t, null);
                        tempList.Add(obj);
                    }
                    object[] array = tempList.ToArray();
                    result.LoadDataRow(array, true);
                }
            }
            return result;
        }
    }
}
