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
        return await _contexto.Citas.AnyAsync(c => c.CitaId == id);
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
        cita.Estado = "En curso";
        if (cita.CitaId == 0)
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

    public async Task<Citas> ObtenerCitaPorId(int id)
    {
        return await _contexto.Citas.AsNoTracking()
            .Include(c => c.Doctor)
            .FirstOrDefaultAsync(c => c.CitaId == id);
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

    public async Task<List<Citas>> ListarCitasPorDoctor(int doctorId)
    {
        return await _contexto.Citas.AsNoTracking()
            .Where(c => c.DoctorId == doctorId)
            .Include(c => c.Doctor)
            .ToListAsync();
    }

    public async Task<bool> ActualizarCita(Citas cita)
    {
        cita.Estado = "Modificado";
        var entradas = _contexto.ChangeTracker.Entries<Citas>()
            .Where(e => e.Entity.CitaId == cita.CitaId);

        foreach (var entrada in entradas)
        {
            entrada.State = EntityState.Detached;
        }

        _contexto.Attach(cita);
        _contexto.Entry(cita).State = EntityState.Modified;
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<List<Citas>> ObtenerCitasPorDetalles(string nombre, string cedula, string numeroSeguroMedico, string telefono)
    {
        return await _contexto.Citas
            .Where(c => c.NombreCompleto == nombre || c.Cedula == cedula || c.NumeroSeguro == numeroSeguroMedico || c.Telefono == telefono)
            .ToListAsync();
    }

    public async Task<List<Citas>> ObtenerCitasPorDetallesExcluyendoId(string nombre, string cedula, string numeroSeguroMedico, string telefono, int citaId)
    {
        return await _contexto.Citas
            .Where(c => (c.NombreCompleto == nombre || c.Cedula == cedula || c.NumeroSeguro == numeroSeguroMedico || c.Telefono == telefono) && c.CitaId != citaId)
            .ToListAsync();
    }

}
