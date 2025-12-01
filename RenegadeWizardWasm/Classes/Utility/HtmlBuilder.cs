using System.Text.RegularExpressions;
using System.Xml.Linq;

public class HtmlBuilder
{
    private class SpanConfig
    {
        public string Text { get; set; } = string.Empty;
        public bool IsBold { get; set; }
        public bool IsItalic { get; set; }
        public string? Color { get; set; }
        public string? FontSize { get; set; }
        public List<string> Classes { get; set; } = new(); 
    }

    private readonly List<SpanConfig> _spans = new();
    private SpanConfig? _currentSpan;
    private string _name = string.Empty;

    public HtmlBuilder Text(string text)
    {
        _currentSpan = new SpanConfig { Text = text };
        _spans.Add(_currentSpan);
        return this;
    }

    public HtmlBuilder Bold()
    {
        if (_currentSpan != null)
            _currentSpan.IsBold = true;
        return this;
    }

    public HtmlBuilder Italic()
    {
        if (_currentSpan != null)
            _currentSpan.IsItalic = true;
        return this;
    }

    public HtmlBuilder FontSize(string sizeClass)
    {
        if (_currentSpan != null)
            _currentSpan.FontSize = sizeClass;
        return this;
    }

    public HtmlBuilder Animate(params string[] classNames)
    {
        if (_currentSpan != null)
            _currentSpan.Classes.AddRange(classNames);
        return this;
    }

    public HtmlBuilder Red() => SetColor("red");
    public HtmlBuilder Green() => SetColor("lightgreen");
    public HtmlBuilder Blue() => SetColor("lightblue");
    public HtmlBuilder Orange() => SetColor("lightorange");
    public HtmlBuilder Purple() => SetColor("lightpurple");

    private HtmlBuilder SetColor(string color)
    {
        if (_currentSpan != null)
            _currentSpan.Color = color;
        return this;
    }

    public HtmlBuilder Name(string name)
    {
        _name = $"<b class='console-line'>{name}: </b>";
        return this;

        
    }

    public string Build()
    {
        var result = _name;

        foreach (var span in _spans)
        {
            var styleParts = new List<string>();
            if (!string.IsNullOrEmpty(span.Color))
                styleParts.Add($"color:{span.Color}");
            if (span.IsBold)
                styleParts.Add("font-weight:bold");
            if (span.IsItalic)
                styleParts.Add("font-style:italic");

            var style = string.Join("; ", styleParts);
            var classAttr = "console-line ";
            if (!string.IsNullOrEmpty(span.FontSize))
                classAttr += $" {span.FontSize} ";

            classAttr += string.Join(" ", span.Classes);
            result += $"<span class='{classAttr}' style=\"{style}\">{span.Text}</span>";

        }
        return result;
    }

}
