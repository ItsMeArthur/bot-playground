using Microsoft.Bot.Connector;
using System.Collections.Generic;

namespace BreakingNewsBotByAPI.Utils
{
    public static class Subscriptions
    {
        public static Dictionary<string, IMessageActivity> SubscribedUsers = new Dictionary<string, IMessageActivity>();
    }
}