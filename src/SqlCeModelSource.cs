﻿using JetBrains.Annotations;
using Microsoft.Data.Entity.Internal;

namespace ErikEJ.Data.Entity.SqlServerCe
{
    public class SqlCeModelSource : ModelSource
    {
        public SqlCeModelSource(
            [NotNull] IDbSetFinder setFinder, 
            [NotNull] IModelValidator modelValidator
            )
            : base(setFinder, modelValidator)
        {
        }
    }
}