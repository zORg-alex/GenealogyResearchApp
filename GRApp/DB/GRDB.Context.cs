﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GenealogyResearchApp.GRAppLib.DB
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class GRDBCont : DbContext
    {
        public GRDBCont()
            : base("GRDBCont")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<NameGroup> NameGroups { get; set; }
        public virtual DbSet<Name> Names { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Place> Places { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<DocumentLine> DocumentLines { get; set; }
    }
}
