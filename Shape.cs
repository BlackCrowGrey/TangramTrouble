using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
/*
 * Names: Zawn Zachow, Dylan Mahala
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
    }
}
