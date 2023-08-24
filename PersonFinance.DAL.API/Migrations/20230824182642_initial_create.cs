using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonFinance.API.DAL.Migrations
{
    /// <inheritdoc />
    public partial class initial_create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "contracts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Person = table.Column<string>(type: "character varying", nullable: false),
                    ReceiptDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    InterestRate = table.Column<decimal>(type: "numeric", nullable: false),
                    MoneyCredit_Amount = table.Column<short>(type: "smallint", nullable: false),
                    MoneyCredit_Corrency = table.Column<decimal>(type: "numeric", nullable: false),
                    Returned = table.Column<bool>(type: "boolean", nullable: false),
                    ReturnedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ReturnedMoney_Amount = table.Column<short>(type: "smallint", nullable: true),
                    ReturnedMoney_Corrency = table.Column<decimal>(type: "numeric", nullable: true),
                    TypeContract = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contracts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "expenses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Category = table.Column<string>(type: "character varying", nullable: false),
                    SubCategory = table.Column<string>(type: "character varying", nullable: false),
                    ExpenditureDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    MoneySpent_Amount = table.Column<short>(type: "smallint", nullable: false),
                    MoneySpent_Corrency = table.Column<decimal>(type: "numeric", nullable: false),
                    PurposeSpending = table.Column<string>(type: "character varying", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_expenses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "incomes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MoneyReceived_Amount = table.Column<short>(type: "smallint", nullable: false),
                    MoneyReceived_Corrency = table.Column<decimal>(type: "numeric", nullable: false),
                    ReceiptDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    TypeActivity = table.Column<string>(type: "character varying", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_incomes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "savings_persons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_savings_persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "money_accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Number = table.Column<Guid>(type: "uuid", nullable: false),
                    Bank = table.Column<string>(type: "character varying", nullable: false),
                    TypeAccount = table.Column<short>(type: "smallint", nullable: false),
                    SavingsId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_money_accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_money_accounts_savings_persons_SavingsId",
                        column: x => x.SavingsId,
                        principalTable: "savings_persons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "finances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false),
                    Money_Amount = table.Column<short>(type: "smallint", nullable: false),
                    Money_Corrency = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_finances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_finances_money_accounts_PersonId",
                        column: x => x.PersonId,
                        principalTable: "money_accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_finances_savings_persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "savings_persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_finances_PersonId",
                table: "finances",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_money_accounts_SavingsId",
                table: "money_accounts",
                column: "SavingsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contracts");

            migrationBuilder.DropTable(
                name: "expenses");

            migrationBuilder.DropTable(
                name: "finances");

            migrationBuilder.DropTable(
                name: "incomes");

            migrationBuilder.DropTable(
                name: "money_accounts");

            migrationBuilder.DropTable(
                name: "savings_persons");
        }
    }
}
