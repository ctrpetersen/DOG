//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DOG
{
    using System;
    using System.Collections.Generic;
    
    public partial class Item
    {
        public int id { get; set; }
        public Nullable<int> slot { get; set; }
        public Nullable<int> dog_id { get; set; }
        public Nullable<int> atk_power { get; set; }
        public Nullable<int> defense { get; set; }
        public Nullable<int> will { get; set; }
        public Nullable<int> intelligence { get; set; }
        public Nullable<int> special_effect { get; set; }
        public string name { get; set; }
    
        public virtual Dog Dog { get; set; }
    }
}