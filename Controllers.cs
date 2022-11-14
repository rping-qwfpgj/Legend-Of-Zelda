using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using LegendofZelda.Interfaces;
using System.Diagnostics;
using Commands;

namespace Controllers
{
    public class KeyboardController : IController
	{
		private Dictionary<Keys, ICommand> keyBindings = new();
		private ICommand noInput;
		private ICommand previousCommand;
		

        // Pass the noInput command into the keyboard controller in Game1's initialize function
        public KeyboardController(ICommand command) 
		{
			noInput = command;
			previousCommand = command;
		}

		public void AddCommand(Keys key, ICommand command)
		{
			keyBindings.Add(key, command);
		}

		public void Update()
		{ 
			KeyboardState kstate = Keyboard.GetState();

			if(kstate.GetPressedKeyCount() == 0)
			{
				noInput.Execute();
				previousCommand = noInput;
			} 
			else if(kstate.GetPressedKeyCount() == 1)
			{
                // Loop through the bindings. If a key is down, execute its command.
                foreach (Keys key in keyBindings.Keys)
                {
                    if (kstate.IsKeyDown(key))
                    {
                        Type typeField = previousCommand.GetType();
                        if (typeField != keyBindings[key].GetType())
                        {
                            keyBindings[key].Execute();
                         Debug.WriteLine(keyBindings[key]);
						}
                        previousCommand = keyBindings[key];
                    }
                }
            }			
		}
    }

    public class MouseController : IController
    {
        private Vector2 center;
        private Game1 myGame;
        private ButtonState previousButtonState;
        public MouseController(Game1 game, Vector2 vector)
        {
            center = vector;
            myGame = game;
            previousButtonState = ButtonState.Pressed;
        }

        public void Update()
        {
            MouseState state = Mouse.GetState();

            if (previousButtonState != ButtonState.Pressed) 
            {
                if (state.LeftButton == ButtonState.Pressed)
                {
                    if (state.X < center.X)
                    {
                        new PreviousRoomCommand(myGame).Execute();
                    }
                    else if (state.X > center.X)
                    {
                        new NextRoomCommand(myGame).Execute();
                    }
                }

            }
            previousButtonState = state.LeftButton;

        }

           
    }
    
}


