using BaileFunk.DTO_s;
using BaileFunk.Mapper;
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

    public async Task<Usuario> InsertAsync(UsuarioCreateDTO usuario)
    {
        if (usuario.Roles.Contains("ADMIN"))
        {
            var adminExists = await _repository.GetByPseudonymOrUsernameAsync(usuario.Username);
        
            if (adminExists != null)
                throw new Exception("Username já está em uso.");
        }
        
        var usuarioExists = await _repository.GetByPseudonymOrUsernameAsync(usuario.Pseudonym);
        
        if (usuarioExists != null)
            throw new Exception("Pseudonym já está em uso.");
        
        usuario.Password = _passwordService.HashPassword(usuario.Password);

        Usuario usuarioEntity = Mapper.UsuarioMapper.ToEntity(usuario);
        
        Usuario usuarioNovo = await _repository.InsertAsync(usuarioEntity);

        return usuarioNovo;
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