using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Assembler
{
    public partial class Form1 : Form
    {
        const int COL_COUNT = 7;
        int rowCount;
        int nopCount = 0;

        string fileName = "program.dat";

        List<Instruction> program = new List<Instruction>();

        List<string> comment = new List<string>();
        //List<bool> checkedLabels = new List<bool>();

        TextBox[] labelTxb;
        TextBox[] opcodeTxb;
        TextBox[] r1Txb;
        TextBox[] r2Txb;
        Button[] buttonAdd;
        Button[] buttonRmv;
        //CheckBox[] checkBoxs;

        public Form1()
        {
            InitializeComponent();

            panel1.AutoScroll = false;
            panel1.HorizontalScroll.Enabled = false;
            panel1.HorizontalScroll.Visible = false;
            panel1.HorizontalScroll.Maximum = 0;
            panel1.AutoScroll = true;

            //tableLayoutPanel1.Width = 100;
            //tableLayoutPanel1.Height = 100;

            string[] Opcode4Bits = new string[]{ "OP4", "R2", "R2" };
            string[] Opcode2Bits = new string[] { "OP2", "R2", "IMM4" };
            string[] Opcode8Bits = new string[] { "OP8" };
            Instruction.addEncodeFormat("ADD", Opcode4Bits);
            Instruction.addEncodeFormat("SUB", Opcode4Bits);
            Instruction.addEncodeFormat("LOAD", Opcode4Bits);
            Instruction.addEncodeFormat("STORE", Opcode4Bits);
            Instruction.addEncodeFormat("JLEZ", Opcode4Bits);
            Instruction.addEncodeFormat("JALR", Opcode4Bits);
            Instruction.addEncodeFormat("LUI", Opcode2Bits);
            Instruction.addEncodeFormat("LLI", Opcode2Bits);
            Instruction.addEncodeFormat("HALT", Opcode8Bits);
            Instruction.addEncodeFormat("NOP", Opcode8Bits);

            Instruction.addInstruction("ADD", "0000");
            Instruction.addInstruction("SUB", "0001");
            Instruction.addInstruction("LOAD", "0010");
            Instruction.addInstruction("STORE", "0011");
            Instruction.addInstruction("JLEZ", "0100");
            Instruction.addInstruction("JALR", "0101");
            Instruction.addInstruction("LUI", "10");
            Instruction.addInstruction("LLI", "11");
            Instruction.addInstruction("A", "00");
            Instruction.addInstruction("B", "01");
            Instruction.addInstruction("C", "10");
            Instruction.addInstruction("D", "11");
            Instruction.addInstruction("HALT", "01110000");
            Instruction.addInstruction("NOP", "01100000");

            comment.Add("");



            program.Insert(0, new Instruction("", "", new string[2] { "", "" }, ""));
            comment.Insert(0, "");

            rowCount += 1;
            ResizeForm();
            WriteTextbox();


        }

        int lineNumber;
        // Convert to machine code.
        private void ConvertBtn_Click(object sender, EventArgs e)
        {
            try
            {
                binaryTxb.Text = "";
                hex1Txb.Text = "";
                hex2Txb.Text = "";
                memHexTxb.Text = "";

                ReadTextbox();

                for (lineNumber = 0; lineNumber < program.Count(); lineNumber++)
                {
                    //if (statement.binayInstr(program) != null)
                    string r2;
                    if (program[lineNumber].opcodeText == "LOAD" || program[lineNumber].opcodeText == "STORE")
                        r2 = "[" + program[lineNumber].r[1] + "]";
                    else if (program[lineNumber].opcodeText == "LLI" || program[lineNumber].opcodeText == "LUI")
                        r2 = "0x" + Convert.ToString(program[lineNumber].binayInstr(program) & 15, 16);
                    else
                        r2 = program[lineNumber].r[1];

                    // Doc 
                    binaryTxb.Text += string.Format("{0,-3}{1,-7}{2,-5} {3,-1},{4,-8}{5,-10}{6,-5}{7}\r\n",
                        lineNumber.ToString("X"),
                        (program[lineNumber].label == "" ? "" : program[lineNumber].label + ":"),
                        program[lineNumber].opcodeText,
                        program[lineNumber].r[0],
                        r2,
                        Convert.ToString(program[lineNumber].binayInstr(program), 2).PadLeft(8, '0'),
                        Convert.ToString(program[lineNumber].binayInstr(program), 16).PadLeft(2, '0'),
                         (program[lineNumber].comment != "" ? "; " + program[lineNumber].comment : "")
                    );

                    /*
                        binaryTxb.Text += lineNumber.ToString("X") + " " +
                        (program[lineNumber].label == "" ? "" : program[lineNumber].label + ":") + "\t" +

                        program[lineNumber].opcodeText + " " + program[lineNumber].r[0] + "," + r2 +
                        "\t\t" +

                        Convert.ToString(program[lineNumber].binayInstr(program), 2).PadLeft(8, '0') + "\t" +
                        Convert.ToString(program[lineNumber].binayInstr(program), 16).PadLeft(2, '0') +

                        (program[lineNumber].comment != "" ? "\t; " + program[lineNumber].comment : "") +

                        "\r\n";
                     */

                    // C program array
                    hex1Txb.Text +=
                        "0x" +
                        Convert.ToString(program[lineNumber].binayInstr(program), 16).PadLeft(2, '0') +
                        ", ";

                    // verilog
                    hex2Txb.Text +=
                        varNameTxb.Text + "[" + lineNumber + "]=8'h" +
                        Convert.ToString(program[lineNumber].binayInstr(program), 16).PadLeft(2, '0') +
                        "; ";

                    // simulator Memory
                    memHexTxb.Text += Convert.ToString(program[lineNumber].binayInstr(program), 16).PadLeft(2, '0') +
                        "\r\n";
                    /*
                    // Add NOPs
                    for (int nop = 1; nop <= nopNumUpDown.Value; nop++)
                    {
                        hex1Txb.Text +=
                        "0x" +
                        Convert.ToString(Convert.ToByte(Instruction.encoding["NOP"], 2), 16).PadLeft(2, '0') +
                        ", ";

                        hex2Txb.Text +=
                        varNameTxb.Text + "[" + lineNumber + "]=8'h" +
                        Convert.ToString(Convert.ToByte(Instruction.encoding["NOP"], 2), 16).PadLeft(2, '0') +
                        "; ";

                        memHexTxb.Text += Convert.ToString(Convert.ToByte(Instruction.encoding["NOP"], 2), 16).PadLeft(2, '0') +
                        "\r\n";

                    }
                     */
                }

                serializeToFile();
                MessageBox.Show("Converted and saved successfully!");
            }
            catch(OverflowException)
            {
                MessageBox.Show(string.Format("Incorrect value on PC: {0}.\nMake sure entered number are in HEX and less then 0xF ", lineNumber.ToString("X")));
            }
            catch(KeyNotFoundException)
            {
                MessageBox.Show(string.Format("Incorrect instruction on PC: {0}.", lineNumber.ToString("X")));
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0} Exception caught.", ex));
            }

        }


        private void ReadFromText_Click(object sender, EventArgs e)
        {
            try
            {
                program.Clear();
                comment.Clear();

                string inputStr = binaryTxb.Text;
                string[] lines = Regex.Split(inputStr, "\r\n");
                foreach (var instrLine in lines)
                {
                    if (instrLine == "")
                        continue;
                    string[] codeNcomment = Regex.Split(instrLine, @";");
                    string[] code = Regex.Split(codeNcomment[0], @"\W+");

                    List<string> newCode = new List<string>();
                    foreach (var word in code)
                    {
                        if (word != "")
                            newCode.Add(word);
                    }
                    code = newCode.ToArray();

                    string lbl, op, r1, r2, cm;
                    if (codeNcomment.Length == 1)
                        cm = "";
                    else
                        cm = codeNcomment[1];

                    if (Instruction.encodeFormat.ContainsKey(code[1]))
                    {
                        lbl = "";
                        op = code[1];
                        int numberOfCode = Instruction.encodeFormat[op].Length;
                        r1 = (numberOfCode >= 2 ? code[2] : "");
                        r2 = (numberOfCode >= 3 ? code[3] : "");
                    }
                    else if (Instruction.encodeFormat.ContainsKey(code[2]))
                    {
                        lbl = code[1];
                        op = code[2];
                        int numberOfCode = Instruction.encodeFormat[op].Length;
                        r1 = (numberOfCode >= 2 ? code[3] : "");
                        r2 = (numberOfCode >= 3 ? code[4] : "");
                    }
                    else
                        throw new Exception("Incorrect Assembly format. Make sure one instruction per line. Enter PC number, label, and encode instruction separate with space.");
                    r2 = Regex.Replace(r2, "0x|\\[|\\]", "");
                    program.Add(new Instruction(lbl, op, new string[] { r1, r2 }, cm));
                }

                rowCount = program.Count();
                ResizeForm();
                WriteTextbox();
                ReadTextbox();

                serializeToFile();
                MessageBox.Show("Read and saved successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0} Exception caught.", ex));
            }
        }

        protected void ResizeForm()
        {
            tableLayoutPanel1.Controls.Clear();
            
            tableLayoutPanel1.ColumnStyles.Clear();
            tableLayoutPanel1.RowStyles.Clear();

            tableLayoutPanel1.ColumnCount = COL_COUNT;
            tableLayoutPanel1.RowCount = rowCount + 1;

            tableLayoutPanel1.Width = COL_COUNT * 100;
            tableLayoutPanel1.Height = (rowCount + 1) * 30;

            //comment.Clear();

            labelTxb = new TextBox[rowCount];
            opcodeTxb = new TextBox[rowCount];
            r1Txb = new TextBox[rowCount];
            r2Txb = new TextBox[rowCount];
            buttonAdd = new Button[rowCount + 1];
            buttonRmv = new Button[rowCount];
            //checkBoxs = new CheckBox[rowCount];

            for (int i = 0; i < COL_COUNT; i++)
            {
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            }

            for (int i = 0; i < rowCount; i++)
            {
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                
                Label numLbl = new Label();
                numLbl.Text = i.ToString("X");
                numLbl.Width = 25;
                tableLayoutPanel1.Controls.Add(numLbl, 0, i);

                labelTxb[i] = new TextBox();
                labelTxb[i].Width = 50;
                tableLayoutPanel1.Controls.Add(labelTxb[i], 1, i);

                opcodeTxb[i] = new TextBox();
                opcodeTxb[i].Width = 50;
                tableLayoutPanel1.Controls.Add(opcodeTxb[i], 2, i);

                r1Txb[i] = new TextBox();
                r1Txb[i].Width = 50;
                tableLayoutPanel1.Controls.Add(r1Txb[i], 3, i);

                r2Txb[i] = new TextBox();
                r2Txb[i].Width = 50;
                tableLayoutPanel1.Controls.Add(r2Txb[i], 4, i);

                buttonAdd[i] = new Button();
                buttonAdd[i].Text = "+";
                buttonAdd[i].Width = 30;
                buttonAdd[i].Name = i.ToString();
                buttonAdd[i].Click += new EventHandler(buttonAdd_Click);
                tableLayoutPanel1.Controls.Add(buttonAdd[i],5,i);

                buttonRmv[i] = new Button();
                buttonRmv[i].Text = "-";
                buttonRmv[i].Width = 30;
                buttonRmv[i].Name = i.ToString();
                buttonRmv[i].Click += new EventHandler(buttonRmv_Click);
                tableLayoutPanel1.Controls.Add(buttonRmv[i], 6, i);

                //comment.Add("");

                //checkBoxs[i] = new CheckBox();
                //checkBoxs[i].Text = "Labels";
                //tableLayoutPanel1.Controls.Add(checkBoxs[i], 6, i);
            }

            buttonAdd[rowCount] = new Button();
            buttonAdd[rowCount].Text = "+";
            buttonAdd[rowCount].Width = 30;
            buttonAdd[rowCount].Name = rowCount.ToString();
            buttonAdd[rowCount].Click += new EventHandler(buttonAdd_Click);
            tableLayoutPanel1.Controls.Add(buttonAdd[rowCount], 5, rowCount);

        }

        protected void buttonAdd_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            // identify which button was clicked and perform necessary actions
            int index = Int32.Parse(button.Name);
            ReadTextbox();

            program.Insert(index, new Instruction("", "", new string[2]{"",""}, ""));
            comment.Insert(index,"");

            //checkedLabels.Insert(index, false);

            rowCount += 1;
            ResizeForm();
            WriteTextbox();
        }

        protected void buttonRmv_Click(object sender, EventArgs e)
        {
            if (rowCount <= 1)
                return;

            Button button = sender as Button;
            // identify which button was clicked and perform necessary actions
            int index = Int32.Parse(button.Name);
            ReadTextbox();

            program.RemoveAt(index);
            comment.RemoveAt(index);

            //checkedLabels.RemoveAt(index);

            rowCount -= 1;
            ResizeForm();
            WriteTextbox();
        }

        private void AddNop(object sender, EventArgs e)
        {
            ReadTextbox();

            // Remove all NOPs
            int i = 0;
            for (int j = 0; j < rowCount; j += nopCount + 1)
            {
                for (int k = 0; k < nopCount; k++)
                { 
                    program.RemoveAt(i + 1);
                    comment.RemoveAt(i + 1);
                }
                i++;
            }

           // Original rowCount
           rowCount = rowCount / (nopCount + 1);

           nopCount = Convert.ToInt32(nopNumUpDown.Value);
           
           // insert NOPs
           for (int j = 0; j < rowCount; j ++)
            {
                for (int k = 0; k < nopCount; k++)
                {
                    program.Insert(j * (nopCount+1) + k + 1, new Instruction("", "NOP", new string[2] { "", "" }, ""));
                    comment.Insert(j * (nopCount + 1) + k + 1, "");
                }

            }

            rowCount = rowCount + rowCount * nopCount;

            ResizeForm();
            WriteTextbox();
        }

        protected void ReadTextbox()
        {
            program.Clear();

            //***Add Ignore space from txb.

            for (int i = 0; i < rowCount; i++)
            {
                //if (opcodeTxb[i].Text == "")
                //    continue;
                program.Add(new Instruction(
                    labelTxb[i].Text, opcodeTxb[i].Text, 
                    new string[2] { r1Txb[i].Text, r2Txb[i].Text },
                    comment.ElementAt(i)
                    ));

                //checkedLabels.Add(checkBoxs[i].Checked);
            }
        }

        protected void WriteTextbox()
        {
            if (opcodeTxb.Count() != rowCount)
                return;

            comment.Clear();

            for (int i = 0; i < program.Count(); i++)
            {
                labelTxb[i].Text = program.ElementAt(i).label;
                opcodeTxb[i].Text = program.ElementAt(i).opcodeText;
                r1Txb[i].Text = program.ElementAt(i).r[0];
                r2Txb[i].Text = program.ElementAt(i).r[1];

                comment.Add(program.ElementAt(i).comment);
                //comment[i] = program.ElementAt(i).comment;
                //checkBoxs[i].Checked = checkedLabels.ElementAt(i);
            }
        }


        protected void serializeToFile()
        {
            FileStream file = null;

            try
            {
                file = new FileStream(
                    fileName, FileMode.Create, FileAccess.Write);

                // Serialize using List<TimeAlarm>.
                XmlSerializer alarmWriter
                    = new XmlSerializer(typeof(List<Instruction>));
                alarmWriter.Serialize(file, program);


            }
            catch (SerializationException serEx)
            {
                MessageBox.Show("Error saving: " + serEx.Message);
            }
            catch (IOException ioEx)
            {
                MessageBox.Show("Error saving: " + ioEx.Message);
            }
            finally
            {
                if (file != null)
                    file.Close();
            }
        }


        private void DeserializeFromFile()
        {
            FileStream file = null;

            try
            {
                file = new FileStream(
                    fileName, FileMode.Open, FileAccess.Read);

                // Deserialize using List<TimeAlarm>.
                XmlSerializer alarmReader
                    = new XmlSerializer(
                        typeof(List<Instruction>),                  // type of collection to store.
                        new Type[] { typeof(Instruction) }    // need to tell what is each element in the collection.
                        );

                program = (List<Instruction>)alarmReader.Deserialize(file);

                rowCount = program.Count();
            }
            catch (SerializationException serEx)
            {
                MessageBox.Show("Error loading: " + serEx.Message);
            }
            catch (IOException ioEx)
            {
                MessageBox.Show("Error loading: " + ioEx.Message);
            }
            finally
            {
                if (file != null)
                    file.Close();
            }
        }

        private void binaryCopyBtn_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(binaryTxb.Text);
        }

        private void hex1CopyBtn_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(hex1Txb.Text);
        }

        private void hex2CopyBtn_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(hex2Txb.Text);
        }

        private void memHexCopyBtn_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(memHexTxb.Text);
        }

        private void importBtn_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fileName = openFileDialog1.FileName;
                DeserializeFromFile();
                if (program.Count() < 1)
                    rowCount = 1;
                else
                    rowCount = program.Count();

                ResizeForm();

                WriteTextbox();

            }
        }

        private void ReadFromHex_Click(object sender, EventArgs e)
        {
            try
            {
                program.Clear();
                comment.Clear();

                string inputStr = memHexTxb.Text;
                string[] lines = Regex.Split(inputStr, "\r\n");
                foreach (var instrLine in lines)
                {
                    program.Add(new Instruction(instrLine));
                }

                rowCount = program.Count();
                ResizeForm();
                WriteTextbox();
                ReadTextbox();

                serializeToFile();
                MessageBox.Show("Read and saved successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0} Exception caught.", ex));
            }
        }

    }

}
