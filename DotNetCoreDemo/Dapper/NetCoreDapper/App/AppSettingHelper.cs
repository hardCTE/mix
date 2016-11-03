using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace App
{
    public class AppSettingHelper
    {
        public IConfiguration Configuration { get; private set; }

        private AppSettingHelper(string configFile)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(configFile, optional: true, reloadOnChange: true);
            
            var config = builder.Build();

            Configuration = config;

            var dftConn = Configuration.GetConnectionString("DefaultConnection");
            
        }
    }
}
