using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonFinance.API.DAL.Migrations
{
    /// <inheritdoc />
    public partial class remove_entity_savings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_finances_savings_persons_SavingsId",
                table: "finances");

            migrationBuilder.DropForeignKey(
                name: "FK_money_accounts_savings_persons_SavingsId",
                table: "money_accounts");

            migrationBuilder.DropTable(
                name: "savings_persons");

            migrationBuilder.RenameColumn(
                name: "SavingsId",
                table: "money_accounts",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_money_accounts_SavingsId",
                table: "money_accounts",
                newName: "IX_money_accounts_PersonId");

            migrationBuilder.RenameColumn(
                name: "SavingsId",
                table: "finances",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_finances_SavingsId",
                table: "finances",
                newName: "IX_finances_PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_finances_persons_PersonId",
                table: "finances",
                column: "PersonId",
                principalTable: "persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_money_accounts_persons_PersonId",
                table: "money_accounts",
                column: "PersonId",
                principalTable: "persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_finances_persons_PersonId",
                table: "finances");

            migrationBuilder.DropForeignKey(
                name: "FK_money_accounts_persons_PersonId",
                table: "money_accounts");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "money_accounts",
                newName: "SavingsId");

            migrationBuilder.RenameIndex(
                name: "IX_money_accounts_PersonId",
                table: "money_accounts",
                newName: "IX_money_accounts_SavingsId");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "finances",
                newName: "SavingsId");

            migrationBuilder.RenameIndex(
                name: "IX_finances_PersonId",
                table: "finances",
                newName: "IX_finances_SavingsId");

            migrationBuilder.CreateTable(
                name: "savings_persons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_savings_persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_savings_persons_persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_savings_persons_PersonId",
                table: "savings_persons",
                column: "PersonId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_finances_savings_persons_SavingsId",
                table: "finances",
                column: "SavingsId",
                principalTable: "savings_persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_money_accounts_savings_persons_SavingsId",
                table: "money_accounts",
                column: "SavingsId",
                principalTable: "savings_persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
