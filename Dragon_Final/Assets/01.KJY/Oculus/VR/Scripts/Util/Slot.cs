using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public GameObject ItemInSlot;
    public Image slotImage;
    Color originalColor;

    void Start()
    {
        slotImage = GetComponentInChildren<Image>();
        originalColor = slotImage.color;
    }

    private void OnTriggerStay(Collider other)
    {
        //if (ItemInSlot != null) return;
        GameObject obj = other.gameObject;
        if (!IsItem(obj)) return;
        if (OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger))
        {
            InsertItem(obj);
        }
        if (other.gameObject.name.Contains("RightControllerAnchor") && OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            ReleaseItem(obj);
        }
    }

    bool IsItem(GameObject obj)
    {
        return obj.GetComponent<Item>();
    }

    void InsertItem(GameObject obj)
    {
        obj.GetComponent<Rigidbody>().isKinematic = true;
        obj.transform.SetParent(gameObject.transform, true);
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localEulerAngles = obj.GetComponent<Item>().slotRotatin;
        obj.GetComponent<Item>().inSlot = true;
        obj.GetComponent<Item>().currentSlot = this;
        ItemInSlot = obj;
        //slotImage.color = Color.gray;
    }

    void ReleaseItem(GameObject obj)
    {
        obj.GetComponent<Rigidbody>().isKinematic = false;
        obj.transform.SetParent(null);
        obj.transform.localPosition = this.transform.position;
        obj.transform.localEulerAngles = obj.GetComponent<Item>().slotRotatin;
        obj.GetComponent<Item>().inSlot = false;
        obj.GetComponent<Item>().currentSlot = null;
        ItemInSlot = null;
        ResetColor();
    }

    public void ResetColor()
    {
        slotImage.color = originalColor;
    }

    void Inventoryobj()
    {
        print("준석이");
        // 인벤토리 추가 ***
        if (ItemInSlot.GetComponent<Item>() == null) return;
        print("준석이2");
        if (ItemInSlot.GetComponent<Item>().inSlot == true)
        {
            // print("준석이바보3");
            ItemInSlot.GetComponent<Slot>().ItemInSlot = null;
            // print("준석이멍충이4");
            ItemInSlot.transform.parent = null;
            ItemInSlot.GetComponent<Item>().inSlot = false;
            print("준석이멍충이5");
            ItemInSlot.GetComponent<Item>().currentSlot.ResetColor();
            ItemInSlot.GetComponent<Item>().currentSlot = null;
            //    print("준석이멍충이");
        }
    }
}

