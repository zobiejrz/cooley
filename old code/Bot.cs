using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DiscordBot
{
    class Program
    {
        static void Main(string[] args) => new Program().Start();
        private DiscordClient _client;
        public void Start()
        {
            _client = new DiscordClient();
            _client.MessageReceived += async (s, e) =>
            {
                if (!e.Message.IsAuthor)
                    await e.Channel.SendMessage(e.Message.Text);
            };
            _client.ExecuteAndWait(async () => {
                await _client.Connect("MzB4tDI3MjYxMTQ2MjM0ODgw.C-f7yg.odsFzgy0ZISJdp0-d2-ebEmAz5Y", TokenType.Bot);
            });
            //set bot prefix
            _client.UsingCommands(x => {
                x.PrefixChar = '~'; //find how to set 2 character as prefix ";/"
                x.HelpMode = HelpMode.Public;
            });
             
            _client.GetService<CommandService>().CreateCommand("name") //Create a command
                .Alias(new string[] { "cmd", "command" }) //add 2 aliases, so it can be run with ~cmd and ~command
                .Description("Command description.") //add description, it will be shown when ~help is used
                .Parameter("ParameterName", ParameterType.Required) //as an argument, we have a person we want to greet
                .Do(async e =>
                {
                    await e.Channel.SendMessage($"{e.User.Name} Command reply {e.GetArg("ParameterName")}"); //sends a message to channel with the given text
                });
            //TODO: Find how to create a Channel, learn more about Parameters and make this work!
            _client.GetService<CommandService>().CreateGroup("make", make =>
            {
                make.CreateCommand("textch") //~make textch
                .Alias(new string[] { "textch" })
                .Description("Creates a new Text Channel.")// Not work yet
                .Parameter("???", ParameterType.Required)
                .Do(async e =>
               {
                   await e.Channel.SendMessage($"{e.User.Name} i donno wtf i'm doing {e.GetArg("???")}");
               });
                make.CreateCommand("voicech") //~make voicech
                .Alias(new string[] { "voicech" })
                .Description("Creates a new Voice Channel.") // not work yet
                .Parameter("????", ParameterType.Required)
                .Do(async e =>
               {
                   await e.Channel.SendMessage($"{e.User.Name} change it later {e.GetArg("???")}");
               });
            });
            //exemple//we would run our commands with ~do greet X and ~do bye X
            _client.GetService<CommandService>().CreateGroup("do", cgb =>
            {
                cgb.CreateCommand("greet")
                        .Alias(new string[] { "gr", "hi" })
                        .Description("Greets a person.")
                        .Parameter("GreetedPerson", ParameterType.Required)
                        .Do(async e =>
                        {
                            await e.Channel.SendMessage($"{e.User.Name} greets {e.GetArg("GreetedPerson")}");
                        });
                cgb.CreateCommand("bye")
                        .Alias(new string[] { "bb", "gb" })
                        .Description("Greets a person.")
                        .Parameter("GreetedPerson", ParameterType.Required)
                        .Do(async e =>
                        {
                            await e.Channel.SendMessage($"{e.User.Name} says goodbye to {e.GetArg("GreetedPerson")}");
                        });
            });
        }
    }
}
