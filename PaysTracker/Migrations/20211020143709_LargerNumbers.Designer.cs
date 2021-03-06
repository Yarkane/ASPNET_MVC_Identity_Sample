// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PaysTracker.Data;

namespace PaysTracker.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20211020143709_LargerNumbers")]
    partial class LargerNumbers
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PaysTracker.Models.Pays", b =>
                {
                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Dirigeant")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Population")
                        .HasColumnType("float");

                    b.Property<int>("RegimeId")
                        .HasColumnType("int");

                    b.Property<double>("Surface")
                        .HasColumnType("float");

                    b.HasKey("Nom");

                    b.HasIndex("RegimeId");

                    b.ToTable("ListePays");
                });

            modelBuilder.Entity("PaysTracker.Models.Regime", b =>
                {
                    b.Property<int>("RegimeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RegimeId");

                    b.ToTable("ListeRegimes");
                });

            modelBuilder.Entity("PaysTracker.Models.Pays", b =>
                {
                    b.HasOne("PaysTracker.Models.Regime", "Regime")
                        .WithMany("ListePays")
                        .HasForeignKey("RegimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Regime");
                });

            modelBuilder.Entity("PaysTracker.Models.Regime", b =>
                {
                    b.Navigation("ListePays");
                });
#pragma warning restore 612, 618
        }
    }
}
