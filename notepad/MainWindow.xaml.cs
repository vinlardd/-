﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace notepad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void mi_save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog fileDialog =
                new SaveFileDialog();

            fileDialog.ShowDialog();

            if (string.IsNullOrEmpty(fileDialog.SafeFileName))
                return;
            File.WriteAllText(fileDialog.FileName, tb_content.Text);
        }

        private void mi_open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog
                = new OpenFileDialog();
            fileDialog.ShowDialog();


            if (string.IsNullOrEmpty(fileDialog.FileName)) 
                return;
            var content = 
                File.ReadAllText
                (fileDialog.FileName);
            tb_content.Text = content;
        }

        private void mi_about_Click(object sender, RoutedEventArgs e)
        {
            Windows.About about = new Windows.About();

            about.Show();

            // ShowDialog(); - открыть в формате диалогового окна
            // this.Close(); - закрыть текущее окно
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            tb_content.Height = this.Height;
        }
    }
}
