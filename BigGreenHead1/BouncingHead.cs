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
        //public Vector2 Velocity;
        // public Vector2 Position;
        public static Texture2D Texture;
        public static Viewport GraphicsViewport;
        
        // using private to enforce encapsulation
        private Vector2 position;
        private Vector2 velocity;
        
        // accessors and mutators
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        public Vector2 Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }
        
        private Color drawingColor;
        public Color DrawingColor
        {
            get { return drawingColor; }
            set { drawingColor = value; }
        }
        
        
        
        
      public BouncingHead(float x, float y, float vx, float vy)
        {
            position =  new Vector2(x, y);
            velocity = new Vector2(vx, vy);
            drawingColor = Color.White;
        }
      
      public BouncingHead()
      {
        position = new Vector2(0f, 0f);
        velocity = new Vector2(1f, 1f);
        drawingColor = Color.White;
      }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, position, drawingColor);
        }
        
        public void Update()
        {
            position += velocity;
            
            if (position.X < 0 || position.X > GraphicsViewport.Width - Texture.Width)
                velocity.X = -velocity.X;
            
            if (position.Y < 0 || position.Y > GraphicsViewport.Height - Texture.Height)
                velocity.Y = -velocity.Y;
        }
    }
}

