using Swashbuckle.AspNetCore.Annotations;

namespace CodeGardenApi.Controllers.Post;

public sealed record CreatePostDto(
    [property: SwaggerSchema(Nullable = false)]
    int? UserId,
    [property: SwaggerSchema(Nullable = false)]
    string? Title,
    [property: SwaggerSchema(Nullable = false)]
    string? Content);
    
    public sealed record UpdatePostDto(
    [property: SwaggerSchema(Nullable = true)]
    string? Title,
    [property: SwaggerSchema(Nullable = true)]
    string? Content,
    [property: SwaggerSchema(Nullable = true)]
    int? Upvotes,
    [property: SwaggerSchema(Nullable = true)]
    int? Downvotes);
    