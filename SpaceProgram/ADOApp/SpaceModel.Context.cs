﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SpaceProgram.ADOApp
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SpaceProgramEntities : DbContext
    {
        public SpaceProgramEntities()
            : base("name=SpaceProgramEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AdvertisingAgent> AdvertisingAgent { get; set; }
        public virtual DbSet<Advertisment> Advertisment { get; set; }
        public virtual DbSet<Balance> Balance { get; set; }
        public virtual DbSet<Cosmodrome> Cosmodrome { get; set; }
        public virtual DbSet<Crew> Crew { get; set; }
        public virtual DbSet<Crew_Employee> Crew_Employee { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Flight> Flight { get; set; }
        public virtual DbSet<Flight_Advertisment> Flight_Advertisment { get; set; }
        public virtual DbSet<Planet> Planet { get; set; }
        public virtual DbSet<Qualification> Qualification { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Route> Route { get; set; }
        public virtual DbSet<SpaceObject> SpaceObject { get; set; }
        public virtual DbSet<SpaceObjectType> SpaceObjectType { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}
