//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Champions.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class Attendant
    {
        public int ID { get; set; }
        public string name { get; set; }
        public int idGrupo { get; set; }
        public int power { get; set; }
    
        public virtual Team Team { get; set; }
    }
}