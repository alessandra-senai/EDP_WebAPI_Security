using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EDPWebAPISecurity.Migrations
{
    /// <inheritdoc />
    public partial class TableProfileInsertValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                                 "INSERT " +
                                 "INTO Profile" +
                                     "(name) " +
                                 "VALUES" +
                                     "('Employee')," +
                                     "('Manager')," +
                                     "('Administrator')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
