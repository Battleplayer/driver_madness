using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryPackage : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(1,1,1,1);
    [SerializeField] Color32 noPackageColor = new Color32(0,1,1,1);

    [SerializeField] float time=0.2f;
    bool hasPackage;
    SpriteRenderer spriteRenderer;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();    
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Package" && !hasPackage) {
            spriteRenderer.color = hasPackageColor;
            hasPackage = true;
            Destroy(other.gameObject, time);
        }
        if (other.tag == "Customer" && hasPackage) {
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}
