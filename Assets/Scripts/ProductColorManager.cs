using UnityEngine;

public class ProductColorManager : MonoBehaviour
{
    public void SetRed() => ChangeProductColor(Color.red);
    public void SetBlue() => ChangeProductColor(Color.blue);
    public void SetGreen() => ChangeProductColor(Color.green);

    private void ChangeProductColor(Color newColor)
    {
        // Search for the desk with the "Product" tag we created yesterday
        GameObject product = GameObject.FindWithTag("Product");

        if (product != null)
        {
            Renderer[] renderers = product.GetComponentsInChildren<Renderer>();
            foreach (Renderer r in renderers)
            {
                r.material.color = newColor;
            }
            // This is for the professor's analytics requirement
            Debug.Log("Analytics: Product color changed to " + newColor.ToString());
        }
        else
        {
            Debug.Log("Color Change Failed: No product placed in scene yet.");
        }
    }
}
