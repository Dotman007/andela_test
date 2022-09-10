using Events.Domain.Entities;
using Events.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Domain.Services
{
    public class CampaignEmailSender: ICampaignSender
    {
        public List<EmailCampaign> AddToEmail(List<EmailCampaign> emailCampaign)
        {
            return emailCampaign;
        }
    }
}
