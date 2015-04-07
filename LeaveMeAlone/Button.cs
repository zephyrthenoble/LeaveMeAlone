using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeaveMeAlone;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LeaveMeAlone
{

    public class Button
    {    
        public Texture2D sprite;
        public Rectangle rectangle;
        public Text text;
        public Button(Texture2D pic, int x, int y, int width, int height)
        {
            this.sprite = pic;
            this.rectangle= new Rectangle(x, y, width, height);
            this.text = new Text(new Vector2(x+10, y+10));
        }
        public void Draw(SpriteBatch sb)
        {
            sb.Draw(sprite, rectangle, Color.White);
            text.Draw(sb);
        }
        public void Draw(SpriteBatch sb, Color r, Color t)
        {
            sb.Draw(sprite, rectangle, r);
            text.Draw(sb, t);
        }
        public void DrawRect(SpriteBatch sb, Color c)
        {
            sb.Draw(sprite, rectangle, c);
            text.Draw(sb);
        }
        public void DrawText(SpriteBatch sb, Color c)
        {
            sb.Draw(sprite, rectangle, Color.White);
            Color temp = text.color;
            text.Draw(sb, c);
        }
        public Boolean Intersects(int x, int y)
        {
            if(rectangle.Contains(x,y))
            {
                return true;
            }
            return false;
        }
        public void UpdateText(string update)
        {
            text.changeMessage(update);
        }
    }
}
