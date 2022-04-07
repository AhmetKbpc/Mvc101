using Mvc101.Services.SmsService;
using System.Diagnostics;

namespace Mvc101.Models
{
    public class SonicSmsService : ISmsService
    {

        public SmsStates Send(SmsModel model)
        {
            Debug.Write($"Sonic:{model.TelefonNo} - {model.Mesaj}");
            return SmsStates.Sent;
        }
    }
}
