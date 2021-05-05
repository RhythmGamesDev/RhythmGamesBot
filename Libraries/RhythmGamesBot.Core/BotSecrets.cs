namespace RhythmGamesBot.Core
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Text.Json;

    class BotSecrets
    {
        private static string jsonString = File.ReadAllText("");
        private static BotSecretsJson botSecrets = JsonSerializer.Deserialize<BotSecretsJson>(json: jsonString);
        public static string token = botSecrets.token;
    }
}
