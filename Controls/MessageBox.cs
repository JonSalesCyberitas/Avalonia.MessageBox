using System.Diagnostics;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Templates;
using Avalonia.Media;
using Avalonia.Styling;

namespace MessageBox.Controls
{
    public class MessageBox : TemplatedControl
    {
        public static readonly StyledProperty<string> TitleProperty =
            AvaloniaProperty.Register<MessageBox, string>(nameof(Title));

        public static readonly StyledProperty<string> MessageProperty =
            AvaloniaProperty.Register<MessageBox, string>(nameof(Message));

        public static readonly StyledProperty<MessageBoxButtons> ButtonsProperty =
            AvaloniaProperty.Register<MessageBox, MessageBoxButtons>(nameof(Buttons));

        public string Title
        {
            get => GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public string Message
        {
            get => GetValue(MessageProperty);
            set => SetValue(MessageProperty, value);
        }

        public MessageBoxButtons Buttons
        {
            get => GetValue(ButtonsProperty);
            set => SetValue(ButtonsProperty, value);
        }

        
        static MessageBox()
        {

        }

        public MessageBox()
        {
            // Constructor logic here
            this.AttachedToVisualTree += (sender, e) => 
            {
                Debug.WriteLine("MessageBox attached to visual tree.");
            };
        }

        private static StackPanel _buttonPanel;

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            _buttonPanel = e.NameScope.Find<StackPanel>("PART_ButtonPanel");
            UpdateButtons();
        }

        private void UpdateButtons()
        {
            if (_buttonPanel is null)
                return;

            _buttonPanel.Children.Clear();

            switch (Buttons)
            {
                case MessageBoxButtons.OK:
                    _buttonPanel.Children.Add(CreateButton("OK"));
                    break;
                case MessageBoxButtons.OKCancel:
                    _buttonPanel.Children.Add(CreateButton("OK"));
                    _buttonPanel.Children.Add(CreateButton("Cancel"));
                    break;
                // Handle other cases
            }
        }
        
        private Button CreateButton(string content)
        {
            var button = new Button { Content = content };

            // Apply the style
            button.Classes.Add("MessageBoxButton");

            // Add click event handlers and other logic here
            return button;
        }

        // You can add additional properties, methods, and event handlers here
    }
    
    public enum MessageBoxButtons
    {
        OK,
        OKCancel,
        YesNo,
        YesNoCancel
        // Add more button combinations as needed
    }
}