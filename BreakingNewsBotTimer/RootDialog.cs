using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;

namespace BreakingNewsBot
{
    public class RootDialog : IDialog<Object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceived);
        }

        private async Task MessageReceived(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            IMessageActivity message = await argument;
            string msg = string.Empty;

            if (message.Text == "subscribe")
            {
                MessagesController.SubscribedUsers.Add(message.From.Id, message);
                msg = "You was subscribed to the news";
            }
            else
            {
                MessagesController.SubscribedUsers.Remove(message.From.Id);
                msg = "You was unsubscribed from the news";
            }

            await context.PostAsync(msg);
        }
    }
}