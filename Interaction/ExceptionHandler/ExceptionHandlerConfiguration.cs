using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Utility.Interaction.ExceptionHandler
{
    public class ExceptionHandlerConfiguration
    {
        public ExceptionHandlerConfiguration()
        {
        }

        public bool showTechnicalInformation { get; set; }
        public string contactEmailAddress { get; set; }
        public string gitHubRepository { get; set; }
        public string bugTracker { get; set; }
    }
}
