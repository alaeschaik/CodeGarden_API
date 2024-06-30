using Swashbuckle.AspNetCore.Annotations;

namespace CodeGardenApi.Controllers.Question;

public sealed record CreateQuestionDto
(
    [property: SwaggerSchema(Nullable = false)]
    string? Content,
    [property: SwaggerSchema(Nullable = false)]
    string? CorrectAnswer
);

public sealed record UpdateQuestionDto
(
    [property: SwaggerSchema(Nullable = true)]
    string? Content,
    [property: SwaggerSchema(Nullable = true)]
    string? CorrectAnswer
);
