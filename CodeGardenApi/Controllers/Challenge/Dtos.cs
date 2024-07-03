using CodeGardenApi.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace CodeGardenApi.Controllers.Challenge;

public sealed record CreateChallengeDto(
    [property: SwaggerSchema(Nullable = false)]
    ChallengeType ChallengeType,
    [property: SwaggerSchema(Nullable = false)]
    int SectionId,
    [property: SwaggerSchema(Nullable = false)]
    string Content);

public sealed record UpdateChallengeDto(
    [property: SwaggerSchema(Nullable = true)]
    ChallengeType? ChallengeType,
    [property: SwaggerSchema(Nullable = true)]
    int? SectionId,
    [property: SwaggerSchema(Nullable = true)]
    string? Content);

public sealed record ChallengeDtoHelper
{
    public static ChallengeType ToChallengeTypeDto(ChallengeType? challengeType) =>
        challengeType switch
        {
            ChallengeType.MultipleChoice => ChallengeType.MultipleChoice,
            ChallengeType.Question => ChallengeType.Question,
            ChallengeType.CodeSnippet => ChallengeType.CodeSnippet,
            ChallengeType.LearningContent => ChallengeType.LearningContent,
            _ => throw new ArgumentOutOfRangeException(nameof(challengeType), challengeType, null),
        };
}