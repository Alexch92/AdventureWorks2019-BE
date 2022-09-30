using System.Data;
using AdventureWorks2019BE.Connection;
using AdventureWorks2019BE.ObjectMapper;

namespace AdventureWorks2019BE.Repositories
{
    public class BaseRepository<E,M> : BaseConnection
    {
        public List<E> Entities;

        public BaseRepository()
        {
            Entities = new List<E>();
        }

        public async Task<E> findById(long id)
        {
            E entity = (E)Activator.CreateInstance(typeof(E));

            string query = "SELECT * "
                         +$"FROM dbo.{(string)entity.GetType().GetProperty("_Tabella").GetValue(entity)} "
                         +$"WHERE id = {id}";

            string s = (string)entity.GetType().GetProperty("_Tabella").GetValue(entity);

            DataSet ds = this.ExecuteQueryForDataSet(query);
            Entities = ObjectMapper<E,M>.Map(ds);

            return await Task.FromResult(Entities.FirstOrDefault());
        }

        public async Task<List<E>> findAll(Func<E, bool> predicate = null)
        {
            E entity = (E)Activator.CreateInstance(typeof(E));

            string query = "SELECT * "
                         +$"FROM dbo.{(string)entity.GetType().GetProperty("_Tabella").GetValue(entity)}";

            DataSet ds = this.ExecuteQueryForDataSet(query);
            Entities = ObjectMapper<E, M>.Map(ds);

            if (predicate != null && Entities != null)
                Entities = Entities.Where(predicate).ToList();

            return await Task.FromResult(Entities);
        }

        public async Task<List<E>> FindByWhereClause(string whereClause)
        {
            if (String.IsNullOrEmpty(whereClause))
                return null;

            E entity = (E)Activator.CreateInstance(typeof(E));

            string query = "SELECT * "
                         +$"FROM dbo.{(string)entity.GetType().GetProperty("_Tabella").GetValue(entity)} "
                         + "WHERE " + whereClause;

            DataSet ds = this.ExecuteQueryForDataSet(query);
            Entities = ObjectMapper<E, M>.Map(ds);

            return await Task.FromResult(Entities);
        }

    }
}
