using CodeGardenApi.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace CodeGardenApi.Controllers.Challenge;

public sealed record CreateChallengeDto(
    [property: SwaggerSchema(Nullable = false)]
    ChallengeTypeDto ChallengeType,
    [property: SwaggerSchema(Nullable = false)]
    int SectionId,
    [property: SwaggerSchema(Nullable = false)]
    string Content);

public sealed record UpdateChallengeDto(
    [property: SwaggerSchema(Nullable = true)]
    ChallengeTypeDto? ChallengeType,
    [property: SwaggerSchema(Nullable = true)]
    int? SectionId,
    [property: SwaggerSchema(Nullable = true)]
    string? Content);

public enum ChallengeTypeDto
{
    MultipleChoice,
    Question,
    CodeSnippet,
}

public sealed record ChallengeDtoHelper
{
    public static ChallengeType ToChallengeTypeDto(ChallengeTypeDto? challengeType) =>
        challengeType switch
        {
            ChallengeTypeDto.MultipleChoice => ChallengeType.MultipleChoice,
            ChallengeTypeDto.Question => ChallengeType.Question,
            ChallengeTypeDto.CodeSnippet => ChallengeType.CodeSnippet,
            _ => throw new ArgumentOutOfRangeException(nameof(challengeType), challengeType, null),
        };
}