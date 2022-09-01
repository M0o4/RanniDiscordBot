using Discord;
using Discord.WebSocket;

namespace RanniDiscordBot.RanniDiscordBot.Infrastructure.Services.InteractiveService.InteractiveMessage.PageMessageService;

public class PageMessage : IInteractiveMessage
{
    public IUserMessage Message => _message;

    private readonly IUserMessage _message;

    private readonly string[] _pages;

    private int _currentPage = 0;

    public PageMessage(IUserMessage message,string[] pages)
    {
        _pages = pages;
        _message = message;
    }

    public Task Interact(SocketReaction reaction) => 
        _message.ModifyAsync(msg => msg.Content = ChangePage(reaction));

    public string ChangePage(SocketReaction reaction)
    {
        switch (reaction.Emote)
        {
            case var _ when Equals(reaction.Emote, PageMessageEmote.Back):
                ChangePageBack();
                break;
            case var _ when Equals(reaction.Emote, PageMessageEmote.Next):
                ChangePageNext();
                break;
        }

        var page = "```";
        page += _pages[_currentPage];
        page += "```";
        page += $"{PageMessageEmote.PageEmoji}: {_currentPage+1}/{_pages.Length}";
        return page;
    }

    private void ChangePageBack()
    {
        if(_currentPage == 0)
            return;
        _currentPage--;
    }

    private void ChangePageNext()
    {
        if(_currentPage == _pages.Length -1)
            return;
        _currentPage++;
    }
}