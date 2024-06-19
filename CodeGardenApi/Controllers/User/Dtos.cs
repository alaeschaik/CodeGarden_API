using Swashbuckle.AspNetCore.Annotations;

namespace CodeGardenApi.Controllers.User;

public sealed record RegisterUserDto(
    [property: SwaggerSchema(Nullable = false)]
    string? Username,
    [property: SwaggerSchema(Nullable = false)]
    string? Email,
    [property: SwaggerSchema(Nullable = false)]
    string? Password,
    [property: SwaggerSchema(Nullable = false)]
    string? Firstname,
    [property: SwaggerSchema(Nullable = false)]
    string? Lastname);

public sealed record LoginModel(
    [property: SwaggerSchema(Nullable = false)]
    string? Email,
    [property: SwaggerSchema(Nullable = false)]
    string? Password);