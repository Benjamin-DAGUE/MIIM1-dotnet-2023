namespace UnicornManager.Layouts;

public partial class MainLayout
{
    private bool _IsDarkMode;
    private bool _Open = false;

    void ToggleDrawer()
    {
        _Open = !_Open;
    }
}
