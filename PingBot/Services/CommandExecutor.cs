using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using PingBot.Commands;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace PingBot.Services
{
    public class CommandExecutor:ICommandExecutor
    {
        private readonly  List<BaseCommand> _commands;
        private BaseCommand _lastCommand;
        private async Task ExecuteCommand(string commandName, Update update)
        {
            _lastCommand = _commands.First(x => x.Name == commandName);
            await _lastCommand.ExecuteAsync(update);
        }

        public CommandExecutor(IServiceProvider serviceProvider)
        {
            _commands = serviceProvider.GetServices<BaseCommand>().ToList();
        }
        public async Task Execute(Update update)
        {
            if(update?.Message?.Chat == null && update?.CallbackQuery == null)
                return;
            if (update.Type == UpdateType.Message)
            {
                switch (update.Message?.Text)
                {
                    
                    case "Отобразить камеру":
                        await ExecuteCommand(CommandNames.GetCamCommand, update);
                        return;
                }
            }
            if (update.Message != null && update.Message.Text.Contains(CommandNames.StartCommand))
            {
                await ExecuteCommand(CommandNames.StartCommand, update);
                return;
            }
           
        }
    }
}