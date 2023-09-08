using Ibos2.Controllers;
using Microsoft.EntityFrameworkCore;
namespace Ibos2

{
    public class start
    {
        private IConfiguration _config;
        private IConfiguration config;

        public start(IConfiguration _config)
        {
            _config = config;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<IBOSDBContext>(
                options => options.usesqlserver(_config.GetConnectionString("EmployeeDBConnection")))
        }
    }

}