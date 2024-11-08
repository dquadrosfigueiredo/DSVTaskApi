using DSV.Task.RestApi.Domain.Entities;
using System.Text.Json;

namespace DSV.Task.RestApi.Repositories
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();

        T? GetById(int id);

        T Create(T entity);

        T? Update(T entity);
        bool Delete(int id);

        protected static List<T>? LoadJsonFile(string basePath, string dbFileName)
        {
            var path = Path.Combine(basePath, dbFileName);
            if (File.Exists(path))
            {
                var json = File.ReadAllText(path);
                return JsonSerializer.Deserialize<List<T>>(json);
            }
            return new List<T>();
        }

        protected static void SaveJsonFile(List<T> data, string basePath, string dbFileName)
        {
            var path = Path.Combine(basePath, dbFileName);
            var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, json);
        }
    }
}
