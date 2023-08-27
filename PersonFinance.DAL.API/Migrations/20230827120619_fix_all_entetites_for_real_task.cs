using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonFinance.API.DAL.Migrations
{
    /// <inheritdoc />
    public partial class fix_all_entetites_for_real_task : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropTable(
                name: "finances");

            migrationBuilder.DropTable(
                name: "money_accounts");

            migrationBuilder.DropTable(
                name: "persons");

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
                table: "incomes");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "expenses");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "contracts");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "incomes",
                type: "character varying",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "expenses",
                type: "character varying",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "contracts",
                type: "character varying",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "banking_accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserName = table.Column<string>(type: "character varying", nullable: false),
                    BankName = table.Column<string>(type: "character varying", nullable: false),
                    DateStart = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    InterestRate = table.Column<decimal>(type: "numeric", nullable: false),
                    Money_Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Money_Corrency = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_banking_accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cashes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserName = table.Column<string>(type: "character varying", nullable: false),
                    Money_Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Money_Corrency = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cashes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "invests_accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserName = table.Column<string>(type: "character varying", nullable: false),
                    DateStart = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    InterestRate = table.Column<decimal>(type: "numeric", nullable: false),
                    Money_Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Money_Corrency = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invests_accounts", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "banking_accounts");

            migrationBuilder.DropTable(
                name: "cashes");

            migrationBuilder.DropTable(
                name: "invests_accounts");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "incomes");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "expenses");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "contracts");

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

            migrationBuilder.CreateTable(
                name: "money_accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false),
                    Bank = table.Column<string>(type: "character varying", nullable: false),
                    NumberBank = table.Column<string>(type: "character varying", nullable: false),
                    TypeAccount = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_money_accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_money_accounts_persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "finances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MoneyAccountId = table.Column<Guid>(type: "uuid", nullable: true),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: true),
                    Money_Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Money_Corrency = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_finances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_finances_money_accounts_MoneyAccountId",
                        column: x => x.MoneyAccountId,
                        principalTable: "money_accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_finances_persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_finances_MoneyAccountId",
                table: "finances",
                column: "MoneyAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_finances_PersonId",
                table: "finances",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_money_accounts_PersonId",
                table: "money_accounts",
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
        }
    }
}
