using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ZZTOA_Model;
using ZZTOA_DAL;
namespace ZZTOA_BLL
{
    public class ExportExcel_BLL
    {
        public static ReturnMsg ExportMs(ref MemoryStream ms,int type =0,string path="")
        {
            ExcelFields ef = new ExcelFields() { Name = "张三", CreateTime = DateTime.Now };
            ExcelFields ef2 = new ExcelFields() { Name = "张三", CreateTime = DateTime.Now };
            List<ExcelFields> efList = new List<ExcelFields>();
            efList.Add(ef);
            efList.Add(ef2);
            ReturnMsg rm=ZZTOA_DAL.ExportExcel_DAL.ExportList(ref ms,efList,type,path);
            //ReturnMsg rm=ZZTOA_DAL.ExportExcel_DAL.ExportDataTable(ref ms,new System.Data.DataTable(),type,path);           
            return rm;
        }
    }
}
