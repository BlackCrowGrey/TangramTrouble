using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
/*
 * Names: Zawn Zachow, Dylan Mahala
 * Project: Tangram Trouble
 */
namespace TangramTrouble
{
    class GameObject
    {
        /*Fields*/
        private Vector2 position;
        private Texture2D image;

        /*Properties*/
        /// <summary>
        /// Width of the object.
        /// </summary>
        public int Width
        {
            get { return image.Width; }
        }

        /// <summary>
        /// Height of the object.
        /// </summary>
        public int Height
        {
            get { return image.Height; }
        }

        /// <summary>
        /// X position of the object.
        /// </summary>
        public float PositionX
        {
            get {  return position.X; }
            set { position.X = value; }
        }

        /// <summary>
        /// Y position of the object.
        /// </summary>
        public float PositionY
        {
            get { return position.Y; }
            set { position.Y = value; }
        }

        /*Constructors*/
        public GameObject(Texture2D image, int xStart, int yStart)
        {
            this.image = image;
            PositionX = xStart;
            PositionY = yStart;
        }

        /*Methods*/
        public virtual void Draw(SpriteBatch sb, Color color)
        {
            //place code here
        }
    }
}
