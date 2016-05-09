using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace minigame.PipePuzzel
{
    //TODO add class that holds the walked path of a crawler
    public class PipePuzzelManager : BaseBehaviour
    {
        /// <summary>
        /// instance of class
        /// </summary>
        public static PipePuzzelManager Instance
        {
            get
            {
                return instace;
            }
        }

        static PipePuzzelManager instace;

        /// <summary>
        /// contains all the pipe locations used in the puzzle;
        /// Array is formatted x,y;
        /// </summary>
        PipeSlot[,] pipes;

        /// <summary>
        /// Start point of the pipe System
        /// </summary>
        public Pipe StartPoint;

        /// <summary>
        /// End Point of the pipe System
        /// </summary>
        public Pipe EndPoint;

        List<Vector2> pathFindingPoints;
        List<Pipe> PipesInPath;

        [Tooltip("Width in pipes ")]
        public int puzzleWidth;
        [Tooltip("Height in pipes")]
        public int puzzleHeight;

        public float pipeHeight = 50;
        public float pipeWidth = 50;

        public Pipe Straight, Bend;
        public PipeSlot pipeSlot;
        void Awake()
        {
            instace = this;
        }

        protected override void Start()
        {
            GeneratePuzzelField();
            StartMainThreadUpdate();
            StartSecondThreadUpdate();

            
            pathFindingPoints = new List<Vector2>();
            PipesInPath = new List<Pipe>();
            
        }

        public void GeneratePuzzelField()
        {
            float pipeHeight = 50, pipeWidth = 50;
            int x, y;
            GameObject G;
            PipeSlot p;
            RectTransform t;

            //buffering width and height so i don't have to get it every itteration of the loop

                t = (RectTransform)pipeSlot.transform;
                pipeHeight = t.rect.height + 1;
                pipeWidth = t.rect.width + 1;

            //making a clean array where the puzzle bits will be stored
            pipes = new PipeSlot[puzzleWidth, puzzleHeight];

            //Creating the puzzle field
            for (y = 0; y < puzzleHeight; y++)
            {
                for (x = 0; x < puzzleWidth; x++)
                {
                    G = Instantiate(pipeSlot.gameObject);
                    G.name = "Pipe-Slot";

                    p = G.GetComponent<PipeSlot>();
                   
                    pipes[x, y] = p;

                    t = (RectTransform)G.transform;

                    t.SetParent(transform, false);
                    t.anchorMax = new Vector2(0, 0);
                    t.anchorMin = new Vector2(0, 0);

                    t.pivot = Vector2.one / 2f;

                    t.anchoredPosition = new Vector2((pipeWidth/2f)+(x * pipeWidth), (pipeHeight / 2f) + (y * pipeHeight));

                    t.sizeDelta = new Vector2(pipeWidth, pipeHeight);

                }
            }

        }

        public override void MainUpdate()
        {

        }

        int i;
        int l;
        bool canMove = false;
        public override void SecondaryThreadUpdate()
        {
            l = pathFindingPoints.Count;

            for(i=0;i< l; i++)
            {
                while (canMove)
                {
                    //TODO creat path crawler
                }
            }
        }
    }
}
