namespace UI.ReactiveViews
{
    public class TextMeshProReactiveStringView : TextMeshProReactiveView<string>
    {
        protected override string GetTextValue(string value)
        {
            return value;
        }
    }
}