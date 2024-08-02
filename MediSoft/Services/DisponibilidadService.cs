using MediSoft.DAL;
using MediSoft.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MediSoft.Services
{
    public class DisponibilidadService
    {
        private readonly Context _contexto;

        public DisponibilidadService(Context contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> Existe(int id)
        {
            try
            {
                return await _contexto.Disponibilidades.AnyAsync(d => d.DisponibilidadId == id);
            }
            catch (Exception ex)
            {
                // Log the exception (ex)
                throw new Exception("Error verificando la existencia de la disponibilidad.", ex);
            }
        }

        private async Task<bool> Insertar(Disponibilidades disponibilidad)
        {
            try
            {
                _contexto.Disponibilidades.Add(disponibilidad);
                return await _contexto.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                // Log the exception (ex)
                throw new Exception("Error al insertar la disponibilidad.", ex);
            }
        }

        private async Task<bool> Modificar(Disponibilidades disponibilidad)
        {
            try
            {
                _contexto.Disponibilidades.Update(disponibilidad);
                return await _contexto.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                // Log the exception (ex)
                throw new Exception("Error al modificar la disponibilidad.", ex);
            }
        }

        public async Task<bool> Guardar(Disponibilidades disponibilidad)
        {
            try
            {
                if (disponibilidad.DisponibilidadId == 0)
                {
                    // Insertar nueva disponibilidad
                    await _contexto.Disponibilidades.AddAsync(disponibilidad);
                }
                else
                {
                    // Actualizar existencia
                    var existing = await _contexto.Disponibilidades.FindAsync(disponibilidad.DisponibilidadId);
                    if (existing == null)
                        return false;

                    // Actualizar propiedades
                    existing.DoctorId = disponibilidad.DoctorId;
                    existing.DiasDisponibilidad = disponibilidad.DiasDisponibilidad;
                    existing.Consultorio = disponibilidad.Consultorio;
                    existing.HoraInicio = disponibilidad.HoraInicio;
                    existing.HoraFin = disponibilidad.HoraFin;

                    _contexto.Disponibilidades.Update(existing);
                }

                await _contexto.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                var disponibilidad = await _contexto.Disponibilidades.FindAsync(id);
                if (disponibilidad != null)
                {
                    _contexto.Disponibilidades.Remove(disponibilidad);
                    return await _contexto.SaveChangesAsync() > 0;
                }
                return false;
            }
            catch (Exception ex)
            {
                // Log the exception (ex)
                throw new Exception("Error al eliminar la disponibilidad.", ex);
            }
        }

        public async Task<Disponibilidades?> Buscar(int id)
        {
            try
            {
                return await _contexto.Disponibilidades.AsNoTracking()
                    .Include(d => d.Doctor) 
                    .FirstOrDefaultAsync(d => d.DisponibilidadId == id);
            }
            catch (Exception ex)
            {
                // Log the exception (ex)
                throw new Exception("Error al buscar la disponibilidad.", ex);
            }
        }

        public async Task<List<Disponibilidades>> Listar(Expression<Func<Disponibilidades, bool>> criterio)
        {
            try
            {
                return await _contexto.Disponibilidades.AsNoTracking()
                    .Where(criterio)
                    .Include(d => d.Doctor)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                // Log the exception (ex)
                throw new Exception("Error al listar las disponibilidades.", ex);
            }
        }

        public async Task<List<Disponibilidades>> ListarDisponibilidades()
        {
            try
            {
                return await _contexto.Disponibilidades.AsNoTracking()
                    .Include(d => d.Doctor)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                // Log the exception (ex)
                throw new Exception("Error al listar todas las disponibilidades.", ex);
            }
        }

        public async Task<int> ObtenerCantidadDisponibilidadesAsync()
        {
            try
            {
                return await _contexto.Disponibilidades.CountAsync();
            }
            catch (Exception ex)
            {
                // Log the exception (ex)
                throw new Exception("Error al obtener la cantidad de disponibilidades.", ex);
            }
        }

        public async Task<List<Disponibilidades>> ObtenerDisponibilidadesPorDoctor(int doctorId)
        {
            try
            {
                return await _contexto.Disponibilidades
                    .AsNoTracking()
                    .Where(d => d.DoctorId == doctorId)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                // Maneja la excepción y log
                throw new Exception("Error al obtener las disponibilidades por doctor.", ex);
            }
        }

        public async Task<bool> Actualizar(Disponibilidades disponibilidad)
        {
            try
            {
                var existing = await _contexto.Disponibilidades.FindAsync(disponibilidad.DisponibilidadId);
                if (existing == null)
                {
                    throw new Exception("Disponibilidad no encontrada.");
                }

                // Actualiza las propiedades existentes
                existing.DoctorId = disponibilidad.DoctorId;
                existing.DiasDisponibilidad = disponibilidad.DiasDisponibilidad;
                existing.HoraInicio = disponibilidad.HoraInicio;
                existing.HoraFin = disponibilidad.HoraFin;
                existing.Consultorio = disponibilidad.Consultorio;

                _contexto.Disponibilidades.Update(existing);
                return await _contexto.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                // Log the exception (ex)
                throw new Exception("Error al actualizar la disponibilidad.", ex);
            }
        }

        public async Task<Disponibilidades?> ObtenerDisponibilidadPorId(int id)
        {
            return await Buscar(id);
        }
    }
}
