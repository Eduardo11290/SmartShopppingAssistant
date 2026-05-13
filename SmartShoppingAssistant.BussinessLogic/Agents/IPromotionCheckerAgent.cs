using Microsoft.Agents.AI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartShoppingAssistant.BusinessLogic.Agents
{
    public interface IPromotionCheckerAgent
    {
        ChatClientAgent Build(string cartJson);
    }
}
