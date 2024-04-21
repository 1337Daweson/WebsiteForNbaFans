using Microsoft.EntityFrameworkCore;
﻿using System;
using System.Collections.Generic;

namespace WebsiteForNbaFans.Models;

public partial class NbaWebContext : DbContext
{
    public NbaWebContext()
    {
    }

    public NbaWebContext(DbContextOptions<NbaWebContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Article> Articles { get; set; }


    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseSqlServer("Server=PRECIOUSONE\\SQLEXPRESS;Database=NbaWeb;Trusted_Connection=True;Encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Article>(entity =>
        {
            entity.Property(e => e.Title).HasMaxLength(255);

            entity.Property(e => e.Content).HasMaxLength(255);
        });

       

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}