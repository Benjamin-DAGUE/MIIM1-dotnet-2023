using Microsoft.AspNetCore.Components;

namespace CoursBlazor.Components;

public partial class BenTextField
{
    [Parameter]
    public string Text { get; set; } = string.Empty;

    [Parameter]
    public EventCallback<string> TextChanged { get; set; }

    private void OnTextChange()
    {
        TextChanged.InvokeAsync(Text);
    }
}
