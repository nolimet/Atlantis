using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

namespace minigame.PipePuzzel
{
    public class DragPipe : util.dragDropSystem.ItemDrag
    {
        Transform lastItemSlotEntered;

        public override void OnEndDrag(PointerEventData eventData)
        {
            
            base.OnEndDrag(eventData);

            if (!transform.parent.gameObject.GetComponent<PipeSlot>() && lastItemSlotEntered)
            {
                Destroy(this);
            }

            gameObject.GetComponent<Button>().enabled = true;
        }
    }
}