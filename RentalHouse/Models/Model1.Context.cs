﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RentalHouse.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DbRentalHouseEntities : DbContext
    {
        public DbRentalHouseEntities()
            : base("name=DbRentalHouseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<T_City> T_City { get; set; }
        public virtual DbSet<T_Houses> T_Houses { get; set; }
        public virtual DbSet<T_State> T_State { get; set; }
        public virtual DbSet<T_Users> T_Users { get; set; }
    }
}