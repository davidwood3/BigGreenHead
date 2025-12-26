using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace BigGreenHead1
{
    public class BouncingHead
    {
        public Vector2 Position;
        public Vector2 Velocity;
        public Texture2D Texture;

        public BouncingHead(Vector2 position, Vector2 velocity, Texture2D texture)
        {
            Position =  new Vector2(0f,0f);
            Velocity = velocity;
            Texture = texture;
        }
    }
}

