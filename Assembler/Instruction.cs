using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Assembler
{
    [Serializable]
    public class Instruction : IComparable
    {
        public static Dictionary<string, string> encoding = new Dictionary<string, string>();
        public static Dictionary<string, string[]> encodeFormat = new Dictionary<string, string[]>();

        static public void addInstruction(string key, string code)
        { 
            encoding.Add(key, code);
        }

        static public void addEncodeFormat(string key, string[] code)
        {
            encodeFormat.Add(key, code);
        }

        public string label;
        public string opcodeText;

        public string[] r;
        public string comment;

        public int CompareTo(Object o)
        {
            Instruction e = o as Instruction;
            if (e == null)
                throw new ArgumentException("o is not an Instruction object.");

            return label.CompareTo(e.label);
        }

        public Instruction()
        {

        }

        public Instruction(string labelText, string op, string[] rKey, string cm)
        {
            label = labelText.ToUpper();
            label = Regex.Replace(label, @"\s", "");

            opcodeText = op.ToUpper();
            opcodeText = Regex.Replace(opcodeText, @"\s", "");
            
            for (int i = 0; i < rKey.Length; i++)
            {
                if (rKey[i] == null)
                    rKey[i] = "";
                else
                {
                    rKey[i] = Regex.Replace(rKey[i], @"\s", "");
                    rKey[i] = rKey[i].ToUpper();
                }
            }
            r = rKey;
            comment = cm;
        }

        public Instruction(string hexCode)
        {
            string binarystring = String.Join(String.Empty,
                hexCode.Select(
                c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')
                ) );
            int opLength = -1;
            foreach(var op in encoding)
            {
                opLength = op.Value.Length;
                if (op.Value == binarystring.Substring(0, opLength))
                {
                    opcodeText = op.Key;
                    break;
                }
            }
            if (opLength == -1)
                opcodeText = "NOP";
            string[] strformat = encodeFormat[opcodeText];

            int readPointer = 0;
            int R_Index = 0;

            string[] rKey = new string[strformat.Length - 1];

            foreach (var encode in strformat)
            {
                Regex re = new Regex(@"([a-zA-Z]+)(\d+)");
                Match result = re.Match(encode);
                string alphaPart = result.Groups[1].Value;
                int numberPart = Convert.ToInt32(result.Groups[2].Value);
                switch (alphaPart)
                {
                    case "OP":
                        readPointer += numberPart;
                        break;

                    case "R":
                        //string rBinStr = binarystring.Substring(3, 5);
                        string rBinStr = binarystring.Substring(readPointer, numberPart);
                        foreach (var letter in encoding)
                        {
                            if (rBinStr == letter.Value)
                                rKey[R_Index] = letter.Key;
                        }
                        
                        readPointer += numberPart;
                        R_Index++;
                        break;

                    case "IMM":
                        string immBinStr = binarystring.Substring(readPointer, numberPart);
                        rKey[R_Index] = Convert.ToInt32(immBinStr, 2).ToString("X");
                        readPointer += numberPart;
                        R_Index++;
                        break;
                }

            }

            r = rKey;
            comment = "";

        }

        public byte binayInstr(List<Instruction> program)
        {
            if (opcodeText == "")
                return 0;

            string[] pattern = encodeFormat[opcodeText];
            string binaryStr = "";
            int R_Index = 0;
            for (int i = 0; i < pattern.Length; i++)
            {
                // Match letters and numbers only, separate by space into array.
                Regex re = new Regex(@"([a-zA-Z]+)(\d+)");
                Match result = re.Match(pattern[i]);

                string alphaPart = result.Groups[1].Value;
                int numberPart = Convert.ToInt32(result.Groups[2].Value);

                switch(alphaPart)
                { 
                    case "OP":
                    binaryStr += encoding[opcodeText];
                    break;

                    case "R":
                    binaryStr += encoding[r[R_Index]];
                    R_Index++;
                    break;

                    case "IMM":
                    int num;
                    // Try to conert imm string to number, if non number value, return num with PC label number.
                    if (!Int32.TryParse(r[R_Index], NumberStyles.HexNumber, new CultureInfo("en-US"), out num))
                    {
                        // Find jump loaction number.
                        num = program.FindIndex(
                            es => es.label.Equals(r[R_Index], StringComparison.Ordinal));
                        // Shift for LLI or LUI for PC number.
                        if (opcodeText == "LLI")
                        {
                            num = (num & 0xF);

                        }
                        else
                        {
                            num = num >> 4;

                        }
                    }

                    binaryStr += Convert.ToString(num, 2).PadLeft(numberPart, '0');
                    R_Index++;
                    break;

                    default:
                    
                    break;

                }
            }

            byte binaryCode = Convert.ToByte(binaryStr, 2); ;
            return binaryCode;
        }
    }
}
