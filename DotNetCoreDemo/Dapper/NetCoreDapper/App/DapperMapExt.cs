using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Dapper;

namespace DapperMapExt
{
    public class DapperScaffold
    {
        /// <summary>
        /// 初始化 类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool Initialize(Type type)
        {
            try
            {
                var mapper = (SqlMapper.ITypeMap)Activator.CreateInstance(
                    typeof(ColumnAttributeTypeMapper<>).MakeGenericType(type));
                SqlMapper.SetTypeMap(type, mapper);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 初始化 指定命名空间的程序集
        /// </summary>
        /// <param name="nameSpace"></param>
        /// <param name="asm"></param>
        /// <returns></returns>
        public static bool Initialize(string nameSpace, Assembly asm)
        {
            try
            {
                var types = from type in asm.GetTypes()
                            where type.GetTypeInfo().IsClass && type.Namespace == nameSpace
                            select type;

                types.ToList().ForEach(type =>
                {
                    var mapper = (SqlMapper.ITypeMap)
                        Activator.CreateInstance(typeof(ColumnAttributeTypeMapper<>).MakeGenericType(type));

                    SqlMapper.SetTypeMap(type, mapper);
                });
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }

    /// <summary>
    /// Uses the Name value of the <see cref="ColumnAttribute"/> specified to determine
    /// the association between the name of the column in the query results and the member to
    /// which it will be extracted. If no column mapping is present all members are mapped as
    /// usual.
    /// </summary>
    /// <typeparam name="T">The type of the object that this association between the mapper applies to.</typeparam>
    public class ColumnAttributeTypeMapper<T> : FallbackTypeMapper
    {
        public ColumnAttributeTypeMapper()
            : base(new SqlMapper.ITypeMap[]
                {
                    new CustomPropertyTypeMap(
                       typeof(T),
                       (type, columnName) =>
                           type.GetProperties().FirstOrDefault(prop =>
                               prop.GetCustomAttributes(false)
                                   .OfType<ColumnAttribute>()
                                   .Any(attr => attr.Name == columnName)
                               )
                       ),
                    new DefaultTypeMap(typeof(T))
                })
        {
        }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class ColumnAttribute : Attribute
    {
        public string Name { get; set; }
    }

    public class FallbackTypeMapper : SqlMapper.ITypeMap
    {
        private readonly IEnumerable<SqlMapper.ITypeMap> _mappers;

        public FallbackTypeMapper(IEnumerable<SqlMapper.ITypeMap> mappers)
        {
            _mappers = mappers;
        }


        public ConstructorInfo FindConstructor(string[] names, Type[] types)
        {
            foreach (var mapper in _mappers)
            {
                try
                {
                    ConstructorInfo result = mapper.FindConstructor(names, types);
                    if (result != null)
                    {
                        return result;
                    }
                }
                catch (NotImplementedException)
                {
                }
            }

            return null;
        }

        public SqlMapper.IMemberMap GetConstructorParameter(ConstructorInfo constructor, string columnName)
        {
            foreach (var mapper in _mappers)
            {
                try
                {
                    var result = mapper.GetConstructorParameter(constructor, columnName);
                    if (result != null)
                    {
                        return result;
                    }
                }
                catch (NotImplementedException)
                {
                }
            }
            return null;
        }

        public SqlMapper.IMemberMap GetMember(string columnName)
        {
            foreach (var mapper in _mappers)
            {
                try
                {
                    var result = mapper.GetMember(columnName);
                    if (result != null)
                    {
                        return result;
                    }
                }
                catch (NotImplementedException)
                {
                }
            }
            return null;
        }


        public ConstructorInfo FindExplicitConstructor()
        {
            return _mappers
                .Select(mapper => mapper.FindExplicitConstructor())
                .FirstOrDefault(result => result != null);
        }
    }
}
