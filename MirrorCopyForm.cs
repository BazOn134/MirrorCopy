using System;
using System.Collections.Generic;
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
        public Dictionary<string, DateTime> listFiles;

        #region Инициализаторы
        public MirrorCopyForm()
        {
            InitializeComponent();
        }               

        /// <summary>Загрузчик главной формы</summary>
        private void MirrorCopyForm_Load(object sender, EventArgs e)
        {
            InitialData();
            InitialTextField();
            Application.DoEvents();
        }

        /// <summary>Производит инициализацию и первичное заполнение DATA-класса</summary>
        private void InitialData()
        {
            //ТОДО создать штатное получение захардкоденных данных
            GlobalData.FullPathFolderOrig = @"C:\Users\Zalcman\Desktop\ТЕСТ_АРХ\Папка ОСНОВА";
            GlobalData.FullPathFolderOrig = @"\\Server1c\общие документы\Документация СП\Технические предложения\!Комплексы";
            GlobalData.FullPathFolderCopy = @"C:\Users\Zalcman\Desktop\ТЕСТ_АРХ\!Архив";
            GlobalData.FullPathFolderArch = @"C:\Users\Zalcman\Desktop\ТЕСТ_АРХ\!Архив\Папка ОСНОВА";
            GlobalData.FullPathLogSaveToFile = false;
        }

        /// <summary>Производит заполнение текстовых полей формы</summary>
        private void InitialTextField()
        {
            lbl_PathArch.Text = GlobalData.FullPathFolderArch;
            lbl_PathCopy.Text = GlobalData.FullPathFolderCopy;
            lbl_SaveLog.Text = GlobalData.FullPathLogSaveToFile ?  "Информация сохраняется в LOG": "Информация в LOG не сохраняется";
        }
        #endregion

        #region Кликеры текстовых полей
        private void lbl_PathArch_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Directory.Exists(lbl_PathArch.Text)) Process.Start(lbl_PathArch.Text);
        }

        private void lbl_PathCopy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Directory.Exists(lbl_PathCopy.Text)) Process.Start(lbl_PathCopy.Text);
        }
        
        private void lbl_SaveLog_Click(object sender, EventArgs e)
        {
            GlobalData.FullPathLogSaveToFile = true;
            InitialTextField();
        }
        #endregion

        /// <summary>Обработчик нажатия управляющих кнопок</summary>
        private void Button_Click(object sender, EventArgs e)
        {
            //!ТОДО содать класс логики и классы действий
            var button = (Button)sender;
            StateSituation(button.Name.ToString() != "btn_Start");
            if (button.Name.ToString() == "btn_Start")
            {
                ButtonStatus(true, false);
                if (listFiles is null)
                {
                    listFiles = new Dictionary<string, DateTime>();
                }

                StartAcync(listFiles);
            }
            else if (button.Name.ToString() == "btn_Pause")
            {
                ButtonStatus(true, true);
            }
            else if (button.Name.ToString() == "btn_Stop")
            {
                ButtonStatus(false, false);
            }
        }

        private void StartAcync(Dictionary<string, DateTime> listFiles)
        {
            Debug.WriteLine("");
            Debug.WriteLine("Старт обработки ===========================================================");
            MessageBox.Show("Before Task.Run");
            var Process = new RecursiveDirectoryFileProcessor();
            // ТОДО добавить сериализацию класса состава папки-получателя
            Task.Run(() => Process.Start((object)listFiles)); // сбор в listFiles информации по файлам в папке-источнике
            MessageBox.Show("After Task.Run");
            ButtonStatus(false, false);
            StateSituation(true);
        }

        public void ButtonStatus(bool proc, bool paus)
        {
            GlobalData.StageInProcess = proc;
            GlobalData.StageIsOnPause = paus;
        }

        private void StateSituation(bool state=false)
        {
            btn_Start.Visible = state;
            btn_Pause.Visible = !state;
            btn_Stop.Visible = !state;
        }

        #region настройки 
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

        #endregion

    }
}

