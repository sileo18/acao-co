using BaileFunk.DTO_s;
using BaileFunk.Models;
using BaileFunk.Repositories;

namespace BaileFunk.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _repository;

    private readonly PasswordService _passwordService;
    
    public UsuarioService(IUsuarioRepository repository, PasswordService passwordService)
    {
        _repository = repository;
        _passwordService = passwordService;
        
    }
    public async Task<List<Usuario>> GetAllAsync(int pageNumber, int pageSize)
    {
        if (pageNumber < 1) pageNumber = 1;
        if (pageSize < 1) pageSize = 10; // Valor padrão razoável, ajuste conforme necessário

        var skip = (pageNumber - 1) * pageSize;
        
        var usuarios = await _repository.GetAllAsync(skip, pageSize);

        UsuarioPaginatedResponseDTO response = new UsuarioPaginatedResponseDTO
        {
            
        };

        return usuarios;
    }

    public async Task<Usuario?> GetByIdAsync(string id)
    {
        
        var usuario = await _repository.GetByIdAsync(id);

        if (usuario == null)
        {
            return null;
        }

        return usuario;
    }

    public async Task<Usuario> InsertAsync(Usuario usuario)
    {
        usuario.Password = _passwordService.HashPassword(usuario.Password);
        
        return await _repository.InsertAsync(usuario);
    }

    public async Task<Usuario> AuthVictimOrAdminAsync(string username, string password)
    {
        var usuario = await _repository.GetByPseudonymOrUsernameAsync(username);

        if (usuario == null)
        {
            return null;
        }
        
        bool isPasswordValid = _passwordService.VerifyPassword(usuario.Password, password);
        
        if (!isPasswordValid)
        {
            return null;
        }
        
        return usuario;
    }

    public async Task<bool> DeleteAsync(string id)
    {
        return await _repository.DeleteAsync(id);
    }
}