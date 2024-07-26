using MediSoft.DAL;
using MediSoft.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MediSoft.Services;

public class PacientesService
{
    private readonly Context _contexto;

    public PacientesService(Context contexto)
    { 
        _contexto = contexto;
    }

    public async Task<bool> Existe(int id)
    {
        return await _contexto.Pacientes.AnyAsync(p => p.PacienteId == id);
    }

    private async Task<bool> Insertar(Pacientes paciente)
    {
        _contexto.Pacientes.Add(paciente);
        return await _contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Pacientes paciente)
    {
        _contexto.Pacientes.Update(paciente);
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Pacientes paciente)
    {
        if (!await Existe(paciente.PacienteId))
            return await Insertar(paciente);
        else
            return await Modificar(paciente);
    }

    public async Task<bool> Eliminar(int id)
    {
        var paciente = await _contexto.Pacientes
            .Where(p => p.PacienteId == id).ExecuteDeleteAsync();
        return paciente > 0;
    }

    public async Task<Pacientes?> Buscar(int id)
    {
        return await _contexto.Pacientes.AsNoTracking()
            .FirstOrDefaultAsync(p => p.PacienteId == id);
    }

    public async Task<List<Pacientes>> Listar(Expression<Func<Pacientes, bool>> criterio)
    {
        return await _contexto.Pacientes.AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<List<Pacientes>> ListarPacientes()
    {
        return await _contexto.Pacientes
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<bool> ExistePacientePorNumeroSeguro(string numeroSeguro)
    {
        return await _contexto.Pacientes.AnyAsync(p => p.NumeroSeguro == numeroSeguro);
    }

    public async Task<int> GetPacientesCountAsync()
    {
        return await _contexto.Pacientes.CountAsync();
    }
}
