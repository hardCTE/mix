using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;

namespace App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var con = new MySqlConnection("server=172.28.9.175;database=xdb_test;uid=root;pwd=123456;SslMode=None");

            // 添加
            var count = con.Execute("INSERT INTO tb_ip_blacklist(ip,add_time,is_enable) VALUES('172.28.8.120','2016-5-4 10:21:59',1)");
            Console.WriteLine($"Add a item,ret={count}");

            // insert one
            var id = con.QueryFirst<Int32>("INSERT INTO tb_ip_blacklist(ip,add_time,is_enable) VALUES('172.28.8.120','2016-5-4 10:21:59',1);select last_insert_id();");
            Console.WriteLine($"insert last id = {id}");
            Console.WriteLine();

            // query first
            var item = con.QueryFirst("select * from tb_ip_blacklist where id = @Id", new {Id = id});
            Console.WriteLine($"query last item,{item.id}~{item.ip}~{item.add_time}");


            // 查询
            Console.WriteLine("~~~~~~~~~~query all~~~~~~~~~~~~");
            var blackList = con.Query("SELECT * FROM tb_ip_blacklist;");
            foreach (var b in blackList)
            {
                Console.WriteLine($"{b.id}~~{b.ip}~~{b.add_time}");
            }

            // delete
            Console.WriteLine("~~~~~~~~~~delete one~~~~~~~~~~~~");
            var delCount = con.Execute("delete from tb_ip_blacklist where id=@Id", new {Id = id});
            Console.WriteLine($"del {id},count={delCount}");

            Console.WriteLine("~~~~~~~~~~query all~~~~~~~~~~~~");
            var blackList2 = con.Query("SELECT * FROM tb_ip_blacklist;");
            foreach (var b in blackList2)
            {
                Console.WriteLine($"{b.id}~~{b.ip}~~{b.add_time}");
            }

            Console.ReadKey();
        }
    }
}
