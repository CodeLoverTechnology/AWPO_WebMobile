﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AWPO_WebMobile.DbModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AWPODBEntities : DbContext
    {
        public AWPODBEntities()
            : base("name=AWPODBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<M_ContactMaster> M_ContactMaster { get; set; }
        public virtual DbSet<T_OfficersVacanciesMaster> T_OfficersVacanciesMaster { get; set; }
        public virtual DbSet<M_ExamMater> M_ExamMater { get; set; }
        public virtual DbSet<M_FAQMaster> M_FAQMaster { get; set; }
    }
}
