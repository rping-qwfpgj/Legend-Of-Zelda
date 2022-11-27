using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using LegendofZelda.Interfaces;
using GameStates;

namespace LegendofZelda
{

    public class Background : IBackground
    {
        private readonly Texture2D texture;

        private Rectangle sourceRectangle;
        private List<Rectangle> sourceRectangles;
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }

        private readonly int width = 256;
        private readonly int height = 176;

        private readonly Vector2 backgroundLocation;
        private string direction;
        private bool transitioning;
        public bool IsTransitioning { get => transitioning; }
        public Background(Texture2D backgroundTexture, int roomNumber)
        {
            texture = backgroundTexture;

            sourceRectangles = new();
            sourceRectangles.Add(new(515, 886, width, height));
            sourceRectangles.Add(new(258, 886, width, height));
            sourceRectangles.Add(new(772, 886, width, height));
            sourceRectangles.Add(new(515, 709, width, height));
            sourceRectangles.Add(new(515, 532, width, height));
            sourceRectangles.Add(new(258, 532, width, height));
            sourceRectangles.Add(new(772, 532, width, height));
            sourceRectangles.Add(new(515, 355, width, height));
            sourceRectangles.Add(new(258, 355, width, height));
            sourceRectangles.Add(new(1, 355, width, height));
            sourceRectangles.Add(new(772, 355, width, height));
            sourceRectangles.Add(new(1029, 355, width, height));
            sourceRectangles.Add(new(1029, 178, width, height));
            sourceRectangles.Add(new(1286, 178, width, height));
            sourceRectangles.Add(new(515, 178, width, height));
            sourceRectangles.Add(new(515, 1, width, height));
            sourceRectangles.Add(new(258, 1, width, height));
            sourceRectangles.Add(new(1, 1, width, height - 16));
            sourceRectangles.Add(new(258, 886, width, height));
            sourceRectangles.Add(new(1543, 532, width, height)); // white boss room
            sourceRectangles.Add(new(1285, 178, width, height)); // master sword room

            sourceRectangle = sourceRectangles[roomNumber];
            backgroundLocation = new(sourceRectangle.X, sourceRectangle.Y);
            destinationRectangle = new(0, 150, 800, 480);
            direction = "";
        }

        public void SetTransitionDirection(String direction)
        {
            this.direction = direction;
            transitioning = true;
          
            switch (direction)
            {
                case "right":
                    sourceRectangle.Offset(-width, 0);
                    break;
                case "left":
                    sourceRectangle.Offset(width, 0);
                    break;
                case "up":
                    sourceRectangle.Offset(0, height);
                    break;
                case "down":
                    sourceRectangle.Offset(0, -height);
                    break;
            }
        }

        public void Update()
        {
            if (!(sourceRectangle.X == backgroundLocation.X && sourceRectangle.Y == backgroundLocation.Y))
            {
                switch (direction)
                {
                    case "left":
                        sourceRectangle.Offset(-1, 0);
                        break;
                    case "right":
                        sourceRectangle.Offset(1, 0);
                        break;
                    case "up":
                        sourceRectangle.Offset(0, -1);
                        break;
                    case "down":
                        sourceRectangle.Offset(0, 1);
                        break;
                }
            }
            else
            {
                transitioning = false;
            }
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            _spriteBatch.Draw(this.texture, destinationRectangle, sourceRectangle, Color.White);
            _spriteBatch.End();
        }

        public Rectangle GetHitbox()
        {
            return destinationRectangle;
        }
    }
}






    



