//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RulesParser.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Section
    {
        public Section()
        {
            this.SubSections = new HashSet<SubSection>();
        }
    
        public int sectionID { get; set; }
        public int sectionNumber { get; set; }
        public int sectionName { get; set; }
    
        public virtual ICollection<SubSection> SubSections { get; set; }
    }
}
