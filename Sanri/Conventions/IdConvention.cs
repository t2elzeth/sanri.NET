using System;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;
using Humanizer;

namespace Sanri.Conventions
{
    public class IdConvention : IIdConvention
    {
        public void Apply(IIdentityInstance instance)
        {
            if (string.IsNullOrEmpty(instance.GeneratedBy.Class))
            {
                var tableName    = instance.EntityType.Name.Pluralize().Underscore();
                var columnName = instance.Name.Underscore();
                Console.WriteLine(tableName);
                instance.GeneratedBy.Sequence($"{tableName}_{columnName}_seq");

                instance.UnsavedValue("0");
            }

            instance.Column(instance.Name.Underscore());
        }
    }
}