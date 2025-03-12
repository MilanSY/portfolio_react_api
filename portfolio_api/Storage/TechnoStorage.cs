using MySql.Data.MySqlClient;
using portfolio_api.Models;
using System.Data;

namespace portfolio_api.Storage;

public class TechnoStorage : ITechnoStorage
{
    private readonly string _connectionString;

    public TechnoStorage(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<IEnumerable<Techno>> GetAllAsync()
    {
        var technos = new List<Techno>();
        using (var conn = new MySqlConnection(_connectionString))
        {
            await conn.OpenAsync();
            var cmd = new MySqlCommand("SELECT * FROM Techno", conn);
            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    technos.Add(new Techno
                    {
                        Id = Guid.Parse(reader.GetString("id")),
                        Img = reader.GetString("img"),
                        Name = reader.GetString("name"),
                        Url = reader.GetString("url"),
                        Date = reader.GetDateTime("date")
                    });
                }
            }
        }
        return technos;
    }

    public async Task<Techno> GetByIdAsync(string id)
    {
        using (var conn = new MySqlConnection(_connectionString))
        {
            await conn.OpenAsync();
            var cmd = new MySqlCommand("SELECT * FROM Techno WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            using (var reader = await cmd.ExecuteReaderAsync())
            {
                if (await reader.ReadAsync())
                {
                    return new Techno
                    {
                        Id = Guid.Parse(reader.GetString("id")),
                        Img = reader.GetString("img"),
                        Name = reader.GetString("name"),
                        Url = reader.GetString("url"),
                        Date = reader.GetDateTime("date")
                    };
                }
            }
        }
        return null;
    }

    public async Task AddAsync(Techno techno)
    {
        using (var conn = new MySqlConnection(_connectionString))
        {
            await conn.OpenAsync();
            var cmd = new MySqlCommand("INSERT INTO Techno (id, img, name, url, date) VALUES (@id, @img, @name, @url, @date)", conn);
            cmd.Parameters.AddWithValue("@id", techno.Id.ToString());
            cmd.Parameters.AddWithValue("@img", techno.Img);
            cmd.Parameters.AddWithValue("@name", techno.Name);
            cmd.Parameters.AddWithValue("@url", techno.Url);
            cmd.Parameters.AddWithValue("@date", techno.Date);
            await cmd.ExecuteNonQueryAsync();
        }
    }

    public async Task UpdateAsync(string id, Techno techno)
    {
        using (var conn = new MySqlConnection(_connectionString))
        {
            await conn.OpenAsync();
            var cmd = new MySqlCommand("UPDATE Techno SET img = @img, name = @name, url = @url, date = @date WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@img", techno.Img);
            cmd.Parameters.AddWithValue("@name", techno.Name);
            cmd.Parameters.AddWithValue("@url", techno.Url);
            cmd.Parameters.AddWithValue("@date", techno.Date);
            await cmd.ExecuteNonQueryAsync();
        }
    }

    public async Task DeleteAsync(string id)
    {
        using (var conn = new MySqlConnection(_connectionString))
        {
            await conn.OpenAsync();
            var cmd = new MySqlCommand("DELETE FROM Techno WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            await cmd.ExecuteNonQueryAsync();
        }
    }
}
