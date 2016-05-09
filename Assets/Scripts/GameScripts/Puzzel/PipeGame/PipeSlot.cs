using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

namespace minigame.PipePuzzel
{
    public class PipeSlot : util.dragDropSystem.ItemSlot
    {
        public pipeStruct PipeData
        {
            get
            {
                return pipeObj.PipeData;
            }
        }
        Pipe pipeObj;

        public override void OnDrop(PointerEventData eventData)
        {
            base.OnDrop(eventData);

            if (item.GetComponent<Pipe>())
            {
                pipeObj = item.GetComponent<Pipe>();
                pipeObj.transform.localPosition = Vector3.zero;
            }

        }
    }
}