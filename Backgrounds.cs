using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprites;
using LegendofZelda.Interfaces;

namespace Sprint0
{
    public class Background0 : ISprite
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private int width = 256;
        private int height = 176;


        public Background0(Texture2D backgroundTexture)
        {
            this.texture = backgroundTexture;
            this.sourceRectangle = new Rectangle(515, 886, width, height);
            this.destinationRectangle = new Rectangle(0, 0, 800, 480);
        }

        public void Update()
        {
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(this.texture, destinationRectangle, sourceRectangle, Color.White);
            _spriteBatch.End();
        }

        public Rectangle getHitbox()
        {
            return destinationRectangle;
        }
    }

    public class Background1 : ISprite
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private int width = 256;
        private int height = 176;

        public Background1(Texture2D backgroundTexture)
        {
            this.texture = backgroundTexture;
            this.sourceRectangle = new Rectangle(258, 886, width, height);
            this.destinationRectangle = new Rectangle(0, 0, 800, 480);
        }

        public void Update()
        {
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(this.texture, destinationRectangle, sourceRectangle, Color.White);
            _spriteBatch.End();
        }

        public Rectangle getHitbox()
        {
            return destinationRectangle;
        }
    }

    public class Background2 : ISprite
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private int width = 256;
        private int height = 176;

        public Background2(Texture2D backgroundTexture)
        {
            this.texture = backgroundTexture;
            this.sourceRectangle = new Rectangle(772, 886, width, height);
            this.destinationRectangle = new Rectangle(0, 0, 800, 480);
        }

        public void Update()
        {
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(this.texture, destinationRectangle, sourceRectangle, Color.White);
            _spriteBatch.End();
        }

        public Rectangle getHitbox()
        {
            return destinationRectangle;
        }
    }

    public class Background3 : ISprite
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private int width = 256;
        private int height = 176;

        public Background3(Texture2D backgroundTexture)
        {
            this.texture = backgroundTexture;
            this.sourceRectangle = new Rectangle(515, 709, width, height);
            this.destinationRectangle = new Rectangle(0, 0, 800, 480);
        }

        public void Update()
        {
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(this.texture, destinationRectangle, sourceRectangle, Color.White);
            _spriteBatch.End();
        }

        public Rectangle getHitbox()
        {
            return destinationRectangle;
        }
    }

    public class Background4 : ISprite
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private int width = 256;
        private int height = 176;

        public Background4(Texture2D backgroundTexture)
        {
            this.texture = backgroundTexture;
            this.sourceRectangle = new Rectangle(515, 532, width, height);
            this.destinationRectangle = new Rectangle(0, 0, 800, 480);
        }

        public void Update()
        {
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(this.texture, destinationRectangle, sourceRectangle, Color.White);
            _spriteBatch.End();
        }

        public Rectangle getHitbox()
        {
            return destinationRectangle;
        }
    }

    public class Background5 : ISprite
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private int width = 256;
        private int height = 176;

        public Background5(Texture2D backgroundTexture)
        {
            this.texture = backgroundTexture;
            this.sourceRectangle = new Rectangle(258, 532, width, height);
            this.destinationRectangle = new Rectangle(0, 0, 800, 480);
        }

        public void Update()
        {
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(this.texture, destinationRectangle, sourceRectangle, Color.White);
            _spriteBatch.End();
        }

        public Rectangle getHitbox()
        {
            return destinationRectangle;
        }
    }

    public class Background6 : ISprite
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private int width = 256;
        private int height = 176;

        public Background6(Texture2D backgroundTexture)
        {
            this.texture = backgroundTexture;
            this.sourceRectangle = new Rectangle(772, 532, width, height);
            this.destinationRectangle = new Rectangle(0, 0, 800, 480);
        }

        public void Update()
        {
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(this.texture, destinationRectangle, sourceRectangle, Color.White);
            _spriteBatch.End();
        }

        public Rectangle getHitbox()
        {
            return destinationRectangle;
        }
    }

    public class Background7 : ISprite
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private int width = 256;
        private int height = 176;

        public Background7(Texture2D backgroundTexture)
        {
            this.texture = backgroundTexture;
            this.sourceRectangle = new Rectangle(515, 355, width, height);
            this.destinationRectangle = new Rectangle(0, 0, 800, 480);
        }

        public void Update()
        {
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(this.texture, destinationRectangle, sourceRectangle, Color.White);
            _spriteBatch.End();
        }

        public Rectangle getHitbox()
        {
            return destinationRectangle;
        }
    }

    public class Background8 : ISprite
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private int width = 256;
        private int height = 176;

        public Background8(Texture2D backgroundTexture)
        {
            this.texture = backgroundTexture;
            this.sourceRectangle = new Rectangle(258, 355, width, height);
            this.destinationRectangle = new Rectangle(0, 0, 800, 480);
        }

        public void Update()
        {
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(this.texture, destinationRectangle, sourceRectangle, Color.White);
            _spriteBatch.End();
        }

        public Rectangle getHitbox()
        {
            return destinationRectangle;
        }
    }

    public class Background9 : ISprite
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private int width = 256;
        private int height = 176;

        public Background9(Texture2D backgroundTexture)
        {
            this.texture = backgroundTexture;
            this.sourceRectangle = new Rectangle(1, 355, width, height);
            this.destinationRectangle = new Rectangle(0, 0, 800, 480);
        }

        public void Update()
        {
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(this.texture, destinationRectangle, sourceRectangle, Color.White);
            _spriteBatch.End();
        }

        public Rectangle getHitbox()
        {
            return destinationRectangle;
        }
    }

    public class Background10 : ISprite
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private int width = 256;
        private int height = 176;

        public Background10(Texture2D backgroundTexture)
        {
            this.texture = backgroundTexture;
            this.sourceRectangle = new Rectangle(772, 355, width, height);
            this.destinationRectangle = new Rectangle(0, 0, 800, 480);
        }

        public void Update()
        {
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(this.texture, destinationRectangle, sourceRectangle, Color.White);
            _spriteBatch.End();
        }

        public Rectangle getHitbox()
        {
            return destinationRectangle;
        }
    }

    public class Background11 : ISprite
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private int width = 256;
        private int height = 176;

        public Background11(Texture2D backgroundTexture)
        {
            this.texture = backgroundTexture;
            this.sourceRectangle = new Rectangle(1029, 355, width, height);
            this.destinationRectangle = new Rectangle(0, 0, 800, 480);
        }

        public void Update()
        {
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(this.texture, destinationRectangle, sourceRectangle, Color.White);
            _spriteBatch.End();
        }

        public Rectangle getHitbox()
        {
            return destinationRectangle;
        }
    }

    public class Background12 : ISprite
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private int width = 256;
        private int height = 176;

        public Background12(Texture2D backgroundTexture)
        {
            this.texture = backgroundTexture;
            this.sourceRectangle = new Rectangle(1029, 178, width, height);
            this.destinationRectangle = new Rectangle(0, 0, 800, 480);
        }

        public void Update()
        {
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(this.texture, destinationRectangle, sourceRectangle, Color.White);
            _spriteBatch.End();
        }

        public Rectangle getHitbox()
        {
            return destinationRectangle;
        }
    }

    public class Background13 : ISprite
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private int width = 256;
        private int height = 176;

        public Background13(Texture2D backgroundTexture)
        {
            this.texture = backgroundTexture;
            this.sourceRectangle = new Rectangle(1286, 178, width, height);
            this.destinationRectangle = new Rectangle(0, 0, 800, 480);
        }

        public void Update()
        {
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(this.texture, destinationRectangle, sourceRectangle, Color.White);
            _spriteBatch.End();
        }

        public Rectangle getHitbox()
        {
            return destinationRectangle;
        }
    }

    public class Background14 : ISprite
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private int width = 256;
        private int height = 176;

        public Background14(Texture2D backgroundTexture)
        {
            this.texture = backgroundTexture;
            this.sourceRectangle = new Rectangle(515, 178, width, height);
            this.destinationRectangle = new Rectangle(0, 0, 800, 480);
        }

        public void Update()
        {
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(this.texture, destinationRectangle, sourceRectangle, Color.White);
            _spriteBatch.End();
        }

        public Rectangle getHitbox()
        {
            return destinationRectangle;
        }
    }

    public class Background15 : ISprite
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private int width = 256;
        private int height = 176;

        public Background15(Texture2D backgroundTexture)
        {
            this.texture = backgroundTexture;
            this.sourceRectangle = new Rectangle(515, 1, width, height);
            this.destinationRectangle = new Rectangle(0, 0, 800, 480);
        }

        public void Update()
        {
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(this.texture, destinationRectangle, sourceRectangle, Color.White);
            _spriteBatch.End();
        }

        public Rectangle getHitbox()
        {
            return destinationRectangle;
        }
    }

    public class Background16 : ISprite
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private int width = 256;
        private int height = 176;

        public Background16(Texture2D backgroundTexture)
        {
            this.texture = backgroundTexture;
            this.sourceRectangle = new Rectangle(258, 1, width, height);
            this.destinationRectangle = new Rectangle(0, 0, 800, 480);
        }

        public void Update()
        {
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(this.texture, destinationRectangle, sourceRectangle, Color.White);
            _spriteBatch.End();
        }

        public Rectangle getHitbox()
        {
            return destinationRectangle;
        }
    }

    public class Background17 : ISprite
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private int width = 256;
        private int height = 160;

        public Background17(Texture2D backgroundTexture)
        {
            this.texture = backgroundTexture;
            this.sourceRectangle = new Rectangle(1, 1, width, height);
            this.destinationRectangle = new Rectangle(0, 0, 800, 480);
        }

        public void Update()
        {
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(this.texture, destinationRectangle, sourceRectangle, Color.White);
            _spriteBatch.End();
        }

        public Rectangle getHitbox()
        {
            return destinationRectangle;
        }
    }

    public class Background18 : ISprite
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private int width = 256;
        private int height = 176;

        public Background18(Texture2D backgroundTexture)
        {
            this.texture = backgroundTexture;
            this.sourceRectangle = new Rectangle(258, 886, width, height);
            this.destinationRectangle = new Rectangle(0, 0, 800, 480);
        }

        public void Update()
        {
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(this.texture, destinationRectangle, sourceRectangle, Color.White);
            _spriteBatch.End();
        }
        public Rectangle getHitbox()
        {
            return destinationRectangle;
        }

    }
}






    



