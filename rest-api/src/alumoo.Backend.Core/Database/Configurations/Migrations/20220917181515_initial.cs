using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace alumoo.Backend.Core.Database.Configurations.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    ImgUrl = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ImgUrl = table.Column<string>(type: "text", nullable: false),
                    OwnerUserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_Projects_Users_OwnerUserId",
                        column: x => x.OwnerUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Volunteers",
                columns: table => new
                {
                    VolunteerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Location = table.Column<string>(type: "text", nullable: false),
                    Skills = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volunteers", x => x.VolunteerId);
                    table.ForeignKey(
                        name: "FK_Volunteers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Skills = table.Column<string>(type: "text", nullable: false),
                    HoursPerWeek = table.Column<int>(type: "integer", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    NoOfVolunteers = table.Column<int>(type: "integer", nullable: false),
                    ProjectId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_Tasks_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectEntityVolunteerEntity",
                columns: table => new
                {
                    FavoritProjectsProjectId = table.Column<int>(type: "integer", nullable: false),
                    FollowersVolunteerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectEntityVolunteerEntity", x => new { x.FavoritProjectsProjectId, x.FollowersVolunteerId });
                    table.ForeignKey(
                        name: "FK_ProjectEntityVolunteerEntity_Projects_FavoritProjectsProjec~",
                        column: x => x.FavoritProjectsProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectEntityVolunteerEntity_Volunteers_FollowersVolunteerId",
                        column: x => x.FollowersVolunteerId,
                        principalTable: "Volunteers",
                        principalColumn: "VolunteerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Impressions",
                columns: table => new
                {
                    ImpressionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Content = table.Column<string>(type: "text", nullable: false),
                    ImgUrl = table.Column<string>(type: "text", nullable: false),
                    TaskId = table.Column<int>(type: "integer", nullable: false),
                    VolunteerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Impressions", x => x.ImpressionId);
                    table.ForeignKey(
                        name: "FK_Impressions_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "TaskId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Impressions_Volunteers_VolunteerId",
                        column: x => x.VolunteerId,
                        principalTable: "Volunteers",
                        principalColumn: "VolunteerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskEntityVolunteerEntity",
                columns: table => new
                {
                    TasksTaskId = table.Column<int>(type: "integer", nullable: false),
                    VolunteersVolunteerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskEntityVolunteerEntity", x => new { x.TasksTaskId, x.VolunteersVolunteerId });
                    table.ForeignKey(
                        name: "FK_TaskEntityVolunteerEntity_Tasks_TasksTaskId",
                        column: x => x.TasksTaskId,
                        principalTable: "Tasks",
                        principalColumn: "TaskId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskEntityVolunteerEntity_Volunteers_VolunteersVolunteerId",
                        column: x => x.VolunteersVolunteerId,
                        principalTable: "Volunteers",
                        principalColumn: "VolunteerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskEntityVolunteerEntity1",
                columns: table => new
                {
                    ApplicantsVolunteerId = table.Column<int>(type: "integer", nullable: false),
                    ApplicationsTaskId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskEntityVolunteerEntity1", x => new { x.ApplicantsVolunteerId, x.ApplicationsTaskId });
                    table.ForeignKey(
                        name: "FK_TaskEntityVolunteerEntity1_Tasks_ApplicationsTaskId",
                        column: x => x.ApplicationsTaskId,
                        principalTable: "Tasks",
                        principalColumn: "TaskId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskEntityVolunteerEntity1_Volunteers_ApplicantsVolunteerId",
                        column: x => x.ApplicantsVolunteerId,
                        principalTable: "Volunteers",
                        principalColumn: "VolunteerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskEntityVolunteerEntity2",
                columns: table => new
                {
                    FavoritTasksTaskId = table.Column<int>(type: "integer", nullable: false),
                    FollowersVolunteerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskEntityVolunteerEntity2", x => new { x.FavoritTasksTaskId, x.FollowersVolunteerId });
                    table.ForeignKey(
                        name: "FK_TaskEntityVolunteerEntity2_Tasks_FavoritTasksTaskId",
                        column: x => x.FavoritTasksTaskId,
                        principalTable: "Tasks",
                        principalColumn: "TaskId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskEntityVolunteerEntity2_Volunteers_FollowersVolunteerId",
                        column: x => x.FollowersVolunteerId,
                        principalTable: "Volunteers",
                        principalColumn: "VolunteerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Impressions_TaskId",
                table: "Impressions",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Impressions_VolunteerId",
                table: "Impressions",
                column: "VolunteerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEntityVolunteerEntity_FollowersVolunteerId",
                table: "ProjectEntityVolunteerEntity",
                column: "FollowersVolunteerId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_OwnerUserId",
                table: "Projects",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskEntityVolunteerEntity_VolunteersVolunteerId",
                table: "TaskEntityVolunteerEntity",
                column: "VolunteersVolunteerId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskEntityVolunteerEntity1_ApplicationsTaskId",
                table: "TaskEntityVolunteerEntity1",
                column: "ApplicationsTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskEntityVolunteerEntity2_FollowersVolunteerId",
                table: "TaskEntityVolunteerEntity2",
                column: "FollowersVolunteerId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ProjectId",
                table: "Tasks",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Volunteers_UserId",
                table: "Volunteers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Impressions");

            migrationBuilder.DropTable(
                name: "ProjectEntityVolunteerEntity");

            migrationBuilder.DropTable(
                name: "TaskEntityVolunteerEntity");

            migrationBuilder.DropTable(
                name: "TaskEntityVolunteerEntity1");

            migrationBuilder.DropTable(
                name: "TaskEntityVolunteerEntity2");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Volunteers");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
