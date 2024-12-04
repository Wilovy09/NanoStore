using Grpc.Core;
using UserProtoService;

namespace UserService.Services;

public class ManageUserService : User.UserBase
{
    private readonly ILogger<ManageUserService> _logger;
    public ManageUserService(ILogger<ManageUserService> logger)
    {
        _logger = logger;
    }

    public override Task<RegisterReply> Register(RegisterRequest request, ServerCallContext context)
    {
        // TODO: Agregar lógica para registrar usuario y regresar un token
        return Task.FromResult(new RegisterReply
        {
            Token = $"Email: {request.Email}, Passowrd: {request.Password}"
        });
    }
    public override Task<RegisterReply> Login(RegisterRequest request, ServerCallContext context)
    {
        // TODO: Agregar lógica para buscar usuario y regresar un token
        return Task.FromResult(new RegisterReply
        {
            Token = $"Email: {request.Email}, Passowrd: {request.Password}"
        });
    }
    public override Task<MeReply> Me(MeRequest request, ServerCallContext context)
    {
        // TODO: Agregar lógica para buscar usuario
        return Task.FromResult(new MeReply
        {
            UserId = request.UserId,
            Email = "E",
            Password = "W"
        });
    }
}
