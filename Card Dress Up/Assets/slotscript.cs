using UnityEngine;

public class slotscript : MonoBehaviour
{
    public TypesScript.Clothingtype slottype;
    public GameObject slotteditem;
    public LayerMask items;

    private void Update()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, 1, items);
        if (collider != null)
        {
            if (CheckType(collider.gameObject))
            {
                collider.gameObject.transform.position = transform.position;
                slotteditem = collider.gameObject;
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
