using Swashbuckle.AspNetCore.Annotations;

namespace Sdx.Demo.Invoice.Application.Dtos
{
    public class LoginDto
    {
        [SwaggerSchema("Nombre de usuario", ReadOnly = false, Title = "Username", Nullable = false)]
        public string Username { get; set; }

        [SwaggerSchema("Contraseña", ReadOnly = false, Title = "Password", Nullable = false)]
        public string Password { get; set; }
    }
}
