using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApiHotel.Models;

namespace WebApiHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly HotelContext _context;
        public UsuariosController(HotelContext Contexto)
        {
            _context = Contexto;
        }

        // Petición tipo GET: api/usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarioItems()
        {
            return await _context.Usuario.ToListAsync();
        }

        // Petición Tipo Get: Un solo registro api/usuarios/4
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuarioUsuarioID(int id)
        {
            var Usuario = await _context.Usuario.FindAsync(id);

            if (Usuario == null)
            {
                return NotFound();
            }
            return Usuario;
        }

        // Petición de tipo Post: api/Usuarios
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario UsuarioInsertar)
        {
            _context.Usuario.Add(UsuarioInsertar);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsuarioUsuarioID), new { id = UsuarioInsertar.IdUsuario }, UsuarioInsertar);
        }
        /*public async Task<IActionResult> RegistroUsuario(Usuario UsuarioInsertar, Persona PersonaInsertar)
        {
            SqlConnection conn = (SqlConnection)_context.Database.GetDbConnection();
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SP_RegistrarUsuario";
            cmd.Parameters.Add("@CorreoUsuario", System.Data.SqlDbType.VarChar, 50).Value = UsuarioInsertar.CorreoUsuario;
            cmd.Parameters.Add("@ContraseniaUsuario", System.Data.SqlDbType.VarChar, 25).Value = UsuarioInsertar.ContraseniaUsuario;
            cmd.Parameters.Add("@idRol", System.Data.SqlDbType.TinyInt).Value = UsuarioInsertar.IdRol;
            cmd.Parameters.Add("@idSaludo", System.Data.SqlDbType.TinyInt).Value = PersonaInsertar.IdSaludo;
            cmd.Parameters.Add("@NombrePersona", System.Data.SqlDbType.VarChar, 30).Value = PersonaInsertar.NombrePersona;
            cmd.Parameters.Add("@ApellidoPersona", System.Data.SqlDbType.VarChar, 30).Value = PersonaInsertar.ApellidoPersona;
            cmd.Parameters.Add("@DireccionPersona", System.Data.SqlDbType.VarChar, 50).Value = PersonaInsertar.DireccionPersona;
            cmd.Parameters.Add("@NumeroPersona", System.Data.SqlDbType.VarChar, 15).Value = PersonaInsertar.NumeroPersona;
            cmd.Parameters.Add("@NITPersona", System.Data.SqlDbType.VarChar, 11).Value = PersonaInsertar.Nitpersona;
            cmd.Parameters.Add("@idUsuario", System.Data.SqlDbType.Int).Value = UsuarioInsertar.IdUsuario;
            cmd.ExecuteNonQuery();
            conn.Close();
            return CreatedAtAction(nameof(GetUsuarioUsuarioID), new { id = UsuarioInsertar.IdUsuario }, UsuarioInsertar);
        }
        */

        // Petición de tipo PUT: api/Usuarios/2
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario UsuarioEditar)
        {
            if (id != UsuarioEditar.IdUsuario)
            {
                return BadRequest();
            }
            _context.Entry(UsuarioEditar).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        } 

        // Peticion Delete para Borar: api/Usuarios/2
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var UsuarioEliminar = await _context.Usuario.FindAsync(id);

            if(UsuarioEliminar == null)
            {
                return NotFound();
            }

            _context.Usuario.Remove(UsuarioEliminar);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}