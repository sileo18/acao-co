using BaileFunk.Models;

namespace BaileFunk.Repositories;

public interface IUsuarioRepository
{
    Task<List<Usuario>> GetAllAsync(int skip, int pageSize);

    Task<Usuario?> GetByIdAsync(string id);

    Task<Usuario> InsertAsync(Usuario usuario);

    Task<bool> DeleteAsync(string id);

    Task<Usuario?> GetByPseudonymOrUsernameAsync(string identifier);
}