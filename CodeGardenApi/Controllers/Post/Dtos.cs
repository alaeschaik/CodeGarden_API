using Swashbuckle.AspNetCore.Annotations;

namespace CodeGardenApi.Controllers.Post;

public sealed record CreatePostDto(
    [property: SwaggerSchema(Nullable = false)]
    int? UserId,
    [property: SwaggerSchema(Nullable = false)]
    string? Title,
    [property: SwaggerSchema(Nullable = false)]
    string? Content);