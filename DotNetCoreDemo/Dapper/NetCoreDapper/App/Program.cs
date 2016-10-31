using System;
using System.Reflection;
using System.Text;
using App.DALTest;
using App.DbModel;
using App.Operate;
using Dapper;
using DapperMapExt;
using MySql.Data.MySqlClient;

namespace App
{
    public class Program
    {
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

            var test = new TestTbIpBlackListDal(con);
            test.ExecAllTest();

            Console.ReadKey();
        }
    }
}
