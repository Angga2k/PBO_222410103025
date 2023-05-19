using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBO_222410103025
{
    internal class Modul
    {
        public static DialogResult showDialog(String message)
        {
            return MessageBox.Show(message, "Konfirmasi",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
        }

        public static void dialogError(String message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void dialogBerhasil(String message)
        {
            MessageBox.Show(message, "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
