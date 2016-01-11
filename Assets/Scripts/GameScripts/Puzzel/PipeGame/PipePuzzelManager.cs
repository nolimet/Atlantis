using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace minigame.PipePuzzel
{
    //TODO add class that holds the walked path of a crawler
    public class PipePuzzelManager : BaseBehaviour
    {
        /// <summary>
        /// contains all the pipe locations used in the puzzle;
        /// Array is formatted x,y;
        /// </summary>
        Pipe[,] pipes;

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

        public int puzzleWidth, puzzleHeight;

        protected override void Start()
        {
            StartMainThreadUpdate();
            StartSecondThreadUpdate();

            pipes = new Pipe[puzzleWidth, puzzleHeight];
            pathFindingPoints = new List<Vector2>();
            PipesInPath = new List<Pipe>();
            
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
