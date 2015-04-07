using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LeaveMeAlone
{
    public class Text
    {
        public static Dictionary<string, SpriteFont> fonts = new Dictionary<string,SpriteFont>();
        public SpriteFont font;
        public Color color;
        public string message;
        public Vector2 position;
        public static Color DEFAULT_COLOR = Color.Black;

        public Text(SpriteFont f, Color c, Vector2 pos, string msg="")
        {
            message = msg;
            font = f;
            color = c;
            position = pos;
        }
        public Text(Vector2 pos, string msg = "")
        {
            message = msg;
            font = fonts["Arial-12"];
            color = DEFAULT_COLOR;
            position = pos;
        }
        /*public Text(string msg = "")
        {
            message = msg;
            font = fonts["Arial-12"];
            color = DEFAULT_COLOR;
            position = new Vector2(0,0);
        }*/


        public void changeMessage(string msg) 
        {
            message = msg;
        }

        public static void loadContent(ContentManager content)
        {
            //loads font
            fonts["Arial-12"] = content.Load<SpriteFont>("Fonts/Arial-12");
            fonts["Arial-24"] = content.Load<SpriteFont>("Fonts/Arial-24");
            fonts["BattleMenuText-12"] = content.Load<SpriteFont>("Fonts/BattleMenuText-12");
            fonts["RetroComputer-12"] = content.Load<SpriteFont>("Fonts/RetroComputer-12");
        }
        public void Draw(SpriteBatch sb)
        {
            sb.DrawString(font, message, position, color);
        }
        public void Draw(SpriteBatch sb, Color c=default(Color), Vector2 pos = default(Vector2))
        {
            if(c == default(Color))
            {
                c = this.color;
            }
            if(pos == default(Vector2))
            {
                pos = position;
            }
            sb.DrawString(font, message, pos, c);
        }
        public void Move(Vector2 pos)
        {
            position = pos;
        }
    }
}
