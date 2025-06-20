using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using Serilog;

namespace Store.Extensions
{
    public static class ConfigureLogger
    {
        public static IServiceCollection AddSerilog(this IServiceCollection services)
        {
            var columnOptions = new ColumnOptions();
            columnOptions.AdditionalColumns = new List<SqlColumn>
            {
                new SqlColumn("EntityName", System.Data.SqlDbType.NVarChar, true, 100),
                new SqlColumn("Method", System.Data.SqlDbType.NVarChar, true, 100),
            };

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Fatal)
                .MinimumLevel.Override("System", LogEventLevel.Fatal)
                .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Fatal)
                .MinimumLevel.Information()
                .WriteTo.Console()
                .WriteTo.MSSqlServer(
                    connectionString: "Data Source=.\\SQLExpress;Initial Catalog=Store; User ID=development;Password=H4rm0n1t#130524;MultipleActiveResultSets=True;TrustServerCertificate=True",
                    sinkOptions: new Serilog.Sinks.MSSqlServer.MSSqlServerSinkOptions { TableName = "Logs", AutoCreateSqlTable = true },
                    columnOptions: columnOptions)
                .Enrich.FromLogContext()
                .CreateLogger();

            return services;
        }
    }
}