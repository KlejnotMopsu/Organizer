using Organizer.Models;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Organizer.UserControls
{
    /// <summary>
    /// Interaction logic for NoteDisplayControl.xaml
    /// </summary>
    public partial class NoteDisplayControl : UserControl
    {
        #region Dependency properties
        public string NoteContent
        {
            get { return (string)GetValue(NoteContentProperty); }
            set { SetValue(NoteContentProperty, value); }
        }
        public static readonly DependencyProperty NoteContentProperty =
            DependencyProperty.Register("NoteContent", typeof(string), typeof(NoteDisplayControl));


        public NoteModel AssignedNote
        {
            get { return (NoteModel)GetValue(AssignedNoteProperty); }
            set { SetValue(AssignedNoteProperty, value); }
        }
        public static readonly DependencyProperty AssignedNoteProperty =
            DependencyProperty.Register("AssignedNote", typeof(NoteModel), typeof(NoteDisplayControl));


        public Brush BgBrush
        {
            get { return (Brush)GetValue(BgBrushProperty); }
            set { SetValue(BgBrushProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BgBrush.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BgBrushProperty =
            DependencyProperty.Register("BgBrush", typeof(Brush), typeof(NoteDisplayControl));

        public bool IsHighlighted
        {
            get { return (bool)GetValue(IsHighlightedProperty); }
            set { SetValue(IsHighlightedProperty, value); }
        }
        public static readonly DependencyProperty IsHighlightedProperty =
            DependencyProperty.Register("IsHighlighted", typeof(bool), typeof(NoteDisplayControl));

        #endregion


        #region Constructor
        public NoteDisplayControl()
        {
            InitializeComponent();
            Loaded += NoteDisplayControl_Loaded;
        }

        private void NoteDisplayControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (AssignedNote.Is_highlighted)
            {
                Background = Brushes.Red;
            }
        }
        #endregion

        #region Methods
        private void SwitchNoteHighlight()
        {
            AssignedNote.SwitchHighlight();

            if (AssignedNote.Is_highlighted)
                AnimateHighlightIn();
            else
                AnimateHighlightOut();
        }
        #endregion

        #region Button clicks
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("You sure?", "Oi", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Globals.DeleteNote(AssignedNote);
            }            
        }

        private void SwitchHighlightButton_Click(object sender, RoutedEventArgs e)
        {
            SwitchNoteHighlight();
        }
        #endregion

        #region Mouse clicks
        private void TextDisplay_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
                SwitchNoteHighlight();
        }
        #endregion

        #region Animations
        private void AnimateHighlightIn()
        {
            this.Background = new SolidColorBrush(Globals.NoteHighlightBrush);

            /*
            ColorAnimation anim = new ColorAnimation()
            {
                Duration = TimeSpan.FromMilliseconds(1000),
                To = Globals.NoteHighlightBrush
            };

            this.Background.BeginAnimation(anim);
            */
        }
        private void AnimateHighlightOut()
        {
            this.Background = new SolidColorBrush(Colors.Transparent);
        }
        #endregion

        
    }
}
