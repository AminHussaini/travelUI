//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace travelProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Hotel_images
    {
        public int id { get; set; }
        public string h_path { get; set; }
        public Nullable<int> h_id { get; set; }
    
        public virtual Hotel Hotel { get; set; }
    }
}
