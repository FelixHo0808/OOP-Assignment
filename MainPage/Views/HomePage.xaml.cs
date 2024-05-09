using MainPage.ViewModels;
using System.Collections.ObjectModel;

namespace MainPage.Views;

public partial class HomePage : ContentPage
{
	public HomePage(LoginPageViewModel loginPageViewModel)
	{
		InitializeComponent();
		this.BindingContext = loginPageViewModel;
	}
}

public partial class HomePage : ContentPage
{
    public ObservableCollection<MessageModel> Messages { get; set; }

    public HomePage()
    {
        InitializeComponent();
        Messages = new ObservableCollection<MessageModel>();
        messagesList.ItemsSource = Messages;
    }

    private void SendButton_Clicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(inputEntry.Text))
        {
            // Display user message
            Messages.Add(new MessageModel { Text = inputEntry.Text, HorizontalOption = LayoutOptions.End, BackgroundColor = "Blue" });

            // Simulate a bot response
            var response = BotResponse(inputEntry.Text);
            Messages.Add(new MessageModel { Text = response, HorizontalOption = LayoutOptions.Start, BackgroundColor = "Gray" });

            inputEntry.Text = "Hi there"; // Clear the input field after sending
        }

        {
            try
            {
                if (!string.IsNullOrWhiteSpace(inputEntry.Text))
                {
                    // Display user message
                    var userMessage = new MessageModel
                    {
                        Text = inputEntry.Text,
                        HorizontalOption = LayoutOptions.End,
                        BackgroundColor = "Blue"
                    };

                    // UI update must be on the main thread
                    MainThread.BeginInvokeOnMainThread(() =>
                    {
                        Messages.Add(userMessage);

                        // Simulate a bot response
                        var response = BotResponse(inputEntry.Text);
                        var responseMessage = new MessageModel
                        {
                            Text = response,
                            HorizontalOption = LayoutOptions.Start,
                            BackgroundColor = "Gray"
                        };
                        Messages.Add(responseMessage);

                        // Clear the input field after sending
                        inputEntry.Text = "Hi there";
                    });
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    // Inform the user of an error in a user-friendly way
                    DisplayAlert("Error", "An unexpected error occurred. Please try again.", "OK");
                });

                // Consider logging the exception details to a logging service or console
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

    }

    private string BotResponse(string input)
    {
        // Simple hardcoded responses for demonstration
        switch (input.ToLower())
        {
            case "hello":
                return "Hi there!";
            case "how are you?":
                return "I'm doing well, thanks for asking!";
            default:
                return "Sorry, I didn't understand that.";
        }
    }

}

public class MessageModel
{
    public string Text { get; set; }
    public LayoutOptions HorizontalOption { get; set; }
    public string BackgroundColor { get; set; }
}
