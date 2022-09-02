﻿using System.Reflection;
using Discord.Commands;
using Discord.WebSocket;
using RanniDiscordBot.RanniDiscordBot.Infrastructure.Services.LoggerService;

namespace RanniDiscordBot.RanniDiscordBot.Infrastructure.Services;

public class CommandHandler : ICommandHandler
{
    private readonly DiscordSocketClient _client;
    private readonly CommandService _commands;
    private readonly IServiceProvider _services;
    private readonly ILogger _logger;

    public CommandHandler(DiscordSocketClient client, CommandService commands, IServiceProvider services, ILogger logger)
    {
        _logger = logger;
        _client = client;
        _commands = commands;
        _services = services;
    }

    public async Task InstallCommandsAsync()
    {
        _client.MessageReceived += HandleCommandAsync;
        
        await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), 
            _services);
    }

    private async Task HandleCommandAsync(SocketMessage message)
    {
        if (message is not SocketUserMessage userMessage) return;

        int argPos = 0;

        // _logger.LogDebug("start Handle");
        // _logger.LogDebug($"userMessage.HasCharPrefix: {!userMessage.HasCharPrefix('!', ref argPos)}");
        // _logger.LogDebug($"userMessage.HasMentionPrefix: {userMessage.HasMentionPrefix(_client.CurrentUser, ref argPos)}");
        // _logger.LogDebug($"{userMessage}");

        if (!(userMessage.HasCharPrefix('!', ref argPos) || 
              userMessage.HasMentionPrefix(_client.CurrentUser, ref argPos)) ||
            userMessage.Author.IsBot)
            return;

        //_logger.LogDebug("Handle");
        
        var context = new SocketCommandContext(_client, userMessage);

        await _commands.ExecuteAsync(
            context: context, 
            argPos: argPos, 
            services: _services);
    }
}