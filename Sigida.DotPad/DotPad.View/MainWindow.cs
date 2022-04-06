using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotPad.View
{
    public partial class MainWindow : Form
    {
        private Notepad _notepad;
        public MainWindow()
        {
            InitializeComponent();
            _notepad = new Notepad();

            textBoxRealm.TextChanged += StatusBarTextChanger;   
        }

        /// <summary>
        /// Срабатывает при изменении текста в поле ввода текста блокнота 
        /// Уставливает параметры для объекта Notepad
        /// Изменяет текст в status bar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void StatusBarTextChanger(object sender, EventArgs e)
        {
            var text = (TextBox)sender;

            //var space = text.Text.Split(' ').Length - 1;
            
            _notepad.CurentLine = text.Lines.Length;
              
            if (text.Lines.Length != 0) 
            {
                _notepad.CurentColumn = text.Lines[_notepad.CurentLine - 1].Length;
            }
         
            _notepad.Characters = text.Text.Replace(" ","").Length;

            statusBar.Items[1].Text = $"Ln {_notepad.CurentLine}, Col {_notepad.CurentColumn}";         
        }


    }

    class Notepad
    {
        private int _currentLine = 1;
        public int Characters { get; set; }  
        public int CurentLine
        {
            get => _currentLine;
            set
            {
                if (value <= 0)
                    _currentLine = 1;
                else
                    _currentLine = value;
            }
        }
        public int CurentColumn { get; set; }
    }
}
