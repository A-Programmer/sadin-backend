using Microsoft.AspNetCore.Authorization;
using Website.Common.WebFrameworks;
using Website.Services.AuthServices;

namespace Website.Presentation.Controllers;

[Authorize]
public class SecureBaseController : BaseController
{
    private readonly IAuthService AuthServices;

    public SecureBaseController(IAuthService authService) =>
        AuthServices = authService ?? throw new ArgumentNullException(nameof(authService));
    
}
