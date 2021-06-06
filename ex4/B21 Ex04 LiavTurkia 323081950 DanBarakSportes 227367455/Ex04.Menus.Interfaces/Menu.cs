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

        private MenuItem chooseNextItem(MenuItem i_Item)
		{
            bool isRoot = i_Item == this.r_Root;
            MenuItem chosen;

            if (i_Item is IParental)
            {
                List<MenuItem> children = (i_Item as IParental).GetChildren();

                if (children.Count == 1)
                {
                    chosen = children[0];
                }
                else
                {
                    StringBuilder builder = new StringBuilder();
                    builder.AppendLine("\n" + sr_Line);
                    builder.AppendLine("\t\t\t\tChoose a command: ");
                    builder.AppendLine(sr_Line);
                    builder.Append("0: ");
                    if (isRoot)
                    {
                        builder.AppendLine("Exit");
                    }
                    else
                    {
                        builder.AppendLine("Back to main menu");
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
                        chosen = isRoot ? null : r_Root;
                    }
                    else
                    {
                        chosen = children[ordinal - 1];
                    }
                }
            }
            else
            {
                // wait the screen so they can read what the command executed
                Console.WriteLine("Press enter to return to main menu");
                Console.ReadLine();

                chosen = isRoot ? null : r_Root;
            }

            return chosen;
        }

		private MenuItem handleMenuItem(MenuItem i_Item)
		{
            Console.Clear();

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("\n" + sr_Line);
            builder.AppendLine(i_Item.Name);
            builder.AppendLine(sr_Line);

            Console.WriteLine(builder.ToString());

            if (i_Item is IDescribable)
            {
                Console.WriteLine((i_Item as IDescribable).Description);
            }

            if (i_Item is IInputable)
			{
                IInputable inputable = i_Item as IInputable;
                Requirements.TypeRequirement requirement = inputable.GetInputRequirement();

                bool wasAccepted = false;
                while(!wasAccepted)
				{
                    object readObject = this.promptGetInput(requirement);
                    builder = new StringBuilder();
                    wasAccepted = inputable.Execute(readObject, builder);
					Console.WriteLine(builder.ToString());
				}
			}

            if(i_Item is IExecutable)
			{
                (i_Item as IExecutable).Execute();
			}

            return this.chooseNextItem(i_Item);
		}

        private object promptGetInput(Requirements.TypeRequirement i_Requirement)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(i_Requirement.Type);

            // we loop until we recieve a valid input as required by i_Requirement
            // once we recieve a valid input, we return from the function
            while (true)
            {
                object outObject;

                string command = Console.ReadLine();

                if (converter != null && converter.CanConvertFrom(typeof(string)))
                {
                    if (!converter.IsValid(command))
                    {
                        Console.WriteLine(string.Format("Syntax-invalid: not an {0}", i_Requirement.Type.Name));
                        continue;
                    }

                    try
                    {
                        outObject = converter.ConvertFromString(command);
                    }
                    catch
                    {
                        Console.WriteLine(string.Format("Syntax-invalid: not an {0}", i_Requirement.Type.Name));
                        continue;
                    }
                }
                else
                {
                    outObject = command;
                }

                if(i_Requirement.Verify(outObject))
				{
                    return outObject;
				}
				else
                {
                    Console.WriteLine(string.Format("Logic-invalid: {0}", i_Requirement.GetRequirementInformation()));
                }
            }
        }

        public void Show()
		{
			MenuItem currentItem = this.r_Root;
			while ((currentItem = this.handleMenuItem(currentItem)) != null)
			{
			}
		}
	}
}
