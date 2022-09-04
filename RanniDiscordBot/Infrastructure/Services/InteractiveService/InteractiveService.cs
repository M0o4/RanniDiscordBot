using Discord;
using Discord.WebSocket;
using RanniDiscordBot.RanniDiscordBot.Configuration;
using RanniDiscordBot.RanniDiscordBot.Infrastructure.Services.InteractiveService.InteractiveMessage;
using RanniDiscordBot.RanniDiscordBot.Infrastructure.Services.LoggerService;

namespace RanniDiscordBot.RanniDiscordBot.Infrastructure.Services.InteractiveService;

public class InteractiveService : IDisposable, IInteractiveService
{
    private readonly DiscordSocketClient _client;
    private readonly IServer _server;
    
    private readonly Dictionary<ulong, IInteractiveMessage> _interactiveMessages;
    private readonly ILogger _logger;

    public InteractiveService(DiscordSocketClient client, IServer server, ILogger logger)
    {
        _logger = logger;
        _server = server;
        _client = client;
        _interactiveMessages = new Dictionary<ulong, IInteractiveMessage>();

        AddLoadedData();
        SubscribeInteractiveServiceEvents();
    }

    private void AddLoadedData()
    {
        var config = _server.Config;
        
        if(config.RoleMessageData.RoleMessageId == 0)
            return;
        
        AddInteractMessage(config.RoleMessageData.RoleMessageId, config.RoleMessageData.RoleMessage);
    }

    public void AddInteractMessage(ulong messageId, IInteractiveMessage interactiveMessage) => 
        _interactiveMessages.Add(messageId, interactiveMessage);

    public void Dispose()
    {
        _client.ReactionAdded -= HandleOnReactionAddedAsync;
        _client.ReactionRemoved -= HandleOnReactionRemovedAsync;
    }

    private void SubscribeInteractiveServiceEvents()
    {
        _client.ReactionAdded += HandleOnReactionAddedAsync;
        _client.ReactionRemoved += HandleOnReactionRemovedAsync;
    }

    //TODO: Refactoring
    private Task HandleOnReactionAddedAsync(Cacheable<IUserMessage, ulong> message, Cacheable<IMessageChannel, ulong> chanel, SocketReaction reaction)
    {
        _logger.LogDebug("Reaction added");
        
        if (reaction.UserId == _client.CurrentUser.Id) return Task.CompletedTask;
        if (!_interactiveMessages.TryGetValue(message.Id, out var interactiveMessage))
            return Task.CompletedTask;
        
        _ = Task.Run(async ()
            => await interactiveMessage.OnReactionAddedAsync(message, chanel, reaction));
        
        return Task.CompletedTask;
    }
    
    private Task HandleOnReactionRemovedAsync(Cacheable<IUserMessage, ulong> message, Cacheable<IMessageChannel, ulong> chanel, SocketReaction reaction)
    {
        _logger.LogDebug("Reaction removed");
        
        if (reaction.UserId == _client.CurrentUser.Id) return Task.CompletedTask;
        if (!_interactiveMessages.TryGetValue(message.Id, out var interactiveMessage))
            return Task.CompletedTask;
        
        _ = Task.Run(async ()
            => await interactiveMessage.OnReactionRemovedAsync(message, chanel, reaction));
        
        return Task.CompletedTask;
    }
}