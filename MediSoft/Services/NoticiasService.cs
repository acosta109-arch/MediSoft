using MediSoft.DAL;
using MediSoft.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MediSoft.Services;

public class NoticiasService
{
    private readonly Context _contexto;

    public NoticiasService(Context contexto)
    {
        _contexto = contexto;
    }

    public async Task<bool> Existe(int id)
    { 
        return await _contexto.Noticias.AnyAsync(n => n.NoticiaId == id);
    }

    private async Task<bool> Insertar(Noticias noticia)
    {
        _contexto.Noticias.Add(noticia);
        return await _contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Noticias noticia)
    {
        _contexto.Noticias.Update(noticia);
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Noticias noticia)
    {
        if (noticia.NoticiaId == 0)
            return await Insertar(noticia);
        else
            return await Modificar(noticia);
    }

    public async Task<bool> Eliminar(int id)
    {
        var noticia = await _contexto.Noticias.FindAsync(id);
        if (noticia != null)
        {
            _contexto.Noticias.Remove(noticia);
            return await _contexto.SaveChangesAsync() > 0;
        }
        return false;
    }

    public async Task<Noticias?> Buscar(int id)
    {
        return await _contexto.Noticias.AsNoTracking()
        .FirstOrDefaultAsync(n => n.NoticiaId == id);
    }

    public async Task<List<Noticias>> Listar(Expression<Func<Noticias, bool>> criterio)
    {
        return await _contexto.Noticias.AsNoTracking()
        .Where(criterio)
            .ToListAsync();
    }

    public async Task<List<Noticias>> ListarNoticias()
    {
        return await _contexto.Noticias.AsNoTracking()
            .ToListAsync();
    }

    public async Task<int> ObtenerCantidadNoticiasAsync()
    {
        return await _contexto.Noticias.CountAsync();
    }

    public async Task<bool> ExisteNoticiaConDescripcion(string descripcion)
    {
        var noticiaExistente = await _contexto.Noticias
            .FirstOrDefaultAsync(n => n.Descripcion == descripcion);
        return noticiaExistente != null;
    }

}
