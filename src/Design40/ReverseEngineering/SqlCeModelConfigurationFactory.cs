﻿using JetBrains.Annotations;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Relational.Design.ReverseEngineering;
using Microsoft.Data.Entity.Relational.Design.ReverseEngineering.Configuration;
using Microsoft.Data.Entity.Relational.Design.Utilities;
using Microsoft.Data.Entity.SqlServerCompact.Design.ReverseEngineering.Configuration;

namespace Microsoft.Data.Entity.SqlServerCompact.Design.ReverseEngineering
{
    public class SqlCeModelConfigurationFactory : ModelConfigurationFactory
    {
        public SqlCeModelConfigurationFactory(
            [NotNull] IRelationalAnnotationProvider extensionsProvider,
            [NotNull] CSharpUtilities cSharpUtilities,
            [NotNull] ModelUtilities modelUtilities)
            : base(extensionsProvider, cSharpUtilities, modelUtilities)
        {
        }

        public override ModelConfiguration CreateModelConfiguration(
            IModel model, CustomConfiguration customConfiguration)
        {
            return new SqlCeModelConfiguration(
                model, customConfiguration, ExtensionsProvider, CSharpUtilities, ModelUtilities);
        }
    }
}
