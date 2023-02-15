using Microsoft.EntityFrameworkCore.Migrations;
using Service;
using Service.Models;

namespace Service.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "balance", "currency", "name" },
                values: new object[,]
                {
                    { 1, 25000m, "GBP", "Main Fund" },
                    { 2, 1000m, "GBP", "For investment" },
                    { 3, 150m, "CAN", "For Canada market" },
                    { 4, 50m, "USD", "For USA market" }
                });

            migrationBuilder.InsertData(
                table: "transactions",
                columns: new[] { "id", "account_id", "amount", "currency", "direction", "status", "type" },
                values: new object[,]
                {
                    { 14, 2, 5.0m, "GBP", TransactionDirection.Income, TransactionStatus.Completed, TransactionType.Transfer },
                    { 13, 2, 5.0m, "GBP", TransactionDirection.Outcome, TransactionStatus.Completed, TransactionType.Transfer },
                    { 12, 2, 100.0m, "GBP", TransactionDirection.Outcome, TransactionStatus.Declined, TransactionType.Transfer },
                    { 11, 2, 20.0m, "GBP", TransactionDirection.Income, TransactionStatus.Declined, TransactionType.Transfer },
                    { 10, 1, 12000.81m, "GBP", TransactionDirection.Outcome, TransactionStatus.Pending, TransactionType.Transfer },
                    { 9, 1, 0.15m, "GBP", TransactionDirection.Outcome, TransactionStatus.Declined, TransactionType.Fee },
                    { 8, 1, 12.52m, "GBP", TransactionDirection.Outcome, TransactionStatus.Declined, TransactionType.Transfer },
                    { 6, 3, 1000.0m, "USD", TransactionDirection.Income, TransactionStatus.Declined, TransactionType.Transfer },
                    { 15, 2, 200.0m, "GBP", TransactionDirection.Outcome, TransactionStatus.Completed, TransactionType.Fee },
                    { 5, 3, 20.0m, "CAN", TransactionDirection.Outcome, TransactionStatus.Pending, TransactionType.FX },
                    { 4, 3, 0.25m, "CAN", TransactionDirection.Outcome, TransactionStatus.Pending, TransactionType.Fee },
                    { 3, 4, 0.05m, "USD", TransactionDirection.Income, TransactionStatus.Pending, TransactionType.Fee },
                    { 2, 4, 16.49m, "USD", TransactionDirection.Income, TransactionStatus.Pending, TransactionType.FX },
                    { 1, 4, 500m, "USD", TransactionDirection.Outcome, TransactionStatus.Completed, TransactionType.Transfer },
                    { 7, 1, 50.0m, "GBP", TransactionDirection.Income, TransactionStatus.Pending, TransactionType.Transfer },
                    { 16, 2, 0.25m, "GBP", TransactionDirection.Outcome, TransactionStatus.Pending, TransactionType.Fee }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "accounts",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "accounts",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "accounts",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "accounts",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "transactions",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "transactions",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "transactions",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "transactions",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "transactions",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "transactions",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "transactions",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "transactions",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "transactions",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "transactions",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "transactions",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "transactions",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "transactions",
                keyColumn: "id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "transactions",
                keyColumn: "id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "transactions",
                keyColumn: "id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "transactions",
                keyColumn: "id",
                keyValue: 16);
        }
    }
}
