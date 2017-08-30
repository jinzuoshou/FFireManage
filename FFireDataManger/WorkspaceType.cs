using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFireDataManger
{
    public enum WorkspaceType
    {
        UNKNOWN = 0,
        /// <summary>
        /// FileGeodatabase
        /// </summary>
        FGDB = 1,
        /// <summary>
        /// SDE Oracle 
        /// </summary>
        SDE_ORACLE = 2,
        /// <summary>
        /// SDE PostgreSQL 
        /// </summary>
        SDE_POSTGRESQL = 3
    }
}
