using Swashbuckle.AspNetCore.Annotations;

namespace CodeGardenApi.Controllers.Comment;

public sealed record CreateCommentDto(
    [property: SwaggerSchema(Nullable = false)]
    int? PostId,
    [property: SwaggerSchema(Nullable = false)]
    int? UserId,
    [property: SwaggerSchema(Nullable = false)]
    string? Content);

public sealed record UpdateCommentDto(
    [property: SwaggerSchema(Nullable = true)]
    string? Content);