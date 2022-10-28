namespace AllSpice.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]


public class FavoritesController : ControllerBase
{
  private readonly Auth0Provider _auth0provider;

  private readonly FavoritesService _fs;

  public FavoritesController(Auth0Provider auth0provider, FavoritesService fs)
  {
    _auth0provider = auth0provider;
    _fs = fs;
  }


}