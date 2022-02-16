namespace Markdig.Extensions.Bootstrap.Admonitions
{
    public class BootstrapAdmonitionTemplate
    {
        public string BsAlertType { get; set; }
        public string BsIconType { get; set; }
        public string BsAlertHeading { get; set; }
        public string Type { get; set; }

        public BootstrapAdmonitionTemplate(string type, string bsAlertType, string bsIconType, string bsAlertHeading)
        {
            Type = type;
            BsAlertType = bsAlertType;
            BsIconType = bsIconType;
            BsAlertHeading = bsAlertHeading;
        }
    }
}
