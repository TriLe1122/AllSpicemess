namespace AllSpice.Controllers;

[ApiController]
[Route("api/[controller]")]


public class RecipesController : ControllerBase
{
  private readonly Auth0Provider _auth0provider;
  private readonly RecipesService _rs;
  private readonly IngredientsService _is;

  public RecipesController(Auth0Provider auth0provider, RecipesService rs, IngredientsService @is)
  {
    _auth0provider = auth0provider;
    _rs = rs;
    _is = @is;
  }

  [HttpPost]
  public async Task<ActionResult<Recipe>> CreateRecipe([FromBody] Recipe newRecipe)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      newRecipe.creatorId = userInfo.Id;
      Recipe createdRecipe = _rs.CreateRecipe(newRecipe);

      return Ok(createdRecipe);
    }
    catch (Exception e)
    {

      return BadRequest(e.Message);
    }
  }

  [HttpGet]
  public ActionResult<List<Recipe>> GetAllRecipes()
  {
    try
    {
      List<Recipe> recipes = _rs.GetAllRecipes();
      return Ok(recipes);
    }
    catch (Exception e)
    {

      return BadRequest(e.Message);
    }
  }

  [HttpGet("{recipeId}")]
  [Authorize]
  public ActionResult<Recipe> GetRecipeById(int recipeId)
  {
    try
    {
      Recipe foundRecipe = _rs.GetRecipeById(recipeId);
      return Ok(foundRecipe);
    }
    catch (Exception e)
    {

      return BadRequest(e.Message);
    }
  }

  [HttpDelete("{recipeId}")]
  [Authorize]
  public async  Task<ActionResult<String>> ArchiveRecipe(int recipeId)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      _rs.ArchiveRecipe(recipeId, userInfo.Id);

      return Ok("recipe was archived");
    }
    catch (Exception e)
    {

      return BadRequest(e.Message);
    }
  }

  [HttpPut("{recipeId}")]
  [Authorize]
  public async Task<ActionResult<Recipe>> EditRecipe([FromBody] Recipe recipeData, int recipeId)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      Recipe recipe = _rs.EditRecipe(recipeData, userInfo.Id);

      return Ok(recipe);
    }
    catch (Exception e)
    {

      return BadRequest(e.Message);
    }
  }
}