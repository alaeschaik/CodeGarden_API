namespace CodeGardenApi.Controllers.Contributions;

public sealed record CreateContributionDto(
    int DiscussionId,
    int UserId,
    string Content);