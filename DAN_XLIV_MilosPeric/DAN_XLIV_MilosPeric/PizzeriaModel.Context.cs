﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAN_XLIV_MilosPeric
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CustomerDatabaseEntities : DbContext
    {
        public CustomerDatabaseEntities()
            : base("name=CustomerDatabaseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblOrder> tblOrders { get; set; }
        public virtual DbSet<tblPizzaMenu> tblPizzaMenus { get; set; }
        public virtual DbSet<tblPizzaOrder> tblPizzaOrders { get; set; }
        public virtual DbSet<vwPizzaShop> vwPizzaShops { get; set; }
        public virtual DbSet<tblSelectedPizza> tblSelectedPizzas { get; set; }
    }
}
