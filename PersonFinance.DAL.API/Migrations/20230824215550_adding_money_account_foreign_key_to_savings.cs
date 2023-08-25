using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonFinance.API.DAL.Migrations
{
    /// <inheritdoc />
    public partial class adding_money_account_foreign_key_to_savings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_money_accounts_savings_persons_SavingsId",
                table: "money_accounts");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "money_accounts",
                newName: "NumberBank");

            migrationBuilder.AlterColumn<Guid>(
                name: "SavingsId",
                table: "money_accounts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_money_accounts_savings_persons_SavingsId",
                table: "money_accounts",
                column: "SavingsId",
                principalTable: "savings_persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_money_accounts_savings_persons_SavingsId",
                table: "money_accounts");

            migrationBuilder.RenameColumn(
                name: "NumberBank",
                table: "money_accounts",
                newName: "Number");

            migrationBuilder.AlterColumn<Guid>(
                name: "SavingsId",
                table: "money_accounts",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_money_accounts_savings_persons_SavingsId",
                table: "money_accounts",
                column: "SavingsId",
                principalTable: "savings_persons",
                principalColumn: "Id");
        }
    }
}
