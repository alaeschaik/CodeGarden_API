using CodeGardenApi.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace CodeGardenApi.Controllers.UserModule;

public record CreateUserModuleDto(
    [property: SwaggerSchema(Nullable = false)]
    int? UserId,

    [property: SwaggerSchema(Nullable = false)]
    int? ModuleId,

    [property: SwaggerSchema(Nullable = false)]
    ModuleState? State
);

public record UpdateUserModuleDto(

    [property: SwaggerSchema(Nullable = false)]
    int? Id,

    [property: SwaggerSchema(Nullable = false)]
    int? UserId,

    [property: SwaggerSchema(Nullable = false)]
    int? ModuleId,

    [property: SwaggerSchema(Nullable = false)]
    ModuleState? State
);
