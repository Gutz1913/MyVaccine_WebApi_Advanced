using Microsoft.EntityFrameworkCore;

namespace MyVaccine.WebApi.Models;

public class MyVaccineAppDbContext : DbContext
{
    public MyVaccineAppDbContext(DbContextOptions<MyVaccineAppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Dependent> Dependents => Set<Dependent>();
    public DbSet<VaccineCategory> Categories => Set<VaccineCategory>();
    public DbSet<Vaccine> Vaccines => Set<Vaccine>();
    public DbSet<VaccineRecord> VaccineRecords => Set<VaccineRecord>();
    public DbSet<Allergy> Allergies => Set<Allergy>();
    public DbSet<FamilyGroup> FamilyGroups => Set<FamilyGroup>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // ---- User Configuration ----
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(u => u.Id);

            entity.Property(u => u.UserName)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(u => u.Email)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(u => u.Password)
                  .IsRequired()
                  .HasMaxLength(100);
        });

        // ---- Dependent Configuration ----
        modelBuilder.Entity<Dependent>(entity =>
        {
            entity.HasKey(d => d.Id);

            entity.Property(d => d.Name)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(d => d.BirthDate)
                  .IsRequired();

            entity.HasOne(d => d.User)
                  .WithMany(u => u.Dependents)
                  .HasForeignKey(d => d.UserId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // ---- VaccineCategory Configuration ----
        modelBuilder.Entity<VaccineCategory>(entity =>
        {
            entity.HasKey(vc => vc.Id);

            entity.Property(vc => vc.Name)
                  .IsRequired()
                  .HasMaxLength(100);
        });

        // ---- Vaccine Configuration ----
        modelBuilder.Entity<Vaccine>(entity =>
        {
            entity.HasKey(v => v.Id);

            entity.Property(v => v.Name)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.HasMany(v => v.Categories)
                  .WithMany(vc => vc.Vaccines)
                  .UsingEntity(j => j.ToTable("VaccineCategoryVaccines"));
        });

        // ---- VaccineRecord Configuration ----
        modelBuilder.Entity<VaccineRecord>(entity =>
        {
            entity.HasKey(vr => vr.Id);

            entity.Property(vr => vr.DateAdministered)
                  .IsRequired();

            entity.Property(vr => vr.AdministeredLocation)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(vr => vr.AdministeredBy)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.HasOne(vr => vr.User)
                  .WithMany(u => u.VaccineRecords)
                  .HasForeignKey(vr => vr.UserId)
                  .OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(vr => vr.Dependent)
                  .WithMany(d => d.VaccineRecords)
                  .HasForeignKey(vr => vr.DependentId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(vr => vr.Vaccine)
                  .WithMany()
                  .HasForeignKey(vr => vr.VaccineId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // ---- Vaccine Configuration ----
        modelBuilder.Entity<Allergy>(entity =>
        {
            entity.HasKey(a => a.Id);

            entity.Property(a => a.Name)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.HasOne(a => a.User)
                  .WithMany(u => u.Allergies)
                  .HasForeignKey(a => a.UserId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // ---- FamilyGroup Configuration ----
        modelBuilder.Entity<FamilyGroup>(entity =>
        {
            entity.HasKey(fg => fg.Id);

            entity.Property(fg => fg.Name)
                  .IsRequired()
                  .HasMaxLength(100);
        });
    }
}
