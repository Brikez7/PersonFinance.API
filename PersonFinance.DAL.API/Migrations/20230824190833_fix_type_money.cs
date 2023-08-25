using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonFinance.API.DAL.Migrations
{
    /// <inheritdoc />
    public partial class fix_type_money : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "MoneyReceived_Corrency",
                table: "incomes",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "MoneyReceived_Amount",
                table: "incomes",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<short>(
                name: "Money_Corrency",
                table: "finances",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "Money_Amount",
                table: "finances",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<short>(
                name: "MoneySpent_Corrency",
                table: "expenses",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "MoneySpent_Amount",
                table: "expenses",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<short>(
                name: "ReturnedMoney_Corrency",
                table: "contracts",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ReturnedMoney_Amount",
                table: "contracts",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "MoneyCredit_Corrency",
                table: "contracts",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "MoneyCredit_Amount",
                table: "contracts",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "MoneyReceived_Corrency",
                table: "incomes",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<short>(
                name: "MoneyReceived_Amount",
                table: "incomes",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "Money_Corrency",
                table: "finances",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<short>(
                name: "Money_Amount",
                table: "finances",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "MoneySpent_Corrency",
                table: "expenses",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<short>(
                name: "MoneySpent_Amount",
                table: "expenses",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "ReturnedMoney_Corrency",
                table: "contracts",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "ReturnedMoney_Amount",
                table: "contracts",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "MoneyCredit_Corrency",
                table: "contracts",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<short>(
                name: "MoneyCredit_Amount",
                table: "contracts",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");
        }
    }
}
