//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nukangs.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cart
    {
        public int CustomerID { get; set; }
        public int TukangID { get; set; }
        public Nullable<int> hours { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Tukang Tukang { get; set; }
    }
}
