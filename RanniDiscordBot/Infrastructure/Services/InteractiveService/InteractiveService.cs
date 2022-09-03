using Discord;
using Discord.WebSocket;
using RanniDiscordBot.RanniDiscordBot.Infrastructure.Services.InteractiveService.InteractiveMessage;

namespace RanniDiscordBot.RanniDiscordBot.Infrastructure.Services.InteractiveService;

public class InteractiveService : IDisposable, IInteractiveService
{
    private readonly DiscordSocketClient _client;
    private readonly Dictionary<ulong, IInteractiveMessage> _interactiveMessages;

    public InteractiveService(DiscordSocketClient client)
    {
        _client = client;
        _interactiveMessages = new Dictionary<ulong, IInteractiveMessage>();

        SubscribeInteractiveServiceEvents();
    }

    public void AddInteractMessage(ulong messageId, IInteractiveMessage interactiveMessage)
    {
        _interactiveMessages.Add(messageId, interactiveMessage);
    }

    public void Dispose()
    {
        _client.ReactionAdded -= HandlePageReactionAsync;
        _client.ReactionRemoved -= HandlePageReactionAsync;
    }

    private void SubscribeInteractiveServiceEvents()
    {
        _client.ReactionAdded += HandlePageReactionAsync;
        _client.ReactionRemoved += HandlePageReactionAsync;
    }

    private Task HandlePageReactionAsync(Cacheable<IUserMessage, ulong> message, Cacheable<IMessageChannel, ulong> chanel, SocketReaction reaction)
    {
        if (reaction.UserId == _client.CurrentUser.Id) return Task.CompletedTask;
        if (!_interactiveMessages.TryGetValue(message.Id, out var interactiveMessage))
            return Task.CompletedTask;
        
        _ = Task.Run(async ()
            => await interactiveMessage.Interact(reaction));
        
        return Task.CompletedTask;
    }
}