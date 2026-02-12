namespace Lab06;

internal class Button
{
    public delegate void ClickHandler(object sender, string btnName);
    public event ClickHandler Click;
    string buttonName = "MyBtn";
    public void PerformClick()
    {
        if (Click != null)
            Click(this, buttonName);
    }
}
