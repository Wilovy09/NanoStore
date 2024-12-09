using Grpc.Core;
using PostProtoService;
using PostModel.Models;

namespace PostService.Services;

public class ManagePostService : PostProto.PostProtoBase
{
    private readonly ILogger<ManagePostService> _logger;
    private readonly PostContext _dbContext;
    public ManagePostService(ILogger<ManagePostService> logger, PostContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public override async Task<CreateReply> Create(CreateRequest request, ServerCallContext context)
    {

        // No funciona
        var owner = await _dbContext.Post.FromSql($"SELECT * FROM User WHERE id = {request.OwnerId}");

        var post = new Post
        {
            owner_id = request.OwnerId,
            title = request.Title,
            description = request.Description,
            image = request.Image,
        };
        _dbContext.Post.Add(post);
        await _dbContext.SaveChangesAsync();

        return Task.FromResult(new CreateReply
        {
            OwnerId = request.OwnerId,
            Image = request.Image,
            Title = request.Title,
            Description = request.Description
        });
    }
}
