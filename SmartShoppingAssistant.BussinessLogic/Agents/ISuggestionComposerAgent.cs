using Microsoft.Agents.AI;
using SmartShoppingAssistant.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartShoppingAssistant.BusinessLogic.Agents
{
    public interface ISuggestionComposerAgent
    {
        ChatClientAgent Build(string cartJson, string categoriesJson);
    }
}
