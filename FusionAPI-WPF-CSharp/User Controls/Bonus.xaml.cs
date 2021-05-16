using Fusion;
using FusionAPI_WPF_CSharp.ChatBubbles;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace FusionAPI_WPF_CSharp.User_Controls
{
    /// <summary>
    /// Interaction logic for Bonus.xaml
    /// </summary>
    public partial class Bonus : UserControl
    {
        public System.Timers.Timer timer = new System.Timers.Timer();

        public Bonus()
        {
            InitializeComponent();
            UpdateChat();
            timer.Interval = 3500;
            timer.Elapsed += timer_Elapsed;
            timer.Start();
            lblIP.Content = "****************";
        }

        public void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                UpdateChat();
            });
        }

        private async void UpdateChat()
        {
            try
            {
                var chat = await FusionApp.GetChat();
                if (chat.Error == false)
                {
                    spMessages.Children.Clear();
                    foreach (var message in chat.Chat)
                    {
                        if (message.Author[0] == User.UserId)
                        {
                            spMessages.Children.Add(new ucSentBubble(message));
                        }
                        else
                        {
                            spMessages.Children.Add(new ucReceivedBubble(message));
                        }
                    }
                }
                else
                {
                    MessageBox.Show(chat.Message, "FusionAPI.dev");
                }
            }
            catch
            {  
            
            }
        }

        public class FusionVIP
        {
            public string ip { get; set; }
        }

        static WebClient client = new WebClient();
        FusionVIP fsnVIP = JsonConvert.DeserializeObject<FusionVIP>(client.DownloadString("https://fusionapi.dev/api/ip"));

        private void cbShowIP_Click(object sender, RoutedEventArgs e)
        {
            if (cbShowIP.IsChecked == true)
                lblIP.Content = fsnVIP.ip;
            else
                lblIP.Content = "****************";
        }

        private async void btnUpdatePass_Click(object sender, RoutedEventArgs e)
        {
            var resetResponse = await FusionApp.ResetPassword(tbOldPassword.Password, tbNewPassword.Password);
            if (resetResponse.Error == false)
            {
                MessageBox.Show(resetResponse.Message, "FusionAPI.dev");
            }
            else
            {
                MessageBox.Show(resetResponse.Message, "FusionAPI.dev");
            }
        }

        private void btnEmoji_Click(object sender, RoutedEventArgs e)
        {
            if (PeepsEmojiPicker.Visibility == Visibility.Hidden)
                PeepsEmojiPicker.Visibility = Visibility.Visible;
            else
                PeepsEmojiPicker.Visibility = Visibility.Hidden;
        }

        private void tbMessage_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbText.Text = tbMessage.Text;
        }

        private void btnSmile_Click(object sender, RoutedEventArgs e)
        {
            gridSmile.Visibility = Visibility.Visible;
            gridHeart.Visibility = Visibility.Hidden;
            gridBeef.Visibility = Visibility.Hidden;
            gridMisc.Visibility = Visibility.Hidden;
        }

        private void btnHeart_Click(object sender, RoutedEventArgs e)
        {
            gridSmile.Visibility = Visibility.Hidden;
            gridHeart.Visibility = Visibility.Visible;
            gridBeef.Visibility = Visibility.Hidden;
            gridMisc.Visibility = Visibility.Hidden;
        }

        private void btnBeef_Click(object sender, RoutedEventArgs e)
        {
            gridSmile.Visibility = Visibility.Hidden;
            gridHeart.Visibility = Visibility.Hidden;
            gridBeef.Visibility = Visibility.Visible;
            gridMisc.Visibility = Visibility.Hidden;
        }

        private void btnMisc_Click(object sender, RoutedEventArgs e)
        {
            gridSmile.Visibility = Visibility.Hidden;
            gridHeart.Visibility = Visibility.Hidden;
            gridBeef.Visibility = Visibility.Hidden;
            gridMisc.Visibility = Visibility.Visible;
        }

        #region "Smile Emoji's"

        private void emojiSmile_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tbMessage.Text = $"{tbMessage.Text}😀 ";
            tbText.Text = $"{tbText.Text}";
            tbMessage.Select(tbMessage.Text.Length, 0);
        }

        private void emojiXD_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tbMessage.Text = $"{tbMessage.Text}😆 ";
            tbText.Text = $"{tbText.Text}";
            tbMessage.Select(tbMessage.Text.Length, 0);
        }

        private void emojiSweat_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tbMessage.Text = $"{tbMessage.Text}😅 ";
            tbText.Text = $"{tbText.Text}";
            tbMessage.Select(tbMessage.Text.Length, 0);
        }

        private void emojiTrive_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tbMessage.Text = $"{tbMessage.Text}😂 ";
            tbText.Text = $"{tbText.Text}";
            tbMessage.Select(tbMessage.Text.Length, 0);
        }

        private void emojiTongue_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tbMessage.Text = $"{tbMessage.Text}😋 ";
            tbText.Text = $"{tbText.Text}";
            tbMessage.Select(tbMessage.Text.Length, 0);
        }

        private void emojiFuji_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tbMessage.Text = $"{tbMessage.Text}😎 ";
            tbText.Text = $"{tbText.Text}";
            tbMessage.Select(tbMessage.Text.Length, 0);
        }

        private void emojiParty_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tbMessage.Text = $"{tbMessage.Text}🥳 ";
            tbText.Text = $"{tbText.Text}";
            tbMessage.Select(tbMessage.Text.Length, 0);
        }

        private void emojiWorried_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tbMessage.Text = $"{tbMessage.Text}😰 ";
            tbText.Text = $"{tbText.Text}";
            tbMessage.Select(tbMessage.Text.Length, 0);
        }

        private void emojiOhDaDdY_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tbMessage.Text = $"{tbMessage.Text}😩 ";
            tbText.Text = $"{tbText.Text}";
            tbMessage.Select(tbMessage.Text.Length, 0);
        }

        private void emojiMemes_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tbMessage.Text = $"{tbMessage.Text}🤣 ";
            tbText.Text = $"{tbText.Text}";
            tbMessage.Select(tbMessage.Text.Length, 0);
        }

        private void emojiDevil_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tbMessage.Text = $"{tbMessage.Text}😈 ";
            tbText.Text = $"{tbText.Text}";
            tbMessage.Select(tbMessage.Text.Length, 0);
        }

        private void emojiFxck_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tbMessage.Text = $"{tbMessage.Text}🤬 ";
            tbText.Text = $"{tbText.Text}";
            tbMessage.Select(tbMessage.Text.Length, 0);
        }

        private void emojiMiddleFinger_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tbMessage.Text = $"{tbMessage.Text}🖕 ";
            tbText.Text = $"{tbText.Text}";
            tbMessage.Select(tbMessage.Text.Length, 0);
        }

        private void emojiOK_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tbMessage.Text = $"{tbMessage.Text}👌 ";
            tbText.Text = $"{tbText.Text}";
            tbMessage.Select(tbMessage.Text.Length, 0);
        }

        #endregion

        #region "Heart Emoji's"

        private void emojiGreenHeart_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tbMessage.Text = $"{tbMessage.Text}💚 ";
            tbText.Text = $"{tbText.Text}";
            tbMessage.Select(tbMessage.Text.Length, 0);
        }

        private void emojiSparkleHeart_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tbMessage.Text = $"{tbMessage.Text}💖 ";
            tbText.Text = $"{tbText.Text}";
            tbMessage.Select(tbMessage.Text.Length, 0);
        }

        private void emoji2Hearts_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tbMessage.Text = $"{tbMessage.Text}💕 ";
            tbText.Text = $"{tbText.Text}";
            tbMessage.Select(tbMessage.Text.Length, 0);
        }

        private void emojiBeatingHeart_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tbMessage.Text = $"{tbMessage.Text}💓 ";
            tbText.Text = $"{tbText.Text}";
            tbMessage.Select(tbMessage.Text.Length, 0);
        }

        private void emojiKiss_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tbMessage.Text = $"{tbMessage.Text}😘 ";
            tbText.Text = $"{tbText.Text}";
            tbMessage.Select(tbMessage.Text.Length, 0);
        }

        private void emojiBrokenHeart_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tbMessage.Text = $"{tbMessage.Text}💔 ";
            tbText.Text = $"{tbText.Text}";
            tbMessage.Select(tbMessage.Text.Length, 0);
        }

        private void emojiLove_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tbMessage.Text = $"{tbMessage.Text}🥰 ";
            tbText.Text = $"{tbText.Text}";
            tbMessage.Select(tbMessage.Text.Length, 0);
        }

        private void emojiLips_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tbMessage.Text = $"{tbMessage.Text}💋 ";
            tbText.Text = $"{tbText.Text}";
            tbMessage.Select(tbMessage.Text.Length, 0);
        }

        private void EmojiRose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tbMessage.Text = $"{tbMessage.Text}🌹 ";
            tbText.Text = $"{tbText.Text}";
            tbMessage.Select(tbMessage.Text.Length, 0);
        }

        private void emojiDeadRose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tbMessage.Text = $"{tbMessage.Text}🥀 ";
            tbText.Text = $"{tbText.Text}";
            tbMessage.Select(tbMessage.Text.Length, 0);
        }

        private void emojiRibbon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tbMessage.Text = $"{tbMessage.Text}🎀 ";
            tbText.Text = $"{tbText.Text}";
            tbMessage.Select(tbMessage.Text.Length, 0);
        }

        private void emojiBlueHeart_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tbMessage.Text = $"{tbMessage.Text}💙 ";
            tbText.Text = $"{tbText.Text}";
            tbMessage.Select(tbMessage.Text.Length, 0);
        }

        private void emojiPurpleHeart_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tbMessage.Text = $"{tbMessage.Text}💜 ";
            tbText.Text = $"{tbText.Text}";
            tbMessage.Select(tbMessage.Text.Length, 0);
        }

        private void emojiBlackHeart_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tbMessage.Text = $"{tbMessage.Text}🖤 ";
            tbText.Text = $"{tbText.Text}";
            tbMessage.Select(tbMessage.Text.Length, 0);
        }

        #endregion

        #region "Beef Emoji's"

        private void emojiClown_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tbMessage.Text = $"{tbMessage.Text}🤡 ";
            tbText.Text = $"{tbText.Text}";
            tbMessage.Select(tbMessage.Text.Length, 0);
        }

        private void emojiMonkey1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tbMessage.Text = $"{tbMessage.Text}🙈 ";
            tbText.Text = $"{tbText.Text}";
            tbMessage.Select(tbMessage.Text.Length, 0);
        }

        private void emojiMonkey2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tbMessage.Text = $"{tbMessage.Text}🐒 ";
            tbText.Text = $"{tbText.Text}";
            tbMessage.Select(tbMessage.Text.Length, 0);
        }

        private void emojiCat_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tbMessage.Text = $"{tbMessage.Text}🐱 ";
            tbText.Text = $"{tbText.Text}";
            tbMessage.Select(tbMessage.Text.Length, 0);
        }

        private void emojiFire_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tbMessage.Text = $"{tbMessage.Text}🔥 ";
            tbText.Text = $"{tbText.Text}";
            tbMessage.Select(tbMessage.Text.Length, 0);
        }

        private void emojiSleep_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tbMessage.Text = $"{tbMessage.Text}💤 ";
            tbText.Text = $"{tbText.Text}";
            tbMessage.Select(tbMessage.Text.Length, 0);
        }

        private void emojiEyes_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tbMessage.Text = $"{tbMessage.Text}👀 ";
            tbText.Text = $"{tbText.Text}";
            tbMessage.Select(tbMessage.Text.Length, 0);
        }

        private void emojiDead_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tbMessage.Text = $"{tbMessage.Text}💀 ";
            tbText.Text = $"{tbText.Text}";
            tbMessage.Select(tbMessage.Text.Length, 0);
        }

        private void emojiPlug_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tbMessage.Text = $"{tbMessage.Text}🔌 ";
            tbText.Text = $"{tbText.Text}";
            tbMessage.Select(tbMessage.Text.Length, 0);
        }

        private void emojiGem_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tbMessage.Text = $"{tbMessage.Text}💎 ";
            tbText.Text = $"{tbText.Text}";
            tbMessage.Select(tbMessage.Text.Length, 0);
        }

        private void emojiControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tbMessage.Text = $"{tbMessage.Text}🎮 ";
            tbText.Text = $"{tbText.Text}";
            tbMessage.Select(tbMessage.Text.Length, 0);
        }

        private void emojiClap_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tbMessage.Text = $"{tbMessage.Text}👏 ";
            tbText.Text = $"{tbText.Text}";
            tbMessage.Select(tbMessage.Text.Length, 0);
        }

        private void emojiGreenBoi_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tbMessage.Text = $"{tbMessage.Text}👽 ";
            tbText.Text = $"{tbText.Text}";
            tbMessage.Select(tbMessage.Text.Length, 0);
        }

        private void emojiCoonGang_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tbMessage.Text = $"{tbMessage.Text}🦝 ";
            tbText.Text = $"{tbText.Text}";
            tbMessage.Select(tbMessage.Text.Length, 0);
        }

        #endregion

        #region "Misc Emoji's"

        private void emojiPartyPopper_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tbMessage.Text = $"{tbMessage.Text}🎉 ";
            tbText.Text = $"{tbText.Text}";
            tbMessage.Select(tbMessage.Text.Length, 0);
        }

        private void emojiGift_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tbMessage.Text = $"{tbMessage.Text}🎁 ";
            tbText.Text = $"{tbText.Text}";
            tbMessage.Select(tbMessage.Text.Length, 0);
        }

        private void emojiMoney_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tbMessage.Text = $"{tbMessage.Text}💸 ";
            tbText.Text = $"{tbText.Text}";
            tbMessage.Select(tbMessage.Text.Length, 0);
        }

        private void emojiSmoke_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tbMessage.Text = $"{tbMessage.Text}💨 ";
            tbText.Text = $"{tbText.Text}";
            tbMessage.Select(tbMessage.Text.Length, 0);
        }

        private void emojiPill_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tbMessage.Text = $"{tbMessage.Text}💊 ";
            tbText.Text = $"{tbText.Text}";
            tbMessage.Select(tbMessage.Text.Length, 0);
        }

        private void emojiHerb_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tbMessage.Text = $"{tbMessage.Text}🌿 ";
            tbText.Text = $"{tbText.Text}";
            tbMessage.Select(tbMessage.Text.Length, 0);
        }

        private void emojiBomb_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tbMessage.Text = $"{tbMessage.Text}💣 ";
            tbText.Text = $"{tbText.Text}";
            tbMessage.Select(tbMessage.Text.Length, 0);
        }

        private void emojiShield_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tbMessage.Text = $"{tbMessage.Text}🛡 ";
            tbText.Text = $"{tbText.Text}";
            tbMessage.Select(tbMessage.Text.Length, 0);
        }

        private void emojiPin_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tbMessage.Text = $"{tbMessage.Text}📌 ";
            tbText.Text = $"{tbText.Text}";
            tbMessage.Select(tbMessage.Text.Length, 0);
        }

        private void emojiBrain_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tbMessage.Text = $"{tbMessage.Text}🧠 ";
            tbText.Text = $"{tbText.Text}";
            tbMessage.Select(tbMessage.Text.Length, 0);
        }

        private void emojiWet_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tbMessage.Text = $"{tbMessage.Text}💦 ";
            tbText.Text = $"{tbText.Text}";
            tbMessage.Select(tbMessage.Text.Length, 0);
        }

        private void emojiOrangeBoi_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tbMessage.Text = $"{tbMessage.Text}🦧 ";
            tbText.Text = $"{tbText.Text}";
            tbMessage.Select(tbMessage.Text.Length, 0);
        }

        private void emojiCorona_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tbMessage.Text = $"{tbMessage.Text}🦠 ";
            tbText.Text = $"{tbText.Text}";
            tbMessage.Select(tbMessage.Text.Length, 0);
        }

        private void emojiEagle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tbMessage.Text = $"{tbMessage.Text}🦅 ";
            tbText.Text = $"{tbText.Text}";
            tbMessage.Select(tbMessage.Text.Length, 0);
        }

        #endregion

        private async void tbMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var sendMessage = await FusionApp.SendMessage(tbText.Text);
                if (sendMessage.Error == false)
                {
                    spMessages.Children.Insert(0, new ucSentBubble(new ChatResponse { Author = new List<string>() { User.UserId, User.Username }, Content = tbMessage.Text, Edited = false, MessageId = "N/A", Timestamp = 0 }));
                }
                else
                {
                    MessageBox.Show(sendMessage.Message, "FusionAPI.dev");
                }
                tbMessage.Text = "";
                tbText.Text = "";
            }
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }
    }
}
