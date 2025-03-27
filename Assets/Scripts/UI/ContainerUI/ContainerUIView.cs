using UI;

public class ContainerUIView : UIView
{
    internal void ShowContainerUI(bool value)
    {
        if (value)
        {
            gameObject.SetActive(true);
        }
    }
}
