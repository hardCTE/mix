using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
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
            var methods = this.GetType().GetMethods();
            foreach (var method in methods.Where(p => p.Name.StartsWith("Test")))
            {
                Console.WriteLine($"-----begin invoke-----{method.Name}--------");
                method.Invoke(this, null);
                Console.WriteLine($"_____end invoke_______{method.Name}_________{DateTime.Now.ToString("HH:mm:ss")}____");
            }
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

        public void TestAddThenRemoveByIp()
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

            var delCount = _dal.RemoveByIp(items[0].Ip);
            Console.WriteLine($"delete 1, delCount={delCount}");

            var page4 = _dal.GetPageInfo(5);
            if (page4.Item1 != page2.Item1 + 4)
            {
                Console.Error.WriteLine($"Add error,new record count={page4.Item1}");
            }

            var delCounts = _dal.RemoveByIps(new[] {items[1].Ip, items[2].Ip, items[3].Ip});
            Console.WriteLine($"delete 3, delCount={delCounts}");

            var page5 = _dal.GetPageInfo(5);
            if (page5.Item1 != page2.Item1 + 1)
            {
                Console.Error.WriteLine($"Add error,new record count={page5.Item1}");
            }
        }

        public void TestAddThenUpdate()
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

            items[0].Ip = "update_" + items[0].Ip;
            items[0].AddTime = items[0].AddTime.AddHours(1);
            items[0].EndTime = items[0].EndTime?.AddHours(1);
            items[0].IsEnable = !items[0].IsEnable;
            items[0].Descr = "update_" + items[0].Descr;

            items[1].Ip = "update_" + items[1].Ip;
            items[1].AddTime = items[1].AddTime.AddHours(1);
            items[1].EndTime = items[1].EndTime?.AddHours(1);
            items[1].IsEnable = !items[1].IsEnable;
            items[1].Descr = "update_" + items[1].Descr;
            _dal.Update(items.Where(p => p.Id == items[0].Id || p.Id == items[1].Id));


            items[4].Ip = "one update_" + items[4].Ip;
            items[4].AddTime = items[4].AddTime.AddHours(2);
            items[4].EndTime = items[4].EndTime?.AddHours(2);
            items[4].IsEnable = !items[4].IsEnable;
            items[4].Descr = "one update_" + items[4].Descr;
            _dal.Update(items[4]);
        }

        public void TestAddThenUpdate2()
        {
            var items = new List<TbIpBlackList>
            {
                new TbIpBlackList
                {
                    Ip = Guid.NewGuid().ToString("N"),
                    AddTime = DateTime.Now,
                    EndTime = DateTime.Now.AddDays(10),
                    IsEnable = true,
                    Descr = "1-newAdd-" + Guid.NewGuid()
                },
                new TbIpBlackList
                {
                    Ip = Guid.NewGuid().ToString("N"),
                    AddTime = DateTime.Now,
                    EndTime = DateTime.Now.AddDays(10),
                    IsEnable = false,
                    Descr = "2-newAdd-" + Guid.NewGuid()
                },
                new TbIpBlackList
                {
                    Ip = Guid.NewGuid().ToString("N"),
                    AddTime = DateTime.Now,
                    EndTime = DateTime.Now.AddDays(10),
                    IsEnable = true,
                    Descr = "3-newAdd-" + Guid.NewGuid()
                },
                new TbIpBlackList
                {
                    Ip = Guid.NewGuid().ToString("N"),
                    AddTime = DateTime.Now,
                    EndTime = DateTime.Now.AddDays(10),
                    IsEnable = false,
                    Descr = "4-newAdd-" + Guid.NewGuid()
                },
                new TbIpBlackList
                {
                    Ip = Guid.NewGuid().ToString("N"),
                    AddTime = DateTime.Now,
                    EndTime = DateTime.Now.AddDays(10),
                    IsEnable = true,
                    Descr = "5-newAdd-" + Guid.NewGuid()
                },
            };

            var count = _dal.Add(items);
            foreach (var item in items)
            {
                Console.WriteLine($"{item.Id}~{item.Ip}~{item.AddTime}");
            }

            items[0].Ip = "new update_" + items[0].Ip;
            items[0].AddTime = items[0].AddTime.AddHours(1);
            items[0].EndTime = items[0].EndTime?.AddHours(1);
            items[0].IsEnable = !items[0].IsEnable;
            items[0].Descr = "new update_" + items[0].Descr;
            items[0].OriginalId = items[0].Id;

            items[1].Ip = "new update_" + items[1].Ip;
            items[1].AddTime = items[1].AddTime.AddHours(1);
            items[1].EndTime = items[1].EndTime?.AddHours(1);
            items[1].IsEnable = !items[1].IsEnable;
            items[1].Descr = "new update_" + items[1].Descr;
            items[1].OriginalId = items[1].Id;

            var count0 = _dal.Update(items[0], new List<string>
            {
                TbIpBlackList.__.Ip
            });
            Console.WriteLine($"update0 = {count0},id={items[0].Id}");

            var count1 = _dal.Update(items[1], new List<string>
            {
                TbIpBlackList.__.Ip,
                TbIpBlackList.__.AddTime,
                TbIpBlackList.__.EndTime,
                TbIpBlackList.__.IsEnable,
                TbIpBlackList.__.Descr
            });
            Console.WriteLine($"update1 = {count1},id={items[1].Id}");

            var count2 = _dal.Update(items[2], new List<string>
            {
                TbIpBlackList.__.Ip,
                TbIpBlackList.__.AddTime,
                TbIpBlackList.__.EndTime,
                TbIpBlackList.__.IsEnable,
                TbIpBlackList.__.Descr
            });

            Console.WriteLine($"update2 = {count2},id={items[2].Id}");

        }

        public void TestAddThenUpdate3()
        {
            var items = new List<TbIpBlackList>
            {
                new TbIpBlackList
                {
                    Ip = Guid.NewGuid().ToString("N"),
                    AddTime = DateTime.Now,
                    EndTime = DateTime.Now.AddDays(10),
                    IsEnable = true,
                    Descr = "1-add for custom update-" + Guid.NewGuid()
                },
                new TbIpBlackList
                {
                    Ip = Guid.NewGuid().ToString("N"),
                    AddTime = DateTime.Now,
                    EndTime = DateTime.Now.AddDays(10),
                    IsEnable = false,
                    Descr = "2-add for custom update-" + Guid.NewGuid()
                },
                new TbIpBlackList
                {
                    Ip = Guid.NewGuid().ToString("N"),
                    AddTime = DateTime.Now,
                    EndTime = DateTime.Now.AddDays(10),
                    IsEnable = true,
                    Descr = "3-add for custom update-" + Guid.NewGuid()
                },
                new TbIpBlackList
                {
                    Ip = Guid.NewGuid().ToString("N"),
                    AddTime = DateTime.Now,
                    EndTime = DateTime.Now.AddDays(10),
                    IsEnable = false,
                    Descr = "4-add for custom update-" + Guid.NewGuid()
                },
                new TbIpBlackList
                {
                    Ip = Guid.NewGuid().ToString("N"),
                    AddTime = DateTime.Now,
                    EndTime = DateTime.Now.AddDays(10),
                    IsEnable = true,
                    Descr = "5-add for custom update-" + Guid.NewGuid()
                },
            };

            var count = _dal.Add(items);
            foreach (var item in items)
            {
                Console.WriteLine($"{item.Id}~{item.Ip}~{item.AddTime}");
            }

            items[0].Ip = "custom update_" + items[0].Ip;
            items[0].AddTime = items[0].AddTime.AddHours(1);
            items[0].EndTime = items[0].EndTime?.AddHours(2);
            items[0].IsEnable = !items[0].IsEnable;
            items[0].Descr = "custom update_" + items[0].Descr;
            items[0].OriginalId = items[0].Id;

            items[1].Ip = "custom update_" + items[1].Ip;
            items[1].AddTime = items[1].AddTime.AddHours(1);
            items[1].EndTime = items[1].EndTime?.AddHours(2);
            items[1].IsEnable = !items[1].IsEnable;
            items[1].Descr = "custom update_" + items[1].Descr;
            items[1].OriginalId = items[1].Id;

            var where0 = "id=@OriginalId";
            var set0 = "ip=@Ip,add_time=@AddTime";
            var count0 = _dal.Update(items[0], set0, where0);
            Console.WriteLine($"update0 = {count0},id={items[0].Id}");

            var where1 = "id=@Id";
            var set1 = "ip=@Ip,add_time=@AddTime,end_time=@EndTime,is_enable=@IsEnable,descr=@Descr";
            var count1 = _dal.Update(items[1], set1, where1);
            Console.WriteLine($"update1 = {count1},id={items[1].Id}");

            var count2 = _dal.Update(items[2], set0, where0);
            Console.WriteLine($"update2 = {count2},id={items[2].Id}");

            var count3 = _dal.Update(items[3], set1, where1);
            Console.WriteLine($"update2 = {count3},id={items[3].Id}");
        }

        public void TestMathPow()
        {
            var bb = Math.Pow(10, 3);
            Console.WriteLine(bb);
            Console.WriteLine((decimal) bb);
        }
    }
}
