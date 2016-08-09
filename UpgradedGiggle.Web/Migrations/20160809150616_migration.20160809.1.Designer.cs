using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using UpgradedGiggle.Context;

namespace UpgradedGiggle.Web.Migrations
{
    [DbContext(typeof(StatsContext))]
    [Migration("20160809150616_migration.20160809.1")]
    partial class migration201608091
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("UpgradedGiggle.Context.UserStats", b =>
                {
                    b.Property<int>("UserStatsId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nick");

                    b.Property<int>("NumberOfLines");

                    b.HasKey("UserStatsId");

                    b.ToTable("UserStats");
                });
        }
    }
}
