//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Artisaneer.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class State
    {
        public State()
        {
            this.Addresses = new HashSet<Address>();
            this.StateLGAs = new HashSet<StateLGA>();
        }
    
        public byte StateID { get; set; }
        public string StateName { get; set; }
        public string StateShort { get; set; }
    
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<StateLGA> StateLGAs { get; set; }
    }
}