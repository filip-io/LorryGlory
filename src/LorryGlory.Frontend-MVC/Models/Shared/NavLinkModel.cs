namespace LorryGlory_Frontend_MVC.Models.Shared
{
    public class NavLinkModel
    {
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Text { get; set; }
        public string IconClass { get; set; }
        public bool IsButton { get; set; }
        public string CustomClass { get; set; }
    }
}