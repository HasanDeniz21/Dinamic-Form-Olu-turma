using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;

namespace DynamicForm.Framework.Data.Repository.EFRepositoryBase
{
    public abstract class BaseDataContext : DbContext, IDisposable
    {
        public string DatabaseName { get; private set; }
        public string TableName { get; private set; }

        private void Initialize()
        {
            DatabaseName = base.Database.Connection.Database;
            //TableName = base.Database.Connection.Database.;
#if DEBUG
            this.Database.Log = x => Debug.WriteLine(x);
#endif
        }

        protected BaseDataContext(string name) : base(name)
        {
            Initialize();
        }

        protected BaseDataContext(DbConnection connection, bool isOwnsContext) : base(connection, isOwnsContext)
        {
            Initialize();
        }

    }
}
