using Ibos.Data;
using Microsoft.EntityFrameworkCore;

namespace Ibos
{
    public class start
    {
        private IConfiguration _config;
        private IConfiguration config;

        public start(IConfiguration _config) {
            _config = config;
        }
        public void ConfigureServices(IServiceCollection services) {
        services.AddDbContextPool<EmployeeDbContext>(
            options  => options.UseSqlServer(_config.GetConnectionString("EmployeeDBConnection")))
        }
    }

}
