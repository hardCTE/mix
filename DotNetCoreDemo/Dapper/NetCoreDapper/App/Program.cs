using System;
using System.IO;
using System.Reflection;
using System.Text;
using App.DALTest;
using App.DbModel;
using App.Operate;
using Dapper;
using DapperMapExt;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace App
{
    public class Program
    {
        public static IConfiguration Configuration { get; private set; }
        public static IServiceCollection Services { get; private set; }
        public static IServiceProvider ServiceProvider { get; private set; }

        public Program(IServiceCollection serviceCollection, IServiceProvider provider)
        {
            Services = serviceCollection;
            ServiceProvider = provider;

            Configuration = GetConfiguration();

            Services.AddOptions();
            Services.Configure<ConfigSettingModel>(Configuration);
        }

        private IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("setting.json", optional: true, reloadOnChange: true);
            
            return builder.Build();
        }

        public static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var con = new MySqlConnection("server=172.28.9.175;database=xdb_test;uid=root;pwd=123456;SslMode=None");

            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
            //var ns = typeof (TbIpBlackList).Namespace;
            //DapperScaffold.Initialize(ns, );

            //var mapper = (SqlMapper.ITypeMap) Activator.CreateInstance(
            //    typeof (ColumnAttributeTypeMapper<>).MakeGenericType(typeof (TbIpBlackList)));
            //SqlMapper.SetTypeMap(typeof (TbIpBlackList), mapper);

            //var basic = new BasicUsage(con);
            //basic.Use();

            // test dal
            //var test = new TestTbIpBlackListDal(con);
            //test.ExecAllTest();

            var global = Configuration.GetValue<AppExa>("appExa");

            var str = JsonConvert.SerializeObject(global, Formatting.Indented);
            Console.WriteLine(str);

            Console.ReadKey();
        }
    }
}
