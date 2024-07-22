using MediSoft.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using Radzen;

namespace MediSoft.Services;

public class AutentificacionService
{
    private readonly AuthenticationStateProvider _authenticationStateProvider;

    public AutentificacionService(AuthenticationStateProvider authenticationStateProvider)
    {
        _authenticationStateProvider = authenticationStateProvider;
    }
    public async Task Acceder(IJSRuntime JSRuntime, UsuariosService UsuariosService, NotificationService NotificationService, string usuario, string contrasena)
	{
		if (!string.IsNullOrWhiteSpace(usuario) && !string.IsNullOrWhiteSpace(contrasena))
		{
			var usuarioNew = await UsuariosService.IniciarSesion(usuario.Trim(), contrasena.Trim());
			if (usuarioNew != null)
			{
				await JSRuntime.InvokeVoidAsync("eval", "document.getElementById('login').style.display = 'none'; document.getElementById('principal').style.display = 'block';");
				await JSRuntime.InvokeVoidAsync("eval", "InsertarDatoLocal('accedido', 'true')");
				await JSRuntime.InvokeVoidAsync("eval", "InsertarDatoLocal('userID', " + usuarioNew.UsuarioId + ")");
			}
			else
			{
				Mensaje("Advertencia", "Usuario o Contraseña Incorrecta", 4000, "Advertencia", NotificationService);
			}
		}
		else
		{
			Mensaje("Error", "Complete los campos...", 4000, "Error", NotificationService);
		}
	}

	public async Task CerrarSesion(IJSRuntime JSRuntime)
	{
		await JSRuntime.InvokeVoidAsync("eval", "InsertarDatoLocal('accedido', 'false')");
		await JSRuntime.InvokeVoidAsync("eval", "document.getElementById('login').style.display = 'block'; document.getElementById('principal').style.display = 'none';");

	}


	public async Task Verificar(IJSRuntime JSRuntime)
	{
		string accededo = await JSRuntime.InvokeAsync<string>("eval", "ObtenerDatoLocal('accedido')");
		if (string.IsNullOrEmpty(accededo) || accededo != "true")
		{
			await JSRuntime.InvokeVoidAsync("eval", "document.getElementById('login').style.display = 'block'; document.getElementById('principal').style.display = 'none';");

		}
		else
		{
			await JSRuntime.InvokeVoidAsync("eval", "document.getElementById('login').style.display = 'none'; document.getElementById('principal').style.display = 'block';");
		}
	}

	public async Task<Usuarios?> usuarioActual(IJSRuntime JSRuntime, UsuariosService UsuariosService)
	{
		string userIDString = await JSRuntime.InvokeAsync<string>("eval", "ObtenerDatoLocal('userID')");

		if (int.TryParse(userIDString, out int userID))
		{
			return await UsuariosService.Buscar(userID);
		}
		else
		{
			return null;
		}
	}

	public void Mensaje(string cabecera, string mensaje, int tiempo, string tipo, NotificationService NotificationService)
	{
		NotificationMessage objetoMensaje = null;

		if (tipo == "Advertencia")
		{
			objetoMensaje = new NotificationMessage
			{
				Severity = NotificationSeverity.Warning,
				Summary = cabecera,
				Detail = mensaje,
				Duration = tiempo
			};
		}
		else if (tipo == "Exito")
		{
			objetoMensaje = new NotificationMessage
			{
				Severity = NotificationSeverity.Success,
				Summary = cabecera,
				Detail = mensaje,
				Duration = tiempo
			};
		}
		else if (tipo == "Error")
		{
			objetoMensaje = new NotificationMessage
			{
				Severity = NotificationSeverity.Error,
				Summary = cabecera,
				Detail = mensaje,
				Duration = tiempo
			};
		}

		NotificationService.Notify(objetoMensaje);
	}

    public async Task<bool> IsUserInRoleAsync(string role)
    {
        var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;
        return user.IsInRole(role);
    }

}
