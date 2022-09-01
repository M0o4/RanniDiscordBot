using Discord;

namespace RanniDiscordBot.RanniDiscordBot.Infrastructure.Services.InteractiveService.InteractiveMessageService;

public static class RoleMessageEmote
{
    public static readonly IEmote One = new Emoji(":one:");
    public static readonly IEmote Two = new Emoji(":two:");
    public static readonly IEmote Three = new Emoji(":three:");
    public static readonly IEmote Four = new Emoji(":four:");
    public static readonly IEmote Five = new Emoji(":five:");
}