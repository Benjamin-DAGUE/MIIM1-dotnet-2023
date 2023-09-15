using Microsoft.EntityFrameworkCore;
using UnicornManager.DBLib;

namespace UnicornManager.Pages;

public partial class UnicornsList
{
    private List<Unicorn> _Unicorns = new List<Unicorn>();
    private bool _IsLoading = false;

    protected override async Task OnInitializedAsync()
    {
        _IsLoading = true;

        UnicornDbContext context = await ContextFactory.CreateDbContextAsync();
        _Unicorns = await context.Unicorns.ToListAsync();

        _IsLoading = false;

    }
}
