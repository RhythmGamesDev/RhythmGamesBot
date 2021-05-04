﻿using System;

using DSharpPlus;

using RhythmGamesBot.Utils;

namespace RhythmGamesBot.Core
{
    public class RhythmGamesBot
    {
        private static DiscordClient? BotInstance { get; set; }
        private const DiscordIntents Intents = DiscordIntents.All;

        public RhythmGamesBot(Option<DiscordConfiguration> discordConfiguration)
        {
            DiscordConfiguration configuration = discordConfiguration.IsSome() ? discordConfiguration.Unwrap() : new DiscordConfiguration
            {
                // We need to put fields here if we were to use the default configuration (aka the one used for actual production use),
                // the reasoning behind the Optional configuration is that we can tweak the configuration for testing purposes.
            };

            BotInstance = new DiscordClient(configuration);
        }
    }
}