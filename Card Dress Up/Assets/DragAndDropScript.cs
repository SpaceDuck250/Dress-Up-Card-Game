using UnityEngine;

public class DragAndDropScript : MonoBehaviour
{
    public Camera cam;
    Vector3 mousepos;
    public bool holding;
    public GameObject SelectedObj;

    private void Update()
    {
        mousepos = cam.ScreenToWorldPoint(Input.mousePosition);


        Collider2D hit = Physics2D.OverlapPoint(mousepos);

        if (hit != null)
        {
            if (hit.gameObject.tag == "dragdrop")
            {

                Debug.Log("hit");

                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    holding = true;
                    SelectedObj = hit.gameObject;
                }
                else if (Input.GetKeyUp(KeyCode.Mouse0))
                {
                    holding = false;
                }

            }
        }

        if (holding)
        {
            OnHold();
        }
        else
        {
            OnRelease();
        }
    }

    public void OnHold()
    {
        SelectedObj.transform.position = new Vector3(mousepos.x, mousepos.y, SelectedObj.transform.position.z);
        Debug.Log("Holding");
    }

    public void OnRelease()
    {
        SelectedObj = null;
    }
}
