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
        print("�ؼ���");
        // �κ��丮 �߰� ***
        if (ItemInSlot.GetComponent<Item>() == null) return;
        print("�ؼ���2");
        if (ItemInSlot.GetComponent<Item>().inSlot == true)
        {
            // print("�ؼ��̹ٺ�3");
            ItemInSlot.GetComponent<Slot>().ItemInSlot = null;
            // print("�ؼ��̸�����4");
            ItemInSlot.transform.parent = null;
            ItemInSlot.GetComponent<Item>().inSlot = false;
            print("�ؼ��̸�����5");
            ItemInSlot.GetComponent<Item>().currentSlot.ResetColor();
            ItemInSlot.GetComponent<Item>().currentSlot = null;
            //    print("�ؼ��̸�����");
        }
    }
}

