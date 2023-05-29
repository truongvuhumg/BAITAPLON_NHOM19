using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QUANLYTHUVIEN.Models;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<QUANLYTHUVIEN.Models.Nhaxuatban> Nhaxuatban { get; set; } = default!;

        public DbSet<QUANLYTHUVIEN.Models.Author> Author { get; set; } = default!;

        public DbSet<QUANLYTHUVIEN.Models.Category> Category { get; set; } = default!;

        public DbSet<QUANLYTHUVIEN.Models.Book> Book { get; set; } = default!;

        public DbSet<QUANLYTHUVIEN.Models.Employee> Employee { get; set; } = default!;

        public DbSet<QUANLYTHUVIEN.Models.Readers> Readers { get; set; } = default!;

        public DbSet<QUANLYTHUVIEN.Models.Phieumuonsach> Phieumuonsach { get; set; } = default!;

        public DbSet<QUANLYTHUVIEN.Models.Chitietmuontra> Chitietmuontra { get; set; } = default!;
    }
