using ServiceLocatorSystem;
using UnityEngine.UI;

public class ClicksViewService : IService
{
    private Text _clicksField;

    public ClicksViewService(Text clicksField) => _clicksField = clicksField;

    public void Display(string text) => _clicksField.text = text;
}
