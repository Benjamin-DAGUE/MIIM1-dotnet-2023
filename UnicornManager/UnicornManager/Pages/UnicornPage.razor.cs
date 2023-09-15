using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using UnicornManager.DBLib;

namespace UnicornManager.Pages;

public partial class UnicornPage
{
    private Unicorn? _Unicorn;
    private bool _IsLoading = false;

    [Parameter]
    public int Identifier { get; set; }

    protected override async Task OnInitializedAsync()
    {
        _IsLoading = true;

        UnicornDbContext context = await ContextFactory.CreateDbContextAsync();
        _Unicorn = await context.Unicorns.FirstOrDefaultAsync(u => u.Identifier == Identifier);

        _IsLoading = false;
    }
}
