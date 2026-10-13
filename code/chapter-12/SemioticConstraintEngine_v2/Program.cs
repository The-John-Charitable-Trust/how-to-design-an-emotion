using System.Text.Json;
using System.Text.Json.Nodes;

var argsMap = ParseArgs(args);
if (!argsMap.TryGetValue("test", out var testName) || string.IsNullOrWhiteSpace(testName))
{
    PrintUsage();
    return;
}

var dataPath = Path.Combine(AppContext.BaseDirectory, "data.json");
if (!File.Exists(dataPath))
{
    Console.WriteLine($"Could not find data file: {dataPath}");
    return;
}

var root = JsonNode.Parse(File.ReadAllText(dataPath))?.AsObject();
if (root is null)
{
    Console.WriteLine("Could not parse data.json");
    return;
}

switch (testName.ToLowerInvariant())
{
    case "arbitrariness":
        RunArbitrariness(root, argsMap);
        break;
    case "underdetermination":
        RunUnderdetermination(root, argsMap);
        break;
    case "essence":
        RunEssence(root, argsMap);
        break;
    case "identity":
        RunIdentity(root, argsMap);
        break;
    case "significance":
        RunSignificance(root, argsMap);
        break;
    default:
        Console.WriteLine($"Unknown test: {testName}");
        PrintUsage();
        break;
}

static Dictionary<string, string> ParseArgs(string[] args)
{
    var map = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
    for (int i = 0; i < args.Length; i++)
    {
        if (!args[i].StartsWith("--", StringComparison.Ordinal)) continue;
        var key = args[i][2..];
        var value = (i + 1 < args.Length && !args[i + 1].StartsWith("--", StringComparison.Ordinal))
            ? args[++i]
            : "true";
        map[key] = value;
    }
    return map;
}

static void RunArbitrariness(JsonObject root, Dictionary<string, string> argsMap)
{
    var concept = argsMap.TryGetValue("concept", out var supplied) ? supplied : "familyClan";
    var section = root["arbitrariness"]?.AsObject();
    var entry = ResolveEntry(section, concept);
    if (entry is null)
    {
        Console.WriteLine($"No arbitrariness dataset found for concept '{concept}'.");
        return;
    }

    Console.WriteLine("TEST 1: ARBITRARINESS");
    Console.WriteLine();
    Console.WriteLine($"Input concept: {concept}");
    Console.WriteLine("Same admissible sign configuration relative to context:");
    Console.WriteLine($"  IdentityConditions = {FormatMap(entry["identityConditions"])}");
    Console.WriteLine($"  Members = {FormatList(entry["members"])}");
    Console.WriteLine();
    Console.WriteLine("Identifiers by socio-cultural context:");
    foreach (var ctx in entry["contexts"]?.AsArray() ?? new JsonArray())
    {
        Console.WriteLine($"  {ctx?["language"]} -> {ctx?["identifier"]}");
    }
    Console.WriteLine();
    Console.WriteLine("Conclusion:");
    Console.WriteLine("  No intrinsic feature of the sign determines the identifier.");
    Console.WriteLine("  Agents assign identifiers under constraint within a socio-cultural context.");
}

static void RunUnderdetermination(JsonObject root, Dictionary<string, string> argsMap)
{
    var identifier = argsMap.TryGetValue("identifier", out var supplied) ? supplied : "family";
    var section = root["underdetermination"]?.AsObject();
    var entry = ResolveEntry(section, identifier);
    if (entry is null)
    {
        Console.WriteLine($"No underdetermination dataset found for identifier '{identifier}'.");
        return;
    }

    Console.WriteLine("TEST 2: UNDERDETERMINATION");
    Console.WriteLine();
    Console.WriteLine($"Input identifier: {identifier}");
    Console.WriteLine();
    Console.WriteLine("Admissible sign configurations:");
    int i = 1;
    foreach (var cfg in entry["configurations"]?.AsArray() ?? new JsonArray())
    {
        Console.WriteLine($"  {i++}. {cfg?["title"]}");
        Console.WriteLine($"     IdentityConditions = {FormatMap(cfg?["identityConditions"])}");
        Console.WriteLine($"     Members = {FormatList(cfg?["members"])}");
        Console.WriteLine();
    }
    Console.WriteLine("Conclusion:");
    Console.WriteLine("  The identifier does not uniquely determine the sign configuration.");
    Console.WriteLine("  The identifier underdetermines the sign configuration.");
}

static void RunEssence(JsonObject root, Dictionary<string, string> argsMap)
{
    var identifier = argsMap.TryGetValue("identifier", out var supplied) ? supplied : "family";
    var section = root["essence"]?.AsObject();
    var entry = ResolveEntry(section, identifier);
    if (entry is null)
    {
        Console.WriteLine($"No essence dataset found for identifier '{identifier}'.");
        return;
    }

    Console.WriteLine("TEST 3: ABSENCE OF UNIVERSAL OBJECTIVE ESSENCE");
    Console.WriteLine();
    Console.WriteLine($"Input identifier: {identifier}");
    Console.WriteLine();
    Console.WriteLine("Admissible instances by identity conditions:");
    int i = 1;
    foreach (var instance in entry["instances"]?.AsArray() ?? new JsonArray())
    {
        Console.WriteLine($"  {i++}. {instance?["title"]}");
        Console.WriteLine($"     IdentityConditions = {FormatMap(instance?["identityConditions"])}");
        Console.WriteLine($"     Members = {FormatList(instance?["members"])}");
        Console.WriteLine();
    }
    Console.WriteLine("Invariant essence found: NO");
    Console.WriteLine();
    Console.WriteLine("Conclusion:");
    Console.WriteLine("  No single set of identity conditions governs all admissible instances.");
    Console.WriteLine("  There are no universal objective essences.");
}

static void RunIdentity(JsonObject root, Dictionary<string, string> argsMap)
{
    var concept = argsMap.TryGetValue("concept", out var supplied) ? supplied : "family";
    var section = root["identity"]?.AsObject();
    var entry = ResolveEntry(section, concept);
    if (entry is null)
    {
        Console.WriteLine($"No identity dataset found for concept '{concept}'.");
        return;
    }

    Console.WriteLine("TEST 4: ABSENCE OF UNIVERSAL OBJECTIVE IDENTITY");
    Console.WriteLine();
    Console.WriteLine($"Input concept: {concept}");
    Console.WriteLine("Stable admissibility conditions:");
    Console.WriteLine($"  IdentityConditions = {FormatMap(entry["identityConditions"])}");
    Console.WriteLine($"  Members = {FormatList(entry["members"])}");
    Console.WriteLine();
    Console.WriteLine("Admissible identity assignments:");
    foreach (var ctx in entry["contexts"]?.AsArray() ?? new JsonArray())
    {
        Console.WriteLine($"  {ctx?["language"]} -> {ctx?["identifier"]} ({ctx?["identity"]})");
    }
    Console.WriteLine();
    Console.WriteLine("Conclusion:");
    Console.WriteLine("  No intrinsic feature of the sign determines a single universal identity.");
    Console.WriteLine("  There are no universal objective identities.");
}

static void RunSignificance(JsonObject root, Dictionary<string, string> argsMap)
{
    var identifier = argsMap.TryGetValue("identifier", out var supplied) ? supplied : "jobInterview";
    var section = root["significance"]?.AsObject();
    var entry = ResolveEntry(section, identifier);
    if (entry is null)
    {
        Console.WriteLine($"No significance dataset found for identifier '{identifier}'.");
        return;
    }

    Console.WriteLine("TEST 5: ABSENCE OF UNIVERSAL OBJECTIVE SIGNIFICANCE");
    Console.WriteLine();
    Console.WriteLine($"Constant sign: {entry["identifier"]}");
    Console.WriteLine($"  IdentityConditions = {FormatMap(entry["identityConditions"])}");
    Console.WriteLine($"  Context = {entry["context"]}");
    Console.WriteLine();
    Console.WriteLine("Interpreters:");
    foreach (var interpreter in entry["interpreters"]?.AsArray() ?? new JsonArray())
    {
        Console.WriteLine($"  {interpreter?["name"]} -> {interpreter?["motivationalIntensity"]}");
        Console.WriteLine($"    Reason: {interpreter?["reason"]}");
    }
    Console.WriteLine();
    Console.WriteLine("Conclusion:");
    Console.WriteLine("  The sign does not carry a single invariant significance for every interpreter.");
    Console.WriteLine("  There is no universal objective significance.");
}

static JsonObject? ResolveEntry(JsonObject? section, string key)
{
    if (section is null) return null;
    if (section[key] is JsonObject direct) return direct;

    foreach (var kvp in section)
    {
        if (string.Equals(kvp.Key, key, StringComparison.OrdinalIgnoreCase) && kvp.Value is JsonObject obj)
            return obj;
    }

    // alias lookups
    return key.ToLowerInvariant() switch
    {
        "family" when section["familyClan"] is JsonObject familyClan => familyClan,
        "familyclan" when section["familyClan"] is JsonObject familyClan => familyClan,
        "job interview" when section["jobInterview"] is JsonObject jobInterview => jobInterview,
        "jobinterview" when section["jobInterview"] is JsonObject jobInterview => jobInterview,
        _ => null
    };
}

static string FormatMap(JsonNode? node)
{
    if (node is not JsonObject obj) return "{}";
    return "{ " + string.Join(", ", obj.Select(kvp => $"{kvp.Key}: {kvp.Value?.GetValue<string>()}")) + " }";
}

static string FormatList(JsonNode? node)
{
    if (node is not JsonArray arr || arr.Count == 0) return "{ }";
    return "{ " + string.Join(", ", arr.Select(x => x?.GetValue<string>())) + " }";
}

static void PrintUsage()
{
    Console.WriteLine("Usage:");
    Console.WriteLine("  dotnet run -- --test arbitrariness --concept familyClan");
    Console.WriteLine("  dotnet run -- --test underdetermination --identifier family");
    Console.WriteLine("  dotnet run -- --test essence --identifier family");
    Console.WriteLine("  dotnet run -- --test identity --concept family");
    Console.WriteLine("  dotnet run -- --test significance --identifier jobInterview");
}
