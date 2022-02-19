using System.Text;

namespace Quiz_2
{
    public partial class Form1 : Form
    {
        int Num1 = 0;
        int Num2 = 0;
        int Num3 = 0;
        int Num4 = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV (*.csv) | *.csv";
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] readAllText = File.ReadAllLines(openFileDialog.FileName);
                /*
                string readAllText = File.ReadAllText(openFileDialog.FileName);
                //this.textBox1.Text = readAllText;
                //this.dataGridView1.Rows.Add();
                */
            

                for(int i = 0; i < readAllText.Length; i++)
                {
                    //string allDATARAW = readAllline[i];
                    //string[] allDATASplied = allDATARAW.Split(',');
                    //allDATA allDATA = new allDATA(allDATASplited[0], allDATASplited[1], allDATASplited[2]);
                    //addDataToGridView(AllDATAs);
                    //TODO: Add AllDATA object to DataGridView
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = textBoxList.Text;
            dataGridView1.Rows[n].Cells[1].Value = textBoxIncome.Text;
            dataGridView1.Rows[n].Cells[2].Value = textBoxExpenses.Text;

            
            Num2 = Convert.ToInt32(textBoxIncome.Text);
            Num4 = Convert.ToInt32(textBoxExpenses.Text);

            Num1 = Num2 + Num1;
            Num3 = Num4 + Num3;

            textBoxTotalIncome.Text = Num1.ToString();
            textBoxTotalExpenses.Text = Num3.ToString();
            
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "CSV (*.csv) | *.csv";
                bool fileError = false;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (!fileError)
                    {
                        try
                        {
                            int columnCount = dataGridView1.Columns.Count;
                            string column = "";
                            string[] outputCSV = new string[dataGridView1.Rows.Count + 1];
                            for (int i = 0; i < columnCount; i++)
                            {
                                column += dataGridView1.Columns[i].HeaderText.ToString() + ",";
                            }
                            outputCSV[0] += column;
                            for (int i = 1; (i - 1) < dataGridView1.Rows.Count; i++)
                            {
                                for (int j = 0; j < columnCount; j++)
                                {
                                    outputCSV[i] += dataGridView1.Rows[i - 1].Cells[j].Value.ToString() + ",";
                                }
                            }
                            File.WriteAllLines(saveFileDialog.FileName, outputCSV, Encoding.UTF8);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
        }
    }
}