﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class mtgRulesEntities : DbContext
    {
        public mtgRulesEntities()
            : base("name=mtgRulesEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<MainRule> MainRules { get; set; }
        public virtual DbSet<MainRuleExample> MainRuleExamples { get; set; }
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<SubRule> SubRules { get; set; }
        public virtual DbSet<SubRuleExample> SubRuleExamples { get; set; }
    }
}
