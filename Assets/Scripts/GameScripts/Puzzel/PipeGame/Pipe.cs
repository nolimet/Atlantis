using UnityEngine;
using System.Collections;

namespace minigame.PipePuzzel
{
    public class Pipe : BaseBehaviour
    {
        [SerializeField]
        pipeStruct pipeData;

        protected override void Start()
        {
            base.Start();
            pipeData.rotation = PipeRotation.up;
        }

        public void OnClick()
        {
            switch (pipeData.rotation)
            {
                case PipeRotation.up:
                    pipeData.rotation = PipeRotation.left;
                    break;

                case PipeRotation.left:
                    pipeData.rotation = PipeRotation.down;
                    break;

                case PipeRotation.down:
                    pipeData.rotation = PipeRotation.right;
                    break;

                case PipeRotation.right:
                    pipeData.rotation = PipeRotation.up;
                    break;
            }
        }

        public override void MainUpdate()
        {
            switch (pipeData.rotation)
            {
                case PipeRotation.up:
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    break;

                case PipeRotation.left:
                    transform.rotation = Quaternion.Euler(0, 0, 90);
                    break;

                case PipeRotation.down:
                    transform.rotation = Quaternion.Euler(0, 0, 180);
                    break;

                case PipeRotation.right:
                    transform.rotation = Quaternion.Euler(0, 0, -90);
                    break;
            }
        }

    }

    [System.Serializable]
    struct pipeStruct
    {
        public bool up { get { return _setUp; } }
        public bool down { get { return _setDown; } }
        public bool left { get { return _setLeft; } }
        public bool right { get { return _setRight; } }

        [SerializeField]
        bool _up, _right, _down, _left;
        [SerializeField]
        bool _setUp, _setRight, _setDown, _setLeft;

        public PipeRotation rotation
        {
            get  { return _rotation; }
            set
            {
                _rotation = value;

                switch (value)
                {
                    case PipeRotation.up:
                        _setUp = _up;
                        _setRight = _right;
                        _setDown = _down;
                        _setLeft = _left;
                        break;

                    case PipeRotation.right:
                        _setUp = _left;
                        _setRight = _up;
                        _setDown = _right;
                        _setLeft = _down;
                        break;

                    case PipeRotation.down:
                        _setUp = _down;
                        _setRight = _left;
                        _setDown = _up;
                        _setLeft = _right;
                        break;

                    case PipeRotation.left:
                        _setUp = _right;
                        _setRight = _down;
                        _setDown = _left;
                        _setLeft = _up;
                        break;
                }
            }
        }
        PipeRotation _rotation;
    }


    enum PipeRotation
    {
        up = 0,
        left = 1,
        down = 2,
        right = 3
    }
}
