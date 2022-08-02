using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZAW.MirrorCopy.Controller;

namespace ZAW.MirrorCopy
{
    public partial class MirrorCopyForm : Form
    {
        //public delegate void InsertText(string text); // для записи в tslbl_StatusText из другого потока

        public List<ProcessFile> listFiles;

        /// <summary>Обновляет информацию в tslbl_StatusText</summary>
        /// <param name="value">Новый текст</param>
        public void InsertStatusText(string value)
        {
            tslbl_StatusText.Text = value;
        }

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
            lbl_PathArch.Text = TextLabel50(GlobalData.FullPathFolderOrig);
            lbl_PathCopy.Text = TextLabel50(GlobalData.FullPathFolderCopy);
            lbl_SaveLog.Text = GlobalData.FullPathLogSaveToFile ?  "Информация сохраняется в LOG": "Информация в LOG не сохраняется";
        }

        /// <summary>Сокращает путь к файлу/папке до 50-и символов (не более) путем замены наименований промежуточных пакок на "..."</summary>
        /// <param name="str">Путь к файлу/папке</param>
        /// <returns>Короткая строка, не более 50-и символов</returns>
        private string TextLabel50(string str)
        {
            string s2 = "\\";
            string[] mas = str.Split(new string[] { s2 }, StringSplitOptions.None);
            int midel = mas.Length / 2;;
            int otstup = 0; 

            while (str.Length > 50)
            {
                while (mas[midel + otstup] == "..." && mas[midel - otstup] == "...") otstup++;

                if (midel == otstup)
                {
                    str = str.Replace("...", ".");
                    if (str.Length > 50) str = "..." + str.Substring(str.LastIndexOf("\\"));
                    break;
                }

                if (mas[midel + otstup] == "..." || otstup == 0) mas[midel - otstup] = "...";
                else mas[midel + otstup] = "...";

                str = String.Join("\\", mas);
            }
            return str;
        }
        #endregion

        #region Кликеры текстовых полей
        private void lbl_PathArch_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Directory.Exists(GlobalData.FullPathFolderOrig)) Process.Start(GlobalData.FullPathFolderOrig);
        }

        private void lbl_PathCopy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Directory.Exists(GlobalData.FullPathFolderCopy)) Process.Start(GlobalData.FullPathFolderCopy);
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
            var button = (Button)sender;
            StateSituation(button.Name.ToString() != "btn_Start");
            if (button.Name.ToString() == "btn_Start")
            {
                GlobalData.StageInProcess = true;
                listFiles = new List<ProcessFile>();
                StartAcync();
            }
            else if (button.Name.ToString() == "btn_Pause")
                GlobalData.StageInProcess = true;
            else if (button.Name.ToString() == "btn_Stop")
                GlobalData.StageInProcess = false;
        }

        private async void StartAcync()
        {
            var Receiver = new ProcessReceiver();
            var Processor = new RecursiveDirectoryFileProcessor();
            // ТОДО добавить сериализацию класса состава папки-получателя
            //await Task.Run(() => Receiver.Start((object)dictFilesReceiver)); 
            tslbl_StatusText.Text = "Получение списка файлов папки-источника";
            await Task.Run(() => Processor.Start((object)listFiles)); // сбор в listFiles информации по файлам в папке-источнике
            GlobalData.StageInProcess = false;
            tslbl_StatusText.Text = "Готово";
            StateSituation(true);
        }


        /// <summary>Управление видимостью управляющих кнопок</summary>
        private void StateSituation(bool state=false)
        {
            btn_Start.Visible = state;
            btn_Pause.Visible = false; // = !state;
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

