using MySql.Data.MySqlClient;
using portfolio_api.Models;
using System.Data;

namespace portfolio_api.Storage;

public class ProjectStorage : IProjectStorage
{
    private readonly string _connectionString;

    public ProjectStorage(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<IEnumerable<Project>> GetAllAsync()
    {
        var projects = new List<Project>();
        using (var conn = new MySqlConnection(_connectionString))
        {
            await conn.OpenAsync();
            var cmd = new MySqlCommand("SELECT * FROM Project", conn);
            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    var project = new Project
                    {
                        Id = Guid.Parse(reader.GetString("id")),
                        Name = reader.GetString("name"),
                        Description = reader.GetString("description"), 
                        Img = reader.GetString("img"), 
                        Url = reader.GetString("url"),
                        Technos = new List<Techno>() 
                    };

                    var technos = await GetTechnosForProjectAsync(project.Id.ToString());
                    project.Technos.AddRange(technos);

                    projects.Add(project);
                }
            }
        }
        return projects;
    }

    public async Task<Project> GetByIdAsync(string id)
    {
        using (var conn = new MySqlConnection(_connectionString))
        {
            await conn.OpenAsync();
            var cmd = new MySqlCommand("SELECT * FROM Project WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            using (var reader = await cmd.ExecuteReaderAsync())
            {
                if (await reader.ReadAsync())
                {
                    var project = new Project
                    {
                        Id = Guid.Parse(reader.GetString("id")),
                        Name = reader.GetString("name"),
                        Description = reader.GetString("description"),
                        Img = reader.GetString("img"),
                        Url = reader.GetString("url"),
                        Technos = new List<Techno>() 
                    };

                    var technos = await GetTechnosForProjectAsync(project.Id.ToString());
                    project.Technos.AddRange(technos);

                    return project;
                }
            }
        }
        return null;
    }

    public async Task AddAsync(Project project)
    {
        using (var conn = new MySqlConnection(_connectionString))
        {
            await conn.OpenAsync();
            var cmd = new MySqlCommand(
                "INSERT INTO Project (id, name, description, img, url) " +
                "VALUES (@id, @name, @description, @img, @url)", conn);
            cmd.Parameters.AddWithValue("@id", project.Id.ToString());
            cmd.Parameters.AddWithValue("@name", project.Name);
            cmd.Parameters.AddWithValue("@description", project.Description); 
            cmd.Parameters.AddWithValue("@img", project.Img); 
            cmd.Parameters.AddWithValue("@url", project.Url);
            await cmd.ExecuteNonQueryAsync();
        }
    }

    public async Task UpdateAsync(string id, Project project)
    {
        using (var conn = new MySqlConnection(_connectionString))
        {
            await conn.OpenAsync();
            var cmd = new MySqlCommand(
                "UPDATE Project SET name = @name, description = @description, " +
                "img = @img, url = @url WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", project.Name);
            cmd.Parameters.AddWithValue("@description", project.Description); 
            cmd.Parameters.AddWithValue("@img", project.Img);
            cmd.Parameters.AddWithValue("@url", project.Url);
            await cmd.ExecuteNonQueryAsync();
        }
    }

    public async Task DeleteAsync(string id)
    {
        using (var conn = new MySqlConnection(_connectionString))
        {
            await conn.OpenAsync();
            var cmd = new MySqlCommand("DELETE FROM Project WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            await cmd.ExecuteNonQueryAsync();
        }
    }

    public async Task AddTechnoToProjectAsync(string projectId, string technoId)
    {
        using (var conn = new MySqlConnection(_connectionString))
        {
            await conn.OpenAsync();
            var cmd = new MySqlCommand(
                "INSERT INTO Project_Techno (project_id, techno_id) VALUES (@projectId, @technoId)", conn);
            cmd.Parameters.AddWithValue("@projectId", projectId);
            cmd.Parameters.AddWithValue("@technoId", technoId);
            await cmd.ExecuteNonQueryAsync();
        }
    }

    public async Task RemoveTechnoFromProjectAsync(string projectId, string technoId)
    {
        using (var conn = new MySqlConnection(_connectionString))
        {
            await conn.OpenAsync();
            var cmd = new MySqlCommand(
                "DELETE FROM Project_Techno WHERE project_id = @projectId AND techno_id = @technoId", conn);
            cmd.Parameters.AddWithValue("@projectId", projectId);
            cmd.Parameters.AddWithValue("@technoId", technoId);
            await cmd.ExecuteNonQueryAsync();
        }
    }

    private async Task<List<Techno>> GetTechnosForProjectAsync(string projectId)
    {
        var technos = new List<Techno>();
        using (var conn = new MySqlConnection(_connectionString))
        {
            await conn.OpenAsync();
            var cmd = new MySqlCommand(
                "SELECT t.* FROM Techno t " +
                "JOIN Project_Techno pt ON t.id = pt.techno_id " +
                "WHERE pt.project_id = @projectId", conn);
            cmd.Parameters.AddWithValue("@projectId", projectId);
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
}
