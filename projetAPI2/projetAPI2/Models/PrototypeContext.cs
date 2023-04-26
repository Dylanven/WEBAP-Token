using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace projetAPI2.Models;

public partial class PrototypeContext : DbContext
{
    public PrototypeContext()
    {
    }

    public PrototypeContext(DbContextOptions<PrototypeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<CategoryFavorite> CategoryFavorites { get; set; }

    public virtual DbSet<Connection> Connections { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Emoji> Emojis { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventRole> EventRoles { get; set; }

    public virtual DbSet<Forum> Forums { get; set; }

    public virtual DbSet<Invitation> Invitations { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Place> Places { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<StatesEvent> StatesEvents { get; set; }

    public virtual DbSet<StatesTask> StatesTasks { get; set; }

    public virtual DbSet<Survey> Surveys { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<UserAccount> UserAccounts { get; set; }

    public virtual DbSet<UserConnection> UserConnections { get; set; }

    public virtual DbSet<UserEvent> UserEvents { get; set; }

    public virtual DbSet<UserFavorite> UserFavorites { get; set; }

    public virtual DbSet<UserInvitation> UserInvitations { get; set; }

    public virtual DbSet<UserNotification> UserNotifications { get; set; }

    public virtual DbSet<UserPost> UserPosts { get; set; }

    public virtual DbSet<UserQuestion> UserQuestions { get; set; }

    public virtual DbSet<UserTask> UserTasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=Prototype;Trusted_Connection=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.ProviderKey).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.Name).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.IdCategory).HasName("PK__category__79D361B6EE739486");

            entity.ToTable("category");

            entity.Property(e => e.IdCategory).HasColumnName("idCategory");
            entity.Property(e => e.CatName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("catName");
        });

        modelBuilder.Entity<CategoryFavorite>(entity =>
        {
            entity.HasKey(e => new { e.IdCategory, e.IdUser }).HasName("PK__category__4AA21D2E0C9C56A3");

            entity.ToTable("category_favorite");

            entity.Property(e => e.IdCategory).HasColumnName("idCategory");
            entity.Property(e => e.IdUser).HasColumnName("idUser");
        });

        modelBuilder.Entity<Connection>(entity =>
        {
            entity.HasKey(e => e.IdConnection).HasName("PK__connecti__3066470962D4C623");

            entity.ToTable("connection");

            entity.Property(e => e.IdConnection).HasColumnName("idConnection");
            entity.Property(e => e.ConDate)
                .HasColumnType("date")
                .HasColumnName("conDate");
            entity.Property(e => e.ConToken)
                .HasMaxLength(255)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("conToken");
            entity.Property(e => e.IdUser).HasColumnName("idUser");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Connections)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__connectio__idUse__114A936A");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.IdCountry).HasName("PK__country__8536480926E28CA1");

            entity.ToTable("country");

            entity.HasIndex(e => e.CouCode, "UQ__country__BBF9E9CE02C203D9").IsUnique();

            entity.Property(e => e.IdCountry).HasColumnName("idCountry");
            entity.Property(e => e.CouCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("couCode");
            entity.Property(e => e.CouName)
                .HasMaxLength(80)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("couName");
        });

        modelBuilder.Entity<Emoji>(entity =>
        {
            entity.HasKey(e => e.IdEmojis).HasName("PK__emoji__D0839414A356F9AC");

            entity.ToTable("emoji");

            entity.Property(e => e.IdEmojis).HasColumnName("idEmojis");
            entity.Property(e => e.EmoImg)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("emoImg");
            entity.Property(e => e.EmoShortCut)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("emoShortCut");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.IdEvent).HasName("PK__event__B7EA7D76A32487F4");

            entity.ToTable("event");

            entity.Property(e => e.IdEvent).HasColumnName("idEvent");
            entity.Property(e => e.EveDescription)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("eveDescription");
            entity.Property(e => e.EveEndDate)
                .HasColumnType("date")
                .HasColumnName("eveEndDate");
            entity.Property(e => e.EveMaxParticipant).HasColumnName("eveMaxParticipant");
            entity.Property(e => e.EvePublic)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("evePublic");
            entity.Property(e => e.EveStartDate)
                .HasColumnType("date")
                .HasColumnName("eveStartDate");
            entity.Property(e => e.EveTitle)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("eveTitle");
            entity.Property(e => e.IdCountry).HasColumnName("idCountry");
            entity.Property(e => e.IdStatesEvent).HasColumnName("idStatesEvent");

            entity.HasOne(d => d.IdCountryNavigation).WithMany(p => p.Events)
                .HasForeignKey(d => d.IdCountry)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__event__idCountry__14270015");

            entity.HasOne(d => d.IdStatesEventNavigation).WithMany(p => p.Events)
                .HasForeignKey(d => d.IdStatesEvent)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__event__idStatesE__1332DBDC");

            entity.HasMany(d => d.IdCategories).WithMany(p => p.IdEvents)
                .UsingEntity<Dictionary<string, object>>(
                    "EventCategory",
                    r => r.HasOne<Category>().WithMany()
                        .HasForeignKey("IdCategory")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__event_cat__idCat__151B244E"),
                    l => l.HasOne<Event>().WithMany()
                        .HasForeignKey("IdEvent")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__event_cat__idEve__160F4887"),
                    j =>
                    {
                        j.HasKey("IdEvent", "IdCategory").HasName("PK__event_ca__C0774B6D32845BC0");
                        j.ToTable("event_category");
                        j.IndexerProperty<int>("IdEvent").HasColumnName("idEvent");
                        j.IndexerProperty<int>("IdCategory").HasColumnName("idCategory");
                    });
        });

        modelBuilder.Entity<EventRole>(entity =>
        {
            entity.HasKey(e => e.IdRole).HasName("PK__event_ro__E5045C54D9A6D2E3");

            entity.ToTable("event_role");

            entity.HasIndex(e => e.RolName, "UQ__event_ro__F39DC1F6EF9DB536").IsUnique();

            entity.Property(e => e.IdRole).HasColumnName("idRole");
            entity.Property(e => e.RolName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("rolName");
        });

        modelBuilder.Entity<Forum>(entity =>
        {
            entity.HasKey(e => e.IdForum).HasName("PK__forum__74618C427307D0B8");

            entity.ToTable("forum");

            entity.Property(e => e.IdForum).HasColumnName("idForum");
            entity.Property(e => e.ForVue).HasColumnName("forVue");
            entity.Property(e => e.IdEvent).HasColumnName("idEvent");

            entity.HasOne(d => d.IdEventNavigation).WithMany(p => p.Forums)
                .HasForeignKey(d => d.IdEvent)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__forum__idEvent__17F790F9");
        });

        modelBuilder.Entity<Invitation>(entity =>
        {
            entity.HasKey(e => e.IdInvitation).HasName("PK__invitati__CE65ED710AC12B89");

            entity.ToTable("invitation");

            entity.Property(e => e.IdInvitation).HasColumnName("idInvitation");
            entity.Property(e => e.IdEvent).HasColumnName("idEvent");
            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.InvCode)
                .HasMaxLength(255)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("invCode");
            entity.Property(e => e.InvIdUser).HasColumnName("Inv_idUser");

            entity.HasOne(d => d.IdEventNavigation).WithMany(p => p.Invitations)
                .HasForeignKey(d => d.IdEvent)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__invitatio__idEve__1AD3FDA4");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.InvitationIdUserNavigations)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__invitatio__idUse__18EBB532");

            entity.HasOne(d => d.InvIdUserNavigation).WithMany(p => p.InvitationInvIdUserNavigations)
                .HasForeignKey(d => d.InvIdUser)
                .HasConstraintName("FK__invitatio__Inv_i__19DFD96B");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.IdNotification).HasName("PK__notifica__22C0232168C58046");

            entity.ToTable("notification");

            entity.Property(e => e.IdNotification).HasColumnName("idNotification");
            entity.Property(e => e.NotMessage)
                .HasMaxLength(250)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("notMessage");
            entity.Property(e => e.NotTitle)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("notTitle");
        });

        modelBuilder.Entity<Place>(entity =>
        {
            entity.HasKey(e => e.IdPlace).HasName("PK__place__39B84B90309B4559");

            entity.ToTable("place");

            entity.Property(e => e.IdPlace).HasColumnName("idPlace");
            entity.Property(e => e.IdCountry).HasColumnName("idCountry");
            entity.Property(e => e.PlaAddress)
                .HasMaxLength(38)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("plaAddress");

            entity.HasOne(d => d.IdCountryNavigation).WithMany(p => p.Places)
                .HasForeignKey(d => d.IdCountry)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__place__idCountry__1BC821DD");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.IdPost).HasName("PK__post__BE0F4FD63232CEE2");

            entity.ToTable("post");

            entity.Property(e => e.IdPost).HasColumnName("idPost");
            entity.Property(e => e.IdForum).HasColumnName("idForum");
            entity.Property(e => e.MulitAnswer).HasColumnName("mulitAnswer");
            entity.Property(e => e.PosDate)
                .HasColumnType("date")
                .HasColumnName("posDate");
            entity.Property(e => e.PosMessage)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("posMessage");
            entity.Property(e => e.PosTitle)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("posTitle");

            entity.HasOne(d => d.IdForumNavigation).WithMany(p => p.Posts)
                .HasForeignKey(d => d.IdForum)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__post__idForum__1CBC4616");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.IdQuestion).HasName("PK__question__1196F46574C34B34");

            entity.ToTable("question");

            entity.Property(e => e.IdQuestion).HasColumnName("idQuestion");
            entity.Property(e => e.IdSurvey).HasColumnName("idSurvey");
            entity.Property(e => e.QueMessage)
                .HasMaxLength(255)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("queMessage");

            entity.HasOne(d => d.IdSurveyNavigation).WithMany(p => p.Questions)
                .HasForeignKey(d => d.IdSurvey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__question__idSurv__1DB06A4F");
        });

        modelBuilder.Entity<StatesEvent>(entity =>
        {
            entity.HasKey(e => e.IdStatesEvent).HasName("PK__statesEv__CE0B4F9B6782221C");

            entity.ToTable("statesEvent");

            entity.HasIndex(e => e.StaEvName, "UQ__statesEv__5DAF5BE614EC3414").IsUnique();

            entity.Property(e => e.IdStatesEvent).HasColumnName("idStatesEvent");
            entity.Property(e => e.StaEvName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("staEvName");
        });

        modelBuilder.Entity<StatesTask>(entity =>
        {
            entity.HasKey(e => e.IdStatesTask).HasName("PK__statesTa__5A163727362EB978");

            entity.ToTable("statesTask");

            entity.HasIndex(e => e.StaTaName, "UQ__statesTa__6CFBD88188269D95").IsUnique();

            entity.Property(e => e.IdStatesTask).HasColumnName("idStatesTask");
            entity.Property(e => e.StaTaName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("staTaName");
        });

        modelBuilder.Entity<Survey>(entity =>
        {
            entity.HasKey(e => e.IdSurvey).HasName("PK__survey__C10C8BC5470581E4");

            entity.ToTable("survey");

            entity.Property(e => e.IdSurvey).HasColumnName("idSurvey");
            entity.Property(e => e.IdEvent).HasColumnName("idEvent");
            entity.Property(e => e.SurMessage)
                .HasMaxLength(255)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("surMessage");
            entity.Property(e => e.SurMultipleAnswer)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("surMultipleAnswer");
            entity.Property(e => e.SurTitle)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("surTitle");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.IdTask).HasName("PK__task__C3E0F4DA42A3D86B");

            entity.ToTable("task");

            entity.Property(e => e.IdTask).HasColumnName("idTask");
            entity.Property(e => e.IdEvent).HasColumnName("idEvent");
            entity.Property(e => e.IdStatesTask).HasColumnName("idStatesTask");
            entity.Property(e => e.TasDescription)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("tasDescription");
            entity.Property(e => e.TasEndDate)
                .HasColumnType("date")
                .HasColumnName("tasEndDate");
            entity.Property(e => e.TasStartDate)
                .HasColumnType("date")
                .HasColumnName("tasStartDate");
            entity.Property(e => e.TasTitle)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("tasTitle");
        });

        modelBuilder.Entity<UserAccount>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__user_acc__3717C982A18D5D4B");

            entity.ToTable("user_account");

            entity.HasIndex(e => e.UseEmail, "UQ__user_acc__2C4DF4B5817917D8").IsUnique();

            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.IdCountry).HasColumnName("idCountry");
            entity.Property(e => e.IdRole).HasColumnName("idRole");
            entity.Property(e => e.UseAvatar)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("useAvatar");
            entity.Property(e => e.UseBirthDate)
                .HasColumnType("date")
                .HasColumnName("useBirthDate");
            entity.Property(e => e.UseEmail)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("useEmail");
            entity.Property(e => e.UseFirstName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("useFirstName");
            entity.Property(e => e.UseIsActive)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("useIsActive");
            entity.Property(e => e.UseLastName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("useLastName");
            entity.Property(e => e.UsePassword)
                .HasMaxLength(255)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("usePassword");
            entity.Property(e => e.UsePhone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("usePhone");
        });

        modelBuilder.Entity<UserConnection>(entity =>
        {
            entity.HasKey(e => new { e.IdUser, e.IdConnection }).HasName("PK__user_con__B411ADF28B5DA3C2");

            entity.ToTable("user_connection");

            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.IdConnection).HasColumnName("idConnection");
        });

        modelBuilder.Entity<UserEvent>(entity =>
        {
            entity.HasKey(e => new { e.IdUser, e.IdEvent, e.IdRole }).HasName("PK__user_eve__198C6A0978A3B9A5");

            entity.ToTable("user_event");

            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.IdEvent).HasColumnName("idEvent");
            entity.Property(e => e.IdRole).HasColumnName("idRole");
        });

        modelBuilder.Entity<UserFavorite>(entity =>
        {
            entity.HasKey(e => new { e.IdUser, e.IdEvent }).HasName("PK__user_fav__4C696E553F232DF2");

            entity.ToTable("user_favorite");

            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.IdEvent).HasColumnName("idEvent");
        });

        modelBuilder.Entity<UserInvitation>(entity =>
        {
            entity.HasKey(e => new { e.IdUser, e.IdInvitation }).HasName("PK__user_inv__3BF1975534D9287E");

            entity.ToTable("user_invitation");

            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.IdInvitation).HasColumnName("idInvitation");
        });

        modelBuilder.Entity<UserNotification>(entity =>
        {
            entity.HasKey(e => new { e.IdUser, e.IdNotification }).HasName("PK__user_not__353BCBB02E221D16");

            entity.ToTable("user_notification");

            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.IdNotification).HasColumnName("idNotification");
        });

        modelBuilder.Entity<UserPost>(entity =>
        {
            entity.HasKey(e => new { e.IdUser, e.IdPost }).HasName("PK__user_pos__4CF73D7F22EAE078");

            entity.ToTable("user_post");

            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.IdPost).HasColumnName("idPost");
        });

        modelBuilder.Entity<UserQuestion>(entity =>
        {
            entity.HasKey(e => new { e.IdUser, e.IdQuestion }).HasName("PK__user_que__760EA6C4D8BBC28A");

            entity.ToTable("user_question");

            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.IdQuestion).HasColumnName("idQuestion");
        });

        modelBuilder.Entity<UserTask>(entity =>
        {
            entity.HasKey(e => new { e.IdUser, e.IdTask }).HasName("PK__user_tas__8B29C6CF5C255E8D");

            entity.ToTable("user_task");

            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.IdTask).HasColumnName("idTask");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
