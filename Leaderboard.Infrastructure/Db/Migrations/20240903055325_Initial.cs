using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Leaderboard.Infrastructure.Db.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    is_admin = table.Column<bool>(type: "boolean", nullable: false),
                    date_created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    date_updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "activities",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    date_created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    date_updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    user_created_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_updated_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_activities", x => x.id);
                    table.ForeignKey(
                        name: "fk_activities_users_user_created_id",
                        column: x => x.user_created_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_activities_users_user_updated_id",
                        column: x => x.user_updated_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "scores",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    activity_id = table.Column<Guid>(type: "uuid", nullable: false),
                    period_start = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    period_end = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    date_created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    date_updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    user_created_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_updated_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_scores", x => x.id);
                    table.ForeignKey(
                        name: "fk_scores_activities_activity_id",
                        column: x => x.activity_id,
                        principalTable: "activities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_scores_users_user_created_id",
                        column: x => x.user_created_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_scores_users_user_updated_id",
                        column: x => x.user_updated_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_activities_user_created_id",
                table: "activities",
                column: "user_created_id");

            migrationBuilder.CreateIndex(
                name: "ix_activities_user_updated_id",
                table: "activities",
                column: "user_updated_id");

            migrationBuilder.CreateIndex(
                name: "ix_scores_activity_id",
                table: "scores",
                column: "activity_id");

            migrationBuilder.CreateIndex(
                name: "ix_scores_user_created_id",
                table: "scores",
                column: "user_created_id");

            migrationBuilder.CreateIndex(
                name: "ix_scores_user_updated_id",
                table: "scores",
                column: "user_updated_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "scores");

            migrationBuilder.DropTable(
                name: "activities");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
