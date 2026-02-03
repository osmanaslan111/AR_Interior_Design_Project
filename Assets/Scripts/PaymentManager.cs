using UnityEngine;

public class PaymentManager : MonoBehaviour
{
    public GameObject paymentPanel; // We will link the PaymentPanel here

    public void OpenPayment()
    {
        if (paymentPanel != null)
        {
            paymentPanel.SetActive(true);
            Debug.Log("Analytics: Checkout panel opened.");
        }
    }

    public void CompletePurchase()
    {
        if (paymentPanel != null)
        {
            paymentPanel.SetActive(false);
            Debug.Log("Analytics: Transaction Successful!");
        }
    }
}