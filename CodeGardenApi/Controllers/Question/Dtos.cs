using CodeGardenApi.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace CodeGardenApi.Controllers.Question;

public sealed record CreateQuestionDto
(
    [property: SwaggerSchema(Nullable = false)]
    string? Content,
    [property: SwaggerSchema(Nullable = false)]
    string? CorrectAnswer,
    [property: SwaggerSchema(Nullable = false)]
    QuestionType? Type,
    [property: SwaggerSchema(Nullable = false)]
    decimal? XpPoints
);

public sealed record UpdateQuestionDto
(
    [property: SwaggerSchema(Nullable = true)]
    string? Content,
    [property: SwaggerSchema(Nullable = true)]
    string? CorrectAnswer,
    [property: SwaggerSchema(Nullable = false)]
    QuestionType? Type,
    [property: SwaggerSchema(Nullable = false)]
    decimal? XpPoints
);
