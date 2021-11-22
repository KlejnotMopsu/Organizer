using System;
using System.Collections.Generic;
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

namespace Organizer.Views
{
    /// <summary>
    /// Interaction logic for NotesView.xaml
    /// </summary>
    public partial class NotesView : UserControls.BaseUserControl
    {
        #region Constructor
        public NotesView()
        {
            InitializeComponent();
        }
        #endregion

        private void AddNoteButton_Click(object sender, RoutedEventArgs e)
        {
            //NoteAdderText.Visibility = Visibility.Visible;
            //NoteAdderText.Focus();

            /*
            TextBox noteAdder = new TextBox()
            {
                Margin = new Thickness(5)
            };
            */
            //MainGrid.Children.Add(noteAdder);
            //noteAdder.Focus();
            //noteAdder.PreviewKeyDown += NoteAdder_PreviewKeyDown;
        }
        /*
        private void NoteAdder_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine("previerwing");
            if (e.Key == Key.Enter)
            {              
                Models.Globals.AddNoteToDb( ((TextBox)sender).Text );
                this.MainGrid.Children.Remove((TextBox)sender);

                //this.NotesItemsControl.ItemsSource = Models.Globals.AllNotes;
            }
        }*/

        #region Animations
        private void AnimateNoteAdderIn()
        {

        }
        #endregion
    }
}
