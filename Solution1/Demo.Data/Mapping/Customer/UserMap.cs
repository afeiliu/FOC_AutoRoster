using Demo.Core.Domain.Customer;
using System.Data.Entity.ModelConfiguration;

namespace Demo.Data.Mapping.Customer
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            this.ToTable("T_USER");
            this.HasKey(k => k.Id).Property(p => p.Id).HasColumnName("ID");
            this.Property(p => p.EmpNo).HasColumnName("EMPNO").HasMaxLength(64).IsRequired();
            this.Property(p => p.Name).HasColumnName("NAME").HasMaxLength(100).IsRequired();
            this.Property(p => p.Sex).HasColumnName("SEX").HasMaxLength(1).IsOptional();
            this.Property(p => p.ImgUrl).HasColumnName("IMGURL").HasMaxLength(256).IsOptional();
            this.Property(p => p.Birthday).HasColumnName("BIRTHDAY").IsOptional();
            this.Property(p => p.Education).HasColumnName("EDUCATION").HasMaxLength(32).IsOptional();
            this.Property(p => p.MobilePhone).HasColumnName("MOBILEPHONE").HasMaxLength(100).IsOptional();
            this.Property(p => p.OfficePhone).HasColumnName("OFFICEPHONE").HasMaxLength(100).IsOptional();
            this.Property(p => p.Email).HasColumnName("EMAIL").HasMaxLength(128).IsOptional();
            this.Property(p => p.School).HasColumnName("SCHOOL").HasMaxLength(128).IsOptional();
            this.Property(p => p.Job).HasColumnName("JOB").HasMaxLength(64).IsOptional();
            this.Property(p => p.JobAddress).HasColumnName("JOBADDRESS").HasMaxLength(256).IsOptional();
            this.Property(p => p.JobName).HasColumnName("JOBNAME").HasMaxLength(32).IsOptional();
            this.Property(p => p.InductionDate).HasColumnName("INDUCTIONDATE").IsOptional();
            this.Property(p => p.ResignDate).HasColumnName("RESIGNDATE").IsOptional();
            this.Property(p => p.IsUsed).HasColumnName("ISUSED").IsRequired();
            this.Property(p => p.CreateDate).HasColumnName("CREATEDATE");
            this.Property(p => p.CreatePerson).HasColumnName("CREATEPERSON").HasMaxLength(32).IsRequired();
            this.Property(p => p.ModifyDate).HasColumnName("MODIFYDATE");
            this.Property(p => p.ModifyPerson).HasColumnName("MODIFYPERSON").HasMaxLength(32).IsRequired();
        }
    }
}
