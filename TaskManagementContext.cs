using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Task_Mang_Api.Models;

public partial class TaskManagementContext : DbContext
{
    public TaskManagementContext()
    {
    }

    public TaskManagementContext(DbContextOptions<TaskManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DepartmentMaster> DepartmentMasters { get; set; }

    public virtual DbSet<EmployeeMaster> EmployeeMasters { get; set; }

    public virtual DbSet<LeaveBalance> LeaveBalances { get; set; }

    public virtual DbSet<LeaveMaster> LeaveMasters { get; set; }

    public virtual DbSet<LeaveType> LeaveTypes { get; set; }

    public virtual DbSet<TaskMaster> TaskMasters { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DepartmentMaster>(entity =>
        {
            entity.HasKey(e => e.DepId).HasName("PK__departme__00D7A2B39D0181E8");

            entity.ToTable("department_master");

            entity.Property(e => e.DepId).HasColumnName("depId");
            entity.Property(e => e.DepName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("depName");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
        });

        modelBuilder.Entity<EmployeeMaster>(entity =>
        {
            entity.HasKey(e => e.EmpId).HasName("PK__employee__AFB3EC0D284D8550");

            entity.ToTable("employee_master");

            entity.Property(e => e.EmpId).HasColumnName("empId");
            entity.Property(e => e.DepId).HasColumnName("depId");
            entity.Property(e => e.EmpName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("empName");
            entity.Property(e => e.EmpPass)
                .HasMaxLength(50)
                .HasColumnName("empPass");
            entity.Property(e => e.IsActive).HasColumnName("isActive");

            entity.HasOne(d => d.Dep).WithMany(p => p.EmployeeMasters)
                .HasForeignKey(d => d.DepId)
                .HasConstraintName("FK__employee___depId__60A75C0F");
        });

        modelBuilder.Entity<LeaveBalance>(entity =>
        {
            entity.HasKey(e => e.LeaveBalanceId).HasName("PK__leave_ba__4AD5860BAE112B71");

            entity.ToTable("leave_balance");

            entity.Property(e => e.LeaveBalanceId).HasColumnName("leaveBalanceId");
            entity.Property(e => e.EmpId).HasColumnName("empId");
            entity.Property(e => e.LeaveBalanceHour)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("leave_balanceHour");
            entity.Property(e => e.LeaveBalancetype01).HasColumnName("Leave_Balancetype01");
            entity.Property(e => e.LeaveBalancetype02).HasColumnName("Leave_Balancetype02");
            entity.Property(e => e.LeaveBalancetype03).HasColumnName("Leave_Balancetype03");
            entity.Property(e => e.LeaveBalenceday)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("leave_Balenceday");

            entity.HasOne(d => d.Emp).WithMany(p => p.LeaveBalances)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK__leave_bal__empId__693CA210");
        });

        modelBuilder.Entity<LeaveMaster>(entity =>
        {
            entity.HasKey(e => e.LeaveId).HasName("PK__leave_ma__CB46149423E8ABB9");

            entity.ToTable("leave_master");

            entity.Property(e => e.LeaveId).HasColumnName("leaveId");
            entity.Property(e => e.EmpId).HasColumnName("empId");
            entity.Property(e => e.LeaveMonth).HasColumnType("datetime");
            entity.Property(e => e.LeaveTypeId).HasColumnName("leaveTypeId");
            entity.Property(e => e.TotalLeave).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.TotalleaveHours).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Emp).WithMany(p => p.LeaveMasters)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK__leave_mas__empId__66603565");

            entity.HasOne(d => d.LeaveType).WithMany(p => p.LeaveMasters)
                .HasForeignKey(d => d.LeaveTypeId)
                .HasConstraintName("FK__leave_mas__leave__656C112C");
        });

        modelBuilder.Entity<LeaveType>(entity =>
        {
            entity.HasKey(e => e.LeaveTypeId).HasName("PK__leave_ty__CEFA327828152963");

            entity.ToTable("leave_type");

            entity.Property(e => e.LeaveTypeId).HasColumnName("leaveTypeId");
            entity.Property(e => e.LeaveName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("leaveName");
        });

        modelBuilder.Entity<TaskMaster>(entity =>
        {
            entity.HasKey(e => e.TaskId).HasName("PK__task_mas__DD5D5A420D75620B");

            entity.ToTable("task_master");

            entity.Property(e => e.TaskId).HasColumnName("taskId");
            entity.Property(e => e.Isactive).HasColumnName("isactive");
            entity.Property(e => e.TaskEndDate)
                .HasColumnType("date")
                .HasColumnName("task_end_date");
            entity.Property(e => e.TaskName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("taskName");
            entity.Property(e => e.TaskStartDate)
                .HasColumnType("date")
                .HasColumnName("task_start_date");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
