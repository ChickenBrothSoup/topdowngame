using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{

    public GameObject[] PickupFeedbacks;

    public LayerMask TargetLayerMask;

    private void OnTriggerEnter2D(Collider2D col)
    {

        if (!((TargetLayerMask.value & (1 << col.gameObject.layer)) > 0))

         PickedUp(col);

        foreach (var feedback in PickupFeedbacks)
        {
            GameObject.Instantiate(feedback, transform.position, transform.rotation);
        }

        Destroy(gameObject);
    }      

    protected virtual void PickedUp(Collider2D col)
    {

    }
        
    
}

