//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Assignment3.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class RegisterForm
    {
        public int RegisterNo { get; set; }
        public System.DateTime ServiceTime { get; set; }
        public int ClientId { get; set; }
        public int ServiceId { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual Service Service { get; set; }
    }
}
