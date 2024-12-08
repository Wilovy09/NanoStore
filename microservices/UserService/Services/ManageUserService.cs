using Grpc.Core;
using UserProtoService;
using UserModel.Models;

namespace UserService.Services;

public class ManageUserService : UserProto.UserProtoBase
{
    private readonly ILogger<ManageUserService> _logger;
    private readonly UserContext _dbContext;
    public ManageUserService(ILogger<ManageUserService> logger, UserContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public override async Task<RegisterReply> Register(RegisterRequest request, ServerCallContext context)
    {
        var existingUser = _dbContext.User.FirstOrDefault(u => u.Email == request.Email);
        if (existingUser != null)
        {
            throw new RpcException(new Status(StatusCode.AlreadyExists, "El email ya esta en uso."));
        }

        var newUser = new User
        {
            Email = request.Email,
            Password = request.Password
        };

        _dbContext.User.Add(newUser);
        await _dbContext.SaveChangesAsync();


        return new RegisterReply
        {
            Token = $"Email: {request.Email}, Passowrd: {request.Password}"
        };
    }
    public override Task<RegisterReply> Login(RegisterRequest request, ServerCallContext context)
    {
        var user = _dbContext.User.FirstOrDefault(u => u.Email == request.Email && u.Password == request.Password);

        if (user == null) throw new RpcException(new Status(StatusCode.PermissionDenied, "Credenciales incorrectas"));

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
