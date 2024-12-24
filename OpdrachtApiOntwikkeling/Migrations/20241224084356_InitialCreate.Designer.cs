﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OpdrachtApiOntwikkeling.Data;

#nullable disable

namespace OpdrachtApiOntwikkeling.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241224084356_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OpdrachtApiOntwikkeling.Models.Boss", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CombatLevel")
                        .HasColumnType("int")
                        .HasColumnName("combat_level");

                    b.Property<int?>("Hitpoints")
                        .HasColumnType("int")
                        .HasColumnName("hitpoints");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("image");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.Property<int?>("UniqueItemId")
                        .HasColumnType("int")
                        .HasColumnName("unique_item_id");

                    b.HasKey("Id");

                    b.HasIndex("UniqueItemId")
                        .IsUnique()
                        .HasFilter("[unique_item_id] IS NOT NULL");

                    b.ToTable("Bosses", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CombatLevel = 725,
                            Hitpoints = 500,
                            Image = "https://oldschool.runescape.wiki/images/Zulrah_%28serpentine%29.png?29a54",
                            Name = "Zulrah",
                            UniqueItemId = 1
                        },
                        new
                        {
                            Id = 2,
                            CombatLevel = 732,
                            Hitpoints = 750,
                            Image = "https://oldschool.runescape.wiki/images/Vorkath.png?1ce3f",
                            Name = "Vorkath",
                            UniqueItemId = 2
                        },
                        new
                        {
                            Id = 3,
                            CombatLevel = 291,
                            Hitpoints = 255,
                            Image = "https://oldschool.runescape.wiki/images/Cave_kraken.png?4612a",
                            Name = "Kraken",
                            UniqueItemId = 3
                        },
                        new
                        {
                            Id = 4,
                            CombatLevel = 624,
                            Hitpoints = 255,
                            Image = "https://oldschool.runescape.wiki/images/General_Graardor.png?4dd90",
                            Name = "General Graardor",
                            UniqueItemId = 4
                        },
                        new
                        {
                            Id = 5,
                            CombatLevel = 318,
                            Hitpoints = 650,
                            Image = "https://oldschool.runescape.wiki/images/Cerberus.png?47f4c",
                            Name = "Cerberus",
                            UniqueItemId = 5
                        },
                        new
                        {
                            Id = 6,
                            CombatLevel = 303,
                            Hitpoints = 255,
                            Image = "https://oldschool.runescape.wiki/images/Dagannoth_Rex.png?a99a9",
                            Name = "Dagannoth Rex",
                            UniqueItemId = 6
                        },
                        new
                        {
                            Id = 7,
                            CombatLevel = 890,
                            Hitpoints = 1020,
                            Image = "https://oldschool.runescape.wiki/images/Araxxor.png?35d2e",
                            Name = "Araxxor",
                            UniqueItemId = 7
                        },
                        new
                        {
                            Id = 8,
                            CombatLevel = 1136,
                            Hitpoints = 1400,
                            Image = "https://oldschool.runescape.wiki/images/Vardorvis.png?48af8",
                            Name = "Vardorvis",
                            UniqueItemId = 8
                        },
                        new
                        {
                            Id = 9,
                            CombatLevel = 1157,
                            Hitpoints = 2700,
                            Image = "https://oldschool.runescape.wiki/images/The_Leviathan.png?d588a",
                            Name = "The Leviathan",
                            UniqueItemId = 9
                        },
                        new
                        {
                            Id = 10,
                            CombatLevel = 276,
                            Hitpoints = 255,
                            Image = "https://oldschool.runescape.wiki/images/King_Black_Dragon.png?d25f0",
                            Name = "King Black Dragon",
                            UniqueItemId = 10
                        });
                });

            modelBuilder.Entity("OpdrachtApiOntwikkeling.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BossId")
                        .HasColumnType("int")
                        .HasColumnName("boss_id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("image");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("BossId")
                        .IsUnique()
                        .HasFilter("[boss_id] IS NOT NULL");

                    b.ToTable("Locations", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BossId = 1,
                            Description = "A remote island known for its unique teleportation methods and fishing spots.",
                            Image = "https://oldschool.runescape.wiki/images/Zul-Andra.png?bc8fb",
                            Name = "Zul-Andra"
                        },
                        new
                        {
                            Id = 2,
                            BossId = 2,
                            Description = "The lair of Vorkath, a powerful dragon found in the Wilderness.",
                            Image = "https://oldschool.runescape.wiki/images/Ungael.png?2e330",
                            Name = "Ungael"
                        },
                        new
                        {
                            Id = 3,
                            BossId = 3,
                            Description = "A hidden cove where the Kraken resides, known for its treasure.",
                            Image = "https://oldschool.runescape.wiki/images/Kraken_Cove.png?3be60",
                            Name = "Kraken Cove"
                        },
                        new
                        {
                            Id = 4,
                            BossId = 4,
                            Description = "A battleground for gods, featuring powerful bosses and their minions.",
                            Image = "https://oldschool.runescape.wiki/images/God_Wars_Dungeon_Entrance.png?8b0f5",
                            Name = "God Wars Dungeon"
                        },
                        new
                        {
                            Id = 5,
                            BossId = 5,
                            Description = "A hellish cave home to Cerberus, guarded by hellhounds.",
                            Image = "https://oldschool.runescape.wiki/images/Cerberus%27_Lair.png?75520",
                            Name = "Cerberus' Lair"
                        },
                        new
                        {
                            Id = 6,
                            BossId = 6,
                            Description = "An underwater dungeon filled with fearsome creatures and guarded by Dagannoth kings.",
                            Image = "https://oldschool.runescape.wiki/images/Waterbirth_Island_Dungeon_1.png?c9813",
                            Name = "Waterbirth Island Dungeon"
                        },
                        new
                        {
                            Id = 7,
                            BossId = 7,
                            Description = "A cave filled with dangerous spiders in the Morytania region.",
                            Image = "https://oldschool.runescape.wiki/images/Morytania_Spider_Cave.png?74d5c",
                            Name = "Morytania Spider Cave"
                        },
                        new
                        {
                            Id = 8,
                            BossId = 8,
                            Description = "A thick forest known for its dangerous creatures and resources.",
                            Image = "https://oldschool.runescape.wiki/images/The_Stranglewood.png?d5f29",
                            Name = "The Stranglewood"
                        },
                        new
                        {
                            Id = 9,
                            BossId = 9,
                            Description = "The home of the gnomes, located in the Tree Gnome Stronghold.",
                            Image = "https://oldschool.runescape.wiki/images/The_Scar.png?61378",
                            Name = "The Scar"
                        },
                        new
                        {
                            Id = 10,
                            BossId = 10,
                            Description = "A lair deep in the wilderness, home to the King Black Dragon.",
                            Image = "https://oldschool.runescape.wiki/images/KBD_Lair_%28interior%29.png?35aa6",
                            Name = "King Black Dragon Lair"
                        });
                });

            modelBuilder.Entity("OpdrachtApiOntwikkeling.Models.UniqueItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("HighAlch")
                        .HasColumnType("int")
                        .HasColumnName("high_alch");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("image");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("name");

                    b.Property<int?>("Price")
                        .HasColumnType("int")
                        .HasColumnName("price");

                    b.HasKey("Id");

                    b.ToTable("UniqueItems", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            HighAlch = 66000,
                            Image = "https://oldschool.runescape.wiki/images/Tanzanite_fang_detail.png?859ba",
                            Name = "Tanzanite fang",
                            Price = 5784502
                        },
                        new
                        {
                            Id = 2,
                            HighAlch = 900000,
                            Image = "https://oldschool.runescape.wiki/images/Skeletal_visage_detail.png?bccc7",
                            Name = "Skeletal visage",
                            Price = 13440000
                        },
                        new
                        {
                            Id = 3,
                            HighAlch = 50004,
                            Image = "https://oldschool.runescape.wiki/images/Kraken_tentacle_detail.png?e5f2a",
                            Name = "Kraken tentacle",
                            Price = 561782
                        },
                        new
                        {
                            Id = 4,
                            HighAlch = 174006,
                            Image = "https://oldschool.runescape.wiki/images/Bandos_chestplate_detail.png?98028",
                            Name = "Bandos chestplate",
                            Price = 28918892
                        },
                        new
                        {
                            Id = 5,
                            HighAlch = 27000,
                            Image = "https://oldschool.runescape.wiki/images/Primordial_crystal_detail.png?9c62f",
                            Name = "Primordial crystal",
                            Price = 24435004
                        },
                        new
                        {
                            Id = 6,
                            HighAlch = 6000,
                            Image = "https://oldschool.runescape.wiki/images/Berserker_ring_detail.png?81f8b",
                            Name = "Berserker ring",
                            Price = 4460382
                        },
                        new
                        {
                            Id = 7,
                            HighAlch = 120000,
                            Image = "https://oldschool.runescape.wiki/images/Araxyte_fang_detail.png?43deb",
                            Name = "Araxyte fang",
                            Price = 70399444
                        },
                        new
                        {
                            Id = 8,
                            HighAlch = 30000,
                            Image = "https://oldschool.runescape.wiki/images/Executioner%27s_axe_head_detail.png?b410d",
                            Name = "Executioner's axe head",
                            Price = 370436553
                        },
                        new
                        {
                            Id = 9,
                            HighAlch = 360000,
                            Image = "https://oldschool.runescape.wiki/images/Virtus_robe_top_detail.png?b2b4a",
                            Name = "Virtus robe top",
                            Price = 66788559
                        },
                        new
                        {
                            Id = 10,
                            HighAlch = 450000,
                            Image = "https://oldschool.runescape.wiki/images/Draconic_visage_detail.png?6edab",
                            Name = "Draconic visage",
                            Price = 4054769
                        });
                });

            modelBuilder.Entity("OpdrachtApiOntwikkeling.Models.Boss", b =>
                {
                    b.HasOne("OpdrachtApiOntwikkeling.Models.UniqueItem", "UniqueItem")
                        .WithOne()
                        .HasForeignKey("OpdrachtApiOntwikkeling.Models.Boss", "UniqueItemId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("UniqueItem");
                });

            modelBuilder.Entity("OpdrachtApiOntwikkeling.Models.Location", b =>
                {
                    b.HasOne("OpdrachtApiOntwikkeling.Models.Boss", "Boss")
                        .WithOne()
                        .HasForeignKey("OpdrachtApiOntwikkeling.Models.Location", "BossId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Boss");
                });
#pragma warning restore 612, 618
        }
    }
}