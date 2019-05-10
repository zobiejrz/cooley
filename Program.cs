using System;
using Discord;

namespace dnd_character_storage
{
    public class Cooley
    {
        DiscordClient client;

        public Cooley()
        {
            client = new DiscordClient(input =>
            input.LogLevel = LogSeverity.Info;
            input.LogHandler = Log();
        });

        client.ExecuteAndWait(asynce () =>
        {
            await client.Connect("NTc2MjYzODE4ODA0NTkyNjYy.XNT9mw.Tdficz92oSoqAJt38512Xydb8QM", TokenType.Bot);
        });
    }

    private void Log(object sender, LogMessageEventArgse e)
    {
        Console.WriteLine(e.Message);
    }
}