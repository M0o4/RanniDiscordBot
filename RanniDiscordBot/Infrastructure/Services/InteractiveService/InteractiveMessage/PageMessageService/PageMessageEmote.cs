using Discord;

namespace RanniDiscordBot.RanniDiscordBot.Infrastructure.Services.InteractiveService.InteractiveMessage.PageMessageService;

public static class PageMessageEmote
{
    public static IEmote First = new Emoji("⏮");
    public static IEmote Back = new Emoji("◀");
    public static IEmote Next = new Emoji("▶");
    public static IEmote Last = new Emoji("⏭");
    public static IEmote Stop = new Emoji("⏹");
    public static IEmote Jump = new Emoji("🔢");
    public static IEmote Info = new Emoji("ℹ");
    public static IEmote PageEmoji = new Emoji("📄");
}