using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
namespace util.dragDropSystem
{
    public class ItemDrag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        public static GameObject selected;
        public Vector3 StartPos;
        public Transform StartParent;
        protected Vector2 mouseOffSet;

        public virtual void OnBeginDrag(PointerEventData eventData)
        {
            mouseOffSet = eventData.position - (Vector2)transform.position;
            selected = gameObject;
            StartPos = transform.position;
            StartParent = transform.parent;
            transform.SetParent(DragDropManager.MoveContainer);
            if(!GetComponent<CanvasGroup>())
            {
                gameObject.AddComponent<CanvasGroup>();
            }

            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }

        public virtual void OnDrag(PointerEventData eventData)
        {
            transform.position = eventData.position - mouseOffSet;
        }

        public virtual void OnEndDrag(PointerEventData eventData)
        {
            Debug.Log("drag Ended");
           // transform.SetParent(StartParent);
            selected = null;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            if(eventData.pointerEnter != null && eventData.pointerEnter.tag=="dragAble")
            {
                transform.SetParent(eventData.pointerEnter.transform.parent);
                eventData.pointerEnter.transform.SetParent(StartParent);
                ExecuteEvents.ExecuteHierarchy<IHasChanged>(eventData.pointerEnter.transform.parent.gameObject, null, (x, y) => x.onHasChanged());
            }
            if (transform.parent == StartParent || transform.parent==DragDropManager.MoveContainer)
            {
                transform.SetParent(StartParent);
                transform.position = StartPos;
            }

        }
    }
}