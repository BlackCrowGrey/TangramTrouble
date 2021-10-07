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
    class Board : GameObject
    {
        /*Fields*/
        private int width;
        private int height;

        /*Properties*/

        /*Constructors*/
        public Board(Texture2D image, int xStart, int yStart, int w, int h) : base(image, xStart, yStart)
        {

        }

        /*Methods*/
        public override void Draw(SpriteBatch sb, Color color)
        {
            base.Draw(sb, color);
        }
    }
}
