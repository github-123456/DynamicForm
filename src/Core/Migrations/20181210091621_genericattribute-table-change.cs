using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Migrations
{
    public partial class genericattributetablechange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormAttributes_Tenants_TenantId",
                table: "FormAttributes");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Tenants_TenantId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "GenericAttributes");

            migrationBuilder.AlterColumn<int>(
                name: "TenantId",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FormAttributeId",
                table: "GenericAttributes",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TenantId",
                table: "FormAttributes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GenericAttributes_FormAttributeId",
                table: "GenericAttributes",
                column: "FormAttributeId");

            migrationBuilder.AddForeignKey(
                name: "FK_FormAttributes_Tenants_TenantId",
                table: "FormAttributes",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GenericAttributes_FormAttributes_FormAttributeId",
                table: "GenericAttributes",
                column: "FormAttributeId",
                principalTable: "FormAttributes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Tenants_TenantId",
                table: "Orders",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormAttributes_Tenants_TenantId",
                table: "FormAttributes");

            migrationBuilder.DropForeignKey(
                name: "FK_GenericAttributes_FormAttributes_FormAttributeId",
                table: "GenericAttributes");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Tenants_TenantId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_GenericAttributes_FormAttributeId",
                table: "GenericAttributes");

            migrationBuilder.DropColumn(
                name: "FormAttributeId",
                table: "GenericAttributes");

            migrationBuilder.AlterColumn<int>(
                name: "TenantId",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "GenericAttributes",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TenantId",
                table: "FormAttributes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_FormAttributes_Tenants_TenantId",
                table: "FormAttributes",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Tenants_TenantId",
                table: "Orders",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
