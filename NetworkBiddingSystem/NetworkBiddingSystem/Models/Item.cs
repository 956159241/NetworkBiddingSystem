//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace NetworkBiddingSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Item
    {
        public int ItemId { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> AskingPrice { get; set; }
        public Nullable<int> SellerId { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
        public Nullable<int> ItemBidDocId { get; set; }
        public Nullable<int> Status { get; set; }
        public string ItemName { get; set; }
    }
}
