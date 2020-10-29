using Microsoft.WindowsAzure.Storage;
using NotesApp.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Speech.Recognition;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NotesApp.Views
{
    /// <summary>
    /// Interaction logic for NotesWindow.xaml
    /// </summary>
    /// 

    
    public partial class NotesWindow : Window
    {
        SpeechRecognitionEngine recognizer;
        NotesVM VM;
        public NotesWindow()
        {
            InitializeComponent();

            VM =  this.Resources["VM"] as  NotesVM;
            ContainerDockPanel.DataContext = VM;

            VM.SelectedNoteChanged += VM_SelectedNoteChanged;

            var currentCulture = (from r in SpeechRecognitionEngine.InstalledRecognizers()
                                  where r.Culture.Equals(Thread.CurrentThread.CurrentCulture)
                                  select r).FirstOrDefault();
            recognizer = new SpeechRecognitionEngine(currentCulture);

            recognizer.SpeechRecognized += Recognizer_SpeechRecognized;

            GrammarBuilder builder = new GrammarBuilder();
            builder.AppendDictation();

            Grammar grammar = new Grammar(builder);
            recognizer.LoadGrammar(grammar);
            recognizer.SetInputToDefaultAudioDevice();

            var fontFamilySource = Fonts.SystemFontFamilies.OrderBy(f => f.Source).ToList();
            List<double> fontSizeSource = new List<double>() { 8, 10, 12, 14, 16, 18, 20, 24, 30, 35, 40, 50, 60, 70, 80 };

            fontFamilyComboBox.ItemsSource = fontFamilySource;
            fontSizeComboBox.ItemsSource = fontSizeSource;
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            if (string.IsNullOrEmpty(App.UserId))
            {
                
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.ShowDialog();
            }
        }
        private void Recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string recognizedText = e.Result.Text;
            contentReachTextBox.Document.Blocks.Add(new Paragraph(new Run(recognizedText)));
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void contentReachTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int ammountofCharacter = new TextRange(contentReachTextBox.Document.ContentStart, contentReachTextBox.Document.ContentEnd).Text.Length;

            statusTextBlock.Text = $"Document length:{ammountofCharacter} characters";
        }

        private void boldButton_Click(object sender, RoutedEventArgs e)
        {
            bool isButtonEnable = (sender as ToggleButton).IsChecked ?? false;

            if (isButtonEnable)
            {
                contentReachTextBox.Selection.ApplyPropertyValue(Inline.FontWeightProperty, FontWeights.Bold);
            }
            else
            {
                contentReachTextBox.Selection.ApplyPropertyValue(Inline.FontWeightProperty, FontWeights.Normal);
            }
        }

        private void speechButton_Click(object sender, RoutedEventArgs e)
        {
            bool isButtonEnable = (sender as ToggleButton).IsChecked ?? false;

            if (isButtonEnable)
            {
                recognizer.RecognizeAsync(RecognizeMode.Multiple);
            }
            else
            {
                recognizer.RecognizeAsyncStop();
            }
        }

        private void contentReachTextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            var selectedBoldState = contentReachTextBox.Selection.GetPropertyValue(Inline.FontWeightProperty);
            var selectedItalicState = contentReachTextBox.Selection.GetPropertyValue(Inline.FontStyleProperty);

            var selectedUnderlineState = contentReachTextBox.Selection.GetPropertyValue(Inline.TextDecorationsProperty);

            boldButton.IsChecked = (selectedBoldState != DependencyProperty.UnsetValue) && (selectedBoldState.Equals(FontWeights.Bold));
            italicButton.IsChecked = (selectedItalicState != DependencyProperty.UnsetValue) && (selectedItalicState.Equals(FontStyles.Italic));
            underlineButton.IsChecked = (selectedUnderlineState != DependencyProperty.UnsetValue) && (selectedUnderlineState.Equals(TextDecorations.Underline));

            fontFamilyComboBox.SelectedItem = contentReachTextBox.Selection.GetPropertyValue(Inline.FontFamilyProperty);
            fontSizeComboBox.Text = (contentReachTextBox.Selection.GetPropertyValue(Inline.FontSizeProperty)).ToString();


        }

        private void italicButton_Click(object sender, RoutedEventArgs e)
        {
            bool isButtonEnable = (sender as ToggleButton).IsChecked ?? false;

            if (isButtonEnable)
            {
                contentReachTextBox.Selection.ApplyPropertyValue(Inline.FontStyleProperty, FontStyles.Italic);
            }
            else
            {
                contentReachTextBox.Selection.ApplyPropertyValue(Inline.FontStyleProperty, FontStyles.Normal);
            }
        }

        private void underlineButton_Click(object sender, RoutedEventArgs e)
        {
            bool isButtonEnable = (sender as ToggleButton).IsChecked ?? false;

            if (isButtonEnable)
            {
                contentReachTextBox.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Underline);
            }
            else
            {
                TextDecorationCollection textDecoration;

                (contentReachTextBox.Selection.GetPropertyValue(Inline.TextDecorationsProperty) as TextDecorationCollection).TryRemove(TextDecorations.Underline, out textDecoration);


                contentReachTextBox.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, textDecoration);
            }
        }

        private void fontFamilyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            contentReachTextBox.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, fontFamilyComboBox.SelectedItem);
        }

        private void fontSizeComboBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(fontSizeComboBox.Text))
                contentReachTextBox.Selection.ApplyPropertyValue(Inline.FontSizeProperty, fontSizeComboBox.Text);
        }
        private async void VM_SelectedNoteChanged(object sender, EventArgs e)
        {
            contentReachTextBox.Document.Blocks.Clear();

            if (VM.SelectedNote != null)
            {
                if (!string.IsNullOrEmpty(VM.SelectedNote.FileLocation))
                {
                    //Reading file(blob) from azure container
                    Stream rtffileStream = null;
                    using(HttpClient client = new HttpClient())
                    {
                        var response = await client.GetAsync(VM.SelectedNote.FileLocation);
                        rtffileStream = await response.Content.ReadAsStreamAsync();
                        TextRange textRange = new TextRange(contentReachTextBox.Document.ContentStart, contentReachTextBox.Document.ContentEnd);
                        textRange.Load(rtffileStream, DataFormats.Rtf);
                    }
                    //using (FileStream fileStream = new FileStream(VM.SelectedNote.FileLocation, FileMode.Open))
                    //{
                    //    TextRange textRange = new TextRange(contentReachTextBox.Document.ContentStart, contentReachTextBox.Document.ContentEnd);
                    //    textRange.Load(fileStream, DataFormats.Rtf);
                    //}
                }
            }

        }
        private async void SaveFileButton_Click(object sender, RoutedEventArgs e)
        {
            string filename = $"{VM.SelectedNote.Id}.rtf";
            string rtfFile = System.IO.Path.Combine(Environment.CurrentDirectory, filename);
            VM.SelectedNote.FileLocation = rtfFile;

            using (FileStream fileStream = new FileStream(rtfFile, FileMode.Create))
            {
                TextRange textRange = new TextRange(contentReachTextBox.Document.ContentStart, contentReachTextBox.Document.ContentEnd);

                textRange.Save(fileStream, DataFormats.Rtf);

            }

            string fileUrl = await Uploadfile(rtfFile, filename);
            VM.SelectedNote.FileLocation = fileUrl;
            VM.UpdateSelectedNote();

        }

        //function to upload file(blob) to azure
        private async Task<string> Uploadfile(string rtfFile, string filename)
        {
            string fileUrl = string.Empty;
            var account = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=evernotestorageaccount;AccountKey=ShkOq04VV+75hqCMpFgL8nLd0r9EO2E+O9eHJEQvxRYkJByMsbzulcaLRqTrYUoxzhHHIDWTp2i6Nzk0eWNpkw==;EndpointSuffix=core.windows.net");
            var client = account.CreateCloudBlobClient();
            var container = client.GetContainerReference("notes");
            await container.CreateIfNotExistsAsync();
            var blob = container.GetBlockBlobReference(filename);

            using (FileStream fileStream = new FileStream(rtfFile, FileMode.Open))
            {
                await blob.UploadFromStreamAsync(fileStream);
                fileUrl = blob.Uri.OriginalString;
            }
            return fileUrl;
        }
    }
}
