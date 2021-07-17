using System.IO;
using System;
namespace Nitemare3D
{
    //converts nitemare 3d map viewer files into enums (thank you David for leaving those in they're very helpful)
    public static class EntityParser 
    {
        public static void Convert(string file)
        {
            var lines = File.ReadAllLines(file);

            string header = "namespace Nitemare3D\n{\n\tpublic enum Outputted\n\t{\n";

            var f = File.CreateText("OutputtedEnum.cs");

            f.Write(header);
            foreach(var line in lines)
            {
                var tokens = line.Split(' ', line.Length, StringSplitOptions.RemoveEmptyEntries);
                var id = int.Parse(tokens[0], System.Globalization.NumberStyles.HexNumber);
                
                //get enum name
                string name = "";
                for(int i = 4; i < tokens.Length; i++)
                {
                    name += tokens[i];
                }

                string output = "";
                for(int i = 0; i < name.Length; i++)
                {
                    if(char.IsLetterOrDigit(name[i]))
                    {
                        output += name[i];
                    }
                }
                f.WriteLine("\t\t" + output + " = " + id + ",");


            
            }

            f.Write("\t}\n}");

            
            
            f.Close();
        }
    }
}