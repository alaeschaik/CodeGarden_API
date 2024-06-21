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
    string? UsernameOrEmail,
    [property: SwaggerSchema(Nullable = false)]
    string? Password);

public sealed record LoginResponse(
    [property: SwaggerSchema(Nullable = false)]
    int? Id,
    [property: SwaggerSchema(Nullable = false)]
    string? Token,
    [property: SwaggerSchema(Nullable = false)]
    string ExpiresAt,
    [property: SwaggerSchema(Nullable = false)]
    string? Username);

public sealed record ResetPasswordDto(
    [property: SwaggerSchema(Nullable = false)]
    string? UsernameOrEmail,
    [property: SwaggerSchema(Nullable = false)]
    string? OldPassword,
    [property: SwaggerSchema(Nullable = false)]
    string? NewPassword);

public sealed record UpdateUserDto(
    [property: SwaggerSchema(Nullable = true)]
    string? Username,
    [property: SwaggerSchema(Nullable = true)]
    string? Email,
    [property: SwaggerSchema(Nullable = true)]
    string? Firstname,
    [property: SwaggerSchema(Nullable = true)]
    string? Lastname);

public sealed record TokenResponse(
    string Token,
    string Expiration);