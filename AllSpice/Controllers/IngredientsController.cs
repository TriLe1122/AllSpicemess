namespace AllSpice.Controllers;

[ApiController]
[Route("api/[controller]")]


public class IngredientsController : ControllerBase
{
  private readonly Auth0Provider _auth0provider;

  private readonly IngredientsService _is;

  public IngredientsController(Auth0Provider auth0provider, IngredientsService @is)
  {
    _auth0provider = auth0provider;
    _is = @is;
  }
}