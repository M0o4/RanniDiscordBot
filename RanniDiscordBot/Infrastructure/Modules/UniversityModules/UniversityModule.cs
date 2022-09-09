using System.Runtime.InteropServices;
using Discord;
using Discord.Commands;
using RanniDiscordBot.RanniDiscordBot.Infrastructure.Services.InteractiveService.InteractiveMessage.RoleMessageService.
    Utils;
using RanniDiscordBot.RanniDiscordBot.Infrastructure.Services.LoggerService;

namespace RanniDiscordBot.RanniDiscordBot.Infrastructure.Modules.UniversityModules;

public class UniversityModule : ModuleBase<SocketCommandContext>
{
    private readonly ILogger _logger;

    public UniversityModule(ILogger logger)
        => _logger = logger;

    [Command("ft")]
    [Summary("Печатает список факультетов или выдает роль, если указать название роли через пробел")]
    public Task PrintAddFacultiesRole([Summary("Название роли")] string roleName = "")
    {
        var roles = Context.Guild.Roles.Where(r => !UniversityRoles.ExcludeRoles.Contains(r.Name));
        var rolesName = roles.Select(r => r.Name).ToList();

        if (string.IsNullOrEmpty(roleName))
        {
            var joinsRoles = string.Join(",\n", rolesName);
            return ReplyAsync(joinsRoles);
        }

        if (!rolesName.Contains(roleName))
            return ReplyAsync($"Роли `{roleName}` не существует.");

        var role = Context.Guild.Roles.FirstOrDefault(r => r.Name == roleName);
        var user = Context.User as IGuildUser;

        if (user == null || role == null)
            return ReplyAsync("Произошла ошибка");

        _logger.LogDebug($"Роль {role.Name} выдана {user.Nickname}");

        return AddRoleAndRemoveOld(user, role);
    }

    private Task AddRoleAndRemoveOld(IGuildUser user, IRole role)
    {
        //TODO: Fix Remove old role

        //_ = Task.Run(async () =>
        //{
        //    _logger.LogDebug("Ищу роль");
        //    foreach (var r in user.Guild.Roles)
        //    {
        //        if (!UniversityRoles.ExcludeRoles.Contains(r.Name)) continue;
        //        await user.RemoveRoleAsync(r);
        //        break;
        //    }

        //    _logger.LogDebug("Роль удалена");
        //});

        return user.AddRoleAsync(role);
    }
}