using System.Security.Cryptography;
using System.Text;

namespace steganografia
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            checkBox_Encrypt_CheckedChanged(this, EventArgs.Empty);
        }
        private void button_FileFrom_Click(object sender, EventArgs e)
        {
            if (openFileDialog_FileFrom.ShowDialog() == DialogResult.OK)
            {
                textBox_FileFrom.Text = openFileDialog_FileFrom.FileName;
            }
        }

        private void button_FileTo_Click(object sender, EventArgs e)
        {
            if (saveFileDialog_FileTo.ShowDialog() == DialogResult.OK)
            {
                textBox_FileTo.Text = saveFileDialog_FileTo.FileName;
            }
        }

        private bool areAllFieldsFilledIn()
        {
            if (textBox_FileFrom.Text == string.Empty || textBox_Text.Text == string.Empty || pictureBox_FileFrom.Image == null 
                || (checkBox_Encrypt.Checked == true && textBox_Pass.Text == string.Empty)) return false;
            else return true;
        }

        private void button_WriteText_Click(object sender, EventArgs e)
        {
            if (!areAllFieldsFilledIn() || textBox_FileTo.Text == string.Empty)
            {
                MessageBox.Show("Wypełnij wszystkie pola.");
                return;
            }
            try
            {
                byte[] plaintext = Encoding.UTF8.GetBytes(textBox_Text.Text);
                byte[] result = new byte[plaintext.Length];
                if (checkBox_Encrypt.Checked) result = Encryptor.EncryptBytes(plaintext, textBox_Pass.Text);
                else result = plaintext;
                if (Steganography.HideText(textBox_FileFrom.Text, textBox_FileTo.Text, result)) 
                    MessageBox.Show($"Tekst ukryto w obrazku:\n{textBox_FileFrom.Text} -> {textBox_FileTo.Text}");
                else MessageBox.Show($"Błąd ukrywania tekstu do obrazka:\n{textBox_FileFrom.Text} -> {textBox_FileTo.Text}");
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Nie udało się odczytać pliku.\n\nSzczegóły: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd\n\nSzczegóły: {ex.Message}\n\n{ex.StackTrace}");
            }
        }

        private void button_ReadText_Click(object sender, EventArgs e)
        {
            if (!areAllFieldsFilledIn())
            {
                MessageBox.Show("Wypełnij wszystkie pola.");
                return;
            }
            try
            {
                // tutaj będzie metoda desteganografii
                byte[] encryptedData = Steganography.RevealText(textBox_FileFrom.Text);
                byte[] result = new byte[encryptedData.Length];
                if (checkBox_Encrypt.Checked) result = Encryptor.DecryptBytes(encryptedData, textBox_Pass.Text);
                else result = encryptedData;
                textBox_Text.Text = Encoding.UTF8.GetString(result);
                MessageBox.Show($"Tekst wyciągnięto z obrazka: {textBox_FileFrom.Text}");
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Nie udało się odczytać pliku.\n\nSzczegóły: {ex.Message}");
            }
            catch (Exception ex) when (ex is CryptographicException || ex is ArgumentOutOfRangeException)
            {
                MessageBox.Show($"Błąd dekryptarzu.\n\nSzczegóły: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd dekryptarzu.\n\nSzczegóły: {ex.Message}\n\n{ex.StackTrace}");
            }
        }

        private void button_Pass_Click(object sender, EventArgs e)
        {
            if (textBox_Pass.PasswordChar == '\0')
            {
                textBox_Pass.PasswordChar = '*';
                button_Pass.Text = "🙈";
            }
            else
            {
                textBox_Pass.PasswordChar = '\0';
                button_Pass.Text = "👁";
            }
        }

        private void checkBox_Encrypt_CheckedChanged(object sender, EventArgs e)
        {
            textBox_Pass.Enabled = checkBox_Encrypt.Checked;
            button_Pass.Enabled = checkBox_Encrypt.Checked;
        }
    }
}
