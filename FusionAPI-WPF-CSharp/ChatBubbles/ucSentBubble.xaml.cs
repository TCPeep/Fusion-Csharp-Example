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

namespace FusionAPI_WPF_CSharp.ChatBubbles
{
    /// <summary>
    /// Interaction logic for ucSentBubble.xaml
    /// </summary>
    public partial class ucSentBubble : UserControl
    {
        public Fusion.ChatResponse message;

        public ucSentBubble(Fusion.ChatResponse message)
        {
            InitializeComponent();
            lblTitle.Content = message.Author[1];
            tbMessage.Text = message.Content;
        }
    }
}
