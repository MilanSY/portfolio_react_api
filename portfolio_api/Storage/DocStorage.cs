using MySql.Data.MySqlClient;
using portfolio_api.Models;
using System.Data;

namespace portfolio_api.Storage;

public class DocStorage : IDocStorage
{
    private readonly string _connectionString;

    public DocStorage(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<IEnumerable<Doc>> GetAllAsync()
    {
        var docs = new List<Doc>();
        using (var conn = new MySqlConnection(_connectionString))
        {
            await conn.OpenAsync();
            var cmd = new MySqlCommand("SELECT * FROM Doc", conn);
            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    docs.Add(new Doc
                    {
                        Id = reader.GetGuid("id"),
                        Name = reader.GetString("name"),
                        Url = reader.GetString("url"),
                        ProjectId = reader.GetGuid("project_id")
                    });
                }
            }
        }
        return docs;
    }

    public async Task<Doc> GetByIdAsync(string id)
    {
        using (var conn = new MySqlConnection(_connectionString))
        {
            await conn.OpenAsync();
            var cmd = new MySqlCommand("SELECT * FROM Doc WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            using (var reader = await cmd.ExecuteReaderAsync())
            {
                if (await reader.ReadAsync())
                {
                    return new Doc
                    {
                        Id = reader.GetGuid("id"),
                        Name = reader.GetString("name"),
                        Url = reader.GetString("url"),
                        ProjectId = reader.GetGuid("project_id")
                    };
                }
            }
        }
        return null;
    }

    public async Task AddAsync(Doc doc)
    {
        using (var conn = new MySqlConnection(_connectionString))
        {
            await conn.OpenAsync();
            var cmd = new MySqlCommand("INSERT INTO Doc (id, name, url, project_id) VALUES (@id, @name, @url, @projectId)", conn);
            cmd.Parameters.AddWithValue("@id", doc.Id.ToString());
            cmd.Parameters.AddWithValue("@name", doc.Name);
            cmd.Parameters.AddWithValue("@url", doc.Url);
            cmd.Parameters.AddWithValue("@projectId", doc.ProjectId);
            await cmd.ExecuteNonQueryAsync();
        }
    }

    public async Task UpdateAsync(string id, Doc doc)
    {
        using (var conn = new MySqlConnection(_connectionString))
        {
            await conn.OpenAsync();
            var cmd = new MySqlCommand("UPDATE Doc SET name = @name, url = @url, project_id = @projectId WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", doc.Name);
            cmd.Parameters.AddWithValue("@url", doc.Url);
            cmd.Parameters.AddWithValue("@projectId", doc.ProjectId);
            await cmd.ExecuteNonQueryAsync();
        }
    }

    public async Task DeleteAsync(string id)
    {
        using (var conn = new MySqlConnection(_connectionString))
        {
            await conn.OpenAsync();
            var cmd = new MySqlCommand("DELETE FROM Doc WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            await cmd.ExecuteNonQueryAsync();
        }
    }
}
