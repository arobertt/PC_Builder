using PC_Builder.Models;
using System.Text.Json;

namespace PC_Builder.Services;

public class BuildAdvisor
{
    private readonly KnowledgeBase _kb;

    public BuildAdvisor(IWebHostEnvironment env)
    {
        var path = Path.Combine(env.ContentRootPath, "Data", "kb.json");
        var json = File.ReadAllText(path);

        _kb = JsonSerializer.Deserialize<KnowledgeBase>(json,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
    }

    public PcConfig? Suggest(string scop, string buget)
    {
        // Forward chaining: find first rule where all premises are true
        var facts = new HashSet<string> { scop, buget };

        var matchedRule = _kb.Reguli
            .FirstOrDefault(r => r.Daca.All(premise => facts.Contains(premise)));

        if (matchedRule == null) return null;

        return _kb.Configuratii.TryGetValue(matchedRule.Atunci, out var config)
            ? config : null;
    }

    public Dictionary<string, string> GetScopuri() => _kb.Scopuri_Disponibile;
    public Dictionary<string, string> GetBugete() => _kb.Niveluri_Buget;
}