using Microsoft.Maui.Platform;
using static System.Net.Mime.MediaTypeNames;

namespace ButtonCharSpacingIssue;

public partial class MainPage : ContentPage
{
	int count, count1, count2 = 0;

    public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		var button = (Button)sender;
		count++;

		if (count == 1)
			button.Text = $"Clicked {count} time";
		else
			button.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(button.Text);
	}

    private void OnCounterClickNotWorking(object sender, EventArgs e)
    {
        var button = (Button)sender;
        count1++;

        if (count == 1)
            button.Text = $"Clicked {count1} time";
        else
            button.Text = $"Clicked {count1} times";

        SemanticScreenReader.Announce(button.Text);
    }

    private void OnCounterClickedWorkAround(object sender, EventArgs e)
    {
        var button = (Button)sender;
        count2++;

        if (count == 1)
            button.Text = $"Clicked {count2} time";
        else
            button.Text = $"Clicked {count2} times";

        SemanticScreenReader.Announce(button.Text);

#if IOS || MACCATALYST
        var platformButton = button.Handler?.PlatformView as UIKit.UIButton;
        if (platformButton != null)
        {
            var titleLabel = platformButton.TitleLabel;
            titleLabel.Text = button.Text;

            var attributedText = titleLabel.AttributedText?.WithCharacterSpacing(button.CharacterSpacing);
            platformButton.SetAttributedTitle(attributedText, UIKit.UIControlState.Normal);
        }
#endif
    }
}


