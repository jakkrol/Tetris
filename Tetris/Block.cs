using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class Block
    {
        public int Width;
        public int Height;
        public int[,] Grids;


        public static Block old;
        public Block RotateBlock(Block oldBlock)
        {
            old = oldBlock;

            Block newBlock = new Block();
            newBlock.Width = oldBlock.Height;
            newBlock.Height = oldBlock.Width;
            newBlock.Grids = new int[newBlock.Height, newBlock.Width];




            for (int i = 0; i < newBlock.Height; i++)
            {
                for (int j = 0; j < newBlock.Width; j++)
                {
                    newBlock.Grids[i, j] = oldBlock.Grids[oldBlock.Height - j - 1, i];
                    Console.Write(newBlock.Grids[i, j]);
                }
                Console.WriteLine();
            }
            
            return newBlock;
        }

        public Block Back()
        {
            Block oldB = new Block();
            oldB.Height = old.Height;
            oldB.Width = old.Width;
            oldB.Grids = old.Grids;
            return oldB;
        }

    }





           
}

