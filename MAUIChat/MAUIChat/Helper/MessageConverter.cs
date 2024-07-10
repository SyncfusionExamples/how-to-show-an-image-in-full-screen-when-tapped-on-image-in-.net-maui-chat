using Syncfusion.Maui.Chat;

namespace MAUIChat
{
    public class MessageConverter : IChatMessageConverter
    {
        #region Public Methods

        /// <summary>
        /// Converts given data object to a chat message.
        /// </summary>
        /// <param name="data">The data object to be converted as a chat message.</param>
        /// <param name="chat">Instance of <see cref="SfChat"/>. </param>
        /// <returns>Returns the data object as a chat message.</returns>
        public IMessage ConvertToChatMessage(object data, SfChat chat)
        {
            TextMessage message = new TextMessage();
            MessageModel? item = data as MessageModel;

            if(item != null && item.IsImageMessgae)
            { 
                ImageMessage imageMessage = new ImageMessage();
                imageMessage.Author = item.User!;
                imageMessage.Aspect = Aspect.AspectFit;
                imageMessage.DateTime = DateTime.Now;
                imageMessage.Data = item;
                imageMessage.Source = item.ImageSource;
                imageMessage.Size = new Size(100, 100);
                return imageMessage;
            }
            else if (item != null && item.Text!= null && item.User!=null)
            {
                message.Text = item.Text;
                message.Author = item.User;
                message.Data = item;
                if (item?.Suggestions != null)
                {
                    message.Suggestions = item!.Suggestions;
                }
            }

            return message;
        }

        /// <summary>
        /// Converts the given chat message to a data object.
        /// </summary>
        /// <param name="chatMessage">The chat message that is to be converted as a data object.</param>
        /// <param name="chat">Instance of <see cref="SfChat"/>. </param>
        /// <returns>Returns the chat message as a data object.</returns>
        public object ConvertToData(object chatMessage, SfChat chat)
        {
            var message = new MessageModel();
            var item = chatMessage as TextMessage;
            var imageitem = chatMessage as ImageMessage;


            message.Text = item!.Text;
            message.User = chat.CurrentUser;
            if (message.Suggestions != null)
            {
                message.Suggestions = chat.Suggestions;
            }
            return message;
        }
        #endregion
    }
}
