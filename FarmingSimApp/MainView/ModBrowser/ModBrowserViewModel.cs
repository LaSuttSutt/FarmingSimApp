using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Xml;
using FarmingSimApp.Shared.View;
using ReactiveUI;

namespace FarmingSimApp.MainView.ModBrowser;

public class ModBrowserViewModel : ViewModelBase
{
    private string _text = "";
    private HttpClient _client = new();

    public string Text
    {
        get => _text;
        set => this.RaiseAndSetIfChanged(ref _text, value);
    }

    public ModBrowserViewModel()
    {
        LoadMod();
    }

    private async void LoadMod()
    {
        var modId = "250225"; // "294683" "228522" "250225"
        var url = $@"https://www.farming-simulator.com/mod.php?lang=de&country=ch&mod_id={modId}&title=fs2022";

        var text = await _client.GetStringAsync(url);

        var searchString = @"<div class=""table-cell""><b>Version</b></div>
                        <div class=""table-cell"">";

        var start = text.IndexOf(searchString, StringComparison.Ordinal);
        var versionText = text.Substring(start + searchString.Length, 20);
        var versionEnd = versionText.IndexOf('<');

        Version version = new Version(versionText.Substring(0, versionEnd));
        Text = version.ToString();
    }
}