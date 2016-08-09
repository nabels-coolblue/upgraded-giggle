using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using UpgradedGiggle.Context;

namespace UpgradedGiggle.Web.Migrations
{
    [DbContext(typeof(StatsContext))]
    partial class StatsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
