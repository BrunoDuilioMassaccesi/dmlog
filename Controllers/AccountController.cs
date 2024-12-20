using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dmlog.Models;

namespace dreammatch.Controllers
{
    public class AccountController : Controller
    {
        
        [HttpPost]
        public IActionResult Registrar(string nombreUsuario, string gmail, string contraseña, DateTime nacimiento, string Foto)
        {
            
            ViewBag.usuarios = Bd.ListaUsuarios();
            List<Usuario> ListaUsuario = Bd.ListaUsuarios();

                   for(int i = 1; i < ListaUsuario.Count; i++) 
       {
            if (ListaUsuario[i].Gmail == gmail) 
            {
                
                return RedirectToAction("registro", "Home", new {error = "El mail ya esta registrado"});
            }
            else
            {
                Bd.RegistrarUsuario(nombreUsuario, gmail, contraseña, nacimiento, Foto);
            }
       }
            return RedirectToAction("Index","Home");
    

          
       
        }
        

    [HttpPost]
    public IActionResult IniciarSesion(string gmail, string contraseña)
    {
        bool isValidUser = Bd.IniciarSesion(gmail, contraseña);

        if (isValidUser)
        {
            TempData["SuccessMessage"] = "Inicio de sesión exitoso!";
            return RedirectToAction("Index", "Home"); 
        }
        else
        {
            TempData["ErrorMessage"] = "Inicio de sesión incorrecto. Por favor, verifica tus credenciales.";
            return RedirectToAction("LogIn", "Home"); 
        }
    }

    






































        /*
        // Solicitud de recuperación de contraseña
        [HttpPost]
        public IActionResult SolicitarRecuperacion(string gmail)
        {
            try
            {
                // Generar código de recuperación (puede ser aleatorio)
                string codigoRecuperacion = Guid.NewGuid().ToString().Substring(0, 8);
                Bd.SolicitarRecuperacion(gmail, codigoRecuperacion);
                ViewBag.Mensaje = "Código de recuperación enviado a tu correo.";
                return View("RecoveryCodeSent");
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Error al solicitar recuperación de contraseña: {ex.Message}";
                return View("Error");
            }
        }

        // Validar código de recuperación
        [HttpPost]
        public IActionResult ValidarCodigoRecuperacion(string gmail, string codigoRecuperacion)
        {
            try
            {
                if (Bd.ValidarCodigoRecuperacion(gmail, codigoRecuperacion))
                {
                    ViewBag.Gmail = gmail;
                    return View("ResetPassword");
                }
                else
                {
                    ViewBag.Error = "Código de recuperación inválido o expirado.";
                    return View("Recovery");
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Error al validar el código de recuperación: {ex.Message}";
                return View("Error");
            }
        }

        // Actualizar contraseña
        [HttpPost]
        public IActionResult ActualizarContraseña(string gmail, string nuevaContraseña)
        {
            try
            {
                Bd.ActualizarContraseña(gmail, nuevaContraseña);
                ViewBag.Mensaje = "Contraseña actualizada con éxito.";
                return View("Success");
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Error al actualizar la contraseña: {ex.Message}";
                return View("Error");
            }
        }
        */
    }
}
