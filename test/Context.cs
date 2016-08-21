using System.IO;
using Linq2Oracle;
using Oracle.ManagedDataAccess.Client;

namespace Test.DataModel.Code
{
    public partial class DbContextCode : OracleDB
    {
        public DbContextCode(OracleConnection connection, TextWriter logger = null) : base(connection, logger) { }
        public EntityTable<N_USER, N_USER.Query> N_USER => new EntityTable<N_USER, N_USER.Query>(this);
        //public EntityTable<N_USERGROUP,N_USERGROUP.Query> N_USERGROUP { get { return new EntityTable<N_USERGROUP,N_USERGROUP.Query>(this); } }
        //public EntityTable<N_USERGROUP_R,N_USERGROUP_R.Query> N_USERGROUP_R { get { return new EntityTable<N_USERGROUP_R,N_USERGROUP_R.Query>(this); } }
    }
}