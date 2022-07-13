using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

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
            lbl_PathArch.Text = Data.FullPathFolderArch;
            lbl_PathCopy.Text = Data.FullPathFolderCopy;
            lbl_SaveLog.Text = Data.FullPathLogSaveToFile ?  "Информация сохраняется в LOG": "Информация в LOG не сохраняется";
        }

        /// <summary>
        /// Производит инициализацию и первичное заполнение DATA-класса
        /// </summary>
        private void InitialData()
        {
            //ТОДО создать штатное получение захардкоденных данных
            Data.FullPathFolderOrig = @"C:\Users\Zalcman\Desktop\ТЕСТ_АРХ\Папка ОСНОВА";
            Data.FullPathFolderCopy = @"C:\Users\Zalcman\Desktop\ТЕСТ_АРХ\!Архив";
            Data.FullPathFolderArch = @"C:\Users\Zalcman\Desktop\ТЕСТ_АРХ\!Архив\Папка ОСНОВА";
            Data.FullPathLogSaveToFile = false;
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Start_Click(object sender, EventArgs e)
        {
            //!ТОДО содать класс логики и классы действий
            MessageBox.Show("Функция в разработке");
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

