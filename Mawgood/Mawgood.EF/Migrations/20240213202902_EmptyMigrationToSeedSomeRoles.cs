using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mawgood.EF.Migrations
{
    /// <inheritdoc />
    public partial class EmptyMigrationToSeedSomeRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // seed some roles
            migrationBuilder.Sql("INSERT INTO AspNetRoles (Id, Name, NormalizedName) VALUES ('1', 'Employer', 'EMPLOYER')");
            migrationBuilder.Sql("INSERT INTO AspNetRoles (Id, Name, NormalizedName) VALUES ('2', 'JobSeeker', 'JOBSEEKER')");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
