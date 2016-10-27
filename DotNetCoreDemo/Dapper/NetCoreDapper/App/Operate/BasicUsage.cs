using System;
using System.Data;
using App.DbModel;
using Dapper;

namespace App.Operate
{
    public class BasicUsage
    {
        private IDbConnection _con;
        public BasicUsage(IDbConnection con)
        {
            _con = con;
        }

        public void Use()
        {
            // 添加
            var count = _con.Execute("INSERT INTO tb_ip_blacklist(ip,add_time,is_enable) VALUES('172.28.8.120','2016-5-4 10:21:59',1)");
            Console.WriteLine($"Add a item,ret={count}");

            // insert one
            var id = _con.QueryFirst<Int32>("INSERT INTO tb_ip_blacklist(ip,add_time,is_enable) VALUES('172.28.8.120','2016-5-4 10:21:59',1);select last_insert_id();");
            Console.WriteLine($"insert last id = {id}");
            Console.WriteLine();

            // query first
            var item = _con.QueryFirst("select * from tb_ip_blacklist where id = @Id", new { Id = id });
            Console.WriteLine($"query last item,{item.id}~{item.ip}~{item.add_time}");


            // 查询
            Console.WriteLine("~~~~~~~~~~query all~~~~~~~~~~~~");
            var blackList = _con.Query("SELECT * FROM tb_ip_blacklist;");
            foreach (var b in blackList)
            {
                Console.WriteLine($"{b.id}~~{b.ip}~~{b.add_time}");
            }

            Console.WriteLine("~~~~~~~~~~Object Map~~~~~~~~~~~~");
            var obj = _con.QueryFirst<TbIpBlackList>("select * from tb_ip_blacklist where id = @Id", new { Id = id });
            Console.WriteLine($"{obj.Id}--{obj.Ip}--{obj.AddTime}--{obj.Descr}");

            // query multables
            Console.WriteLine("~~~~~~~~~~query multables~~~~~~~~~~~~");
            var mobj = _con.Query<TbIpBlackList, TbIpDescr, TbIpBlackList>(@"SELECT * from tb_ip_blacklist ip
                        left join tb_ip_descr d on ip.id = d.id2 ",
                (list, descr) =>
                {
                    list.Descr = descr.DescrColumn1;
                    return list;
                },
                // where id = @Id 
                //new {Id = id}, 
                splitOn: "Id,Id2");

            foreach (var b in mobj)
            {
                Console.WriteLine($"{b.Id}~~{b.Ip}~~{b.AddTime}~~{b.EndTime}~~{b.Descr}");
            }

            // delete
            Console.WriteLine("~~~~~~~~~~delete one~~~~~~~~~~~~");
            var delCount = _con.Execute("delete from tb_ip_blacklist where id=@Id", new { Id = id });
            Console.WriteLine($"del {id},count={delCount}");

            Console.WriteLine("~~~~~~~~~~query all~~~~~~~~~~~~");
            var blackList2 = _con.Query("SELECT * FROM tb_ip_blacklist;");
            foreach (var b in blackList2)
            {
                Console.WriteLine($"{b.id}~~{b.ip}~~{b.add_time}");
            }
        }
    }
}
