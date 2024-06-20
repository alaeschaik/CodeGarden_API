using Swashbuckle.AspNetCore.Annotations;

namespace CodeGardenApi.Controllers.Section;

public sealed record CreateSectionDto(
    [property: SwaggerSchema(Nullable = false)]
    int? ModuleId,
    [property: SwaggerSchema(Nullable = false)]
    string? Title,
    [property: SwaggerSchema(Nullable = false)]
    decimal? XpPoints);

public sealed record UpdateSectionDto(
    [property: SwaggerSchema(Nullable = true)]
    string? Title,
    [property: SwaggerSchema(Nullable = true)]
    int? ModuleId,
    [property: SwaggerSchema(Nullable = true)]
    decimal? XpPoints);