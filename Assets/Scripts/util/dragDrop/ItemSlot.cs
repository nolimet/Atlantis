using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
namespace util.dragDropSystem
{
    public class ItemSlot : MonoBehaviour, IDropHandler
    {
        public virtual GameObject item
        {
            get
            {
                if (transform.childCount > 0)
                    return transform.GetChild(0).gameObject;
                else
                    return null;
            }

        }

        public virtual void OnDrop(PointerEventData eventData)
        {
            if (!item)
            {
                Debug.Log("droped Handled");
                ItemDrag.selected.transform.SetParent(transform);
                ExecuteEvents.ExecuteHierarchy<IHasChanged>(gameObject,null,(x,y) => x.onHasChanged());
            }
        }
    }
}