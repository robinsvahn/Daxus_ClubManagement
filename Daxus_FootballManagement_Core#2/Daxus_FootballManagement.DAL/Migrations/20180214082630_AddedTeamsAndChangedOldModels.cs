using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Daxus_FootballManagement.DAL.Migrations
{
    public partial class AddedTeamsAndChangedOldModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contract_Players_PlayerId",
                table: "Contract");

            migrationBuilder.DropForeignKey(
                name: "FK_Contract_Team_TeamId",
                table: "Contract");

            migrationBuilder.DropForeignKey(
                name: "FK_GuestSlot_Players_PlayerId",
                table: "GuestSlot");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Team",
                table: "Team");

            migrationBuilder.DropIndex(
                name: "IX_GuestSlot_PlayerId",
                table: "GuestSlot");

            migrationBuilder.DropIndex(
                name: "IX_Contract_PlayerId",
                table: "Contract");

            migrationBuilder.DropIndex(
                name: "IX_Contract_TeamId",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "Registered",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "GuestSlot");

            migrationBuilder.DropColumn(
                name: "Birthdate",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Contract");

            migrationBuilder.RenameTable(
                name: "Team",
                newName: "Teams");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Tier",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GuestId",
                table: "GuestSlot",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlayerFkId",
                table: "GuestSlot",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlayerFkId",
                table: "Contract",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeamFkId",
                table: "Contract",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teams",
                table: "Teams",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_GuestSlot_GuestId",
                table: "GuestSlot",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_GuestSlot_PlayerFkId",
                table: "GuestSlot",
                column: "PlayerFkId");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_PlayerFkId",
                table: "Contract",
                column: "PlayerFkId");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_TeamFkId",
                table: "Contract",
                column: "TeamFkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_Players_PlayerFkId",
                table: "Contract",
                column: "PlayerFkId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_Teams_TeamFkId",
                table: "Contract",
                column: "TeamFkId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GuestSlot_Guests_GuestId",
                table: "GuestSlot",
                column: "GuestId",
                principalTable: "Guests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GuestSlot_Players_PlayerFkId",
                table: "GuestSlot",
                column: "PlayerFkId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contract_Players_PlayerFkId",
                table: "Contract");

            migrationBuilder.DropForeignKey(
                name: "FK_Contract_Teams_TeamFkId",
                table: "Contract");

            migrationBuilder.DropForeignKey(
                name: "FK_GuestSlot_Guests_GuestId",
                table: "GuestSlot");

            migrationBuilder.DropForeignKey(
                name: "FK_GuestSlot_Players_PlayerFkId",
                table: "GuestSlot");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teams",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_GuestSlot_GuestId",
                table: "GuestSlot");

            migrationBuilder.DropIndex(
                name: "IX_GuestSlot_PlayerFkId",
                table: "GuestSlot");

            migrationBuilder.DropIndex(
                name: "IX_Contract_PlayerFkId",
                table: "Contract");

            migrationBuilder.DropIndex(
                name: "IX_Contract_TeamFkId",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Tier",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "GuestId",
                table: "GuestSlot");

            migrationBuilder.DropColumn(
                name: "PlayerFkId",
                table: "GuestSlot");

            migrationBuilder.DropColumn(
                name: "PlayerFkId",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "TeamFkId",
                table: "Contract");

            migrationBuilder.RenameTable(
                name: "Teams",
                newName: "Team");

            migrationBuilder.AddColumn<DateTime>(
                name: "Registered",
                table: "Players",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "GuestSlot",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthdate",
                table: "Guests",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Guests",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "Contract",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Contract",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Team",
                table: "Team",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_GuestSlot_PlayerId",
                table: "GuestSlot",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_PlayerId",
                table: "Contract",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_TeamId",
                table: "Contract",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_Players_PlayerId",
                table: "Contract",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_Team_TeamId",
                table: "Contract",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GuestSlot_Players_PlayerId",
                table: "GuestSlot",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
