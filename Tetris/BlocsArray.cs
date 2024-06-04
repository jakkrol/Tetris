using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class BlocksArray
    {
        private Block[] blocksarray_easy;
        private Block[] blocksarray_normal;
        private Block[] blocksarray_hard;

        public BlocksArray()
        {
            //easy difficulty array
            blocksarray_easy = new Block[]
{
                new Block
                {
                    Width = 1,
                    Height = 2,
                    Grids = new int[,]
                    {
                        { 1 },
                        { 1 }
                    }
                },

                new Block
                {
                    Width = 1,
                    Height = 1,
                    Grids = new int[,]
                    {
                        { 1 }
                    }
                },

                new Block
                {
                    Width = 2,
                    Height = 2,
                    Grids = new int[,]
                    {
                        { 0, 1 },
                        { 1, 1 }

                    }
                },

                new Block
                {
                    Width = 2,
                    Height = 2,
                    Grids = new int[,]
                    {
                        {1, 0 },
                        {1, 1 },
                    }
                },

                new Block
                {
                    Width = 2,
                    Height = 3,
                    Grids = new int[,]
                    {
                        {1, 1 },
                        {1, 1 },
                        {1, 1 }
                    }
                },

                new Block
                {
                    Width = 3,
                    Height = 2,
                    Grids = new int[,]
                    {
                        {1, 1 , 0},
                        {0, 1, 1 }
                    }
                },

                new Block
                {
                    Width = 3,
                    Height = 2,
                    Grids = new int[,]
                    {
                        {0, 1, 1 },
                        {1, 1, 0 }
                    }
                }
            };

            //normal difficulty array
            blocksarray_normal = new Block[]
            {
                new Block
                {
                    Width = 1,
                    Height = 4,
                    Grids = new int[,]
                    {
                        { 1 },
                        { 1 },
                        { 1 },
                        { 1 }
                    }
                },

                new Block
                {
                    Width = 2,
                    Height = 2,
                    Grids = new int[,]
                    {
                        { 1, 1 },
                        { 1, 1 }
                    }
                },

                new Block
                {
                    Width = 3,
                    Height = 2,
                    Grids = new int[,]
                    {
                        { 0, 1, 0 },
                        { 1, 1, 1 }

                    }
                },

                new Block
                {
                    Width = 2,
                    Height = 3,
                    Grids = new int[,]
                    {
                        {1, 1 },
                        {0, 1 },
                        {0, 1 }
                    }
                },

                new Block
                {
                    Width = 2,
                    Height = 3,
                    Grids = new int[,]
                    {
                        {1, 1 },
                        {1, 0 },
                        {1, 0 }
                    }
                },

                new Block
                {
                    Width = 3,
                    Height = 2,
                    Grids = new int[,]
                    {
                        {1, 1 , 0},
                        {0, 1, 1 }
                    }
                },

                new Block
                {
                    Width = 3,
                    Height = 2,
                    Grids = new int[,]
                    {
                        {0, 1, 1 },
                        {1, 1, 0 }
                    }
                }
            };


            //hard difficulty array
            blocksarray_hard = new Block[]
            {
                new Block
                {
                    Width = 2,
                    Height = 4,
                    Grids = new int[,]
                    {
                        { 1, 0 },
                        { 1, 1 },
                        { 1, 0 },
                        { 1, 0 }
                    }
                },

                new Block
                {
                    Width = 2,
                    Height = 3,
                    Grids = new int[,]
                    {
                        { 1, 1 },
                        { 1, 1 },
                        { 1, 0 }
                    }
                },

                new Block
                {
                    Width = 3,
                    Height = 3,
                    Grids = new int[,]
                    {
                        { 0, 1, 0 },
                        { 1, 1, 1 },
                        { 1, 1, 1 }

                    }
                },

                new Block
                {
                    Width = 3,
                    Height = 3,
                    Grids = new int[,]
                    {
                        {1, 1, 0 },
                        {0, 1, 1 },
                        {1, 1, 0 }
                    }
                },

                new Block
                {
                    Width = 2,
                    Height = 3,
                    Grids = new int[,]
                    {
                        {1, 1 },
                        {1, 0 },
                        {1, 0 }
                    }
                },

                new Block
                {
                    Width = 3,
                    Height = 2,
                    Grids = new int[,]
                    {
                        {1, 1 , 0},
                        {0, 1, 1 }
                    }
                },

                new Block
                {
                    Width = 3,
                    Height = 3,
                    Grids = new int[,]
                    {
                        {0, 0, 1 },
                        {0, 1, 1 },
                        {1, 1, 0 }
                    }
                }
            };
        }

        public Block getRndBlock(int diff)
        {
            Block block = null;
            if(diff == 0)
            {
                block = blocksarray_easy[new Random().Next(blocksarray_normal.Length)];
            }
            if(diff == 1)
            {
                block = blocksarray_normal[new Random().Next(blocksarray_normal.Length)];
            }
            if (diff == 2)
            {
                block = blocksarray_hard[new Random().Next(blocksarray_hard.Length)];
            }
            return block;
        }
    }
}
