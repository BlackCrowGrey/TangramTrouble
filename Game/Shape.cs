using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
/*
 * Names: Zawn Zachow, Dylan Mahala, Beckett Raver, Andrew Tark
 * Project: Tangram Trouble
 */
namespace TangramTrouble
{
    class Shape : GameObject
    {
        /*Fields*/

        /*Properties*/

        /*Constructors*/
        public Shape(Texture2D image, int xStart, int yStart) : base(image, xStart, yStart)
        {
            
        }

        /*Methods*/

        /// <summary>
        /// Collision check ya yeet
        /// </summary>
        /// <param name="otherShape"></param>
        /// <returns></returns>
        public bool CheckIsTouching(Shape otherShape)
        {
            if (Position.Intersects(otherShape.Position) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Draws the shape.
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="color"></param>
        public override void Draw(SpriteBatch sb, Color color)
        {
            base.Draw(sb, color);
        }

        public void Drag(MouseState mouse)
        {
            //gets the location of the mouse, but as a rectangle
            Rectangle mouseLoc = new Rectangle(mouse.Position.X, mouse.Position.Y, 1, 1);
            Rectangle imageLoc = new Rectangle(PositionX - Width / 2, PositionY - Height / 2, Width, Height);
            //if the mouse is clicking the shape AND is on the shape...
            if (imageLoc.Intersects(mouseLoc) && mouse.LeftButton == ButtonState.Pressed)
            {
                PositionX = mouse.Position.X - Width / 16;
                PositionY = mouse.Position.Y - Height / 16;
            }
        }

        public void Rotate(MouseState mouse, KeyboardState keyboard)
        {
            //gets the location of the mouse, but as a rectangle
            Rectangle mouseLoc = new Rectangle(mouse.Position.X, mouse.Position.Y, 1, 1);
            Rectangle imageLoc = new Rectangle(PositionX - Width / 2, PositionY - Height / 2, Width, Height);
            //if the mouse is clicking the shape AND is on the shape...
            if (imageLoc.Intersects(mouseLoc) && keyboard.IsKeyDown(Keys.Q))
            {
                Angle -= 0.02f;
            }
            if (imageLoc.Intersects(mouseLoc) && keyboard.IsKeyDown(Keys.E))
            {
                Angle += 0.02f;
            }
        }
    }
}
