using BaileFunk.DTO_s;
using BaileFunk.Models;

namespace BaileFunk.Services;

public interface IUsuarioService
{
    Task<List<Usuario>> GetAllAsync(int pageNumber, int pageSize);

    Task<Usuario?> GetByIdAsync(string id);

    Task<Usuario> InsertAsync(UsuarioCreateDTO usuario);

    Task<Usuario> AuthVictimOrAdminAsync(string pseudonym, string password) ;

    Task<bool> DeleteAsync(string id);
}