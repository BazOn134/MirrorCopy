using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZAW.MirrorCopy.Controller;

namespace ZAW.MirrorCopy
{
    public partial class MirrorCopyForm : Form
    {
        public MirrorCopyForm()
        {
            InitializeComponent();
        }

        private void MirrorCopyForm_Load(object sender, EventArgs e)
        {
            InitialData();
            Application.DoEvents();
            lbl_PathArch.Text = GlobalData.FullPathFolderArch;
            lbl_PathCopy.Text = GlobalData.FullPathFolderCopy;
            lbl_SaveLog.Text = GlobalData.FullPathLogSaveToFile ?  "Информация сохраняется в LOG": "Информация в LOG не сохраняется";
        }

        /// <summary>
        /// Производит инициализацию и первичное заполнение DATA-класса
        /// </summary>
        private void InitialData()
        {
            //ТОДО создать штатное получение захардкоденных данных
            GlobalData.FullPathFolderOrig = @"C:\Users\Zalcman\Desktop\ТЕСТ_АРХ\Папка ОСНОВА";
            GlobalData.FullPathFolderCopy = @"C:\Users\Zalcman\Desktop\ТЕСТ_АРХ\!Архив";
            GlobalData.FullPathFolderArch = @"C:\Users\Zalcman\Desktop\ТЕСТ_АРХ\!Архив\Папка ОСНОВА";
            GlobalData.FullPathLogSaveToFile = false;
        }

        private void lbl_PathArch_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Directory.Exists(lbl_PathArch.Text)) Process.Start(lbl_PathArch.Text);
        }

        private void lbl_PathCopy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Directory.Exists(lbl_PathCopy.Text)) Process.Start(lbl_PathCopy.Text);
        }

        /// <summary> 
        /// Выполняет запуск выполнения биснес-логики
        /// </summary>
        private  void btn_Start_Click(object sender, EventArgs e)
        {
            //!ТОДО содать класс логики и классы действий
            var button = (Button)sender;
            if (button.Text == "Остановить")
            {
                button.Text = "Продолжить";
                button.BackColor =Color.GreenYellow;
                tslbl_StatusText.Text = "Процесс прерван пользователем";
            }
            else
            {
                button.Text = "Остановить";
                button.BackColor =Color.Red;
                tslbl_StatusText.Text = "Обработка продолжается";
                Zapusk(sender, e);
            }
        }

        private async void Zapusk(object sender, EventArgs e)
        {
            var Process = new RecursiveDirectoryFileProcessor();
            await Task.Run(() => Process.Start());
            btn_Start_Click(sender, e);
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ТОДО содать форму настроек
            MessageBox.Show("Функция в разработке");
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ТОДО содать форму справки
            MessageBox.Show("Функция в разработке");
        }
    }
}

