using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EDPWebAPISecurity.Migrations
{
    /// <inheritdoc />
    public partial class TableEmployeeInsertValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                                 "INSERT " +
                                 "INTO Employee" +
                                     "(name, email, password, salary, ProfileId) " +
                                 "VALUES" +
                                     "('Funcionário', 'funcionario@glass.com.br', 'funcionario123', 12546.00, 1)," +
                                     "('Gerente',  'gerente@glass.com.br','gerente123', 23453.89, 2)," +
                                     "('Administrador',  'adm@glass.com.br','adm123', 36453.34, 3)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
