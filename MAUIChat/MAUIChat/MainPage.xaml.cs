using Syncfusion.Maui.Chat;
using Syncfusion.Maui.Popup;

namespace MAUIChat
{
    public partial class MainPage : ContentPage
    {
        SfPopup popup;
        public MainPage()
        {
            InitializeComponent();
            popup = new SfPopup();
            popup.IsFullScreen = true;
            popup.ShowHeader = true;
            popup.ShowFooter = false;
            popup.ShowCloseButton = true;
            popup.HeaderTitle = "";
            popup.Padding = new Thickness(4);
            var dataTemplate = new DataTemplate(() =>
            {
                // Create an Image element
                var image = new Image();
                var bind = new Binding("Source", BindingMode.OneWay);
                image.SetBinding(Image.SourceProperty, bind);
                return image;
            });

            popup.ContentTemplate = dataTemplate;
        }

        private async void Button_ClickedAsync(object sender, EventArgs e)
        {
            var photo = await MediaPicker.CapturePhotoAsync();
            var stream = await photo!.OpenReadAsync();
            var img = ImageSource.FromStream(() => { return stream; });
            sfChat.Messages.Add(new ImageMessage()
            {
                Author = vm.CurrentUser,
                Aspect = Aspect.AspectFill,
                Source = img,
                DateTime = DateTime.Now,
            });
        }

        private void sfChat_ImageTapped(object sender, ImageTappedEventArgs e)
        {
            if (e.Message!.GetType() == typeof(ImageMessage))
            {
                popup.BindingContext = e.Message as ImageMessage;
                popup.Show();
            }
        }
    }

}
