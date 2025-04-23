using MudBlazor;

namespace HomeManagment.Client.Themes;

public static class HomeManagmentTheme
{
    public static MudTheme Instance = new MudTheme()
    {
        PaletteLight = new PaletteLight
        {
            Primary = "#181b32",
            Secondary = "#FFD54F",
           
            // …otros overrides
        },
        PaletteDark = new PaletteDark
        {
            Primary = "#80CBC4",
            Secondary = "#FFECB3",
            Background = "#121212",
            AppbarBackground = "#263238"
        }
    };
}
