using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZZTOA_Model
{
    public enum ExcelType{
        人员信息,
        可添加类型
    }
    /// <summary>
    /// 人员信息记录
    /// 导出Excel的单元记录 ：模板，不同的表可建立类似这样的类
    /// </summary>
    public class ExcelFields  
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
