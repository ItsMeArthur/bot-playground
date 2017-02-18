using BreakingNewsBotByAPI.Utils;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Threading.Tasks;

namespace BreakingNewsBotByAPI.Dialogs
{
    public class RootDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceived);
        }

        public async Task MessageReceived(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            IMessageActivity message = await result;
            string msg = string.Empty;

            if (message.Text == "subscribe")
            {
                Subscriptions.SubscribedUsers.Add(message.From.Id, message);
                msg = "You was subscribed to the news";
            }
            else
            {
                Subscriptions.SubscribedUsers.Remove(message.From.Id);
                msg = "You was unsubscribed from the news";
            }

            await context.PostAsync(msg);
        }
    }
}