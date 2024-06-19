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
    