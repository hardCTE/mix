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
            TestAddThenRemove();
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

        public void TestAddThenRemove()
        {
            var page1 = _dal.GetPageInfo(0);
            var page2 = _dal.GetPageInfo(5);

            if (page1.Item1 != page2.Item1)
            {
                Console.Error.WriteLine($"Error: GetPageInfo,total records {page1.Item1}-{page2.Item1}");
            }

            Console.WriteLine($"PageInfo1:total={page1.Item1},pages={page1.Item2}");
            Console.WriteLine($"PageInfo2:total={page2.Item1},pages={page2.Item2}");

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

            var page3 = _dal.GetPageInfo(5);
            if (page3.Item1 != page2.Item1 + 5)
            {
                Console.Error.WriteLine($"Add error,new record count={page3.Item1}");
            }

            var delCount = _dal.RemoveByPk(items[0].Id);
            Console.WriteLine($"delete 1, delCount={delCount}");

            var page4 = _dal.GetPageInfo(5);
            if (page4.Item1 != page2.Item1 + 4)
            {
                Console.Error.WriteLine($"Add error,new record count={page4.Item1}");
            }

            var delCounts = _dal.RemoveByPks(new[] {items[1].Id, items[2].Id, items[3].Id});
            Console.WriteLine($"delete 3, delCount={delCounts}");

            var page5 = _dal.GetPageInfo(5);
            if (page5.Item1 != page2.Item1 + 1)
            {
                Console.Error.WriteLine($"Add error,new record count={page5.Item1}");
            }
        }
    }
}
