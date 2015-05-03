﻿using ErikEJ.Data.Entity.SqlServerCe.Query;
using JetBrains.Annotations;
using Microsoft.Data.Entity.ChangeTracking.Internal;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Metadata.Internal;
using Microsoft.Data.Entity.Query;
using Microsoft.Data.Entity.Relational.Query;
using Microsoft.Data.Entity.Relational.Query.Expressions;
using Microsoft.Data.Entity.Relational.Query.Methods;
using Microsoft.Data.Entity.Relational.Query.Sql;
using Microsoft.Data.Entity.Utilities;
using Microsoft.Framework.Logging;

namespace ErikEJ.Data.Entity.SqlServerCe.Query
{
    public class SqlServerCeQueryCompilationContext : RelationalQueryCompilationContext
    {
        public SqlServerCeQueryCompilationContext(
            [NotNull] IModel model,
            [NotNull] ILogger logger,
            [NotNull] ILinqOperatorProvider linqOperatorProvider,
            [NotNull] IResultOperatorHandler resultOperatorHandler,
            [NotNull] IEntityMaterializerSource entityMaterializerSource,
            [NotNull] IEntityKeyFactorySource entityKeyFactorySource,
            [NotNull] IClrAccessorSource<IClrPropertyGetter> clrPropertyGetterSource,
            [NotNull] IQueryMethodProvider queryMethodProvider,
            [NotNull] IMethodCallTranslator methodCallTranslator,
            [NotNull] ISqlServerCeValueBufferFactoryFactory valueBufferFactoryFactory)
            : base(
                Check.NotNull(model, nameof(model)),
                Check.NotNull(logger, nameof(logger)),
                Check.NotNull(linqOperatorProvider, nameof(linqOperatorProvider)),
                Check.NotNull(resultOperatorHandler, nameof(resultOperatorHandler)),
                Check.NotNull(entityMaterializerSource, nameof(entityMaterializerSource)),
                Check.NotNull(entityKeyFactorySource, nameof(entityKeyFactorySource)),
                Check.NotNull(clrPropertyGetterSource, nameof(clrPropertyGetterSource)),
                Check.NotNull(queryMethodProvider, nameof(queryMethodProvider)),
                Check.NotNull(methodCallTranslator, nameof(methodCallTranslator)),
                Check.NotNull(valueBufferFactoryFactory, nameof(valueBufferFactoryFactory)))
        {
        }

        public override ISqlQueryGenerator CreateSqlQueryGenerator(SelectExpression selectExpression)
            => new SqlServerCeQueryGenerator(Check.NotNull(selectExpression, nameof(selectExpression)));

        //public override string GetTableName(IEntityType entityType)
        //    => Check.NotNull(entityType, nameof(entityType)).SqlServer().Table;

        //public override string GetSchema(IEntityType entityType)
        //    => Check.NotNull(entityType, nameof(entityType)).SqlServer().Schema;

        //public override string GetColumnName(IProperty property)
        //    => Check.NotNull(property, nameof(property)).SqlServer().Column;
    }
}
