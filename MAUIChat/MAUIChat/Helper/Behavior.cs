using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.Maui.Chat;
using Syncfusion.Maui.Popup;

namespace MAUIChat
{
    public class Behavior : Behavior<SfChat>
    {
        SfPopup popup;

        protected override void OnAttachedTo(SfChat bindable)
        {
            base.OnAttachedTo(bindable);
            InitializePopup();
            bindable.ImageTapped += OnImageTapped;
        }

        private void OnImageTapped(object? sender, ImageTappedEventArgs e)
        {
            if (e.Message!.GetType() == typeof(ImageMessage))
            {
                popup.BindingContext = e.Message as ImageMessage;
                popup.Show();
            }
        }

        private void InitializePopup()
        {
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

        protected override void OnDetachingFrom(SfChat bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.ImageTapped -= OnImageTapped;
            popup = null;
        }
    }
}
