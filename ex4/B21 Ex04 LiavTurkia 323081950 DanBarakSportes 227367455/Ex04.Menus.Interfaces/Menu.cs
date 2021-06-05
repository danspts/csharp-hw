using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Ex04.Menus.Interfaces
{
	public class Menu
	{
		private static readonly string sr_Line = new string('-', 85);

		private readonly MenuItem r_Root;

		public Menu(MenuItem i_Root)
		{
			this.r_Root = i_Root;
		}

		private MenuItem showMenuItem(MenuItem i_Item)
		{
            Console.Clear();

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("\n" + sr_Line);
            builder.AppendLine(i_Item.Name);
            builder.AppendLine(sr_Line);

            if(i_Item is IDescribable)
			{
                builder.AppendLine((i_Item as IDescribable).Description);
			}

            Console.WriteLine(builder.ToString());

            if (i_Item is IInputable)
			{
                IInputable inputable = i_Item as IInputable;
                Requirements.TypeRequirement requirement = inputable.GetInputRequirement();

                bool wasAccepted = false;
                while(!wasAccepted)
				{
                    try
					{
                        object readObject = this.promptGetInput(requirement);
                        builder = new StringBuilder();
                        wasAccepted = inputable.Execute(readObject, builder);
						Console.WriteLine(builder.ToString());
					}catch(FormatException e)
					{
                        Console.WriteLine(e.Message);
                    }
				}
			}

            if(i_Item is IExecutable)
			{
                (i_Item as IExecutable).Execute();
			}

            List<MenuItem> children = i_Item.GetChildren();

            MenuItem chosen;
            if(children.Count == 0)
			{
                if(i_Item == r_Root)
				{
                    chosen = null;
				}
                else
				{
                    chosen = r_Root;
				}
			}else if(children.Count == 1)
			{
                chosen = children[0];
			}
			else
			{
                builder = new StringBuilder();
                builder.AppendLine("\n" + sr_Line);
                builder.AppendLine("\t\t\t\tChoose a command: ");
                builder.AppendLine(sr_Line);
                if(i_Item == r_Root)
				{
                    builder.AppendLine("0: Exit");
				}
				else
                {
                    builder.AppendLine("0: Back to main menu");
                }

                for (int i = 0; i < children.Count; ++i) 
                {
                    builder.AppendLine(string.Format("{0}: {1}", i + 1, children[i].Name));
                }
                builder.AppendLine(sr_Line);
                builder.Append("Number:  ");
                Console.WriteLine(builder.ToString());

                int ordinal = (int)this.promptGetInput(new Requirements.RangeRequirement<int>(0, children.Count));
                if (ordinal == 0)
                {
                    if (i_Item == r_Root)
                    {
                        chosen = null;
                    }
                    else
                    {
                        chosen = r_Root;
                    }
                }
				else
                {
                    chosen = children[ordinal];
                }
            }

            return chosen;
		}

        private object promptGetInput(Requirements.TypeRequirement i_Requirement)
        {
            object outObject;
            
            string command = Console.ReadLine();

            TypeConverter converter = TypeDescriptor.GetConverter(i_Requirement.Type);

            if (converter != null && converter.CanConvertFrom(typeof(string)))
            {
                if (!converter.IsValid(command))
                {
                    throw new FormatException(string.Format("Syntax-invalid: not an {0}", i_Requirement.Type.Name));
                }

                try
                {
                    outObject = converter.ConvertFromString(command);
                }
                catch
                {
                    throw new FormatException(string.Format("Syntax-invalid: not an {0}", i_Requirement.Type.Name));
                }
            }
            else
            {
                outObject = command;
            }

            if(!i_Requirement.Verify(outObject))
			{
                throw new FormatException(string.Format("Logic-invalid: {0}", i_Requirement.GetRequirementInformation()));
			}

            return outObject;
        }

        public void Show()
		{
			MenuItem currentItem = this.r_Root;
			while ((currentItem = this.showMenuItem(currentItem)) != null)
			{
			}
		}
	}
}
