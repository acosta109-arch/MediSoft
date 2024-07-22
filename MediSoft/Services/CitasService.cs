using MediSoft.DAL;
using MediSoft.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MediSoft.Services;

public class CitasService
{
    private readonly Context _contexto;

    public CitasService(Context contexto)
    {
        _contexto = contexto;
    }

    public async Task<bool> Existe(int id)
    {
        return await _contexto.Citas.AnyAsync(c => c.Id == id);
    }

    private async Task<bool> Insertar(Citas cita)
    {
        _contexto.Citas.Add(cita);
        return await _contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Citas cita)
    {
        _contexto.Citas.Update(cita);
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Citas cita)
    {
        if (cita.Id == 0)
            return await Insertar(cita);
        else
            return await Modificar(cita);
    }

    public async Task<bool> Eliminar(int id)
    {
        var cita = await _contexto.Citas.FindAsync(id);
        if (cita != null)
        {
            _contexto.Citas.Remove(cita);
            return await _contexto.SaveChangesAsync() > 0;
        }
        return false;
    }

    public async Task<Citas?> Buscar(int id)
    {
        return await _contexto.Citas.AsNoTracking()
        .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<List<Citas>> Listar(Expression<Func<Citas, bool>> criterio)
    {
        return await _contexto.Citas.AsNoTracking()
        .Where(criterio)
            .ToListAsync();
    }

    public async Task<List<Citas>> ListarCitas()
    {
        return await _contexto.Citas.AsNoTracking()
            .Include(c => c.Doctor)
            .ToListAsync();
    }

    public async Task<bool> ExisteCitaEnFechaHora(int doctorId, DateTime fecha, TimeSpan hora)
    {
        return await _contexto.Citas.AnyAsync(c => c.DoctorId == doctorId && c.Fecha.Date == fecha.Date);
    }

    public async Task<int> ObtenerCantidadCitasAsync()
    {
        return await _contexto.Citas.CountAsync();
    }

    public async Task<List<Citas>> ObtenerCitasPorDoctorYFecha(int doctorId, DateTime fecha)
    {
        return await _contexto.Citas.AsNoTracking()
            .Where(c => c.DoctorId == doctorId && c.Fecha.Date == fecha.Date)
            .ToListAsync();
    }
}
