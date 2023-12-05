﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MusicLibrary.Models;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MusicLibrary.Migrations
{
    [DbContext(typeof(MusicLibraryContext))]
    [Migration("20231130071336_DropAlbumId")]
    partial class DropAlbumId
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MusicLibrary.Models.Album", b =>
                {
                    b.Property<int>("ArtistId")
                        .HasColumnType("integer")
                        .HasColumnName("artist_id");

                    b.Property<string>("AName")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("a_name");

                    b.Property<string>("AGenre")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("a_genre");

                    b.Property<string>("ALength")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("a_length");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("label");

                    b.Property<int>("Numofsongs")
                        .HasColumnType("integer")
                        .HasColumnName("numofsongs");

                    b.Property<int>("Year")
                        .HasColumnType("integer")
                        .HasColumnName("year");

                    b.HasKey("ArtistId", "AName");

                    b.HasIndex(new[] { "AName" }, "unique_a_name")
                        .IsUnique();

                    b.ToTable("album", (string)null);
                });

            modelBuilder.Entity("MusicLibrary.Models.Artist", b =>
                {
                    b.Property<int>("ArtistId")
                        .HasColumnType("integer")
                        .HasColumnName("artist_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("name");

                    b.HasKey("ArtistId")
                        .HasName("artist_pkey");

                    b.HasIndex(new[] { "Name" }, "unique_artist_name")
                        .IsUnique();

                    b.ToTable("artist", (string)null);
                });

            modelBuilder.Entity("MusicLibrary.Models.Follow", b =>
                {
                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("name");

                    b.HasIndex("Email");

                    b.HasIndex("Name");

                    b.ToTable("follow", (string)null);
                });

            modelBuilder.Entity("MusicLibrary.Models.Playlist", b =>
                {
                    b.Property<int>("PlaylistId")
                        .HasColumnType("integer")
                        .HasColumnName("playlist_id");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("name");

                    b.Property<int?>("Numofsongs")
                        .HasColumnType("integer")
                        .HasColumnName("numofsongs");

                    b.Property<int?>("PLength")
                        .HasColumnType("integer")
                        .HasColumnName("p_length");

                    b.HasKey("PlaylistId")
                        .HasName("playlist_pkey");

                    b.HasIndex("Email");

                    b.HasIndex(new[] { "PlaylistId" }, "unique_playlist_id")
                        .IsUnique();

                    b.ToTable("playlist", (string)null);
                });

            modelBuilder.Entity("MusicLibrary.Models.Song", b =>
                {
                    b.Property<string>("AName")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("a_name");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("name");

                    b.Property<int?>("ArtistId")
                        .HasColumnType("integer")
                        .HasColumnName("artist_id");

                    b.Property<string>("FeaturedArtists")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("featured_artists");

                    b.Property<string>("Genre")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("genre");

                    b.Property<int?>("Length")
                        .HasColumnType("integer")
                        .HasColumnName("length");

                    b.HasKey("AName", "Name")
                        .HasName("song_pkey");

                    b.HasIndex(new[] { "Name" }, "unique_song_name")
                        .IsUnique();

                    b.ToTable("song", (string)null);
                });

            modelBuilder.Entity("MusicLibrary.Models.SongPlaylist", b =>
                {
                    b.Property<int?>("PlaylistId")
                        .HasColumnType("integer")
                        .HasColumnName("playlist_id");

                    b.Property<string>("SongName")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("song_name");

                    b.HasIndex("PlaylistId");

                    b.HasIndex("SongName");

                    b.ToTable("song_playlist", (string)null);
                });

            modelBuilder.Entity("MusicLibrary.Models.User", b =>
                {
                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("password");

                    b.HasKey("Email")
                        .HasName("user_pkey");

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("MusicLibrary.Models.Follow", b =>
                {
                    b.HasOne("MusicLibrary.Models.User", "EmailNavigation")
                        .WithMany()
                        .HasForeignKey("Email")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("follow_email_fkey");

                    b.HasOne("MusicLibrary.Models.Artist", "NameNavigation")
                        .WithMany()
                        .HasForeignKey("Name")
                        .HasPrincipalKey("Name")
                        .HasConstraintName("follow_name_fkey");

                    b.Navigation("EmailNavigation");

                    b.Navigation("NameNavigation");
                });

            modelBuilder.Entity("MusicLibrary.Models.Playlist", b =>
                {
                    b.HasOne("MusicLibrary.Models.User", "EmailNavigation")
                        .WithMany("Playlists")
                        .HasForeignKey("Email")
                        .HasConstraintName("playlist_email_fkey");

                    b.Navigation("EmailNavigation");
                });

            modelBuilder.Entity("MusicLibrary.Models.SongPlaylist", b =>
                {
                    b.HasOne("MusicLibrary.Models.Playlist", "Playlist")
                        .WithMany()
                        .HasForeignKey("PlaylistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("song_playlist_playlist_id_fkey");

                    b.HasOne("MusicLibrary.Models.Song", "SongNameNavigation")
                        .WithMany()
                        .HasForeignKey("SongName")
                        .HasPrincipalKey("Name")
                        .HasConstraintName("song_playlist_song_name_fkey");

                    b.Navigation("Playlist");

                    b.Navigation("SongNameNavigation");
                });

            modelBuilder.Entity("MusicLibrary.Models.User", b =>
                {
                    b.Navigation("Playlists");
                });
#pragma warning restore 612, 618
        }
    }
}