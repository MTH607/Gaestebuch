﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Gästebuch.Models
    {
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    /// <summary>
    /// Defines the <see cref="GästebuchEntities" />.
    /// </summary>
    public partial class GästebuchEntities : DbContext
        {
        /// <summary>
        /// Initializes a new instance of the <see cref="GästebuchEntities"/> class.
        /// </summary>
        public GästebuchEntities()
            : base("name=GästebuchEntities")
            {
            }

        /// <summary>
        /// The OnModelCreating.
        /// </summary>
        /// <param name="modelBuilder">The modelBuilder<see cref="DbModelBuilder"/>.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
            throw new UnintentionalCodeFirstException();
            }

        /// <summary>
        /// Gets or sets the tbl_Admin.
        /// </summary>
        public virtual DbSet<tbl_Admin> tbl_Admin { get; set; }

        /// <summary>
        /// Gets or sets the tbl_ChangeLog.
        /// </summary>
        public virtual DbSet<tbl_ChangeLog> tbl_ChangeLog { get; set; }

        /// <summary>
        /// Gets or sets the tbl_Einträge.
        /// </summary>
        public virtual DbSet<tbl_Einträge> tbl_Einträge { get; set; }
        }
    }
