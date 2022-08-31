﻿using Discord;
using Discord.WebSocket;

namespace RanniDiscordBot.RanniDiscordBot.Infrastructure.Services.InteractiveService.PageMessageService;

public class PageMessage
{
    public IUserMessage Message => _message;
    public PageMessage(IUserMessage message,string[] pages)
    {
        _pages = pages;
        _message = message;
    }

    private readonly IUserMessage _message;
    private readonly string[] _pages;
    private int _currentPage = 0;

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