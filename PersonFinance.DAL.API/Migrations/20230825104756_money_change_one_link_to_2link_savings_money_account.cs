using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonFinance.API.DAL.Migrations
{
    /// <inheritdoc />
    public partial class money_change_one_link_to_2link_savings_money_account : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_finances_money_accounts_PersonId",
                table: "finances");

            migrationBuilder.DropForeignKey(
                name: "FK_finances_savings_persons_PersonId",
                table: "finances");

            migrationBuilder.DropIndex(
                name: "IX_finances_PersonId",
                table: "finances");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "finances");

            migrationBuilder.AddColumn<Guid>(
                name: "MoneyAccountId",
                table: "finances",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SavingsId",
                table: "finances",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_finances_MoneyAccountId",
                table: "finances",
                column: "MoneyAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_finances_SavingsId",
                table: "finances",
                column: "SavingsId");

            migrationBuilder.AddForeignKey(
                name: "FK_finances_money_accounts_MoneyAccountId",
                table: "finances",
                column: "MoneyAccountId",
                principalTable: "money_accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_finances_savings_persons_SavingsId",
                table: "finances",
                column: "SavingsId",
                principalTable: "savings_persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_finances_money_accounts_MoneyAccountId",
                table: "finances");

            migrationBuilder.DropForeignKey(
                name: "FK_finances_savings_persons_SavingsId",
                table: "finances");

            migrationBuilder.DropIndex(
                name: "IX_finances_MoneyAccountId",
                table: "finances");

            migrationBuilder.DropIndex(
                name: "IX_finances_SavingsId",
                table: "finances");

            migrationBuilder.DropColumn(
                name: "MoneyAccountId",
                table: "finances");

            migrationBuilder.DropColumn(
                name: "SavingsId",
                table: "finances");

            migrationBuilder.AddColumn<Guid>(
                name: "PersonId",
                table: "finances",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_finances_PersonId",
                table: "finances",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_finances_money_accounts_PersonId",
                table: "finances",
                column: "PersonId",
                principalTable: "money_accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_finances_savings_persons_PersonId",
                table: "finances",
                column: "PersonId",
                principalTable: "savings_persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
