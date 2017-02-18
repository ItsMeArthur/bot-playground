using BreakingNewsBotByAPI.Utils;
using Microsoft.Bot.Connector;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BreakingNewsBotByAPI.Controllers
{
    public class NotificationsController : ApiController
    {
        public async Task<HttpResponseMessage> Post([FromBody]string message)
        {
            foreach (var subscriber in Subscriptions.SubscribedUsers)
            {
                await SendMessage(message, subscriber.Value);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        public async Task SendMessage(string text, IMessageActivity value)
        {
            Activity storedActivity = (Activity)value;
            Activity reply = storedActivity.CreateReply(text);
            ConnectorClient client = new ConnectorClient(new Uri(storedActivity.ServiceUrl));
            await client.Conversations.ReplyToActivityAsync(reply);
        }
    }
}
