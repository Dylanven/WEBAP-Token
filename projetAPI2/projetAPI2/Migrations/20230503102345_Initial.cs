using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projetAPI2.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    idCategory = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    catName = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__category__79D361B6EE739486", x => x.idCategory);
                });

            migrationBuilder.CreateTable(
                name: "category_favorite",
                columns: table => new
                {
                    idCategory = table.Column<int>(type: "int", nullable: false),
                    idUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__category__4AA21D2E0C9C56A3", x => new { x.idCategory, x.idUser });
                });

            migrationBuilder.CreateTable(
                name: "country",
                columns: table => new
                {
                    idCountry = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    couName = table.Column<string>(type: "char(80)", unicode: false, fixedLength: true, maxLength: 80, nullable: false),
                    couCode = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__country__8536480926E28CA1", x => x.idCountry);
                });

            migrationBuilder.CreateTable(
                name: "emoji",
                columns: table => new
                {
                    idEmojis = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    emoImg = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    emoShortCut = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__emoji__D0839414A356F9AC", x => x.idEmojis);
                });

            migrationBuilder.CreateTable(
                name: "event_role",
                columns: table => new
                {
                    idRole = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rolName = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__event_ro__E5045C54D9A6D2E3", x => x.idRole);
                });

            migrationBuilder.CreateTable(
                name: "notification",
                columns: table => new
                {
                    idNotification = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    notTitle = table.Column<string>(type: "char(100)", unicode: false, fixedLength: true, maxLength: 100, nullable: false),
                    notMessage = table.Column<string>(type: "char(250)", unicode: false, fixedLength: true, maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__notifica__22C0232168C58046", x => x.idNotification);
                });

            migrationBuilder.CreateTable(
                name: "statesEvent",
                columns: table => new
                {
                    idStatesEvent = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    staEvName = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__statesEv__CE0B4F9B6782221C", x => x.idStatesEvent);
                });

            migrationBuilder.CreateTable(
                name: "statesTask",
                columns: table => new
                {
                    idStatesTask = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    staTaName = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__statesTa__5A163727362EB978", x => x.idStatesTask);
                });

            migrationBuilder.CreateTable(
                name: "survey",
                columns: table => new
                {
                    idSurvey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    surTitle = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    surMessage = table.Column<string>(type: "char(255)", unicode: false, fixedLength: true, maxLength: 255, nullable: false),
                    surMultipleAnswer = table.Column<byte[]>(type: "binary(1)", fixedLength: true, maxLength: 1, nullable: false),
                    idEvent = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__survey__C10C8BC5470581E4", x => x.idSurvey);
                });

            migrationBuilder.CreateTable(
                name: "task",
                columns: table => new
                {
                    idTask = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tasTitle = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    tasDescription = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    tasStartDate = table.Column<DateTime>(type: "date", nullable: false),
                    tasEndDate = table.Column<DateTime>(type: "date", nullable: false),
                    idStatesTask = table.Column<int>(type: "int", nullable: false),
                    idEvent = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__task__C3E0F4DA42A3D86B", x => x.idTask);
                });

            migrationBuilder.CreateTable(
                name: "user_account",
                columns: table => new
                {
                    idUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    useEmail = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    useFirstName = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: false),
                    useLastName = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: false),
                    usePassword = table.Column<string>(type: "char(255)", unicode: false, fixedLength: true, maxLength: 255, nullable: false),
                    useBirthDate = table.Column<DateTime>(type: "date", nullable: false),
                    usePhone = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    useAvatar = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    useIsActive = table.Column<byte[]>(type: "binary(1)", fixedLength: true, maxLength: 1, nullable: false),
                    idRole = table.Column<int>(type: "int", nullable: false),
                    idCountry = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__user_acc__3717C982A18D5D4B", x => x.idUser);
                });

            migrationBuilder.CreateTable(
                name: "user_connection",
                columns: table => new
                {
                    idUser = table.Column<int>(type: "int", nullable: false),
                    idConnection = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__user_con__B411ADF28B5DA3C2", x => new { x.idUser, x.idConnection });
                });

            migrationBuilder.CreateTable(
                name: "user_event",
                columns: table => new
                {
                    idUser = table.Column<int>(type: "int", nullable: false),
                    idEvent = table.Column<int>(type: "int", nullable: false),
                    idRole = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__user_eve__198C6A0978A3B9A5", x => new { x.idUser, x.idEvent, x.idRole });
                });

            migrationBuilder.CreateTable(
                name: "user_favorite",
                columns: table => new
                {
                    idUser = table.Column<int>(type: "int", nullable: false),
                    idEvent = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__user_fav__4C696E553F232DF2", x => new { x.idUser, x.idEvent });
                });

            migrationBuilder.CreateTable(
                name: "user_invitation",
                columns: table => new
                {
                    idUser = table.Column<int>(type: "int", nullable: false),
                    idInvitation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__user_inv__3BF1975534D9287E", x => new { x.idUser, x.idInvitation });
                });

            migrationBuilder.CreateTable(
                name: "user_notification",
                columns: table => new
                {
                    idUser = table.Column<int>(type: "int", nullable: false),
                    idNotification = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__user_not__353BCBB02E221D16", x => new { x.idUser, x.idNotification });
                });

            migrationBuilder.CreateTable(
                name: "user_post",
                columns: table => new
                {
                    idUser = table.Column<int>(type: "int", nullable: false),
                    idPost = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__user_pos__4CF73D7F22EAE078", x => new { x.idUser, x.idPost });
                });

            migrationBuilder.CreateTable(
                name: "user_question",
                columns: table => new
                {
                    idUser = table.Column<int>(type: "int", nullable: false),
                    idQuestion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__user_que__760EA6C4D8BBC28A", x => new { x.idUser, x.idQuestion });
                });

            migrationBuilder.CreateTable(
                name: "user_task",
                columns: table => new
                {
                    idUser = table.Column<int>(type: "int", nullable: false),
                    idTask = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__user_tas__8B29C6CF5C255E8D", x => new { x.idUser, x.idTask });
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "place",
                columns: table => new
                {
                    idPlace = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    plaAddress = table.Column<string>(type: "char(38)", unicode: false, fixedLength: true, maxLength: 38, nullable: false),
                    idCountry = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__place__39B84B90309B4559", x => x.idPlace);
                    table.ForeignKey(
                        name: "FK__place__idCountry__1BC821DD",
                        column: x => x.idCountry,
                        principalTable: "country",
                        principalColumn: "idCountry");
                });

            migrationBuilder.CreateTable(
                name: "event",
                columns: table => new
                {
                    idEvent = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    evePublic = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    eveTitle = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    eveDescription = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    eveStartDate = table.Column<DateTime>(type: "date", nullable: false),
                    eveEndDate = table.Column<DateTime>(type: "date", nullable: false),
                    eveMaxParticipant = table.Column<short>(type: "smallint", nullable: true),
                    idStatesEvent = table.Column<int>(type: "int", nullable: false),
                    idCountry = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__event__B7EA7D76A32487F4", x => x.idEvent);
                    table.ForeignKey(
                        name: "FK__event__idCountry__14270015",
                        column: x => x.idCountry,
                        principalTable: "country",
                        principalColumn: "idCountry");
                    table.ForeignKey(
                        name: "FK__event__idStatesE__1332DBDC",
                        column: x => x.idStatesEvent,
                        principalTable: "statesEvent",
                        principalColumn: "idStatesEvent");
                });

            migrationBuilder.CreateTable(
                name: "question",
                columns: table => new
                {
                    idQuestion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    queMessage = table.Column<string>(type: "char(255)", unicode: false, fixedLength: true, maxLength: 255, nullable: false),
                    idSurvey = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__question__1196F46574C34B34", x => x.idQuestion);
                    table.ForeignKey(
                        name: "FK__question__idSurv__1DB06A4F",
                        column: x => x.idSurvey,
                        principalTable: "survey",
                        principalColumn: "idSurvey");
                });

            migrationBuilder.CreateTable(
                name: "connection",
                columns: table => new
                {
                    idConnection = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    conDate = table.Column<DateTime>(type: "date", nullable: false),
                    conToken = table.Column<string>(type: "char(255)", unicode: false, fixedLength: true, maxLength: 255, nullable: false),
                    idUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__connecti__3066470962D4C623", x => x.idConnection);
                    table.ForeignKey(
                        name: "FK__connectio__idUse__114A936A",
                        column: x => x.idUser,
                        principalTable: "user_account",
                        principalColumn: "idUser");
                });

            migrationBuilder.CreateTable(
                name: "event_category",
                columns: table => new
                {
                    idEvent = table.Column<int>(type: "int", nullable: false),
                    idCategory = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__event_ca__C0774B6D32845BC0", x => new { x.idEvent, x.idCategory });
                    table.ForeignKey(
                        name: "FK__event_cat__idCat__151B244E",
                        column: x => x.idCategory,
                        principalTable: "category",
                        principalColumn: "idCategory");
                    table.ForeignKey(
                        name: "FK__event_cat__idEve__160F4887",
                        column: x => x.idEvent,
                        principalTable: "event",
                        principalColumn: "idEvent");
                });

            migrationBuilder.CreateTable(
                name: "forum",
                columns: table => new
                {
                    idForum = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    forVue = table.Column<int>(type: "int", nullable: false),
                    idEvent = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__forum__74618C427307D0B8", x => x.idForum);
                    table.ForeignKey(
                        name: "FK__forum__idEvent__17F790F9",
                        column: x => x.idEvent,
                        principalTable: "event",
                        principalColumn: "idEvent");
                });

            migrationBuilder.CreateTable(
                name: "invitation",
                columns: table => new
                {
                    idInvitation = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    invCode = table.Column<string>(type: "char(255)", unicode: false, fixedLength: true, maxLength: 255, nullable: false),
                    idUser = table.Column<int>(type: "int", nullable: false),
                    Inv_idUser = table.Column<int>(type: "int", nullable: true),
                    idEvent = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__invitati__CE65ED710AC12B89", x => x.idInvitation);
                    table.ForeignKey(
                        name: "FK__invitatio__Inv_i__19DFD96B",
                        column: x => x.Inv_idUser,
                        principalTable: "user_account",
                        principalColumn: "idUser");
                    table.ForeignKey(
                        name: "FK__invitatio__idEve__1AD3FDA4",
                        column: x => x.idEvent,
                        principalTable: "event",
                        principalColumn: "idEvent");
                    table.ForeignKey(
                        name: "FK__invitatio__idUse__18EBB532",
                        column: x => x.idUser,
                        principalTable: "user_account",
                        principalColumn: "idUser");
                });

            migrationBuilder.CreateTable(
                name: "post",
                columns: table => new
                {
                    idPost = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    posTitle = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    posMessage = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    posDate = table.Column<DateTime>(type: "date", nullable: false),
                    mulitAnswer = table.Column<int>(type: "int", nullable: false),
                    idForum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__post__BE0F4FD63232CEE2", x => x.idPost);
                    table.ForeignKey(
                        name: "FK__post__idForum__1CBC4616",
                        column: x => x.idForum,
                        principalTable: "forum",
                        principalColumn: "idForum");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "([NormalizedName] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "([NormalizedUserName] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_connection_idUser",
                table: "connection",
                column: "idUser");

            migrationBuilder.CreateIndex(
                name: "UQ__country__BBF9E9CE02C203D9",
                table: "country",
                column: "couCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_event_idCountry",
                table: "event",
                column: "idCountry");

            migrationBuilder.CreateIndex(
                name: "IX_event_idStatesEvent",
                table: "event",
                column: "idStatesEvent");

            migrationBuilder.CreateIndex(
                name: "IX_event_category_idCategory",
                table: "event_category",
                column: "idCategory");

            migrationBuilder.CreateIndex(
                name: "UQ__event_ro__F39DC1F6EF9DB536",
                table: "event_role",
                column: "rolName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_forum_idEvent",
                table: "forum",
                column: "idEvent");

            migrationBuilder.CreateIndex(
                name: "IX_invitation_idEvent",
                table: "invitation",
                column: "idEvent");

            migrationBuilder.CreateIndex(
                name: "IX_invitation_idUser",
                table: "invitation",
                column: "idUser");

            migrationBuilder.CreateIndex(
                name: "IX_invitation_Inv_idUser",
                table: "invitation",
                column: "Inv_idUser");

            migrationBuilder.CreateIndex(
                name: "IX_place_idCountry",
                table: "place",
                column: "idCountry");

            migrationBuilder.CreateIndex(
                name: "IX_post_idForum",
                table: "post",
                column: "idForum");

            migrationBuilder.CreateIndex(
                name: "IX_question_idSurvey",
                table: "question",
                column: "idSurvey");

            migrationBuilder.CreateIndex(
                name: "UQ__statesEv__5DAF5BE614EC3414",
                table: "statesEvent",
                column: "staEvName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__statesTa__6CFBD88188269D95",
                table: "statesTask",
                column: "staTaName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__user_acc__2C4DF4B5817917D8",
                table: "user_account",
                column: "useEmail",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "category_favorite");

            migrationBuilder.DropTable(
                name: "connection");

            migrationBuilder.DropTable(
                name: "emoji");

            migrationBuilder.DropTable(
                name: "event_category");

            migrationBuilder.DropTable(
                name: "event_role");

            migrationBuilder.DropTable(
                name: "invitation");

            migrationBuilder.DropTable(
                name: "notification");

            migrationBuilder.DropTable(
                name: "place");

            migrationBuilder.DropTable(
                name: "post");

            migrationBuilder.DropTable(
                name: "question");

            migrationBuilder.DropTable(
                name: "statesTask");

            migrationBuilder.DropTable(
                name: "task");

            migrationBuilder.DropTable(
                name: "user_connection");

            migrationBuilder.DropTable(
                name: "user_event");

            migrationBuilder.DropTable(
                name: "user_favorite");

            migrationBuilder.DropTable(
                name: "user_invitation");

            migrationBuilder.DropTable(
                name: "user_notification");

            migrationBuilder.DropTable(
                name: "user_post");

            migrationBuilder.DropTable(
                name: "user_question");

            migrationBuilder.DropTable(
                name: "user_task");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "user_account");

            migrationBuilder.DropTable(
                name: "forum");

            migrationBuilder.DropTable(
                name: "survey");

            migrationBuilder.DropTable(
                name: "event");

            migrationBuilder.DropTable(
                name: "country");

            migrationBuilder.DropTable(
                name: "statesEvent");
        }
    }
}
