//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication2
{
    using System;
    using System.Collections.Generic;
    
    public partial class sale
    {
        public System.Guid 售货编号 { get; set; }
        public string 客户电话 { get; set; }
        public System.DateTime 销售时间 { get; set; }
        public string 操作人员 { get; set; }
        public System.Guid 商品编号 { get; set; }
    
        public virtual customer customer { get; set; }
        public virtual goods goods { get; set; }
        public virtual Register Register { get; set; }
    }
}
