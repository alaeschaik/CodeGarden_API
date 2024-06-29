using Swashbuckle.AspNetCore.Annotations;

namespace CodeGardenApi.Controllers.OpenEndedQuestion;

public sealed record CreateOpenEndedQuestionDto
(
    [property: SwaggerSchema(Nullable = false)]
    string? Content,
    [property: SwaggerSchema(Nullable = false)]
    string? CorrectAnswer
);

public sealed record UpdateOpenEndedQuestionDto
(
    [property: SwaggerSchema(Nullable = true)]
    string? Content,
    [property: SwaggerSchema(Nullable = true)]
    string? CorrectAnswer
);
