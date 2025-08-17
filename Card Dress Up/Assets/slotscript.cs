using UnityEngine;

public class slotscript : MonoBehaviour
{
    // Add the swap mechanic

    public TypesScript.Clothingtype slottype;
    public GameObject slotteditem;
    public LayerMask items;
    public bool invoked;

    private void Update()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, 1, items);
        if (collider != null)
        {
            if (CheckType(collider.gameObject))
            {
                if (slotteditem != null)
                {
                    slotteditem.GetComponent<ClothesScript>().homeslot = collider.gameObject.GetComponent<ClothesScript>().homeslot;
                    slotteditem.transform.position = slotteditem.GetComponent<ClothesScript>().homeslot.transform.position;
                    slotteditem = null;
                }

                collider.gameObject.transform.position = transform.position;
                slotteditem = collider.gameObject;

                if (slotteditem != null && !invoked)
                {
                    PointsManagerScript.instance.OnSlotted?.Invoke();
                    invoked = true;
                }

                
                collider.gameObject.GetComponent<ClothesScript>().homeslot = gameObject;
                

                Debug.Log("in the slot");
            }

        }

    }

    public bool CheckType(GameObject obj)
    {
        if (obj.GetComponent<ClothesScript>().clothingtype == slottype)
        {
            
            return true;
        }
        else
        {
            return false;
        }
    }
}
