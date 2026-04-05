namespace PC_Builder.Models;

public class PcConfig
{
    public string Descriere { get; set; } = "";
    public string Cpu { get; set; } = "";
    public string Gpu { get; set; } = "";
    public string Ram { get; set; } = "";
    public string Stocare { get; set; } = "";
    public string Placa_De_Baza { get; set; } = "";
    public string Sursa { get; set; } = "";
    public string Pret_Estimat { get; set; } = "";
}

public class Rule
{
    public string Id { get; set; } = "";
    public List<string> Daca { get; set; } = new();
    public string Atunci { get; set; } = "";
}

public class KnowledgeBase
{
    public List<string> Premise_Posibile { get; set; } = new();
    public List<Rule> Reguli { get; set; } = new();
    public Dictionary<string, PcConfig> Configuratii { get; set; } = new();
    public Dictionary<string, string> Niveluri_Buget { get; set; } = new();
    public Dictionary<string, string> Scopuri_Disponibile { get; set; } = new();
}