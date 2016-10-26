Dapper.SqlMapper.SetTypeMap(
    typeof(TModel),
    new CustomPropertyTypeMap(
        typeof(TModel),
        (type, columnName) =>
            type.GetProperties().FirstOrDefault(prop =>
                prop.GetCustomAttributes(false)
                    .OfType<ColumnAttribute>()
                    .Any(attr => attr.Name == columnName))));