namespace CodeGardenApi.Controllers.Discussions;

public sealed record CreateDiscussionDto(
    string Title,
    string Content,
    int UserId);

public sealed record UpdateDiscussionDto(
    string Title,
    string Content);

public sealed record CreateDiscussionContributionDto(
    int UserId,
    string Content);

public sealed record UpdateDiscussionContributionDto(
    string Content);