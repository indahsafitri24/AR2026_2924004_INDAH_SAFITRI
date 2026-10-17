using UnityEngine;
using UnityEngine.UIElements;

public class MobileUIController : MonoBehaviour
{
    public PlayerMovement player;
    public UIDocument uiDocument;

    private bool up, down, left, right;

    void OnEnable()
    {
        if (uiDocument == null)
            uiDocument = GetComponent<UIDocument>();

        if (uiDocument == null)
        {
            Debug.LogError("UIDocument tidak ditemukan!");
            return;
        }

        var root = uiDocument.rootVisualElement;

        BindButton(root, "UpButton",
            () => up = true, () => up = false);

        BindButton(root, "DownButton",
            () => down = true, () => down = false);

        BindButton(root, "LeftButton",
            () => left = true, () => left = false);

        BindButton(root, "RightButton",
            () => right = true, () => right = false);
    }

    void BindButton(
        VisualElement root,
        string buttonName,
        System.Action pressed,
        System.Action released)
    {
        var button = root.Q<Button>(buttonName);

        if (button == null)
        {
            Debug.LogError("Tombol tidak ditemukan: " + buttonName);
            return;
        }

        button.RegisterCallback<PointerDownEvent>(evt =>
        {
            pressed();
            UpdateMovement();
        });

        button.RegisterCallback<PointerUpEvent>(evt =>
        {
            released();
            UpdateMovement();
        });

        button.RegisterCallback<PointerCaptureOutEvent>(evt =>
        {
            released();
            UpdateMovement();
        });
    }

    void UpdateMovement()
    {
        if (player == null) return;

        float x = (right ? 1f : 0f) - (left ? 1f : 0f);
        float y = (up ? 1f : 0f) - (down ? 1f : 0f);

        player.SetMobileInput(x, y);
    }
}