using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.BackgroundJobs;

namespace Acme.BookStore.EmailSending
{
    [BackgroundJobName("emails")]
    public class EmailSendingArgs
    {
        public string EmailAddress { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
