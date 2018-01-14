using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZZTOA_Model;
using ZZTOA_BLL;
using System.IO;
namespace ZZTOA.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <returns></returns>
        public FileResult ExportExcelToClient()
        {
            //导出到客户端
            MemoryStream ms = new MemoryStream();
            ReturnMsg rm=ZZTOA_BLL.ExportExcel_BLL.ExportMs(ref ms,0,"");
            return File(ms, "application/vnd.ms-excel", "人员信息.xls");
        }
        /// <summary>
        /// 导出到服务器
        /// </summary>
        /// <returns></returns>
        public ActionResult ExportExcelToServer()
        {
            MemoryStream ms = new MemoryStream();
            ReturnMsg rm = ZZTOA_BLL.ExportExcel_BLL.ExportMs(ref ms, 1, "D:/人员信息.xls");
            return Json(new { code = rm.code, msg = rm.msg });
        }
        
    }
}