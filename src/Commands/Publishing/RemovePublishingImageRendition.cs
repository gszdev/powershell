﻿using System.Linq;
using System.Management.Automation;
using Microsoft.SharePoint.Client;

using PnP.PowerShell.Commands.Base.PipeBinds;
using Resources = PnP.PowerShell.Commands.Properties.Resources;


namespace PnP.PowerShell.Commands.Publishing
{
    [Cmdlet(VerbsCommon.Remove, "PublishingImageRendition")]
    
    
    public class RemovePublishingImageRendition : PnPWebCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public ImageRenditionPipeBind Identity;

        [Parameter(Mandatory = false)]
        public SwitchParameter Force;

        protected override void ExecuteCmdlet()
        {
            var rendition = Identity.GetImageRendition(SelectedWeb);

            if (rendition != null)
            {
                if (Force ||
                    ShouldContinue(string.Format(Resources.RemoveImageRenditionWithName0, rendition.Name), Resources.Confirm))
                {
                    SelectedWeb.RemovePublishingImageRendition(rendition.Name);
                }
            }
        }
    }
}
