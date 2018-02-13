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
    
    public partial class Address
    {
        public Address()
        {
            this.People = new HashSet<Person>();
        }
    
        public System.Guid AddressID { get; set; }
        public byte StateID { get; set; }
        public int StateLGID { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public Nullable<int> PersonId { get; set; }
    
        public virtual State State { get; set; }
        public virtual StateLGA StateLGA { get; set; }
        public virtual ICollection<Person> People { get; set; }
        public virtual Person Person { get; set; }
    }
}
