using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PC_Builder.Models;
using PC_Builder.Services;

namespace PC_Builder.Pages;

public class IndexModel : PageModel
{
    private readonly BuildAdvisor _advisor;

    public IndexModel(BuildAdvisor advisor) => _advisor = advisor;

    [BindProperty] public string SelectedScop { get; set; } = "";
    [BindProperty] public string SelectedBuget { get; set; } = "";

    public PcConfig? Result { get; set; }
    public Dictionary<string, string> Scopuri { get; set; } = new();
    public Dictionary<string, string> Bugete { get; set; } = new();

    public void OnGet()
    {
        Scopuri = _advisor.GetScopuri();
        Bugete = _advisor.GetBugete();
    }

    public void OnPost()
    {
        Scopuri = _advisor.GetScopuri();
        Bugete = _advisor.GetBugete();
        Result = _advisor.Suggest(SelectedScop, SelectedBuget);
    }
}