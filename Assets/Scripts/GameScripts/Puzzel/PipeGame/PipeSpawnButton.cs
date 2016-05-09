using UnityEngine;
using System.Collections;
namespace minigame.PipePuzzel
{
    public class PipeSpawnButton : MonoBehaviour {

        public Pipe PrefabPipe;
        public Transform parentForPrefabs;
        public void OnClick()
        {
            GameObject g = Instantiate(PrefabPipe.gameObject) as GameObject;
            g.transform.SetParent(parentForPrefabs, false);
            g.AddComponent<DragPipe>();
            g.GetComponent<UnityEngine.UI.Button>().enabled = false;
        }
    }
}