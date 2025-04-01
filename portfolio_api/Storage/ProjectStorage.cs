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
            var cmd = new MySqlCommand("SELECT * FROM project", conn);
            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    var project = new Project
                    {
                        Id = reader.GetGuid("id"),
                        Name = reader.IsDBNull("name") ? string.Empty : reader.GetString("name"),
                        Description = reader.IsDBNull("description") ? string.Empty : reader.GetString("description"), 
                        Img = reader.IsDBNull("img") ? string.Empty : reader.GetString("img"), 
                        Url = reader.IsDBNull("url") ? string.Empty : reader.GetString("url"),
                        Github = reader.IsDBNull("github") ? string.Empty : reader.GetString("github"),
                        Date = reader.IsDBNull("date") ? DateTime.MinValue : reader.GetDateTime("date"),
                        Technos = new(),
                        Docs = new()
                    };

                    var technos = await GetTechnosForProjectAsync(project.Id.ToString());
                    project.Technos.AddRange(technos);

                    var docs = await GetDocsForProjectAsync(project.Id);
                    project.Docs.AddRange(docs);

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
            var cmd = new MySqlCommand("SELECT * FROM project WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            using (var reader = await cmd.ExecuteReaderAsync())
            {
                if (await reader.ReadAsync())
                {
                    var project = new Project
                    {
                        Id = reader.GetGuid("id"),
                        Name = reader.IsDBNull("name") ? string.Empty : reader.GetString("name"),
                        Description = reader.IsDBNull("description") ? string.Empty : reader.GetString("description"), 
                        Img = reader.IsDBNull("img") ? string.Empty : reader.GetString("img"), 
                        Url = reader.IsDBNull("url") ? string.Empty : reader.GetString("url"),
                        Github = reader.IsDBNull("github") ? string.Empty : reader.GetString("github"),
                        Date = reader.IsDBNull("date") ? DateTime.MinValue : reader.GetDateTime("date"),
                        Technos = new(),
                        Docs = new()
                    };

                    var technos = await GetTechnosForProjectAsync(project.Id.ToString());
                    project.Technos.AddRange(technos);

                    var docs = await GetDocsForProjectAsync(project.Id);
                    project.Docs.AddRange(docs);

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
                "INSERT INTO project (id, name, description, img, url, github, date) VALUES (@id, @name, @description, @img, @url, @github, @date)", conn);
            cmd.Parameters.AddWithValue("@id", project.Id.ToString());
            cmd.Parameters.AddWithValue("@name", project.Name);
            cmd.Parameters.AddWithValue("@description", project.Description);
            cmd.Parameters.AddWithValue("@img", project.Img);
            cmd.Parameters.AddWithValue("@url", project.Url);
            cmd.Parameters.AddWithValue("@github", project.Github); 
            cmd.Parameters.AddWithValue("@date", project.Date); 
            await cmd.ExecuteNonQueryAsync();
        }
    }

    public async Task UpdateAsync(string id, Project project)
    {
        using (var conn = new MySqlConnection(_connectionString))
        {
            await conn.OpenAsync();
            var cmd = new MySqlCommand(
                "UPDATE project SET name = @name, description = @description, img = @img, url = @url, github = @github, date = @date WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", project.Name);
            cmd.Parameters.AddWithValue("@description", project.Description); 
            cmd.Parameters.AddWithValue("@img", project.Img);
            cmd.Parameters.AddWithValue("@url", project.Url);
            cmd.Parameters.AddWithValue("@github", project.Github);
            cmd.Parameters.AddWithValue("@date", project.Date); 
            await cmd.ExecuteNonQueryAsync();
        }
    }

    public async Task DeleteAsync(string id)
    {
        using (var conn = new MySqlConnection(_connectionString))
        {
            await conn.OpenAsync();
            var cmd = new MySqlCommand("DELETE FROM project WHERE id = @id", conn);
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
                "INSERT INTO project_techno (project_id, techno_id) VALUES (@projectId, @technoId)", conn);
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
                "DELETE FROM project_techno WHERE project_id = @projectId AND techno_id = @technoId", conn);
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
                "SELECT t.* FROM techno t " +
                "JOIN project_techno pt ON t.id = pt.techno_id " +
                "WHERE pt.project_id = @projectId", conn);
            cmd.Parameters.AddWithValue("@projectId", projectId);
            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    technos.Add(new Techno
                    {
                        Id = reader.GetGuid("id"),
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

    private async Task<List<Doc>> GetDocsForProjectAsync(Guid projectId)
    {
        var docs = new List<Doc>();
        using (var conn = new MySqlConnection(_connectionString))
        {
            await conn.OpenAsync();
            var cmd = new MySqlCommand(
                "SELECT * FROM doc WHERE project_id = @projectId", conn);
            cmd.Parameters.AddWithValue("@projectId", projectId.ToString());
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
}
