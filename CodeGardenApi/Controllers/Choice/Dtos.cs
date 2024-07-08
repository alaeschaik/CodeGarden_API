using Swashbuckle.AspNetCore.Annotations;

namespace CodeGardenApi.Controllers.Choice;

public sealed record CreateChoiceDto(
    [property: SwaggerSchema(Nullable = false)]
    string? Content,
    [property: SwaggerSchema(Nullable = false)]
    bool? IsCorrect
);

public sealed record UpdateChoiceDto(
    [property: SwaggerSchema(Nullable = true)]
    string? Content,
    [property: SwaggerSchema(Nullable = true)]
    bool? IsCorrect
);

public sealed record AnswerChoiceDto(
    [property: SwaggerSchema(Nullable = false)]
    string? Answer
);