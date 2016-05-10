using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

namespace minigame.PipePuzzel
{
    public class DragPipe : util.dragDropSystem.ItemDrag
    {
        [SerializeField]
        Transform lastItemSlotEntered;

        public override void OnEndDrag(PointerEventData eventData)
        {
            
            base.OnEndDrag(eventData);

            if (!transform.parent.gameObject.GetComponent<PipeSlot>() && !lastItemSlotEntered)
            {
                Destroy(this.gameObject);
            }
            if (transform.parent.gameObject.GetComponent<PipeSlot>())
            {
                lastItemSlotEntered = transform.parent;
            }

            gameObject.GetComponent<Button>().enabled = true;
        }
    }
}