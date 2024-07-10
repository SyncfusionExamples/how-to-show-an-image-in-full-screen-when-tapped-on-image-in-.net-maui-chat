using System.Collections.ObjectModel;
using System.ComponentModel;
using Syncfusion.Maui.Chat;

namespace MAUIChat
{
    public class ChatViewModel : INotifyPropertyChanged
    {
        #region Fields
        
        private Author currentUser;

        ObservableCollection<MessageModel> messageCollection;

        #endregion

        #region Constructor
        public ChatViewModel()
        {
            messageCollection = new ObservableCollection<MessageModel>();
            currentUser = new Author() { Name = "Stevan", Avatar = "peoplecircle2.png" };
            GenerateMessages();
        }
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the collection of messages of a conversation.
        /// </summary>
        public ObservableCollection<MessageModel> MessageCollection
        {
            get
            {
                return messageCollection;
            }

            set
            {
                messageCollection = value;
                RaisePropertyChanged("MessageCollection");
            }
        }

        /// <summary>
        /// Gets or sets the current user of the message.
        /// </summary>
        public Author CurrentUser
        {
            get
            {
                return currentUser;
            }
            set
            {
                currentUser = value;
                RaisePropertyChanged("CurrentUser");
            }
        }
        #endregion

        #region INotifyPropertyChanged

        /// <summary>
        /// Property changed handler.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Occurs when property is changed.
        /// </summary>
        /// <param name="propName">changed property name</param>
        public void RaisePropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        #endregion

        #region Message Generation
        private void GenerateMessages()
        {
            messageCollection.Add(new MessageModel()
            {
                User = currentUser,
                Text = "Hi guys, good morning! I'm very delighted to share with you the news that our team is going to launch a new mobile application.",
            });

            messageCollection.Add(new MessageModel()
            {
                User = new Author() { Name = "Andrea", Avatar = "peoplecircle16.png" },
                Text = "Oh! That's great.",
            });

            messageCollection.Add(new MessageModel()
            {
                User = new Author() { Name = "Harrison", Avatar = "peoplecircle14.png" },
                Text = "That is good news.",
            });
            messageCollection.Add(new MessageModel()
            {
                User = new Author() { Name = "Harrison", Avatar = "peoplecircle14.png" },
                IsImageMessgae = true,
                ImageSource = "dotnet_bot.png"
            });
        }
        #endregion
    }
}
