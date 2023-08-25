using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonFinance.API.DAL.Migrations
{
    /// <inheritdoc />
    public partial class add_entity_person : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Person",
                table: "contracts",
                newName: "OtherPerson");

            migrationBuilder.AddColumn<Guid>(
                name: "PersonId",
                table: "savings_persons",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "NumberBank",
                table: "money_accounts",
                type: "character varying",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "PersonId",
                table: "incomes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PersonId",
                table: "expenses",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PersonId",
                table: "contracts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "persons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persons", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_savings_persons_PersonId",
                table: "savings_persons",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_incomes_PersonId",
                table: "incomes",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_expenses_PersonId",
                table: "expenses",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_contracts_PersonId",
                table: "contracts",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_contracts_persons_PersonId",
                table: "contracts",
                column: "PersonId",
                principalTable: "persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_expenses_persons_PersonId",
                table: "expenses",
                column: "PersonId",
                principalTable: "persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_incomes_persons_PersonId",
                table: "incomes",
                column: "PersonId",
                principalTable: "persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_savings_persons_persons_PersonId",
                table: "savings_persons",
                column: "PersonId",
                principalTable: "persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contracts_persons_PersonId",
                table: "contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_expenses_persons_PersonId",
                table: "expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_incomes_persons_PersonId",
                table: "incomes");

            migrationBuilder.DropForeignKey(
                name: "FK_savings_persons_persons_PersonId",
                table: "savings_persons");

            migrationBuilder.DropTable(
                name: "persons");

            migrationBuilder.DropIndex(
                name: "IX_savings_persons_PersonId",
                table: "savings_persons");

            migrationBuilder.DropIndex(
                name: "IX_incomes_PersonId",
                table: "incomes");

            migrationBuilder.DropIndex(
                name: "IX_expenses_PersonId",
                table: "expenses");

            migrationBuilder.DropIndex(
                name: "IX_contracts_PersonId",
                table: "contracts");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "savings_persons");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "incomes");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "expenses");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "contracts");

            migrationBuilder.RenameColumn(
                name: "OtherPerson",
                table: "contracts",
                newName: "Person");

            migrationBuilder.AlterColumn<Guid>(
                name: "NumberBank",
                table: "money_accounts",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying");
        }
    }
}
