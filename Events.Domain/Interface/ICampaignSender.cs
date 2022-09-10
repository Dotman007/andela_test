using Events.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Domain.Interface
{
    public interface ICampaignSender
    {
        List<EmailCampaign> AddToEmail(List<EmailCampaign> emailCampaign);
    }
}
