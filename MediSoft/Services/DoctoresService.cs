using MediSoft.DAL;
using MediSoft.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MediSoft.Services;

public class DoctoresService
{
    private readonly Context _contexto;

    public DoctoresService(Context contexto)
    {
        _contexto = contexto;
    }
     
    public async Task<bool> Existe(int id)
    {
        return await _contexto.Doctores.AnyAsync(d => d.DoctorId == id);
    }

    private async Task<bool> Insertar(Doctores doctor)
    {
        _contexto.Doctores.Add(doctor);
        return await _contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Doctores doctor)
    {
        _contexto.Doctores.Update(doctor);
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Doctores doctor)
    {
        if (doctor.DoctorId == 0)
            return await Insertar(doctor);
        else
            return await Modificar(doctor);
    }

    public async Task<bool> Eliminar(int id)
    {
        var doctor = await _contexto.Doctores.FindAsync(id);
        if (doctor != null)
        {
            _contexto.Doctores.Remove(doctor);
            return await _contexto.SaveChangesAsync() > 0;
        }
        return false;
    }

    public async Task<Doctores?> Buscar(int id)
    {
        return await _contexto.Doctores
       .Include(d => d.DetalleDoctores) // Incluye detalles
       .FirstOrDefaultAsync(d => d.DoctorId == id);
    }

    public async Task<List<Doctores>> Listar(Expression<Func<Doctores, bool>> criterio)
    {
        return await _contexto.Doctores.AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<List<Doctores>> ListarDoctores()
    {
        return await _contexto.Doctores.AsNoTracking()
            .ToListAsync();
    }

    public async Task<int> ObtenerCantidadDoctoresAsync()
    {
        return await _contexto.Doctores.CountAsync();
    }
}
