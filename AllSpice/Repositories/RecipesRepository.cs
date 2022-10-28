namespace AllSpice.Repositories;

public class RecipesRepository : BaseRepository
{
  public RecipesRepository(IDbConnection db) : base(db)
  {
  }

  internal Recipe CreateRecipe(Recipe newRecipe)
  {
    string sql = @"
          INSERT INTO recipes(title,img,instructions,category,creatorId)
          VALUES(@Title,@Img,@Instructions,@Category,@CreatorId);
          SELECT LAST_INSERT_ID()
          ;";
    int recipeId = _db.ExecuteScalar<int>(sql, newRecipe);
    newRecipe.Id = recipeId;
    return newRecipe;
  }

  internal List<Recipe> GetAllRecipes()
  {
    string sql = @"
            SELECT
            rec.*,
            COUNT(fav.id) AS FavoriteCount,
            a.*
            FROM recipes rec
            JOIN accounts a ON a.id = rec.creatorId
            LEFT JOIN favorites fav ON fav.recipeId = rec.id
            GROUP BY rec.id
            ;";
    return _db.Query<Recipe, Profile, Recipe>(sql, (recipe, profile) =>
    {
      recipe.Creator = profile;
      return recipe;
    }).ToList();
  }

  internal Recipe GetById(int recipeId)
  {
    string sql = @"
            SELECT
            rec.*,
            a.*
            FROM recipes rec
            JOIN accounts a ON a.id = rec.creatorId
            LEFT JOIN favorites fav ON fav.recipeId = fav.id
            WHERE rec.id = @recipeId
            ;";
    return _db.Query<Recipe, Profile, Recipe>(sql, (recipe, profile) =>
    {
      recipe.Creator = profile;
      return recipe;
    }, new { recipeId }).FirstOrDefault();
  }

  internal void ArchiveRecipe(Recipe foundRecipe)
  {
    string sql = @"
              UPDATE recipes
              SET
              archived = 1
               WHERE id = @Id
                   ;";
    var rowsAffected = _db.Execute(sql, foundRecipe);
    if (rowsAffected == 0)
    {
      throw new Exception("Unable to update foundRecipe");
    }

  }

  internal Recipe EditRecipe(Recipe recipeData)
  {
      string sql = @"
              UPDATE recipes SET
              title = @title,
              category = @category,
              img= @img,
              instructions = @instructions,
              WHERE id = @id


                   ;";
                  int recipeRow = _db.Execute(sql,recipeData);
                  if( recipeRow == 0)
                  {
                  throw new Exception("Unable to update this recipe");
                  }
                  
                   return recipeData;
  }
}