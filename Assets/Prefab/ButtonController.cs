using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject hostButton;
    public GameObject clientButton;

    // Hàm ẩn nút Client khi nhấn Host
    public void OnHostButtonClicked()
    {
        clientButton.SetActive(false);
    }

    // Hàm ẩn nút Host khi nhấn Client
    public void OnClientButtonClicked()
    {
        hostButton.SetActive(false);
    }
}
