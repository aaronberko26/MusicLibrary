using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MusicLibrary.Models;

public partial class MusicLibraryContext : DbContext
{
    public MusicLibraryContext()
    {
    }

    public MusicLibraryContext(DbContextOptions<MusicLibraryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Album> Albums { get; set; }

    public virtual DbSet<Artist> Artists { get; set; }

    public virtual DbSet<Follow> Follows { get; set; }

    public virtual DbSet<Playlist> Playlists { get; set; }

    public virtual DbSet<Song> Songs { get; set; }

    public virtual DbSet<SongPlaylist> SongPlaylists { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=MusicLibrary;Username=postgres;Password=coosavecA10!");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Album>(entity =>
        {
            

            entity.ToTable("album");
            entity.HasKey(a => new { a.ArtistId, a.AName });

            entity.HasIndex(e => e.AName, "unique_a_name").IsUnique();
            
            entity.Property(e => e.AGenre)
                .HasMaxLength(255)
                .HasColumnName("a_genre");
            entity.Property(e => e.ALength).HasColumnName("a_length");
            entity.Property(e => e.AName)
                .HasMaxLength(255)
                .HasColumnName("a_name");
            entity.Property(e => e.ArtistId).HasColumnName("artist_id");
            entity.Property(e => e.Label)
                .HasMaxLength(255)
                .HasColumnName("label");
            entity.Property(e => e.Numofsongs).HasColumnName("numofsongs");
            entity.Property(e => e.Year).HasColumnName("year");
        });

        modelBuilder.Entity<Artist>(entity =>
        {
            entity.HasKey(e => e.ArtistId).HasName("artist_pkey");

            entity.ToTable("artist");

            entity.HasIndex(e => e.Name, "unique_artist_name").IsUnique();

            entity.Property(e => e.ArtistId)
                .ValueGeneratedNever()
                .HasColumnName("artist_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Follow>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("follow");

            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");

            entity.HasOne(d => d.EmailNavigation).WithMany()
                .HasForeignKey(d => d.Email)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("follow_email_fkey");

            entity.HasOne(d => d.NameNavigation).WithMany()
                .HasPrincipalKey(p => p.Name)
                .HasForeignKey(d => d.Name)
                .HasConstraintName("follow_name_fkey");
        });

        modelBuilder.Entity<Playlist>(entity =>
        {
            entity.HasKey(e => e.PlaylistId).HasName("playlist_pkey");

            entity.ToTable("playlist");

            entity.HasIndex(e => e.PlaylistId, "unique_playlist_id").IsUnique();

            entity.Property(e => e.PlaylistId)
                .ValueGeneratedNever()
                .HasColumnName("playlist_id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Numofsongs).HasColumnName("numofsongs");
            entity.Property(e => e.PLength).HasColumnName("p_length");

            entity.HasOne(d => d.EmailNavigation).WithMany(p => p.Playlists)
                .HasForeignKey(d => d.Email)
                .HasConstraintName("playlist_email_fkey");
        });

        modelBuilder.Entity<Song>(entity =>
        {
            entity.HasKey(e => new { e.AName, e.Name }).HasName("song_pkey");

            entity.ToTable("song");

            entity.HasIndex(e => e.Name, "unique_song_name").IsUnique();

            entity.Property(e => e.AName)
                .HasMaxLength(255)
                .HasColumnName("a_name");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.ArtistId).HasColumnName("artist_id");
            entity.Property(e => e.FeaturedArtists)
                .HasMaxLength(255)
                .HasColumnName("featured_artists");
            entity.Property(e => e.Genre)
                .HasMaxLength(255)
                .HasColumnName("genre");
            entity.Property(e => e.Length).HasColumnName("length");
        });

        modelBuilder.Entity<SongPlaylist>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("song_playlist");

            entity.Property(e => e.PlaylistId).HasColumnName("playlist_id");
            entity.Property(e => e.SongName)
                .HasMaxLength(255)
                .HasColumnName("song_name");

            entity.HasOne(d => d.Playlist).WithMany()
                .HasForeignKey(d => d.PlaylistId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("song_playlist_playlist_id_fkey");

            entity.HasOne(d => d.SongNameNavigation).WithMany()
                .HasPrincipalKey(p => p.Name)
                .HasForeignKey(d => d.SongName)
                .HasConstraintName("song_playlist_song_name_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Email).HasName("user_pkey");

            entity.ToTable("user");

            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
