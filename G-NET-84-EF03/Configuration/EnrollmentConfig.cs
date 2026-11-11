using G_NET_84_EF03.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace G_NET_84_EF03.Configuration;

internal class EnrollmentConfig : IEntityTypeConfiguration<Enrollment>
{
    public void Configure(EntityTypeBuilder<Enrollment> builder)
    {
        builder.Property(e => e.ProgressPercentage)
            .HasPrecision(5, 2);

        builder.Property(e => e.FinalGrade)
             .HasPrecision(5, 2);

        builder.HasKey(e => new { e.CourseId, e.StudentId });

        //Student - Enrollment | one(mandatory) - many(optional)
        builder.HasOne(e => e.Student)
            .WithMany(s => s.Enrollments)
            .HasForeignKey(e => e.StudentId);

        //Course - Enrollment | one(mandatory) - many(optional)
        builder.HasOne(e => e.Course)
            .WithMany(c => c.Enrollments)
            .HasForeignKey(e => e.CourseId);

        //Progress must be between 0 and 100.An enrollment is Completed when its progressreaches 100.
        builder.ToTable(t => t.HasCheckConstraint(
            "CK_Enrollment_ProgressPercentage",
            "[ProgressPercentage] >= 0 AND [ProgressPercentage] <= 100"
        ));
    }
}
