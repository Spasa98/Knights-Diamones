﻿// <auto-generated />
using System;
using DAL.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(KnightsAndDiamondsContext))]
    partial class KnightsAndDiamondsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DAL.Models.AttackInTurn", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("CardFieldID")
                        .HasColumnType("int");

                    b.Property<bool>("IsAttackingAbble")
                        .HasColumnType("bit");

                    b.Property<int>("TurnID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CardFieldID");

                    b.HasIndex("TurnID");

                    b.ToTable("AttackInTurns", (string)null);
                });

            modelBuilder.Entity("DAL.Models.Card", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("CardName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CardTypeID")
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EffectID")
                        .HasColumnType("int");

                    b.Property<string>("ImgPath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CardTypeID");

                    b.HasIndex("EffectID");

                    b.ToTable("Cards", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("Card");
                });

            modelBuilder.Entity("DAL.Models.CardField", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("CardOnFieldID")
                        .HasColumnType("int");

                    b.Property<bool>("CardPosition")
                        .HasColumnType("bit");

                    b.Property<bool>("CardShowen")
                        .HasColumnType("bit");

                    b.Property<int>("FieldIndex")
                        .HasColumnType("int");

                    b.Property<string>("FieldType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlayerID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CardOnFieldID");

                    b.HasIndex("PlayerID");

                    b.ToTable("CardFields", (string)null);
                });

            modelBuilder.Entity("DAL.Models.CardInDeck", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("CardID")
                        .HasColumnType("int");

                    b.Property<int>("DeckID")
                        .HasColumnType("int");

                    b.Property<int?>("GraveID")
                        .HasColumnType("int");

                    b.Property<int?>("PlayerID")
                        .HasColumnType("int");

                    b.Property<int?>("PlayersHandID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CardID");

                    b.HasIndex("DeckID");

                    b.HasIndex("GraveID");

                    b.HasIndex("PlayerID");

                    b.HasIndex("PlayersHandID");

                    b.ToTable("CardInDecks", (string)null);
                });

            modelBuilder.Entity("DAL.Models.CardType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("ImgPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("CardTypes", (string)null);
                });

            modelBuilder.Entity("DAL.Models.Deck", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Decks", (string)null);
                });

            modelBuilder.Entity("DAL.Models.Effect", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EffectTypeID")
                        .HasColumnType("int");

                    b.Property<int?>("NumOfCardsAffected")
                        .HasColumnType("int");

                    b.Property<int?>("PointsAddedLost")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("EffectTypeID");

                    b.ToTable("Effects", (string)null);
                });

            modelBuilder.Entity("DAL.Models.EffectType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("EffectTypes", (string)null);
                });

            modelBuilder.Entity("DAL.Models.Game", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("GraveID")
                        .HasColumnType("int");

                    b.Property<int>("Loser")
                        .HasColumnType("int");

                    b.Property<int>("PlayerOnTurn")
                        .HasColumnType("int");

                    b.Property<int>("TurnNumber")
                        .HasColumnType("int");

                    b.Property<int>("Winner")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("GraveID");

                    b.ToTable("Games", (string)null);
                });

            modelBuilder.Entity("DAL.Models.Grave", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.HasKey("ID");

                    b.ToTable("Graves", (string)null);
                });

            modelBuilder.Entity("DAL.Models.Player", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<bool>("GaemeStarted")
                        .HasColumnType("bit");

                    b.Property<int>("GameID")
                        .HasColumnType("int");

                    b.Property<int?>("HandID")
                        .HasColumnType("int");

                    b.Property<int>("LifePoints")
                        .HasColumnType("int");

                    b.Property<int?>("Play")
                        .HasColumnType("int");

                    b.Property<int>("RPSGameID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("GameID");

                    b.HasIndex("HandID");

                    b.HasIndex("RPSGameID");

                    b.HasIndex("UserID");

                    b.ToTable("Players", (string)null);
                });

            modelBuilder.Entity("DAL.Models.PlayersHand", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.HasKey("ID");

                    b.ToTable("PlayerHands", (string)null);
                });

            modelBuilder.Entity("DAL.Models.RockPaperScissorsGame", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("Winner")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("RockPaperScissorsGames", (string)null);
                });

            modelBuilder.Entity("DAL.Models.Turn", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<bool>("BattlePhase")
                        .HasColumnType("bit");

                    b.Property<bool>("DrawPhase")
                        .HasColumnType("bit");

                    b.Property<bool>("EndPhase")
                        .HasColumnType("bit");

                    b.Property<int?>("GameID")
                        .HasColumnType("int");

                    b.Property<bool>("MainPhase")
                        .HasColumnType("bit");

                    b.Property<bool>("MonsterSummoned")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("GameID");

                    b.ToTable("Turns", (string)null);
                });

            modelBuilder.Entity("DAL.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MainDeckID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SurName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("DAL.Models.MonsterCard", b =>
                {
                    b.HasBaseType("DAL.Models.Card");

                    b.Property<int>("AttackPoints")
                        .HasColumnType("int");

                    b.Property<int>("DefencePoints")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfStars")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("MonsterCard");
                });

            modelBuilder.Entity("DAL.Models.AttackInTurn", b =>
                {
                    b.HasOne("DAL.Models.CardField", "CardField")
                        .WithMany("AttackInTurn")
                        .HasForeignKey("CardFieldID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.Turn", "Turn")
                        .WithMany("AttackInTurn")
                        .HasForeignKey("TurnID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CardField");

                    b.Navigation("Turn");
                });

            modelBuilder.Entity("DAL.Models.Card", b =>
                {
                    b.HasOne("DAL.Models.CardType", "CardType")
                        .WithMany("Cards")
                        .HasForeignKey("CardTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.Effect", "Effect")
                        .WithMany("Cards")
                        .HasForeignKey("EffectID");

                    b.Navigation("CardType");

                    b.Navigation("Effect");
                });

            modelBuilder.Entity("DAL.Models.CardField", b =>
                {
                    b.HasOne("DAL.Models.CardInDeck", "CardOnField")
                        .WithMany("CardFields")
                        .HasForeignKey("CardOnFieldID");

                    b.HasOne("DAL.Models.Player", "Player")
                        .WithMany("Fields")
                        .HasForeignKey("PlayerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CardOnField");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("DAL.Models.CardInDeck", b =>
                {
                    b.HasOne("DAL.Models.Card", "Card")
                        .WithMany("CardInDecks")
                        .HasForeignKey("CardID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.Deck", "Deck")
                        .WithMany("CardsInDeck")
                        .HasForeignKey("DeckID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.Grave", "Grave")
                        .WithMany("ListOfCardsInGrave")
                        .HasForeignKey("GraveID");

                    b.HasOne("DAL.Models.Player", "Player")
                        .WithMany("Deck")
                        .HasForeignKey("PlayerID");

                    b.HasOne("DAL.Models.PlayersHand", "PlayersHand")
                        .WithMany("CardsInHand")
                        .HasForeignKey("PlayersHandID");

                    b.Navigation("Card");

                    b.Navigation("Deck");

                    b.Navigation("Grave");

                    b.Navigation("Player");

                    b.Navigation("PlayersHand");
                });

            modelBuilder.Entity("DAL.Models.Deck", b =>
                {
                    b.HasOne("DAL.Models.User", "User")
                        .WithMany("Decks")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Models.Effect", b =>
                {
                    b.HasOne("DAL.Models.EffectType", "EffectType")
                        .WithMany()
                        .HasForeignKey("EffectTypeID");

                    b.Navigation("EffectType");
                });

            modelBuilder.Entity("DAL.Models.Game", b =>
                {
                    b.HasOne("DAL.Models.Grave", "Grave")
                        .WithMany()
                        .HasForeignKey("GraveID");

                    b.Navigation("Grave");
                });

            modelBuilder.Entity("DAL.Models.Player", b =>
                {
                    b.HasOne("DAL.Models.Game", "Game")
                        .WithMany("Players")
                        .HasForeignKey("GameID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.PlayersHand", "Hand")
                        .WithMany()
                        .HasForeignKey("HandID");

                    b.HasOne("DAL.Models.RockPaperScissorsGame", "RPSGame")
                        .WithMany("Players")
                        .HasForeignKey("RPSGameID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Hand");

                    b.Navigation("RPSGame");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Models.Turn", b =>
                {
                    b.HasOne("DAL.Models.Game", "Game")
                        .WithMany("Turns")
                        .HasForeignKey("GameID");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("DAL.Models.Card", b =>
                {
                    b.Navigation("CardInDecks");
                });

            modelBuilder.Entity("DAL.Models.CardField", b =>
                {
                    b.Navigation("AttackInTurn");
                });

            modelBuilder.Entity("DAL.Models.CardInDeck", b =>
                {
                    b.Navigation("CardFields");
                });

            modelBuilder.Entity("DAL.Models.CardType", b =>
                {
                    b.Navigation("Cards");
                });

            modelBuilder.Entity("DAL.Models.Deck", b =>
                {
                    b.Navigation("CardsInDeck");
                });

            modelBuilder.Entity("DAL.Models.Effect", b =>
                {
                    b.Navigation("Cards");
                });

            modelBuilder.Entity("DAL.Models.Game", b =>
                {
                    b.Navigation("Players");

                    b.Navigation("Turns");
                });

            modelBuilder.Entity("DAL.Models.Grave", b =>
                {
                    b.Navigation("ListOfCardsInGrave");
                });

            modelBuilder.Entity("DAL.Models.Player", b =>
                {
                    b.Navigation("Deck");

                    b.Navigation("Fields");
                });

            modelBuilder.Entity("DAL.Models.PlayersHand", b =>
                {
                    b.Navigation("CardsInHand");
                });

            modelBuilder.Entity("DAL.Models.RockPaperScissorsGame", b =>
                {
                    b.Navigation("Players");
                });

            modelBuilder.Entity("DAL.Models.Turn", b =>
                {
                    b.Navigation("AttackInTurn");
                });

            modelBuilder.Entity("DAL.Models.User", b =>
                {
                    b.Navigation("Decks");
                });
#pragma warning restore 612, 618
        }
    }
}
