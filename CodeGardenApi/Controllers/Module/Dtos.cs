using Swashbuckle.AspNetCore.Annotations;

namespace CodeGardenApi.Controllers.Module;

public sealed record CreateModuleDto(
    [property: SwaggerSchema(Nullable = false)]
    string? Title,
    [property: SwaggerSchema(Nullable = false)]
    string? Description,
    [property: SwaggerSchema(Nullable = false)]
    string? Introduction,
    [property: SwaggerSchema(Nullable = false)]
    string? Content,
    [property: SwaggerSchema(Nullable = false)]
    decimal? TotalXpPoints);

public sealed record UpdateModuleDto(
    [property: SwaggerSchema(Nullable = true)]
    string? Title,
    [property: SwaggerSchema(Nullable = true)]
    string? Description,
    [property: SwaggerSchema(Nullable = true)]
    string? Introduction,
    [property: SwaggerSchema(Nullable = true)]
    string? Content,
    [property: SwaggerSchema(Nullable = true)]
    decimal? TotalXpPoints);