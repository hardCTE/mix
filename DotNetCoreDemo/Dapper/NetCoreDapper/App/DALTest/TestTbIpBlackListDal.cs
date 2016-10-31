using System;
using System.Collections.Generic;
using System.Data;
using App.DAL;
using App.DbModel;
using MySql.Data.MySqlClient;

namespace App.DALTest
{
    public class TestTbIpBlackListDal
    {
        private TbIpBlackListDal _dal;

        public TestTbIpBlackListDal(IDbConnection dbConn = null)
        {
            var conn = dbConn ?? new MySqlConnection("server=172.28.9.175;database=xdb_test;uid=root;pwd=123456;SslMode=None");
            _dal = new TbIpBlackListDal(conn);
        }

        public void ExecAllTest()
        {
            TestAdd();
            TestAdds();
        }

        public void TestAdd()
        {
            var item = new TbIpBlackList
            {
                Ip = Guid.NewGuid().ToString("N"),
                AddTime = DateTime.Now,
                EndTime = DateTime.Now.AddDays(10),
                IsEnable = true,
                Descr = "Test-" + Guid.NewGuid()
            };

            var count = _dal.Add(item);
            if (count != 1)
            {
                Console.Error.WriteLine($"Error：Add count <> 1, actual value={count}");
            }

            if (item.Id <= 1)
            {
                Console.Error.WriteLine($"Error: add item and Id = {item.Id}");
            }
        }

        public void TestAdds()
        {
            var items = new List<TbIpBlackList>
            {
                new TbIpBlackList
                {
                    Ip = Guid.NewGuid().ToString("N"),
                    AddTime = DateTime.Now,
                    EndTime = DateTime.Now.AddDays(10),
                    IsEnable = true,
                    Descr = "1-Test-" + Guid.NewGuid()
                },
                new TbIpBlackList
                {
                    Ip = Guid.NewGuid().ToString("N"),
                    AddTime = DateTime.Now,
                    EndTime = DateTime.Now.AddDays(10),
                    IsEnable = false,
                    Descr = "2-Test-" + Guid.NewGuid()
                },
                new TbIpBlackList
                {
                    Ip = Guid.NewGuid().ToString("N"),
                    AddTime = DateTime.Now,
                    EndTime = DateTime.Now.AddDays(10),
                    IsEnable = true,
                    Descr = "3-Test-" + Guid.NewGuid()
                },
                new TbIpBlackList
                {
                    Ip = Guid.NewGuid().ToString("N"),
                    AddTime = DateTime.Now,
                    EndTime = DateTime.Now.AddDays(10),
                    IsEnable = false,
                    Descr = "4-Test-" + Guid.NewGuid()
                },
                new TbIpBlackList
                {
                    Ip = Guid.NewGuid().ToString("N"),
                    AddTime = DateTime.Now,
                    EndTime = DateTime.Now.AddDays(10),
                    IsEnable = true,
                    Descr = "5-Test-" + Guid.NewGuid()
                },
            };

            var count = _dal.Add(items);
            if (count != 5)
            {
                Console.Error.WriteLine($"Error：Add count <> 5, actual value={count}");
            }

            Console.WriteLine($"Info: add items");
            foreach (var item in items)
            {
                Console.WriteLine($"{item.Id}~{item.IsEnable}~{item.Ip}~{item.AddTime}~{item.Descr}");
            }
        }
    }
}
