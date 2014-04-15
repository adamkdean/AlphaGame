using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using AlphaGame.Framework;

namespace AlphaGame.Components
{
    class GridComponent : IComponent
    {
        protected VariableService vars;
        private Texture2D texture;
        private int cellSize;
        private int[][] gridArray;
        private double ElapsedMilliseconds;

        private int PiggyInTheMiddle = 0;
        private int PiggyFat = 8;
        private int Speed = 75;

        public GridComponent(Game game, int cellSize, Texture2D texture)
        {
            vars = ServiceExtensionMethods.GetService<VariableService>(game.Services);
            
            this.cellSize = cellSize;
            this.texture = texture;

            InitializeGridArray(vars.DisplayHeight / cellSize, vars.DisplayWidth / cellSize);
        }

        private void InitializeGridArray(int gridHeight, int gridWidth)
        {
            // we will use a [y,x] array here as we want to move vertical (y) rows around
            gridArray = new int[gridHeight][];
            for (var y = 0; y < gridHeight; y++)
            {
                gridArray[y] = new int[gridWidth];
                for (var x = 0; x < gridWidth; x++)
                {
                    gridArray[y][x] = 0;
                }
            }

            PiggyInTheMiddle = gridWidth / 2;
        }

        public void Update(GameTime gameTime)
        {
            ElapsedMilliseconds += gameTime.ElapsedGameTime.TotalMilliseconds;

            if (ElapsedMilliseconds > Speed) 
            {
                ElapsedMilliseconds = 0;

                for (var y = gridArray.Length - 1; y > 0; y--)
                {
                    gridArray[y] = (int[])gridArray[y - 1].Clone();
                }

                PiggyInTheMiddle += vars.Random.Next(-1, 2);
                if (PiggyInTheMiddle < 1) PiggyInTheMiddle = 1;
                if (PiggyInTheMiddle >= gridArray[0].Length - 1) PiggyInTheMiddle = gridArray[0].Length - 2;

                for (var x = 0; x < gridArray[0].Length; x++)
                {
                    if (x > 0 && x < gridArray[0].Length - 1 &&
                        x < PiggyInTheMiddle + PiggyFat &&
                        x > PiggyInTheMiddle - PiggyFat)
                    {
                        gridArray[0][x] = 0;
                    }
                    else
                    {
                        gridArray[0][x] = 1;
                    }
                }
            }
        }

        public void Draw(GameTime gameTime)
        {
            //vars.SpriteBatch.Draw(background, new Rectangle(0, 0, vars.DisplayWidth, vars.DisplayHeight), Color.White);

            for (var y = 0; y < gridArray.Length; y++)
            {
                for (var x = 0; x < gridArray[y].Length; x++)
                {
                    if (gridArray[y][x] > 0)
                    {
                        var rect = new Rectangle(x * cellSize, y * cellSize, cellSize, cellSize);
                        vars.SpriteBatch.Draw(texture, rect, Color.White);
                    }
                }
            }
        }
    }
}
