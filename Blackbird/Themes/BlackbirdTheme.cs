using MudBlazor;

namespace Blackbird.Themes
{
    public static class BlackbirdTheme
    {
        public static MudTheme Create()
        {
            return new MudTheme
            {
                Palette = new PaletteLight
                {
                    Primary = MudBlazor.Colors.DeepPurple.Default,
                    Secondary = MudBlazor.Colors.Green.Accent4,
                    AppbarBackground = MudBlazor.Colors.DeepPurple.Default,
                },
                PaletteDark = new PaletteDark
                {
                    Primary = MudBlazor.Colors.DeepPurple.Lighten1,
                },
                Typography = new Typography()
                {
                    Default = new Default()
                    {
                        FontFamily = new[] { "Roboto", "Helvetica", "Arial", "sans-serif" },
                    },
                    H1 = new H1()
                    {
                        FontFamily = new[] { "Roboto", "Helvetica", "Arial", "sans-serif" },
                    },
                    // Add other font options for H2, H3, etc., as needed
                },
                LayoutProperties = new LayoutProperties
                {
                    DefaultBorderRadius = "4px",
                },
            };
        }
    }
}
