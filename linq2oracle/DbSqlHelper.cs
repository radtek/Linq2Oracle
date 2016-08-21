using Linq2Oracle.Expressions;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Linq2Oracle
{
    public static class DbSqlHelper
    {
        #region Internal Members

        internal static StringBuilder AppendParam(this StringBuilder sql, OracleParameterCollection param, OracleDbType dbType, object value) 
            => sql.Append(':').Append(param.Add(param.Count.ToString(), dbType, value, ParameterDirection.Input).ParameterName);

        internal static R[] ConvertAll<T, R>(this T[] array, Converter<T, R> converter) 
            => Array.ConvertAll(array, converter);

        #endregion

        #region Where Column In (...)
        public static SqlBoolean In<E, T>(this E @this, IEnumerable<T> values) where E : IDbExpression<T>
            => @this.In(values.ToArray());

        public static SqlBoolean In<E, T>(this E @this, T[] values)
            where E : IDbExpression<T> 
            => new SqlBoolean(sql =>
                                                    {
                if (values.Length == 0)
                {
                    sql.Append("1=2");
                    return;
                }

                // Oracle SQL������IN(...) list�j�p����W�L1000��, 
                // �p�G���ƤӦh���ӦҼ{�ϥΨ�L�d�߱���

                sql.Append(@this).Append(" IN (");

                bool isEnum = typeof(T).IsEnum;
                string delimiter = string.Empty;
                foreach (var t in values)
                {
                    sql.Append(delimiter).AppendParam(t);
                    delimiter = ", ";
                }

                sql.Append(')');
            });

        public static SqlBoolean In<E, T>(this E @this, IQueryContext<T> subquery)
            where E : IDbExpression<T> 
            => new SqlBoolean(sql => sql.Append(@this).Append(" IN (").AppendQuery(subquery).Append(')'));
        #endregion
        #region Where (Column1,Column2) In (...)
        public static SqlBoolean In<E1, E2, T1, T2>(this Tuple<E1, E2> @this, Tuple<T1, T2>[] values)
            where E1 : IDbExpression<T1>
            where E2 : IDbExpression<T2>
            => new SqlBoolean(sql =>
            {
                if (values.Length == 0)
                {
                    sql.Append("1=2");
                    return;
                }

                sql.Append('(').Append(@this.Item1).Append(',').Append(@this.Item2).Append(") IN (");

                bool t1IsEnum = typeof(T1).IsEnum;
                bool t2IsEnum = typeof(T2).IsEnum;
                string delimiter = string.Empty;
                foreach (var t in values)
                {
                    sql.Append(delimiter)
                        .Append('(')
                            .AppendParam(t.Item1)
                        .Append(',')
                            .AppendParam(t.Item2)
                        .Append(')');

                    delimiter = ", ";
                }

                sql.Append(")");
            });

        public static SqlBoolean In<E1, E2, T1, T2>(this Tuple<E1, E2> @this, IEnumerable<Tuple<T1, T2>> values)
            where E1 : IDbExpression<T1>
            where E2 : IDbExpression<T2> 
            => @this.In(values.ToArray());

        public static SqlBoolean In<E1, E2, T1, T2>(this Tuple<E1, E2> @this, IQueryContext<Tuple<T1, T2>> subquery)
            where E1 : IDbExpression<T1>
            where E2 : IDbExpression<T2> 
            => new SqlBoolean(sql =>
                sql.Append('(')
                            .Append(@this.Item1).Append(',')
                            .Append(@this.Item2).Append(") IN (")
                            .AppendQuery(subquery)
                            .Append(')'));
        #endregion
        #region Where (Column1,Column2,Column3) In (...)
        public static SqlBoolean In<E1, E2, E3, T1, T2, T3>(this Tuple<E1, E2, E3> @this, Tuple<T1, T2, T3>[] values)
            where E1 : IDbExpression<T1>
            where E2 : IDbExpression<T2>
            where E3 : IDbExpression<T3>
            => new SqlBoolean(sql =>
            {
                if (values.Length == 0)
                {
                    sql.Append("1=2");
                    return;
                }

                sql.Append('(')
                    .Append(@this.Item1).Append(',')
                    .Append(@this.Item2).Append(',')
                    .Append(@this.Item3)
                .Append(") IN (");

                bool t1IsEnum = typeof(T1).IsEnum;
                bool t2IsEnum = typeof(T2).IsEnum;
                bool t3IsEnum = typeof(T3).IsEnum;
                string delimiter = string.Empty;
                foreach (var t in values)
                {
                    sql.Append(delimiter)
                        .Append('(')
                            .AppendParam(t.Item1)
                        .Append(',')
                            .AppendParam(t.Item2)
                        .Append(',')
                            .AppendParam(t.Item3)
                        .Append(')');
                    delimiter = ", ";
                }
                sql.Append(')');
            });

        public static SqlBoolean In<E1, E2, E3, T1, T2, T3>(this Tuple<E1, E2, E3> @this, IEnumerable<Tuple<T1, T2, T3>> values)
            where E1 : IDbExpression<T1>
            where E2 : IDbExpression<T2>
            where E3 : IDbExpression<T3> 
            => @this.In(values.ToArray());

        public static SqlBoolean In<E1, E2, E3, T1, T2, T3>(this Tuple<E1, E2, E3> @this, IQueryContext<Tuple<T1, T2, T3>> subquery)
            where E1 : IDbExpression<T1>
            where E2 : IDbExpression<T2>
            where E3 : IDbExpression<T3>
            => new SqlBoolean(sql => sql.Append('(')
                                                  .Append(@this.Item1).Append(',')
                                                  .Append(@this.Item2).Append(',')
                                                  .Append(@this.Item3).Append(") IN (")
                                                  .AppendQuery(subquery)
                                                  .Append(')'));
        #endregion

        #region Delete
        public static int Delete<C, T>(this QueryContext<C, T, T> @this, Func<C, SqlBoolean> predicate = null)
            where T : DbEntity
            where C : class,new()
        {
            if (predicate != null)
                @this = @this.Where(predicate);

            using (var cmd = @this.Db.CreateCommand())
            {
                var sql = new SqlContext(new StringBuilder(32), cmd.Parameters);
                sql.Append("DELETE FROM (").Append("SELECT ").Append(sql.GetAlias(@this) + ".*", @this).Append(')');
                cmd.CommandText = sql.ToString();
                return @this.Db.ExecuteNonQuery(cmd);
            }
        }
        #endregion
    }
}