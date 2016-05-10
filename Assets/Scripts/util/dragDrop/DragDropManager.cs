using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
namespace util.dragDropSystem
{
    public class DragDropManager : MonoBehaviour
    {
        static DragDropManager()
        {
            if (instance)
            {
                MoveContainer = instance._MoveContainer;
            }

            if(MoveContainer == null)
            {
                Debug.LogWarning("NO Movecontainer for dragdrop System... Creating one");

                GameObject g = new GameObject();
                g.transform.SetParent(FindObjectOfType<Canvas>().gameObject.transform, false);
                MoveContainer = g.transform;
            }

            MoveContainer.name = "DragDropMoveContainer";
        }

        public static Transform MoveContainer;
        static DragDropManager instance;
        [SerializeField]
        Transform _MoveContainer;
        // Use this for initialization
        void Awake()
        {
            instance = this;
        }
    }
}
namespace UnityEngine.EventSystems
{
    public interface IHasChanged : IEventSystemHandler
    {
        void onHasChanged();
    }
}
