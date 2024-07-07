using CoensioEvulatorApi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CoensioEvulatorApi.Data
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Test> Tests { get; set; }
        public DbSet<CodingQuestion> CodingQuestions { get; set; }
        public DbSet<CodingQuestionsTestTakerAnswer> CodingQuestionsTestTakerAnswers { get; set; }
        public DbSet<FreeTextQuestion> FreeTextQuestions { get; set; }
        public DbSet<FreeTextQuestionTestTakerAnswer> FreeTextQuestionTestTakerAnswers { get; set; }
        public DbSet<MultipleChoiceQuestion> MultipleChoiceQuestions { get; set; }
        public DbSet<MultipleChoiceQuestionTestTakerAnswer> MultipleChoiceQuestionTestTakerAnswers { get; set; }
        public DbSet<AssesmentAssignment> AssesmentAssignments { get; set; }
        public ApiDbContext(DbContextOptions<ApiDbContext> opt) : base(opt)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.UseIdentityColumns();
            builder.Entity<Test>()
                .HasMany(x => x.CodingQuestions)
                .WithMany(y => y.Tests)
                .UsingEntity(j => j.ToTable("TestCodingQuestions"));

            builder.Entity<Test>()
               .HasMany(x => x.FreeTextQuestions)
               .WithMany(y => y.Tests)
               .UsingEntity(j => j.ToTable("TestFreeTextQuestions"));

            builder.Entity<Test>()
               .HasMany(x => x.MultipleChoiceQuestions)
               .WithMany(y => y.Tests)
               .UsingEntity(j => j.ToTable("TestMultipleChoiceQuestions"));

            builder.Entity<AssesmentAssignment>()
                .HasOne(x => x.Test)
                .WithMany(y => y.AssesmentAssignments);

            builder.Entity<CodingQuestionsTestTakerAnswer>()
                .HasOne(x => x.CodingQuestion)
                .WithMany(y => y.CodingQuestionTestTakerAnswers);

            builder.Entity<FreeTextQuestionTestTakerAnswer>()
               .HasOne(x => x.FreeTextQuestion)
               .WithMany(y => y.FreeTextQuestionTestTakerAnswers);

            builder.Entity<MultipleChoiceQuestionTestTakerAnswer>()
               .HasOne(x => x.MultipleChoiceQuestion)
               .WithMany(y => y.MultipleChoiceQuestionTestTakerAnswers);

            builder.Entity<AssesmentAssignment>()
               .HasMany(a => a.CodingQuestionsTestTakerAnswers)
               .WithOne(c => c.AssesmentAssignment);

            builder.Entity<AssesmentAssignment>()
               .HasMany(a => a.FreeTextQuestionTestTakerAnswers)
               .WithOne(f => f.AssesmentAssignment);

            builder.Entity<AssesmentAssignment>()
               .HasMany(a => a.MultipleChoiceQuestionTestTakerAnswers)
               .WithOne(m => m.AssesmentAssignment);

        }

    }
}
