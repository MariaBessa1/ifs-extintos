using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Extintos
{
    internal class Config
    {
        public static void Fullscreen(Form form) //método para configurar o formulário em tela cheia
        {
            if (form == null) return;

          form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable; // Configura o estilo da borda do formulário para ser redimensionável
            form.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height); // Configura o tamanho do formulário para ocupar toda a tela
            form.WindowState = FormWindowState.Maximized; // Configura o estado da janela para maximizado, garantindo que o formulário seja exibido em tela cheia
            form.Show();
        }


        //public List<String> jogadores ()
    }
}