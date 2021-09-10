using System;
using System.Collections.Generic;
using System.Text;

namespace Sdx.Demo.Invoice.Infrastructure.Persistence.Entities
{
    public class PersistenceSettings
    {
        public bool UseMsSql { get; set; }

        public bool UseOracle { get; set; }

        public PersistenceConnectionStrings ConnectionStrings { get; set; }

        public class PersistenceConnectionStrings
        {
            // ReSharper disable once InconsistentNaming
            public string MSSQL { get; set; }

            public string Oracle { get; set; }
        }
    }
}
