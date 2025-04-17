using Microsoft.AspNetCore.Mvc;

public abstract class AuthenticatedController : Controller
{
    protected string CurrentUsername
    {
        get
        {
            var username = User.Identity?.Name;

            if (string.IsNullOrEmpty(username))
                throw new UnauthorizedAccessException("User not authenticated.");

            return username;
        }
    }
}