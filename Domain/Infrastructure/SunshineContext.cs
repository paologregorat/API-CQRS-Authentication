using Microsoft.EntityFrameworkCore;
using WebAPI_CQRS.Domain.Entity;

namespace WebAPI_CQRS.Domain.Infrastructure
{
    public class SunshineContext : DbContext
    {
        public SunshineContext(DbContextOptions<SunshineContext> options) : base(options)
        {
        }
        
        public virtual DbSet<Utente> Utenti { get; set; } = null!;
        public virtual DbSet<Corso> Corsi { get; set; } = null!;
        public virtual DbSet<Operatore> Operatori { get; set; } = null!;
        public virtual DbSet<Personale> Personale { get; set; } = null!;
        public virtual DbSet<TipoCorso> TipiCorsi { get; set; } = null!;
        public virtual DbSet<Struttura> Strutture { get; set; } = null!;
        public virtual DbSet<TipoMovimento> TipiMovimenti { get; set; } = null!;
        public virtual DbSet<Movimento> Movimenti { get; set; } = null!;
        public virtual DbSet<UtenteCorso> UtentiCorsi { get; set; } = null!;
        public virtual DbSet<CalendarioCorso> CalendariCorsi { get; set; } = null!;
        public virtual DbSet<UtenteCalendarioCorso> UtentiCalendariCorsi { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Utente>(entity =>
            {
                entity.ToTable("Utenti");

                entity.HasKey(e => e.ID);
                entity.Property(e => e.ID).ValueGeneratedNever();
            });
                
            modelBuilder.Entity<Corso>(entity =>
            {
                entity.ToTable("Corsi");

                entity.HasKey(e => e.ID);
                entity.Property(e => e.ID).ValueGeneratedNever();
                
                entity.HasOne(d => d.TipoCorso)
                    .WithMany(p => p!.Corsi)
                    .HasForeignKey(d => d.TipoCorsoID)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("corso_tipocorso_id_fk");
            });
            
            modelBuilder.Entity<Operatore>(entity =>
            {
                entity.ToTable("Operatori");

                entity.HasKey(e => e.ID);
                entity.Property(e => e.ID).ValueGeneratedNever();
            });
            
            modelBuilder.Entity<Personale>(entity =>
            {
                entity.ToTable("Personale");

                entity.HasKey(e => e.ID);
                entity.Property(e => e.ID).ValueGeneratedNever();
            });
            
            modelBuilder.Entity<TipoCorso>(entity =>
            {
                entity.ToTable("TipiCorsi");

                entity.HasKey(e => e.ID);
                entity.Property(e => e.ID).ValueGeneratedNever();
            });
            
            modelBuilder.Entity<Struttura>(entity =>
            {
                entity.ToTable("Strutture");

                entity.HasKey(e => e.ID);
                entity.Property(e => e.ID).ValueGeneratedNever();
            });
            
            modelBuilder.Entity<TipoMovimento>(entity =>
            {
                entity.ToTable("TipiMovimenti");

                entity.HasKey(e => e.ID);
                entity.Property(e => e.ID).ValueGeneratedNever();
            });
            
            modelBuilder.Entity<Movimento>(entity =>
            {
                entity.ToTable("Movimenti");

                entity.HasKey(e => e.ID);
                entity.Property(e => e.ID).ValueGeneratedNever();
                
                entity.HasOne(d => d.TipoMovimento)
                    .WithMany(p => p!.Movimenti)
                    .HasForeignKey(d => d.TipoMovimentoID)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("movimento_tipomovimento_id_fk");
                
                entity.HasOne(d => d.Utente)
                    .WithMany(p => p!.Movimenti)
                    .HasForeignKey(d => d.UtenteID)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("movimento_utente_id_fk");
                
                entity.HasOne(d => d.Personale)
                    .WithMany(p => p!.Movimenti)
                    .HasForeignKey(d => d.PersonaleID)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("movimento_personale_id_fk");
            });
            
            modelBuilder.Entity<UtenteCorso>(entity =>
            {
                entity.ToTable("Utenti_Corsi");

                entity.HasKey(e => e.ID);
                entity.Property(e => e.ID).ValueGeneratedNever();
                
                entity.HasOne(d => d.Utente)
                    .WithMany(p => p!.UtenteCorsi)
                    .HasForeignKey(d => d.UtenteID)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("utentecorso_utente_id_fk");
                
                entity.HasOne(d => d.Corso)
                    .WithMany(p => p!.UtentiCorso)
                    .HasForeignKey(d => d.CorsoID)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("utentecorso_corso_id_fk");
            });
            
            modelBuilder.Entity<CalendarioCorso>(entity =>
            {
                entity.ToTable("CalendariCorsi");

                entity.HasKey(e => e.ID);
                entity.Property(e => e.ID).ValueGeneratedNever();
                
                entity.HasOne(d => d.Personale)
                    .WithMany(p => p!.CalendariCorsi)
                    .HasForeignKey(d => d.PersonaleID)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("calendariocorso_personale_id_fk");
                
                entity.HasOne(d => d.Corso)
                    .WithMany(p => p!.CalendarioCorso)
                    .HasForeignKey(d => d.CorsoID)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("calendariocorso_corso_id_fk");
                
                entity.HasOne(d => d.Struttura)
                    .WithMany(p => p!.CalendariCorsi)
                    .HasForeignKey(d => d.StrutturaID)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("calendariocorso_struttura_id_fk");
            });
            
            modelBuilder.Entity<UtenteCalendarioCorso>(entity =>
            {
                entity.ToTable("Utenti_CalendariCorsi");

                entity.HasKey(e => e.ID);
                entity.Property(e => e.ID).ValueGeneratedNever();
                
                entity.HasOne(d => d.Utente)
                    .WithMany(p => p!.UtenteCalendariCorsi)
                    .HasForeignKey(d => d.UtenteID)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("utentcalendarioecorso_utente_id_fk");
                
                entity.HasOne(d => d.CalendarioCorso)
                    .WithMany(p => p!.UtentiCalendarioCorso)
                    .HasForeignKey(d => d.CalendarioCorsoID)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("utentecalendariocorso_corso_id_fk");
            });
        }
    }
}