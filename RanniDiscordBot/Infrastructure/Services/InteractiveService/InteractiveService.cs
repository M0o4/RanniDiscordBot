using Discord;
using Discord.WebSocket;
using RanniDiscordBot.RanniDiscordBot.Infrastructure.Services.InteractiveService.PageMessageService;

namespace RanniDiscordBot.RanniDiscordBot.Infrastructure.Services.InteractiveService;

public class InteractiveService : IDisposable, IInteractiveService
{
    private readonly DiscordSocketClient _client;
    private readonly Dictionary<ulong, PageMessage> _pageMessages;

    public InteractiveService(DiscordSocketClient client)
    {
        _client = client;
        _pageMessages = new Dictionary<ulong, PageMessage>();

        SubscribeInteractiveServiceEvents();
    }

    public void AddPageMessage(ulong messageId, PageMessage pageMessage)
    {
        _pageMessages.Add(messageId, pageMessage);
    }

    public void Dispose()
    {
        UnSubscribeInteractiveServiceEvents();
    }

    private void SubscribeInteractiveServiceEvents()
    {
        SubscribePageReactionEvents();
    }

    private void SubscribePageReactionEvents() 
    {
        _client.ReactionAdded += HandlePageReactionAsync;
        _client.ReactionRemoved += HandlePageReactionAsync;
    }

    private void UnSubscribeInteractiveServiceEvents()
    {
        UnSubscribePageReactionEvents();
    }

    private void UnSubscribePageReactionEvents()
    {
        _client.ReactionAdded -= HandlePageReactionAsync;
        _client.ReactionRemoved -= HandlePageReactionAsync;
    }

    private Task HandlePageReactionAsync(Cacheable<IUserMessage, ulong> message, Cacheable<IMessageChannel, ulong> chanel, SocketReaction reaction)
    {
        if (reaction.UserId == _client.CurrentUser.Id) return Task.CompletedTask;
        if (!_pageMessages.TryGetValue(message.Id, out var pageMessage))
        {
            return Task.CompletedTask;
        }
            
        _ = Task.Run(async () =>
        {
            await pageMessage.Message.ModifyAsync(msg => msg.Content = pageMessage.ChangePage(reaction));
        });
        return Task.CompletedTask;
    }
}