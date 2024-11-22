using UnityEngine;
using TMPro;
using System.Net;

public class IPChecker : MonoBehaviour
{
    [SerializeField] private string configuredIP = "192.168.0.1"; // Địa chỉ IP đã cấu hình
    [SerializeField] private GameObject warningPanel;            // Bảng cảnh báo
    [SerializeField] private TMP_Text warningText;               // TextMeshPro Text trong bảng cảnh báo

    void Start()
    {
        string localIP = GetLocalIPAddress(); // Lấy địa chỉ IP của thiết bị
        if (localIP != configuredIP)         // Kiểm tra IP
        {
            // Cập nhật nội dung thông báo
            warningText.text = $"IP thiết bị không đúng.\nHãy thay IP {configuredIP} cho thiết bị.";
            warningPanel.SetActive(true);    // Hiển thị bảng cảnh báo
        }
        else
        {
            warningPanel.SetActive(false);   // Ẩn bảng cảnh báo nếu IP đúng
        }
    }

    private string GetLocalIPAddress()
    {
        var host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            {
                return ip.ToString(); // Trả về địa chỉ IPv4 đầu tiên
            }
        }
        Debug.LogError("No IPv4 address found for the local machine.");
        return "Unknown IP";
    }
}
