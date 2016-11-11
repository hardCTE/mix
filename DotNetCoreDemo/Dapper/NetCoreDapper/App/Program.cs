using System;
using System.Data;
using System.IO;
using System.Text;
using App.DALTest;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;

namespace App
{
    public class Program
    {
        public static IConfiguration Configuration { get; private set; }
        public static IServiceCollection Services { get; private set; }

        public static IDbConnection DbConnection { get; private set; }

        private static IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("setting.json", optional: true, reloadOnChange: true);
            
            return builder.Build();
        }

        private static void Init()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            Services =new ServiceCollection();
            Configuration = GetConfiguration();

            Services.AddOptions();
            Services.Configure<ConfigSettingModel>(Configuration);
            
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
            DbConnection = new MySqlConnection("server=172.28.9.175;database=xdb_test;uid=root;pwd=123456;SslMode=None");
        }

        public static void Main(string[] args)
        {
            Init();

            //var ns = typeof (TbIpBlackList).Namespace;
            //DapperScaffold.Initialize(ns, );

            //var mapper = (SqlMapper.ITypeMap) Activator.CreateInstance(
            //    typeof (ColumnAttributeTypeMapper<>).MakeGenericType(typeof (TbIpBlackList)));
            //SqlMapper.SetTypeMap(typeof (TbIpBlackList), mapper);

            //var basic = new BasicUsage(con);
            //basic.Use();

            // test dal
            var test = new TestTbIpBlackListRawDal(DbConnection);
            test.ExecAllTest();

            /*
            // 获取配置信息
            var global = Configuration.GetValue<AppExa>("appExa");

            var str = Newtonsoft.Json.JsonConvert.SerializeObject(global, Newtonsoft.Json.Formatting.Indented);
            Console.WriteLine(str);
            */

            Console.ReadKey();
        }
    }
}
