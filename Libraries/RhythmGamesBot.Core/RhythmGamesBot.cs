using System;

using DSharpPlus;
using Microsoft.Extensions.Logging;
using RhythmGamesBot.Utils;

namespace RhythmGamesBot.Core
{
    public class RhythmGamesBot
    {
        private static Option<DiscordClient> BotInstance { get; set; }
        private const DiscordIntents Intents = DiscordIntents.All;

        public RhythmGamesBot(Option<DiscordConfiguration> discordConfiguration)
        {
            DiscordConfiguration configuration = discordConfiguration.IsSome() ? discordConfiguration.Unwrap() : new DiscordConfiguration
            {
                // We need to put fields here if we were to use the default configuration (aka the one used for actual production use),
                // the reasoning behind the Optional configuration is that we can tweak the configuration for testing purposes.

                //Bot Configurations
                Token = new BotSecrets().token, //class containing the token, you can impliment your own security system or data management.
                TokenType = TokenType.Bot,

                //Since the bot is going to use discord events in need to be able to use all intents.
                Intents = DiscordIntents.All,

                //logging
                MinimumLogLevel = LogLevel.Debug,
                LogTimestampFormat = "MMM dd yyyy - hh:mm:ss tt" //time on log set as example Jan 01 2021 - 07:07:07 PM

            };

            BotInstance = Option<DiscordClient>.Some(new DiscordClient(configuration));
        }
    }
}