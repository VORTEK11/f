using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AudioPlayer
{
    public partial class MainWindow : Window
    {
        private List<string> audioFiles;
        private int currentFileIndex = 0;
        private bool isPlaying = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SelectFolder_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new CommonOpenFileDialog
            {
                IsFolderPicker = true,
                Title = "Выберите папку с аудиофайлами"
            };

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                string folderPath = dialog.FileName;
                LoadAudioFiles(folderPath);
                if (audioFiles.Count > 0)
                    PlayAudio(audioFiles.First());
            }
        }

        private void LoadAudioFiles(string folderPath)
        {
            audioFiles = Directory.GetFiles(folderPath, "*.mp3").ToList();
        }

        private void PlayAudio(string filePath)
        {
            mediaElement.Stop();
            mediaElement.Source = new Uri(filePath);
            mediaElement.Play();
            isPlaying = true;
            playPauseButton.Content = "&#xE769;";
        }

        private void PlayPause_Click(object sender, RoutedEventArgs e)
        {
            if (isPlaying)
            {
                mediaElement.Pause();
                isPlaying = false;
                playPauseButton.Content = "&#xE768;";
            }
            else
            {
                mediaElement.Play();
                isPlaying = true;
                playPauseButton.Content = "&#xE769;";
            }
        }

        private void Previous_Click(object sender, RoutedEventArgs e)
        {
            if (currentFileIndex > 0)
            {
                currentFileIndex--;
                PlayAudio(audioFiles[currentFileIndex]);
            }
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (currentFileIndex < audioFiles.Count - 1)
            {
                currentFileIndex++;
                PlayAudio(audioFiles[currentFileIndex]);
            }
        }

        private void Repeat_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Position = TimeSpan.Zero;
            mediaElement.Play();
        }

        private void Shuffle_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            currentFileIndex = random.Next(audioFiles.Count);
            PlayAudio(audioFiles[currentFileIndex]);
        }

        private void mediaElement_MediaOpened(object sender, RoutedEventArgs e)
        {
            positionSlider.Minimum = 0;
            positionSlider.Maximum = mediaElement.NaturalDuration.TimeSpan.TotalSeconds;
        }

        private void mediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            if (currentFileIndex < audioFiles.Count - 1)
            {
                currentFileIndex++;
                PlayAudio(audioFiles[currentFileIndex]);
            }
            else
            {
                mediaElement.Stop();
                isPlaying = false;
                playPauseButton.Content = "&#xE768;";
            }
        }

        private void positionSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (mediaElement.NaturalDuration.HasTimeSpan)
            {
                TimeSpan newPosition = TimeSpan.FromSeconds(positionSlider.Value);
                mediaElement.Position = newPosition;
            }
        }
    }
}
