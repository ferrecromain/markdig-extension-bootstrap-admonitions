namespace Markdig.Extensions.Admonitions
{
    public class AdmonitionTemplate
    {
        public string BsAlertType { get; set; }
        public string BsIconType { get; set; }
        public string BsAlertHeading { get; set; }
        public string Type { get; set; }

        public AdmonitionTemplate(string type, string bsAlertType, string bsIconType, string bsAlertHeading)
        {
            Type = type;
            BsAlertType = bsAlertType;
            BsIconType = bsIconType;
            BsAlertHeading = bsAlertHeading;
        }
    }
}
