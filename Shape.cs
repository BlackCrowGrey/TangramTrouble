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

        public bool CheckIsTouching(Shape otherShape)
        {
            //put code here later
            return true;
        }

        public override void Draw(SpriteBatch sb, Color color)
        {
            base.Draw(sb, color);
        }
    }
}
