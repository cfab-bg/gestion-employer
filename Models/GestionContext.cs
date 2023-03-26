using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;


namespace StaffApi.Models{
public class GestionContext : DbContext
{
    public DbSet<Employer> Employers { get; set; }
    public DbSet<Avantage> Avantages { get; set; }

    public string DbPath { get; }

    public GestionContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "Dasdjkfjghhhhgsf.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}
}

