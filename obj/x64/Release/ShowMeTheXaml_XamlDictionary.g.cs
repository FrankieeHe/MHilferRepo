
using System.Collections.Generic;

namespace ShowMeTheXAML
{
    public static class XamlDictionary
    {
        static XamlDictionary()
        {
            XamlResolver.Set("cards_3", @"<smtx:XamlDisplay Key=""cards_3"" Margin=""4 4 0 0"" VerticalContentAlignment=""Top"" xmlns:smtx=""clr-namespace:ShowMeTheXAML;assembly=ShowMeTheXAML"">
  <materialDesign:Card Foreground=""{DynamicResource PrimaryHueDarkForegroundBrush}"" Padding=""0"" Width=""400"" xmlns:materialDesign=""http://materialdesigninxaml.net/winfx/xaml/themes"">
    <Grid xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation"">
      <Grid.RowDefinitions>
        <RowDefinition Height=""Auto"" />
        <RowDefinition Height=""Auto"" />
      </Grid.RowDefinitions>
      <TextBlock Grid.Row=""0"" Margin=""16 4 16 2"" Background=""#03a9f4"" FontSize=""14"" Style=""{StaticResource MaterialDesignHeadlineTextBlock}"" Text=""{Binding Key}""></TextBlock>
      <TextBlock Grid.Row=""1"" Margin=""16 0 16 2"" VerticalAlignment=""Center"" FontSize=""12"" Foreground=""Black"" HorizontalAlignment=""Left"" Style=""{StaticResource MaterialDesignHeadlineTextBlock}"" Text=""{Binding Value}"" />
      <StackPanel Grid.Row=""1"" Orientation=""Horizontal"" Margin=""16 0 16 8"" HorizontalAlignment=""Right"">
        <Button HorizontalAlignment=""Right"" VerticalAlignment=""Bottom"" Style=""{StaticResource MaterialDesignToolForegroundButton}"" Width=""30"" Padding=""2 0 2 0"" Foreground=""Black"" materialDesign:RippleAssist.IsCentered=""True"">
          <materialDesign:PackIcon Kind=""OpenInNew"" />
          <Button.InputBindings>
            <MouseBinding Gesture=""LeftClick"" Command=""{Binding Path= DataContext.LeftClickCommand, ElementName=SearchResultGird}"" CommandParameter=""{Binding Key}"" />
          </Button.InputBindings>
        </Button>
      </StackPanel>
    </Grid>
  </materialDesign:Card>
</smtx:XamlDisplay>");
XamlResolver.Set("feedback", @"<smtx:XamlDisplay Grid.Row=""2"" Key=""feedback"" VerticalAlignment=""Bottom"" Grid.ColumnSpan=""2"" Height=""44"" xmlns:smtx=""clr-namespace:ShowMeTheXAML;assembly=ShowMeTheXAML"">
  <StackPanel HorizontalAlignment=""Right"" xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation"">
    <TextBlock Style=""{StaticResource MaterialDesignBody2TextBlock}""> Do you like it?</TextBlock>
    <Viewbox Margin=""0 4 0 8"" Height=""16"" HorizontalAlignment=""Left"" VerticalAlignment=""Bottom"">
      <materialDesign:RatingBar Value=""4"" Orientation=""Horizontal"" Foreground=""Gold"" Margin=""0"" xmlns:materialDesign=""http://materialdesigninxaml.net/winfx/xaml/themes"" />
    </Viewbox>
  </StackPanel>
</smtx:XamlDisplay>");
        }
    }
}