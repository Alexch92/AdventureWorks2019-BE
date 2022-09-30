using AdventureWorks2019BE.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AdventureWorks2019BE.ObjectMapper
{
    public class ObjectMapper<E,M>
    {
        private static List<E> Entities { get; set; }
        private static IObjectMapper Mapper { get; set; }

        public static List<E> Map(DataSet ds)
        {
            Entities = new List<E>();
            Mapper = (IObjectMapper)Activator.CreateInstance(typeof(M), null);

            DataRowCollection rows = ds.Tables[0].Rows;
            Dictionary<string, string> fieldsDict = Mapper.FieldsDictionary;

            foreach (DataRow row in rows)
            {
                E entity = (E)Activator.CreateInstance(typeof(E));

                foreach (DataColumn column in row.Table.Columns)
                {
                    string fieldName = column.ColumnName;
                    object value = row[column];

                    if (fieldsDict.ContainsKey(fieldName)) 
                    {
                        string field = fieldsDict[fieldName];

                        Type entityType = entity.GetType();

                        if (!string.IsNullOrEmpty(field) && entityType != null)
                        {
                            PropertyInfo prop = entityType.GetProperty(field);

                            if (prop != null)
                            {
                                prop.SetValue(entity, value);
                            }
                        }
                    }
                }

                Entities.Add(entity);
            }

            return Entities;
        }
    }
}
