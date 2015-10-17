﻿using System.Collections.Generic;
using Microsoft.Data.Entity.Internal;
using Microsoft.Data.Entity.MetaData.Conventions.Internal;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Internal;
using Microsoft.Data.Entity.Storage.Internal;
using Microsoft.Data.Entity.Update;
using Microsoft.Data.Entity.Update.Internal;
using Microsoft.Data.Entity.ValueGeneration.Internal;
using Xunit;

namespace Microsoft.Data.Entity.Tests.Extensions
{
    public class SqlCeEntityFrameworkServicesBuilderExtensionsTest : RelationalEntityFrameworkServicesBuilderExtensionsTest
    {
        [Fact]
        public override void Services_wire_up_correctly()
        {
            base.Services_wire_up_correctly();

            // Relational
            VerifySingleton<IComparer<ModificationCommand>>();

            // SQL Server Ce dingletones
            VerifySingleton<SqlCeValueGeneratorCache>();           
            VerifySingleton<SqlCeTypeMapper>();            
            VerifySingleton<SqlCeModelSource>();

            // SQL Server Ce scoped
            VerifyScoped<SqlCeConventionSetBuilder>();
            VerifyScoped<ISqlCeUpdateSqlGenerator>();
            VerifyScoped<SqlCeModificationCommandBatchFactory>();
            VerifyScoped<SqlCeDatabaseProviderServices>();
            VerifyScoped<ISqlCeDatabaseConnection>();
            VerifyScoped<SqlCeMigrationsAnnotationProvider>();
            VerifyScoped<SqlCeMigrationsSqlGenerator>();
            VerifyScoped<SqlCeDatabaseCreator>();

            // Migrations
            VerifyScoped<IMigrationsAssembly>();
            VerifyScoped<SqlCeHistoryRepository>();
            VerifyScoped<IMigrator>();
            VerifySingleton<IMigrationsIdGenerator>();
            VerifyScoped<IMigrationsModelDiffer>();
            VerifyScoped<SqlCeMigrationsSqlGenerator>();
        }

        public SqlCeEntityFrameworkServicesBuilderExtensionsTest()
            : base(SqlCeTestHelpers.Instance)
        {
        }
    }
}
