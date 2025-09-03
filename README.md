# how-to-show-an-image-in-full-screen-when-tapped-on-image-in-.net-maui-chat
how-to-show-an-image-in-full-screen-when-tapped-on-image-in-.net-maui-chat

## Sample

```xaml  

    <sfChat:SfChat x:Name="sfChat" Grid.Row="1"
                    IncomingMessageTimestampFormat="dd/mm : HH:MM tt" 
                    ShowTimeBreak="True"                                                   
                    CurrentUser="{Binding CurrentUser}"
                    ItemsSource="{Binding MessageCollection}"
                    ItemsSourceConverter="{StaticResource MessageConverter}" 
                    Background="{AppThemeBinding Dark={StaticResource Black}, Light={StaticResource White}}">
        <sfChat:SfChat.Behaviors>
            <local:Behavior/>
        </sfChat:SfChat.Behaviors>
    </sfChat:SfChat>

Behavior:

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
```

## Requirements to run the demo

To run the demo, refer to [System Requirements for .NET MAUI](https://help.syncfusion.com/maui/system-requirements)

## Troubleshooting:
### Path too long exception

If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.

## License

Syncfusion® has no liability for any damage or consequence that may arise from using or viewing the samples. The samples are for demonstrative purposes. If you choose to use or access the samples, you agree to not hold Syncfusion® liable, in any form, for any damage related to use, for accessing, or viewing the samples. By accessing, viewing, or seeing the samples, you acknowledge and agree Syncfusion®'s samples will not allow you seek injunctive relief in any form for any claim related to the sample. If you do not agree to this, do not view, access, utilize, or otherwise do anything with Syncfusion®'s samples.

